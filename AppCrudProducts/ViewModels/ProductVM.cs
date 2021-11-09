using AppCrudProducts.Data;
using AppCrudProducts.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppCrudProducts.ViewModels
{
    public class ProductVM : BaseViewModel
    {
        public Command _SaveCommand;
        public Command _ShowCommand;

        private string _nameProp;
        private string _priceProp;
        private string _quantityProp;

        ObservableCollection<Products> products = new ObservableCollection<Products>();

        public ObservableCollection<Products> Product { get { return products; } }

        public ProductVM() { }

        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                {
                    _SaveCommand = new Command(SavetoDB);
                }
                return _SaveCommand;
            }
        }

        public ICommand ShowCommand
        {
            get
            {
                if (_ShowCommand == null)
                {
                    _ShowCommand = new Command(ShowData);
                }
                return _ShowCommand;
            }
        }

        public string NameProp { 
            get => _nameProp; 
            set 
            {
                if (_nameProp != value)
                {
                    _nameProp = value;
                }
                OnPropertyChanged();
            } }

        public string PriceProp
        { 
            get => _priceProp; 
            
            set
            {
                if (_priceProp != value)
                {
                    _priceProp = value;
                }
                OnPropertyChanged();

            }
                
        }

        public string QuantityProp 
        { 
            get => _quantityProp;
            set 
            {
                if (_quantityProp != value)
                {
                    _quantityProp = value;
                }
                OnPropertyChanged();
            } 
        }

        private void SavetoDB()
        {
            string name = NameProp;
            double price = Convert.ToDouble(PriceProp);
            int quantity = Convert.ToInt32(QuantityProp);

            DataLogic dl = new DataLogic();
            bool success = dl.SavetoDB(name, price, quantity);
            if (success)
            {
                NameProp = string.Empty;
                PriceProp = string.Empty;
                QuantityProp = string.Empty;
            }
        }
        private void ShowData()
        {
            DataLogic dataLogic = new DataLogic();
            var lstProduct = dataLogic.ShowData();

            foreach (var productDetails in lstProduct)
            {
                Products product = new Products
                {
                    Id = productDetails.Id,
                    Name = productDetails.Name,
                    Price = productDetails.Price,
                    Quantity = productDetails.Quantity,
                };

                Product.Add(product);
            }

        }

    }
}
