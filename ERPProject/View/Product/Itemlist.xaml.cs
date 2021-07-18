using ERPProject.Model;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace ERPProject.View.Product
{
    /// <summary>
    /// MyAccount.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Itemlist : Page
    {
        public ObservableCollection<Tag> GridTags { get; set; }
        public ObservableCollection<Model.Barcode> GridBarcodes { get; set; }
        public ObservableCollection<Brand> GridBrands { get; set; }
        public ObservableCollection<Category> GridCategories { get; set; }

        public Itemlist()
        {
            InitializeComponent();

            GridTags = new ObservableCollection<Tag>();
            GridBarcodes = new ObservableCollection<Model.Barcode>();
            GridBrands = new ObservableCollection<Brand>();
            GridCategories = new ObservableCollection<Category>();

            // 2021.06.10. MG Sung.
            // DB에서 데이터가져오기
            var tags = Logic.DataAccess.GetTags();
            tags.ForEach(x => GridTags.Add(x));
            var barcodes = Logic.DataAccess.GetBarcodes();
            barcodes.ForEach(x => GridBarcodes.Add(x));
            var brands = Logic.DataAccess.GetBrands();
            brands.ForEach(x => GridBrands.Add(x));
            var categories = Logic.DataAccess.GetCategories();
            categories.ForEach(x => GridCategories.Add(x));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                CboRfids.ItemsSource = GridTags;
                CboBarcode.ItemsSource = GridBarcodes;
                CboBrands.ItemsSource = GridBrands;
                CboCategories.ItemsSource = GridCategories;

                List<Model.Item> items = new List<Model.Item>();
                items = Logic.DataAccess.Getitems();

                this.DataContext = items;
            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외발생 MyAccount Loaded : {ex}");
                throw ex;
            }
        }



        private void BtnExportExcel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAddBrand_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationService.Navigate(new AddBrand());
            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외발생 BtnAddBrand_Click : {ex}");
                throw ex;
            }
        }

        private void BtnAddCategory_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationService.Navigate(new AddCategory());
            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외발생 BtnAddCategory_Click : {ex}");
                throw ex;
            }
        }

        private void BtnAddItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationService.Navigate(new AddItem());
            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외발생 BtnAddStore_Click : {ex}");
                throw ex;
            }
        }

        private void BtnEditItem_Click(object sender, RoutedEventArgs e)
        {
            if (GrdData.SelectedItem == null)
            {
                Commons.ShowMessageAsync("제품수정", "수정할 제품를 선택하세요");
                return;
            }

            try
            {
                var itemId = (GrdData.SelectedItem as Model.Item).ItemID;
                NavigationService.Navigate(new EditItem(itemId));
            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외발생 BtnEditStore_Click : {ex}");
                throw ex;
            }
        }
    }
}
