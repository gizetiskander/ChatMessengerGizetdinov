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
    /// Логика взаимодействия для ChitChatTopicWindow.xaml
    /// </summary>
    public partial class ChitChatTopicWindow : Window
    {
        public Chat_dbEntities dbEntities = new Chat_dbEntities();
        public ChitChatTopicWindow()
        {
            InitializeComponent();
            NameTB.Text = LoginWindow.employee.Name;
            var chatRoom = ((Employee)LoginWindow.employee).Id_Employee;
            TopicLst.ItemsSource = dbEntities.ChatMessage.Where(x => x.Id_Employee == chatRoom).ToList();
        }

        private void EmpFinderBtn_Click(object sender, RoutedEventArgs e)
        {
            ChitChatWindow chatWindow = new ChitChatWindow();
            chatWindow.Show();
            this.Close();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void TopicLst_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var top = TopicLst.SelectedItem as ChatMessage;
            TopicWindow topic = new TopicWindow(top);
            topic.Show();
            this.Close();
        }
    }
}
