using BuildingMaterials.DbSingleton;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingMaterials.ViewModel
{
    public class AddProductViewModel:BaseViewModel
    {
        private string _productName;
        private string _productDescription;
        private string _productCategory;
        private decimal _productCost;
        private string _productArticleName;
        private string _productManufacturer;
        private string _productDiscountAmount;
        private string _productQuantityInStock;
        private string _status;

        public string ProductArticleName
        {
            get => _productArticleName;
            set
            {
                _productArticleName = value;
                OnPropertyChanged(nameof(ProductArticleName));
            }
        }

        public string ProductManufacturer
        {
            get => _productManufacturer;
            set
            {
                _productManufacturer = value;
                OnPropertyChanged(nameof(ProductManufacturer));
            }
        }



        private ObservableCollection<Product> _products;
        private Product _product;

        public Product Product
        {
            get => _product;
            set
            {
                _product = value;
                OnPropertyChanged(nameof(Product));
            }
        }


        public ObservableCollection<Product> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        public string ProductName
        {
            get => _productName;
            set
            {
                _productName = value;
                OnPropertyChanged(nameof(ProductName));
            }
        }
        public string ProductDescription
        {
            get => _productDescription;
            set
            {
                _productDescription = value;
                OnPropertyChanged(nameof(ProductDescription));
            }
        }
        public string ProductCategory
        {
            get => _productCategory;
            set
            {
                _productCategory = value;
                OnPropertyChanged(nameof(ProductCategory));
            }
        }
        public decimal ProductCost
        {
            get => _productCost;
            set
            {
                _productCost = value;
                OnPropertyChanged(nameof(ProductCost));
            }
        }
    }
}
