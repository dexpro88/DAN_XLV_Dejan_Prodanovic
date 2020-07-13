﻿using DAN_XLV_Dejan_Prodanovic.Commands;
using DAN_XLV_Dejan_Prodanovic.Service;
using DAN_XLV_Dejan_Prodanovic.View;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
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

        private ICommand deleteProduct;
        public ICommand DeleteProduct
        {
            get
            {
                if (deleteProduct == null)
                {
                    deleteProduct = new RelayCommand(param => DeleteProductExecute(),
                        param => CanDeleteProductExecute());
                }
                return deleteProduct;
            }
        }

        private void DeleteProductExecute()
        {
            try
            {
                if (SelectetProduct != null)
                {

                    MessageBoxResult result = MessageBox.Show("Are you sure that you want to delete this product?"
                       , "My App",
                        MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);

                    int productId = selectetProduct.ID;

                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            dataService.RemoveProduct(productId);
                            ProductList = dataService.GetProducts();
                           
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanDeleteProductExecute()
        {
            if (SelectetProduct == null || SelectetProduct.Stored == true)
            {
                return false;
            }
            else
            {
                return true;
            }
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

       

        private ICommand addProduct;
        public ICommand AddProduct
        {
            get
            {
                if (addProduct == null)
                {
                    addProduct = new RelayCommand(param => AddProductExecute(), 
                        param => CanAddProductExecute());
                }
                return addProduct;
            }
        }

        private void AddProductExecute()
        {
            try
            {
                AddProduct addProduct = new AddProduct();
                addProduct.ShowDialog();

                if ((addProduct.DataContext as AddProductViewModel).IsUpdateProduct == true)
                {
                    ProductList = dataService.GetProducts();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanAddProductExecute()
        {

            return true;
        }

        private ICommand editProduct;
        public ICommand EditProduct
        {
            get
            {
                if (editProduct == null)
                {
                    editProduct = new RelayCommand(param => EditProductExecute(),
                        param => CanEditProductExecute());
                }
                return editProduct;
            }
        }

        private void EditProductExecute()
        {
            try
            {
                EditProduct editProduct = new EditProduct(SelectetProduct);
                editProduct.ShowDialog();

                //if ((editProduct.DataContext as EditProductViewModel).IsUpdateProduct == true)
                //{
                //    ProductList = dataService.GetProducts();
                //}
                ProductList = dataService.GetProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanEditProductExecute()
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
