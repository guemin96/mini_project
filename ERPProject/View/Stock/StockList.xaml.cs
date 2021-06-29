using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace ERPProject.View.Stock
{
    /// <summary>
    /// MyAccount.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class StockList : Page
    {
        public StockList()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Model.Stock> stocks = new List<Model.Stock>();
                stocks = Logic.DataAccess.GetStocks();
                

                this.DataContext = stocks;
                //var productname = Logic.DataAccess.Getitems().Where(i => i.ItemID.Equals());
                //this.DataContext = stocks;
                //진짜 ㄹㅇ 모르겟다. where(i=>i.itemID.Equals,contain 등등 )다 써봤는데 모르겟다.

            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외발생 StockList Loaded : {ex}");
                throw ex;
            }
        }

        

        private void BtnExportExcel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAddItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationService.Navigate(new AddStock());
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
               // NavigationService.Navigate(new EditItem(itemId));
            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외발생 BtnEditStore_Click : {ex}");
                throw ex;
            }
        }
    }
}
