﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CRUDSelector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedCrud = CheckSelection();
            
            OutputTbx.Clear();
            string tempPass = Coder.Encrypt(PasswordPbx.Password, EmailTbx.Text);
            OutputTbx.Text= LoginProcess(selectedCrud, EmailTbx.Text.ToString(), tempPass);
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            OutputTbx.IsEnabled = false;
            FirstNameTbx.Clear();
            LastNameTbx.Clear();
            EmailTbx.Clear();
            PasswordPbx.Clear();
            OutputTbx.Clear();
            ChooseCrudCbx.SelectedItem=null;
        }


        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedCrud = CheckSelection();
            User user = new(FirstNameTbx.Text, LastNameTbx.Text, EmailTbx.Text, PasswordPbx.Password);
            
            OutputTbx.Clear();
            OutputTbx.Text= RegistrationProcess(selectedCrud, user);

        }
        private ICrud CheckSelection()
        {
            switch(ChooseCrudCbx.SelectedIndex)
            {
                case 0:
                    return new MongoCRUD();
                    break;
                case 1:
                    return new SqliteCRUD();
                    break;
            }
            return null;
        }
        private string RegistrationProcess<T>(T selectedCrud, User user) where T:ICrud
        {
            selectedCrud.Register(user);
            return $"Użytkownik został dodany do {ChooseCrudCbx.Text}";
        }
        private string LoginProcess<T>(T selectedCrud, string email, string password) where T: ICrud
        {
            User user = selectedCrud.Login(email,password);
            string outputMessage =
                "Dane użytkownika:\n" +
                $"Imię\t{user.FirstName}\n" +
                $"Nazwisko\t{user.LastName}" +
                $"E-mail:\t{user.Email}\n" +
                $"Zalogowano przy użyciu {ChooseCrudCbx.Text}";
            return outputMessage;
        }
        private void ShowErrorMessage()
        {
            MessageBox.Show("Wystąpił nieznany błąd", "Uwaga!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}