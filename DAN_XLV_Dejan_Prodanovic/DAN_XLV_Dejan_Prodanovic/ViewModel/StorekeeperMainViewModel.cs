using DAN_XLV_Dejan_Prodanovic.Commands;
using DAN_XLV_Dejan_Prodanovic.Service;
using DAN_XLV_Dejan_Prodanovic.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DAN_XLV_Dejan_Prodanovic.ViewModel
{
    class StorekeeperMainViewModel:ViewModelBase
    {
        StorekeeperMainView view;
        IDataService dataService;

        #region Constructors
        public StorekeeperMainViewModel(StorekeeperMainView storekeeperMainOpen)
        {
            view = storekeeperMainOpen;
            dataService = new DataService();
            ProductList = dataService.GetProducts();

        }
        #endregion

        #region Properties
        private tblProduct selectetProduct;
        public tblProduct SelectetProduct
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
        private List<tblProduct> productList;
        public List<tblProduct> ProductList
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



        private ICommand showDetails;
        public ICommand ShowDetails
        {
            get
            {
                if (showDetails == null)
                {
                    showDetails = new RelayCommand(param => ShowDetailsExecute(),
                        param => CanShowDetailsExecute());
                }
                return showDetails;
            }
        }

        private void ShowDetailsExecute()
        {
            try
            {
                ProductDetail productDetail = new ProductDetail();
                productDetail.ShowDialog();

                //if ((addProduct.DataContext as AddProductViewModel).IsUpdateProduct == true)
                //{
                //    ProductList = dataService.GetProducts();
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanShowDetailsExecute()
        {
            if (SelectetProduct==null)
            {
                return false;
            }
            return true;
        }

      
        #endregion
    }
}
