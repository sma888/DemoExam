using BuildingMaterials.DbSingleton;
using BuildingMaterials.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BuildingMaterials.ViewModel
{
    public class AdminWindowViewModel:BaseViewModel
    {
        private ObservableCollection<Product> _products;
        private Product _selectedItem;

        public Product SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
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

        public AdminWindowViewModel()
        {
            _products = new ObservableCollection<Product>();

            var result = DbSingletone.Db.Product.ToList();
            result.ForEach(elem => Products?.Add(elem));
        }


        public void AddWindow()
        {
            var add = new AddProductWindow();
            add.Show();
        }

        public void DeleteProduct()
        {
            using(var db = new db9Entities())
            {
                var result = MessageBox.Show("Вы уверены, что хотите удалить данный элемент?" +
                        "Это действие невозможно отменить.", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        var entityForDelete = db.Product.Where(elem => elem.ProductArticleNumber == SelectedItem.ProductArticleNumber).FirstOrDefault();

                        db.Product.Remove(entityForDelete);

                        db.SaveChanges();

                        if (Products.Count > 0)
                        {
                            Products.Clear();
                        }

                        var result1 = DbSingletone.Db.Product.ToList();
                        result1.ForEach(elem => Products?.Add(elem));

                        MessageBox.Show("Данные успешно удалены", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Информация", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
    }
}
