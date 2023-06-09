﻿using System;
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
using ChatMessenger.db;

namespace ChatMessenger.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public static Chat_dbEntities dbEntities = new Chat_dbEntities();
        public static Employee employee;
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LogBtn_Click(object sender, RoutedEventArgs e)
        {
            if (UserNameTB.Text == "" || PasswordTB.Password == "")
            {
                MessageBox.Show("Введите данные!");
            }
            foreach(var emp in dbEntities.Employee)
            {
                if (emp.UserName == UserNameTB.Text.Trim())
                {
                    if (emp.Password == PasswordTB.Password.Trim())
                    {
                        MessageBox.Show($"Добро пожаловать - {emp.Name}");
                        employee = emp;
                        ChitChatTopicWindow chatTopicWindow = new ChitChatTopicWindow();
                        chatTopicWindow.Show();
                        this.Close();
                    }
                }
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void RembMeCB_Checked(object sender, RoutedEventArgs e)
        {
            if (RembMeCB.IsChecked == true)
            {
                MessageBox.Show("Хорошая работа, Олег!");
            }
            else if (RembMeCB.IsChecked == false)
            {
                MessageBox.Show("Грустно(((");
            }
        }
    }
}
