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
    public partial class AddStock : Page
    {
        public AddStock()
        {
            InitializeComponent();
        }



        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                LblStoreID.Visibility = LblItemQuantity.Visibility = LblItemID.Visibility = Visibility.Hidden;

                //Model.Item items = new Model.Item();
                //List<int> itemIDs = new List<int>()
                //{
                //    items.ItemID
                //};

                //CboItemID.ItemsSource = itemIDs;
                
                var items = Logic.DataAccess.Getitems();
                CboItemID.ItemsSource = items;
                
                // items라는 변수에 Logic.DataAccess.Getitems의 데이터를 끌고 와서 콤보박스 아이템소스에 넣어주고
                // WPF코드안에서  DisplayMemberPath="ItemName"로 끌고 와준다.
               
                var stores = Logic.DataAccess.GetStores();
                CboStoreID.ItemsSource = stores;


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


            //if (string.IsNullOrEmpty(TxtItemDescription.Text))
            //{
            //    LblItemDescription.Visibility = Visibility.Visible;
            //    LblItemDescription.Text = "제품설명을 입력하세요";
            //    isValid = false;
            //}

            //if (CboItemStatus.SelectedIndex < 0)
            //{
            //    LblItemStatus.Visibility = Visibility.Visible;
            //    LblItemStatus.Text = "제품상태를 선택하세요";
            //    isValid = false;
            //}



            //if (string.IsNullOrEmpty(TxtTagID.Text))
            //{
            //    LblTagID.Visibility = Visibility.Visible;
            //    LblTagID.Text = "제품RFID를 입력하세요";
            //    isValid = false;
            //}
            //else
            //{
            //    var cnt = Logic.DataAccess.Getitems().Where(i => i.TagID.Equals(TxtTagID.Text)).Count();
            //    if (cnt > 0)
            //    {
            //        LblTagID.Visibility = Visibility.Visible;
            //        LblTagID.Text = "중복된 제품RFID가 존재합니다.";
            //        isValid = false;
            //    }
            //}

            //if (string.IsNullOrEmpty(TxtBarcodeID.Text))
            //{
            //    LblBarcodeID.Visibility = Visibility.Visible;
            //    LblBarcodeID.Text = "제품RFID를 입력하세요";
            //    isValid = false;
            //}
            //else
            //{
            //    var cnt = Logic.DataAccess.Getitems().Where(i => i.BarcodeID.Equals(TxtBarcodeID.Text)).Count();
            //    if (cnt > 0)
            //    {
            //        LblBarcodeID.Visibility = Visibility.Visible;
            //        LblBarcodeID.Text = "중복된 제품바코드가 존재합니다.";
            //        isValid = false;
            //    }
            //}
            //if (string.IsNullOrEmpty(TxtBrandID.Text))
            //{
            //    LblBrandID.Visibility = Visibility.Visible;
            //    LblBrandID.Text = "제품브랜드를 입력하세요";
            //    isValid = false;
            //}
            //if (string.IsNullOrEmpty(TxtCategoryID.Text))
            //{
            //    LblCategoryID.Visibility = Visibility.Visible;
            //    LblCategoryID.Text = "제품카테고리를 입력하세요";
            //    isValid = false;
            //}


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
                stock.Quantity = int.Parse(TxtItemQuantity.Text);
                stock.ItemID = int.Parse(CboItemID.SelectedValue.ToString());
                stock.StoreID = int.Parse(CboStoreID.SelectedValue.ToString());


                try
                {
                    var result = Logic.DataAccess.SetStocks(stock);
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
