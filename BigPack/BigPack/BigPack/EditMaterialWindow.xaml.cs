using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BigPack
{
    /// <summary>
    /// Логика взаимодействия для EditMaterialWindow.xaml
    /// </summary>
    public partial class EditMaterialWindow : Window
    {
        public EditMaterialWindow()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        string unitex;
        int typeex;
        private void LitrButton_Click(object sender, RoutedEventArgs e)
        {
            unitex = "л";
            UnitButton.Content = "Литры";
            unitgrid.Visibility = Visibility.Hidden;
        }

        private void KGButton_Click(object sender, RoutedEventArgs e)
        {
            unitex = "кг";
            UnitButton.Content = "Килограммы";
            unitgrid.Visibility = Visibility.Hidden;
        }

        private void GButton_Click(object sender, RoutedEventArgs e)
        {
            unitex = "г";
            UnitButton.Content = "Граммы";
            unitgrid.Visibility = Visibility.Hidden;
        }

        private void MButton_Click(object sender, RoutedEventArgs e)
        {
            unitex = "м";
            UnitButton.Content = "Метры";
            unitgrid.Visibility = Visibility.Hidden;
        }

        private void UnitButton_Click(object sender, RoutedEventArgs e)
        {
            if (unitgrid.Visibility == Visibility.Hidden)
            {
                unitgrid.Visibility = Visibility.Visible;
                typegrid.Visibility = Visibility.Hidden;
            }
            else
            {
                unitgrid.Visibility = Visibility.Hidden;
            }
        }

        private void TypeButton_Click(object sender, RoutedEventArgs e)
        {
            if (typegrid.Visibility == Visibility.Hidden)
            {
                typegrid.Visibility = Visibility.Visible;
                unitgrid.Visibility = Visibility.Hidden;
            }
            else
            {
                typegrid.Visibility = Visibility.Hidden;
            }
        }

        private void GranuliButton_Click(object sender, RoutedEventArgs e)
        {
            typeex = 1;
            TypeButton.Content = "Гранулы";
            typegrid.Visibility = Visibility.Hidden;
        }

        private void ColorsButton_Click(object sender, RoutedEventArgs e)
        {
            typeex = 2;
            TypeButton.Content = "Краски";
            typegrid.Visibility = Visibility.Hidden;
        }

        private void NitkiButton_Click(object sender, RoutedEventArgs e)
        {
            typeex = 3;
            TypeButton.Content = "Нитки";
            typegrid.Visibility = Visibility.Hidden;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var r = App.BGDB.Material.Where(c => c.ID == NowClass.NowIDMat).FirstOrDefault();
            r.Title = TitleText.Text;
            r.CountInStock = Convert.ToDouble(CountInStockText.Text);
            r.CountInPack = Convert.ToInt32(CountInPackText.Text);
            r.MinCount = Convert.ToInt32(MinCountText.Text);
            r.Cost = Convert.ToInt32(CostText.Text);
            r.Unit = unitex;
            r.MaterialTypeID = typeex;
            r.Description = DisText.Text;
            App.BGDB.SaveChanges();
            MessageBox.Show("Успешно!", "BigPack", MessageBoxButton.OK, MessageBoxImage.Information);
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
