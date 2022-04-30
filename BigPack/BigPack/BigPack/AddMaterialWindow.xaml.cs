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
    /// Логика взаимодействия для AddMaterialWindow.xaml
    /// </summary>
    public partial class AddMaterialWindow : Window
    {
        public AddMaterialWindow()
        {
            InitializeComponent();
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
            else { 
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

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Material material = new Material()
            {
                Title = TitleText.Text,
                CountInStock = Convert.ToDouble(CountInStockText.Text),
                CountInPack = Convert.ToInt32(CountInPackText.Text),
                MinCount = Convert.ToInt32(MinCountText.Text),
                Cost = Convert.ToInt32(CostText.Text),
                Unit = unitex,
                MaterialTypeID = typeex,
                Description = DisText.Text
            };
            App.BGDB.Material.Add(material);
            App.BGDB.SaveChanges();
            MessageBox.Show("Успешно!","BigPack",MessageBoxButton.OK,MessageBoxImage.Information);
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
