using DAN_XLV_Dejan_Prodanovic.Commands;
using DAN_XLV_Dejan_Prodanovic.Service;
using DAN_XLV_Dejan_Prodanovic.View;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DAN_XLV_Dejan_Prodanovic.ViewModel
{
    class ManagerMainViewModel:ViewModelBase
    {
        ManagerMainView view;
        IDataService dataService;

        #region Constructors
        public ManagerMainViewModel(ManagerMainView managerMainOpen)
        {
            view = managerMainOpen;
            dataService = new DataService();
            productList = dataService.GetProducts();
        }
        #endregion

        #region Properties
        private Product selectetProduct;
        public Product SelectetProduct
        {
            get
            {
                return selectetProduct;
            }
            set
            {
                selectetProduct = value;
                OnPropertyChanged("SelectetProduct");
            }
        }
        private List<Product> productList;
        public List<Product> ProductList
        {
            get
            {
                return productList;
            }
            set
            {
                productList = value;
                OnPropertyChanged("ProductList");
            }
        }
        #endregion

        #region Commands
        private ICommand logout;
        public ICommand Logout
        {
            get
            {
                if (logout == null)
                {
                    logout = new RelayCommand(param => LogoutExecute(), param => CanLogoutExecute());
                }
                return logout;
            }
        }

        private void LogoutExecute()
        {
            try
            {
                LoginView loginView = new LoginView();
                loginView.Show();
                view.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanLogoutExecute()
        {
            return true;
        }

        private ICommand close;
        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }
                return close;
            }
        }

        private void CloseExecute()
        {
            try
            {
                view.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanCloseExecute()
        {
            return true;
        }
        #endregion
    }
}
