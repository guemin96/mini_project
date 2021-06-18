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
    public partial class AddItem : Page
    {
        public AddItem()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                LblItemName.Visibility = LblItemDescription.Visibility =
                    LblItemStatus.Visibility = LblTagID.Visibility = LblBarcodeID.Visibility =
                    LblBrandID.Visibility = LblCategoryID.Visibility = Visibility.Hidden;

                //콤보박스 초기화
                List<string> comboValues = new List<string>
                {
                    "False", // 0, index 0
                    "True"   // 1, index 1
                };
                CboItemStatus.ItemsSource = comboValues;
                //comboValues라는 이름의 리스트에 true와 false를 넣어주고 밑에 Admin과 Activated에 이 리스트를 넣어주면서 초기화를 시켜준다.

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

                TxtItemID.Text = TxtItemDescription.Text = CboItemStatus.Text = CboTagID.Text =
                    CboBarcodeID.Text = CboBrandID.Text = CboCategoryID.Text = "";

                TxtItemName.Focus();
            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외발생 MyAccount Loaded : {ex}");
                throw ex;
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        public bool IsValidInput()
        {
            bool isValid = true;
            LblItemName.Visibility = LblItemDescription.Visibility =
                    LblItemStatus.Visibility = LblTagID.Visibility = LblBarcodeID.Visibility =
                    LblBrandID.Visibility = LblCategoryID.Visibility = Visibility.Hidden;

            if (string.IsNullOrEmpty(TxtItemName.Text))
            {
                LblItemName.Visibility = Visibility.Visible;
                LblItemName.Text = "제품명을 입력하세요";
                isValid = false;
            }
            else if (Logic.DataAccess.Getitems().Where(i => i.ItemName.Equals(TxtItemName.Text)).Count() > 0)
            {
                LblItemName.Visibility = Visibility.Visible;
                LblItemName.Text = "중복된 제품 이름이 존재합니다.";
                isValid = false;
            }

            if (string.IsNullOrEmpty(TxtItemDescription.Text))
            {
                LblItemDescription.Visibility = Visibility.Visible;
                LblItemDescription.Text = "제품설명을 입력하세요";
                isValid = false;
            }

            if (CboItemStatus.SelectedIndex < 0)
            {
                LblItemStatus.Visibility = Visibility.Visible;
                LblItemStatus.Text = "제품상태를 선택하세요";
                isValid = false;
            }

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

            var item = new Model.Item();

            isValid = IsValidInput();//유효성 체크

            if (isValid)
            {
                item.ItemName = TxtItemName.Text;
                item.ItemDescription = TxtItemDescription.Text;
                item.ItemStatus = bool.Parse(CboItemStatus.SelectedValue.ToString());
                item.TagID = int.Parse(CboTagID.SelectedValue.ToString());
                item.BarcodeID = int.Parse(CboBarcodeID.SelectedValue.ToString());
                item.BrandID = int.Parse(CboBrandID.SelectedValue.ToString());
                item.CategoryID = int.Parse(CboCategoryID.SelectedValue.ToString());

                try
                {
                    var result = Logic.DataAccess.SetItems(item);
                    if (result == 0)
                    {
                        Commons.LOGGER.Error("AddStore.xaml.cs 창고 정보 저장오류 발생");
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
        }

        private void Control_LostFocus(object sender, RoutedEventArgs e)
        {
            IsValidInput();
        }
    }
}
