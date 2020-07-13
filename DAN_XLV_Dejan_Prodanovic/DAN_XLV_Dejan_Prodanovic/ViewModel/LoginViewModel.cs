﻿using DAN_XLV_Dejan_Prodanovic.Commands;
using DAN_XLV_Dejan_Prodanovic.Constants;
using DAN_XLV_Dejan_Prodanovic.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DAN_XLV_Dejan_Prodanovic.ViewModel
{
    class LoginViewModel : ViewModelBase
    {
        LoginView view;

        public LoginViewModel(LoginView loginView)
        {
            view = loginView;
        }

        private string userName;
        public string UserName
        {

            get
            {
                return userName;
            }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        public string Error
        {
            get { return null; }
        }

        public string this[string someProperty]
        {
            get
            {
                 
                return string.Empty;
            }
        }

        

        private ICommand submitCommand;
        public ICommand SubmitCommand
        {
            get
            {
                if (submitCommand == null)
                {
                    submitCommand = new RelayCommand(Submit);
                    return submitCommand;
                }
                return submitCommand;
            }
        }

        void Submit(object obj)
        {
            //UserValidation userValidation = new UserValidation();
            //string password = (obj as PasswordBox).Password;
            //if (!userValidation.IsCorrectUser(userName, password))
            //{
            //    WarningView warning = new WarningView(view);
            //    warning.Show("User name or password are not correct!");
            //    return;
            //}


            //WelcomeView main = new WelcomeView();
            string password = (obj as PasswordBox).Password;

            if (string.IsNullOrEmpty(UserName)||string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Empty");
                return;
            }
            if (UserName.Equals(UserConstants.MANAGER_USER_NAME) && 
                password.Equals(UserConstants.MANAGER_PASSWORD))
            {
                MessageBox.Show("Dobrodosli menager");
            }
            else if (UserName.Equals(UserConstants.STOREKEEPER_USER_NAME) &&
                password.Equals(UserConstants.STOREKEEPER_PASSWORD))
            {
                MessageBox.Show("Dobrodosli magacioner");

            }
            else
            {
                MessageBox.Show("Wrong username or password");

            }

            view.Close();
            //main.Show();
        }
    }
}
