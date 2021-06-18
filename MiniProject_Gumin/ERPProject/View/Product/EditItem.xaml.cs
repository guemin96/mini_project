using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ERPProject.View.Product
{
    /// <summary>
    /// MyAccount.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class EditItem : Page
    {
        private int ItemID { get; set; }

        private Model.Item CurrentItem { get; set; }

        public EditItem()
        {
            InitializeComponent();
        }

        public EditItem(int itemId) : this()
        {
            ItemID = itemId;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LblItemName.Visibility = LblItemDescription.Visibility =
                    LblItemStatus.Visibility = LblTagID.Visibility = LblBarcodeID.Visibility =
                    LblBrandID.Visibility = LblCategoryID.Visibility = Visibility.Hidden;

            try
            {

                CurrentItem = Logic.DataAccess.Getitems().Where(i => i.ItemID.Equals(ItemID)).FirstOrDefault();
                List<string> comboValues = new List<string>
                {
                    "False", // 0, index 0
                    "True"   // 1, index 1
                };
                //comboValues라는 이름의 리스트에 true와 false를 넣어주고 밑에 Admin과 Activated에 이 리스트를 넣어주면서 초기화를 시켜준다.
                CboItemStatus.ItemsSource = comboValues;

                // 2021.06.10. MG Sung.
                // DB에서 데이터가져오기
                var rfids = Logic.DataAccess.GetTags();
                CboTagID.ItemsSource = rfids;

                var barcodes = Logic.DataAccess.GetBarcodes();
                CboBarcodeID.ItemsSource = barcodes;

                var brands = Logic.DataAccess.GetBrands();
                CboBrandID.ItemsSource = brands;

                var categories = Logic.DataAccess.GetCategories();
                CboCategoryID.ItemsSource = categories;

                TxtItemID.Text = CurrentItem.ItemID.ToString();
                TxtItemName.Text = CurrentItem.ItemName.ToString();
                TxtItemDescription.Text = CurrentItem.ItemDescription;
                CboItemStatus.SelectedIndex = CurrentItem.ItemStatus == true ? 1 : 0;
                CboTagID.SelectedValue = CurrentItem.TagID.ToString();
                CboBarcodeID.SelectedValue = CurrentItem.BarcodeID.ToString();
                CboBrandID.SelectedValue = CurrentItem.BrandID.ToString();
                CboCategoryID.SelectedValue = CurrentItem.CategoryID.ToString();


            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외발생 MyAccount Loaded : {ex}");
                // Commons.ShowMessageAsync("예외", $"예외발생 : {ex}");
            }
        }

        //3/29일 영상 끝
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private bool isValid = true;

        public bool IsValidInput()
        {

            if (string.IsNullOrEmpty(TxtItemName.Text))
            {
                LblItemName.Visibility = Visibility.Visible;
                LblItemName.Text = "제품이름을 입력하세요";
                isValid = false;
            }

            if (string.IsNullOrEmpty(TxtItemDescription.Text))
            {
                LblItemDescription.Visibility = Visibility.Visible;
                LblItemDescription.Text = "제품설명을 입력하세요";
                isValid = false;
            }

            //if (CboItemStatus.SelectedIndex < 0)
            //{
            //    LblItemStatus.Visibility = Visibility.Visible;
            //    LblItemStatus.Text = "제품상태를 선택하세요";
            //    isValid = false;
            //}

            if (CboTagID.SelectedIndex < 0)
            {
                LblTagID.Visibility = Visibility.Visible;
                LblTagID.Text = "RFID값을 선택하세요";
                isValid = false;
            }

            if (CboBarcodeID.SelectedIndex < 0)
            {
                LblBarcodeID.Visibility = Visibility.Visible;
                LblBarcodeID.Text = "바코드를 선택하세요";
                isValid = false;
            }

            if (CboBrandID.SelectedIndex < 0)
            {
                LblBrandID.Visibility = Visibility.Visible;
                LblBrandID.Text = "제품브랜드를 선택하세요";
                isValid = false;
            }

            if (CboCategoryID.SelectedIndex < 0)
            {
                LblCategoryID.Visibility = Visibility.Visible;
                LblCategoryID.Text = "제품카테고리를 선택하세요";
                isValid = false;
            }

            return isValid;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = true;

            LblItemName.Visibility = LblItemDescription.Visibility =
                   LblItemStatus.Visibility = LblTagID.Visibility = LblBarcodeID.Visibility =
                   LblBrandID.Visibility = LblCategoryID.Visibility = Visibility.Hidden;


            isValid = IsValidInput();//유효성 체크

            if (isValid)
            {
                CurrentItem.ItemName = TxtItemName.Text;
                CurrentItem.ItemDescription = TxtItemDescription.Text;
                CurrentItem.ItemStatus = bool.Parse(CboItemStatus.SelectedValue.ToString());
                CurrentItem.TagID = int.Parse(CboTagID.SelectedValue.ToString());
                CurrentItem.BarcodeID = int.Parse(CboBarcodeID.SelectedValue.ToString());
                CurrentItem.BrandID = int.Parse(CboBrandID.SelectedValue.ToString()); 
                CurrentItem.CategoryID = int.Parse(CboCategoryID.SelectedValue.ToString());

                try
                {
                    var result = Logic.DataAccess.SetItems(CurrentItem);
                    if (result == 0)
                    {
                        Commons.LOGGER.Error("EditItem.xaml.cs 제품 정보 저장오류 발생");
                        Commons.ShowMessageAsync("오류", "저장시 오류가 발생했습니다.");
                    }
                    else
                    {
                        NavigationService.Navigate(new Itemlist());
                    }
                }
                catch (Exception ex)
                {
                    Commons.LOGGER.Error($"예외발생 : {ex}");
                }
            }
            else
            {
                Commons.ShowMessageAsync("오류", "오류발생");
            }

        }

        private void Control_LostFocus(object sender, RoutedEventArgs e)
        {
            IsValidInput();
        }
    }
}
