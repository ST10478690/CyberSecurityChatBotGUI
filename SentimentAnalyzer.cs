using System;

namespace CyberSecurityChatBotGUI
{
    class SentimentAnalyzer
    {
        public string DetectEmotion(string input)
        {
            input = input.ToLower();

            if (input.Contains("sad"))
                return "I'm sorry you're feeling sad. Stay safe online.";

            if (input.Contains("worried"))
                return "Don't worry, I am here to help you.";

            if (input.Contains("confused"))
                return "Take your time, I will help you understand.";

            if (input.Contains("happy"))
                return "I'm glad you're feeling good!";

            return null;
        }
    }
}