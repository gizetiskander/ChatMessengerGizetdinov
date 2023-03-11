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
    /// Логика взаимодействия для ChitChatWindow.xaml
    /// </summary>
    public partial class ChitChatWindow : Window
    {
        public Chat_dbEntities dbEntities = new Chat_dbEntities();
        public ChitChatWindow()
        {
            InitializeComponent();
            SearchLst.ItemsSource = dbEntities.Employee.ToList();
        }

        private void AdminCB_Checked(object sender, RoutedEventArgs e)
        {
            if(AdminCB.IsChecked == true)
            {
                SearchLst.ItemsSource = dbEntities.Employee.Where(x => x.Id_Department == 2).ToList();
                
            }
            else if (AdminCB.IsChecked == false)
            {
                
            }
        }

        private void ITCB_Checked(object sender, RoutedEventArgs e)
        {
            if (ITCB.IsChecked == true)
            {
                SearchLst.ItemsSource = dbEntities.Employee.Where(x => x.Id_Department == 1).ToList();
            }
        }

        private void AnaliticsCB_Checked(object sender, RoutedEventArgs e)
        {
            if (AnaliticsCB.IsChecked == true)
            {
                SearchLst.ItemsSource = dbEntities.Employee.Where(x => x.Id_Department == 3).ToList();
            }
        }

        private void ManagerCB_Checked(object sender, RoutedEventArgs e)
        {
            if (ManagerCB.IsChecked == true)
            {
                SearchLst.ItemsSource = dbEntities.Employee.Where(x => x.Id_Department == 4).ToList();
            }
        }

        private void EmpSearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            var search = dbEntities.Employee.OrderBy(a => a.Name).ToList();
            search = search.Where(a => a.Name.ToLower().Contains(EmpSearchTB.Text.ToLower())).ToList();
            SearchLst.ItemsSource = search;
        }
    }
}
