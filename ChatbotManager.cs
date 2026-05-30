using System;
using System.Collections.Generic;

namespace CyberSecurityChatBotGUI
{
    class ChatbotManager
    {
        public string GetResponse(string input)
        {
            input = input.ToLower();

            if (input.Contains("password"))
                return "Use strong passwords with numbers and symbols.";

            if (input.Contains("phishing"))
                return "Never click suspicious links or emails.";

            if (input.Contains("scam"))
                return "Be careful of online scams and fake websites.";

            if (input.Contains("privacy"))
                return "Protect your personal information online.";

            return "I am not sure. Please ask about cybersecurity.";
        }
    }
}