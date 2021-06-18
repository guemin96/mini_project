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
    public partial class AddCategory : Page
    {
        public AddCategory()
        {
            InitializeComponent();
        }
        
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // 그리드에 DB처리
                List<Category> items = Logic.DataAccess.GetCategories();
                this.DataContext = items;

                LblCategoryName.Visibility = LblCategoryDescription.Visibility = Visibility.Hidden;

                TxtCategoryDescription.Text = TxtCategoryID.Text = TxtCategoryName.Text = "";
                TxtCategoryName.Focus();
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

            if (string.IsNullOrEmpty(TxtCategoryName.Text))
            {
                LblCategoryName.Visibility = Visibility.Visible;
                LblCategoryName.Text = "카테고리명을 입력하세요";
                isValid = false;
            }
            else
            {
                var cnt = Logic.DataAccess.GetCategories().Where(i => i.CategoryName.Equals(TxtCategoryName.Text)).Count();
                if (cnt > 0)
                {
                    LblCategoryName.Visibility = Visibility.Visible;
                    LblCategoryName.Text = "중복된 카테고리 이름이 존재합니다.";
                    isValid = false;
                }
            }

            if (string.IsNullOrEmpty(TxtCategoryDescription.Text))
            {
                LblCategoryDescription.Visibility = Visibility.Visible;
                LblCategoryDescription.Text = "카테고리 설명을 입력하세요";
                isValid = false;
            }

            return isValid;
        }

        public bool IsValidUpdate()
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(TxtCategoryName.Text))
            {
                LblCategoryName.Visibility = Visibility.Visible;
                LblCategoryName.Text = "카테고리명을 입력하세요";
                isValid = false;
            }
            else
            {
                var cnt = Logic.DataAccess.GetCategories().Where(i => i.CategoryName.Equals(TxtCategoryName.Text)).Count();
                if (cnt > 1)
                {
                    LblCategoryName.Visibility = Visibility.Visible;
                    LblCategoryName.Text = "중복된 카테고리 이름이 존재합니다.";
                    isValid = false;
                }
            }

            if (string.IsNullOrEmpty(TxtCategoryDescription.Text))
            {
                LblCategoryDescription.Visibility = Visibility.Visible;
                LblCategoryDescription.Text = "카테고리 설명을 입력하세요";
                isValid = false;
            }

            return isValid;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = true;
            LblCategoryName.Visibility = LblCategoryDescription.Visibility = Visibility.Hidden;
            var item = new Model.Category();

            isValid = IsValidInput();//유효성 체크

            if (isValid)
            {
                item.CategoryName = TxtCategoryName.Text;
                item.CategoryDescription = TxtCategoryDescription.Text;

                try
                {
                    var result = Logic.DataAccess.SetCategory(item);
                    if (result == 0)
                    {
                        Commons.LOGGER.Error("AddCategory 클래스 카테고리 정보 저장오류 발생");
                        Commons.ShowMessageAsync("오류","저장시 오류가 발생했습니다.");
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

        private void GrdData_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            var cate = GrdData.SelectedItem as Category;

            TxtCategoryID.Text = cate.CategoryID.ToString();
            TxtCategoryName.Text = cate.CategoryName;
            TxtCategoryDescription.Text = cate.CategoryDescription;
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = true;
            LblCategoryName.Visibility = LblCategoryDescription.Visibility = Visibility.Hidden;
            var item = GrdData.SelectedItem as Category;

            isValid = IsValidUpdate();//유효성 체크

            if (isValid)
            {
                item.CategoryName = TxtCategoryName.Text;
                item.CategoryDescription = TxtCategoryDescription.Text;

                try
                {
                    var result = Logic.DataAccess.SetCategory(item);
                    if (result == 0)
                    {
                        Commons.LOGGER.Error("AddCategory 클래스 카테고리 정보 저장오류 발생");
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
    }
}
