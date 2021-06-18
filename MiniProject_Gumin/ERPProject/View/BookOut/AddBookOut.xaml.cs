using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using MahApps.Metro.Controls.Dialogs;

namespace ERPProject.View.BookOut
{
    /// <summary>
    /// MyAccount.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AddBookOut : Page
    {
        public AddBookOut()
        {
            InitializeComponent();
        }



        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                LblItemQuantity.Visibility = LblItemID.Visibility = Visibility.Hidden;

                var items = Logic.DataAccess.Getitems();
                CboItemID.ItemsSource = items;

            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외발생 BookOutItemsList Loaded : {ex}");
                throw ex;
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
                LblItemQuantity.Text = "아이템수량을 입력하세요";
                isValid = false;
            }
            if (string.IsNullOrEmpty(CboItemID.Text))
            {
                LblItemID.Visibility = Visibility.Visible;
                LblItemID.Text = "제품 번호를 입력하시오";
                isValid = false;
            }
            //if (string.IsNullOrEmpty(CboStoreID.Text))
            //{
            //    LblStoreID.Visibility = Visibility.Visible;
            //    LblStoreID.Text = "창고 번호를 입력하시오";
            //    isValid = false;
            //}



            return isValid;


        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

            bool isValid = true;

            LblItemID.Visibility = LblItemQuantity.Visibility  = Visibility.Hidden;

            var bookoutitem = new Model.BookOutItem();

            isValid = IsValidInput();//유효성 체크

            if (isValid)
            {
                bookoutitem.Quantity = Int32.Parse(TxtItemQuantity.Text);
                bookoutitem.ItemID = Int32.Parse(CboItemID.SelectedIndex.ToString());
                //bookoutitem.
                //item.ItemName = TxtItemName.Text;
                //item.ItemDescription = TxtItemDescription.Text;
                //item.ItemStatus = bool.Parse(CboItemStatus.SelectedValue.ToString());
                //item.TagID = Int32.Parse(TxtTagID.Text);
                //item.BarcodeID = Int32.Parse(TxtBarcodeID.Text);
                //item.BrandID = Int32.Parse(TxtBrandID.Text);
                //item.CategoryID = Int32.Parse(TxtCategoryID.Text);

                try
                {
                    var result = Logic.DataAccess.Setbookoutitem(bookoutitem);
                    if (result == 0)
                    {
                        Commons.LOGGER.Error("AddStore.xaml.cs 창고 정보 저장오류 발생");
                        Commons.ShowMessageAsync("오류", "저장시 오류가 발생했습니다.");
                    }
                    else
                    {
                        NavigationService.Navigate(new BookOutList());
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
