using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using MahApps.Metro.Controls.Dialogs;

namespace ERPProject.View.Stock
{
    /// <summary>
    /// MyAccount.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class EditStock : Page
    {
        private int StockID { get; set; }
        private Model.Stock CurrentStock { get; set; }
        public EditStock()
        {
            InitializeComponent();
        }

        public EditStock(int stockID) : this()
        {
            StockID = stockID;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                CurrentStock = Logic.DataAccess.GetStocks().Where(s => s.StockID.Equals(StockID)).FirstOrDefault();
                LblStoreID.Visibility = LblItemQuantity.Visibility = LblItemID.Visibility = Visibility.Hidden;

                //Model.Item items = new Model.Item();
                //List<int> itemIDs = new List<int>()
                //{
                //    items.ItemID
                //};

                //CboItemID.ItemsSource = itemIDs;


                //var items = Logic.DataAccess.Getitems();
                //CboItemID.ItemsSource = items;

                var item = Logic.DataAccess.Getitems();
                CboItemID.ItemsSource = item;
                var store = Logic.DataAccess.GetStores();
                CboStoreID.ItemsSource = store;

                TxtItemQuantity.Text = CurrentStock.Quantity.ToString();
                CboItemID.SelectedValue = CurrentStock.ItemID.ToString();
                CboStoreID.SelectedValue = CurrentStock.StockID.ToString();



                // items라는 변수에 Logic.DataAccess.Getitems의 데이터를 끌고 와서 콤보박스 아이템소스에 넣어주고
                // WPF코드안에서  DisplayMemberPath="ItemName"로 끌고 와준다.

                //var stores = Logic.DataAccess.GetStores();
                //CboStoreID.ItemsSource = stores;


            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외발생 AddStock Loaded : {ex}");
            }
        }



        //3/29일 영상 끝

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        public bool IsValidInput()
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(TxtItemQuantity.Text))
            {
                LblItemQuantity.Visibility = Visibility.Visible;
                LblItemQuantity.Text = "창고번호를 입력하세요";
                isValid = false;
            }

            if (string.IsNullOrEmpty(CboItemID.Text))
            {
                LblItemID.Visibility = Visibility.Visible;
                LblItemID.Text = "제품 번호를 입력하시오";
                isValid = false;
            }
            if (string.IsNullOrEmpty(CboStoreID.Text))
            {
                LblStoreID.Visibility = Visibility.Visible;
                LblStoreID.Text = "창고 번호를 입력하시오";
                isValid = false;
            }
            return isValid;

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

            bool isValid = true;

            LblItemID.Visibility = LblItemQuantity.Visibility = LblStoreID.Visibility = Visibility.Hidden;
            //LblItemName.Visibility = LblItemDescription.Visibility =
            //       LblItemStatus.Visibility = LblTagID.Visibility = LblBarcodeID.Visibility =
            //       LblBrandID.Visibility = LblCategoryID.Visibility = Visibility.Hidden;

            var stock = new Model.Stock();
            var item = new Model.Item();

            isValid = IsValidInput();//유효성 체크

            if (isValid)
            {
                CurrentStock.Quantity = int.Parse(TxtItemQuantity.Text);
                CurrentStock.ItemID = int.Parse(CboItemID.SelectedValue.ToString());
                CurrentStock.StoreID = int.Parse(CboStoreID.SelectedValue.ToString());


                try
                {
                    var result = Logic.DataAccess.SetStocks(CurrentStock);
                    if (result == 0)
                    {
                        Commons.LOGGER.Error("AddStore.xaml.cs 창고 정보 저장오류 발생");
                        Commons.ShowMessageAsync("오류", "저장시 오류가 발생했습니다.");
                    }
                    else
                    {
                        NavigationService.Navigate(new StockList());
                    }
                }
                catch (Exception ex)
                {
                    Commons.LOGGER.Error($"예외발생 : {ex}");
                }
            }
        }
    } 
}
