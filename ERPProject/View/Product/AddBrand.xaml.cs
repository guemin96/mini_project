using ERPProject.Model;
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
    public partial class AddBrand : Page
    {
        public AddBrand()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // 그리드에 DB처리
                List<Brand> items = Logic.DataAccess.GetBrands();
                this.DataContext = items;

                LblBrandDescription.Visibility = LblBrandName.Visibility = Visibility.Hidden;

                TxtBrandID.Text = TxtBrandName.Text = TxtBrandDescription.Text = string.Empty;
                TxtBrandName.Focus();
            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외발생 MyAccount Loaded : {ex}");
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

            if (string.IsNullOrEmpty(TxtBrandName.Text))
            {
                LblBrandName.Visibility = Visibility.Visible;
                LblBrandName.Text = "브랜드명을 입력하세요";
                isValid = false;
            }
            else
            {
                var cnt = Logic.DataAccess.GetBrands().Where(b => b.BrandName.Equals(TxtBrandName.Text)).Count();
                if (cnt > 0)
                {
                    LblBrandName.Visibility = Visibility.Visible;
                    LblBrandName.Text = "중복된 제품 이름이 존재합니다.";
                    isValid = false;
                }
            }

            if (string.IsNullOrEmpty(TxtBrandDescription.Text))
            {
                LblBrandDescription.Visibility = Visibility.Visible;
                LblBrandDescription.Text = "브랜드 설명을 입력하세요";
                isValid = false;
            }

            return isValid;
        }

        public bool IsValidUpdate()
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(TxtBrandName.Text))
            {
                LblBrandName.Visibility = Visibility.Visible;
                LblBrandName.Text = "브랜드명을 입력하세요";
                isValid = false;
            }
            else
            {
                var cnt = Logic.DataAccess.GetBrands().Where(b => b.BrandName.Equals(TxtBrandName.Text)).Count();
                if (cnt > 1)
                {
                    LblBrandName.Visibility = Visibility.Visible;
                    LblBrandName.Text = "중복된 제품 이름이 존재합니다.";
                    isValid = false;
                }
            }

            if (string.IsNullOrEmpty(TxtBrandDescription.Text))
            {
                LblBrandDescription.Visibility = Visibility.Visible;
                LblBrandDescription.Text = "브랜드 설명을 입력하세요";
                isValid = false;
            }

            return isValid;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = true;

            LblBrandName.Visibility = LblBrandDescription.Visibility = Visibility.Hidden;

            var item = new Model.Brand();
            isValid = IsValidInput();//유효성 체크

            if (isValid)
            {
                item.BrandName = TxtBrandName.Text;
                item.BrandDescription = TxtBrandDescription.Text;

                try
                {
                    var result = Logic.DataAccess.SetBrand(item);
                    if (result == 0)
                    {
                        Commons.LOGGER.Error("AddBrand 클래스 브랜드 정보 저장오류 발생");
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

        private void InputControl_LostFocus(object sender, RoutedEventArgs e)
        {
            IsValidInput();
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = true;

            LblBrandName.Visibility = LblBrandDescription.Visibility = Visibility.Hidden;

            var item = GrdData.SelectedItem as Brand;
            isValid = IsValidUpdate();//유효성 체크

            if (isValid)
            {
                item.BrandName = TxtBrandName.Text;
                item.BrandDescription = TxtBrandDescription.Text;

                try
                {
                    var result = Logic.DataAccess.SetBrand(item);
                    if (result == 0)
                    {
                        Commons.LOGGER.Error("AddBrand 클래스 브랜드 정보 저장오류 발생");
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

        private void GrdData_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            var brand = GrdData.SelectedItem as Brand;

            TxtBrandID.Text = brand.BrandID.ToString();
            TxtBrandName.Text = brand.BrandName;
            TxtBrandDescription.Text = brand.BrandDescription;
        }
    }
}
