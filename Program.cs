using System;
using System.IO;
using NAudio.Wave; // Required for .m4a playback using NAudio

namespace CybersecurityAwarenessBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Cipher Buddy - Cybersecurity Awareness Bot";

            // Step 1: Play audio greeting
            PlayGreetingSound();

            // Step 2: Show ASCII Art
            ShowAsciiArt();

            // Step 3: Ask user name and greet them
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("What's your name? ");
            Console.ResetColor();

            string name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nHello, {name}! I'm Cipher Buddy 🛡️");
            Console.WriteLine("I'm here to help you stay safe online.\n");
            Console.ResetColor();

            // Step 4: Enter chatbot loop
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Ask me a question (or type 'exit' to quit): ");
                Console.ResetColor();

                string input = Console.ReadLine()?.Trim().ToLower();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("🤖 I didn't catch that. Could you rephrase?");
                    continue;
                }

                if (input == "exit")
                {
                    Console.WriteLine("👋 Stay safe out there! Goodbye!");
                    break;
                }

                RespondToInput(input);
            }
        }

        /// <summary>
        /// Play an .m4a audio greeting using NAudio
        /// </summary>
        static void PlayGreetingSound()
        {
            string filePath = @"Assets\greeting.wav.m4a";
            string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);

            try
            {
                if (!File.Exists(fullPath))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"❌ Audio file not found: {fullPath}");
                    Console.ResetColor();
                    return;
                }

                using (var audioFile = new AudioFileReader(fullPath))
                using (var outputDevice = new WaveOutEvent())
                {
                    outputDevice.Init(audioFile);
                    outputDevice.Play();

                    while (outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        System.Threading.Thread.Sleep(100);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"❌ Error playing audio: {ex.Message}");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Displays the original ASCII art header
        /// </summary>
        static void ShowAsciiArt()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(@"
      ____________________
     |                    |
     |  Hello, I’m        |
     |    Cipher Buddy!   |
     |____________________|
           \ 
            \   🤖 
             [▓▓▓]
            |     |
          --|     |--
            |_____|


   ____ _               _                 
  / ___| |__   ___  ___| | _____ _ __ ___ 
 | |   | '_ \ / _ \/ __| |/ / _ \ '__/ __|
 | |___| | | |  __/ (__|   <  __/ |  \__ \ 
  \____|_| |_|\___|\___|_|\_\___|_|  |___/
               CIPHER BUDDY 🛡️
");
            Console.ResetColor();
        }

        /// <summary>
        /// Respond to user input with cybersecurity awareness tips
        /// </summary>
        static void RespondToInput(string input)
        {
            if (input.Contains("how are you"))
            {
                Console.WriteLine("🤖 I'm just lines of code, but I'm always ready to protect!");
            }
            else if (input.Contains("your purpose"))
            {
                Console.WriteLine("🔐 My purpose is to educate South African citizens on cybersecurity.");
            }
            else if (input.Contains("password"))
            {
                Console.WriteLine("💡 Use a mix of letters, numbers, and symbols. Avoid common or reused passwords.");
            }
            else if (input.Contains("phishing"))
            {
                Console.WriteLine("🚫 Be cautious of emails asking for personal info or urgent actions. Don't click suspicious links!");
            }
            else if (input.Contains("safe browsing"))
            {
                Console.WriteLine("🌐 Use secure HTTPS websites, avoid pop-ups, and don’t download from untrusted sites.");
            }
            else
            {
                Console.WriteLine("🤖 I'm not sure about that. Try asking about passwords, phishing, or safe browsing.");
            }
        }
    }
}                                                                                                           