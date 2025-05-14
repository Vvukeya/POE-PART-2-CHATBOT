using System;
using System.Collections;
using System.Collections.Generic;
using POE_PART_2_CHATBOT;
using System.Linq;

namespace POE_PART_2_CHATBOT
{
    // Delegate for response handling
    delegate void ResponseDelegate(string message);

    internal class backendForAll
    {
        private stored_topics topics;
        private List<string> ignoreWords;
        private Dictionary<string, List<string>> responses; // Use List for multiple responses
        private Check_writeFile memory; // Memory storage
        private string lastTopic; // Track conversation flow
        private Random random; // For random responses
        private string userName; // Store user's name

        public backendForAll(string name)
        {
            // Constructor to initialize the chatbot
            userName = name; // Initialize userName
            topics = new stored_topics();
            ignoreWords = new List<string> { "what", "is", "the", "a", "an", "of", "to", "for", "how", "can", "i", "about" };
            responses = new Dictionary<string, List<string>>();
            memory = new Check_writeFile();
            lastTopic = string.Empty;
            random = new Random();

            memory.check_file(); // Initialize memory file
            store_responses();
        }

        // Filter out ignored words from user input
        private List<string> filterInput(string query)
        {
            string[] words = query.ToLower().Split(' ');
            List<string> filtered = new List<string>();

            foreach (string word in words)
            {
                if (!ignoreWords.Contains(word))
                {
                    filtered.Add(word);
                }
            }

            return filtered;
        }

        // Detect sentiment in user input
        private string detectSentiment(string query)
        {
            query = query.ToLower();
            if (query.Contains("worried") || query.Contains("scared"))
                return "worried";
            if (query.Contains("curious") || query.Contains("interested"))
                return "curious";
            if (query.Contains("frustrated") || query.Contains("annoyed"))
                return "frustrated";
            return "neutral";
        }

        // Check if a word is in the topics
        public bool intopic(string query)
        {
            List<string> filtered = filterInput(query);
            ArrayList topicsList = new ArrayList();
            topics.store_topics(topicsList, new ArrayList());
            // Convert topicsList to a list of strings
            foreach (string topic in topicsList)
            {
                foreach (string word in filtered)
                {
                    if (topic.ToString().ToLower().Contains(word))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // Get a random response for a keyword
        private string getRandomResponse(string key)
        {
            if (responses.ContainsKey(key) && responses[key].Count > 0)
            {
                return responses[key][random.Next(responses[key].Count)];
            }
            return $"I'm not sure about that, {userName}. Try asking about password safety, phishing, or privacy.";
        }

        // Handle response using delegate
        private void displayResponse(string message)
        {
            ResponseDelegate show = (msg) =>
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("ChatBot :> ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(msg);
            };
            show(message);
        }

        // Main method to process user queries
        public void searching(string query)
        {
            string sentiment = detectSentiment(query);
            List<string> filtered = filterInput(query);

            if (filtered.Count == 0)
            {
                displayResponse($"Could you clarify your question, {userName}?");
                return;
            }

            // Check for memory-related queries
            if (query.ToLower().Contains("remember") || query.ToLower().Contains("interest"))
            {
                foreach (string word in filtered)
                {
                    if (responses.ContainsKey(word))
                    {
                        lastTopic = word;
                        List<string> memoryData = memory.return_memory();
                        // Store name twice, interest, and favorite topic
                        memoryData.Add($"{userName} ({userName}) is interested in {word}, favorite topic: {word}");
                        memory.save_memory(memoryData);
                        displayResponse($"Great, {userName}! I'll remember that you're interested in {word}. {getRandomResponse(word)}");
                        return;
                    }
                }
            }

            // Handle "show history" command
            if (query.ToLower().Contains("show history"))
            {
                List<string> memoryData = memory.return_memory();
                if (memoryData.Count > 0)
                {
                    displayResponse("Here's your interest history:");
                    foreach (string entry in memoryData)
                    {
                        displayResponse(entry);
                    }
                }
                else
                {
                    displayResponse($"No history found, {userName}. Try saying you're interested in a topic!");
                }
                return;
            }

            // Handle follow-up questions
            if (!string.IsNullOrEmpty(lastTopic) && query.ToLower().Contains("more"))
            {
                displayResponse($"Since you asked for more on {lastTopic}, {userName}, here's another tip: {getRandomResponse(lastTopic)}");
                return;
            }

            // Process sentiment and respond
            foreach (string word in filtered)
            {
                if (responses.ContainsKey(word))
                {
                    lastTopic = word;
                    string response = getRandomResponse(word);

                    // Adjust response based on sentiment
                    switch (sentiment)
                    {
                        case "worried":
                            response = $"It's understandable to feel worried, {userName}. {response} Let me know if you need more tips!";
                            break;
                        case "curious":
                            response = $"I love your curiosity, {userName}! {response} Want to dive deeper?";
                            break;
                        case "frustrated":
                            response = $"I get that this can be frustrating, {userName}. {response} Let's break it down together.";
                            break;
                    }

                    displayResponse(response);
                    return;
                }
            }

            // Default response for unrecognized input
            List<string> memoryDataFallback = memory.return_memory();
            if (memoryDataFallback.Count > 0)
            {
                string lastInterest = memoryDataFallback[memoryDataFallback.Count - 1].Split(' ').Last();
                displayResponse($"I didn't catch that, {userName}, but I remember you're interested in {lastInterest}. Want to talk about that?");
            }
            else
            {
                displayResponse($"I'm not sure I understand, {userName}. Can you try rephrasing or ask about cybersecurity topics like scam, privacy, or password?");
            }
        }

        // Goodbye message
        public void goodbye(string name)
        {
            displayResponse($"Goodbye, {name}! Stay safe online.");
        }

        // Store predefined chatbot responses
        private void store_responses()
        {
            // General responses
            responses.Add("hello", new List<string> { $"Hello, {userName}! How can I assist you today?", $"Hi, {userName}! Ready to talk cybersecurity?" });
            responses.Add("are", new List<string> { "I'm a chatbot, here to help with cybersecurity!", "No feelings here, but I'm full of cybersecurity tips!" });
            responses.Add("purpose", new List<string> { "My purpose is to provide cybersecurity knowledge and answer your questions.", "I'm here to make you a cybersecurity pro!" });
            responses.Add("ask", new List<string> { "You can ask me about cybersecurity topics like password safety, phishing, or privacy.", "Got a cybersecurity question? I'm all ears... or rather, all code!" });
            responses.Add("help", new List<string> { "I can provide information on cybersecurity topics. Feel free to ask!", "Need cybersecurity advice? I'm your bot!" });

            // Cybersecurity topics with multiple responses
            responses.Add("cybersecurity", new List<string> {
                "Cybersecurity is the practice of protecting systems, networks, and programs from digital attacks.",
                "Cybersecurity keeps your data safe from hackers and threats."
            });
            responses.Add("password", new List<string> {
                "Always use strong, unique passwords and enable two-factor authentication.",
                "Make sure passwords are long, complex, and never reused across accounts.",
                "Avoid using personal info in passwords, like your name or birthday."
            });
            responses.Add("phishing", new List<string> {
                "Beware of suspicious emails and links. Always verify the sender.",
                "Never click links in unsolicited emails; they could be phishing scams.",
                "Phishing emails often mimic trusted organizations. Check the email address carefully."
            });
            responses.Add("browsing", new List<string> {
                "Use secure websites (https) and avoid downloading unknown files.",
                "Clear your browser cache regularly to reduce tracking risks.",
                "Stick to reputable websites to avoid malicious downloads."
            });
            responses.Add("firewall", new List<string> {
                "A firewall helps block unauthorized access to your network. Keep it enabled at all times.",
                "Firewalls act like a security gate for your network traffic."
            });
            responses.Add("antivirus", new List<string> {
                "Regularly update your antivirus software to protect against the latest threats.",
                "Antivirus programs scan for and remove malicious software."
            });
            responses.Add("vpn", new List<string> {
                "A VPN encrypts your internet connection, keeping your online activities private and secure.",
                "Use a VPN on public Wi-Fi to protect your data."
            });
            responses.Add("malware", new List<string> {
                "Malware includes viruses, ransomware, and spyware. Avoid downloading unknown attachments or software.",
                "Keep your software updated to reduce malware vulnerabilities."
            });
            responses.Add("social engineering", new List<string> {
                "Hackers use psychological manipulation to trick people into revealing confidential information. Stay alert and verify requests.",
                "Social engineering can involve fake calls or emails pretending to be someone you trust."
            });
            responses.Add("scam", new List<string> {
                "Scammers often use fake emails or calls to steal your information. Verify before acting.",
                "Be cautious of offers that seem too good to be true—they’re usually scams.",
                "Report suspected scams to authorities to protect others."
            });
            responses.Add("privacy", new List<string> {
                $"Protect your privacy by reviewing app permissions and using strong passwords, {userName}.",
                "Use privacy settings on social media to control who sees your information.",
                "Regularly check your accounts for suspicious activity to maintain privacy."
            });

            // User guidance
            responses.Add("okay", new List<string> { $"Do you want to ask anything else related to cybersecurity, {userName}?", "What's next on your cybersecurity journey?" });
            responses.Add("exit", new List<string> { "Type 'exit' to close the chat. Stay safe online!", "Ready to exit? Just say 'exit'!" });
        }
    }
}