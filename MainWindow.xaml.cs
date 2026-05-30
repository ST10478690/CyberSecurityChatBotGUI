using System;
using System.IO;
using System.Media;
using System.Windows;
using System.Threading.Tasks;

namespace CyberSecurityChatBotGUI
{
    public partial class MainWindow : Window
    {
        ChatbotManager chatbot = new ChatbotManager();
        MemoryManager memory = new MemoryManager();
        SentimentAnalyzer sentiment = new SentimentAnalyzer();

        public MainWindow()
        {
            InitializeComponent();
            PlayGreeting();

            ChatDisplay.Text += "Bot: Hello! I am your Cybersecurity Awareness Bot.\n";
        }

        private void PlayGreeting()
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "greeting.wav");
                SoundPlayer player = new SoundPlayer(path);
                player.PlaySync();
            }
            catch
            {
                MessageBox.Show("Audio not found.");
            }
        }

        private async void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string userMessage = UserInput.Text;

            if (string.IsNullOrWhiteSpace(userMessage))
            {
                ChatDisplay.Text += "Bot: Please enter a message.\n";
                return;
            }

            ChatDisplay.Text += "You: " + userMessage + "\n";
            userMessage = userMessage.ToLower();

            // MEMORY
            if (userMessage.Contains("i like"))
            {
                string topic = userMessage.Replace("i like", "").Trim();
                memory.SaveTopic(topic);

                ChatDisplay.Text += "Bot: I will remember that you like " + topic + "\n";
                UserInput.Clear();
                return;
            }

            if (userMessage.Contains("what do i like"))
            {
                ChatDisplay.Text += "Bot: You like " + memory.RecallTopic() + "\n";
                UserInput.Clear();
                return;
            }

            // SENTIMENT
            string emotion = sentiment.DetectEmotion(userMessage);
            if (!string.IsNullOrEmpty(emotion))
            {
                ChatDisplay.Text += "Bot: " + emotion + "\n";
                UserInput.Clear();
                return;
            }

            // CHATBOT RESPONSE
            string response = chatbot.GetResponse(userMessage);
            ChatDisplay.Text += "Bot: " + response + "\n";

            UserInput.Clear();
        }
    }
}