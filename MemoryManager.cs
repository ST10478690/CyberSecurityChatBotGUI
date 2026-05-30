using System;

namespace CyberSecurityChatBotGUI
{
    class MemoryManager
    {
        private string topic;

        public void SaveTopic(string t)
        {
            topic = t;
        }

        public string RecallTopic()
        {
            return topic;
        }
    }
}