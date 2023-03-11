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
        }
    }
}
