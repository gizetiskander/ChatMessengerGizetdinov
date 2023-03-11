using ChatMessenger.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ChatMessenger.Pages
{
    /// <summary>
    /// Логика взаимодействия для TopicWindow.xaml
    /// </summary>
    public partial class TopicWindow : Window
    {
        public Chat_dbEntities dbEntities = new Chat_dbEntities();
        ChatMessage message;
        public TopicWindow(ChatMessage chatMessager)
        {
            InitializeComponent();
            this.message = chatMessager;
            TopicTB.Text = message.Chatroom.Topic;
            var chatRoom = ((Employee)LoginWindow.employee).Id_Employee;
            MemberLst.ItemsSource = dbEntities.ChatMessage.Where(x => x.Id_Chatroom == chatRoom).ToList();
            ChatLst.ItemsSource = message.Chatroom.ChatMessage.ToList();
        }

        private void LeaveChatBtn_Click(object sender, RoutedEventArgs e)
        {
            ChatMessage chatMessage = dbEntities.ChatMessage.FirstOrDefault();
            chatMessage.Id_Chatroom = message.Id_Chatroom;
            chatMessage.Id_Employee = LoginWindow.employee.Id_Employee;
            dbEntities.ChatMessage.Remove(chatMessage);
            MessageBox.Show("Успешно");
            ChitChatTopicWindow chitChatTopicWindow = new ChitChatTopicWindow();
            chitChatTopicWindow.Show();
            this.Close();
        }

        private void ChangeTopicBtn_Click(object sender, RoutedEventArgs e)
        {
            ChitChatTopicWindow chitChatTopicWindow = new ChitChatTopicWindow();
            chitChatTopicWindow.Show();
            this.Close();
        }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            ChatMessage chatMessage = new ChatMessage();
            chatMessage.Message = MessageTB.Text;
            chatMessage.Date = DateTime.Now;
            var chatRoom = ((Employee)LoginWindow.employee).Id_Employee;
            chatMessage.Id_Chatroom = message.Id_Chatroom;
            chatMessage.Id_Employee = chatRoom;
            ChatLst.ItemsSource = message.Chatroom.ChatMessage.ToList();
            dbEntities.ChatMessage.Add(chatMessage);
            dbEntities.SaveChanges();
            MessageBox.Show("Отправлено!");
            MessageTB.Clear();
        }
    }
}
