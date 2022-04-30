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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BigPack
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void updatematerial() {
            var r = App.BGDB.Material.Select(c => c.ID+"."+"\n"+c.Title+"\nКоличество на складе: "+c.CountInStock+"\nКоличество в упаковке: "+c.CountInPack+"" +
            "\nЦена: "+c.Cost+"\nОписание: "+c.Description).ToList();
            MainList.ItemsSource = r;
        }
        public void updatesupplier() {
            var r = App.BGDB.Supplier.Select(c => c.ID + "\n" + c.SupplierType + " " + c.Title + "\nИНН: " + c.INN + "\nНачало поставок: " + c.StartDate + "\nРейтинг: " + c.QualityRating).ToList();
            MainList.ItemsSource = r;
        }
        public void updateproduct() { 
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Sortgrid.Visibility == Visibility.Hidden)
            {
                Sortgrid.Visibility = Visibility.Visible;
            }
            else {
                Sortgrid.Visibility = Visibility.Hidden;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (NowClass.type == "1")
            {
                AddMaterialWindow addMaterialWindow = new AddMaterialWindow();
                addMaterialWindow.Show();
                this.Close();
            }
            else if (NowClass.type == "2")
            {

            }
            else if (NowClass.type == "3")
            {

            }
            else {
                MessageBox.Show("Вы не выбрали тип!","BigPack",MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MaterialButton_Click(object sender, RoutedEventArgs e)
        {
            NowClass.type = "1";
            updatematerial();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (NowClass.type == "1")
            {
                int countID = 0;
                if (MainList.SelectedItem.ToString()[3].ToString() == ".")
                {
                    countID = Convert.ToInt32(MainList.SelectedItem.ToString()[0].ToString() + MainList.SelectedItem.ToString()[1].ToString() + MainList.SelectedItem.ToString()[2].ToString());
                }
                else if (MainList.SelectedItem.ToString()[2].ToString() == ".")
                {
                    countID = Convert.ToInt32(MainList.SelectedItem.ToString()[0].ToString() + MainList.SelectedItem.ToString()[1].ToString());
                }
                else if (MainList.SelectedItem.ToString()[1].ToString() == ".")
                {
                    countID = Convert.ToInt32(MainList.SelectedItem.ToString()[0].ToString());
                }
                NowClass.NowIDMat = countID;
                EditMaterialWindow editMaterialWindow = new EditMaterialWindow();
                editMaterialWindow.Show();
                this.Close();
            }
            else if (NowClass.type == "2")
            {

            }
            else if (NowClass.type == "3")
            {

            }
            else
            {
                MessageBox.Show("Вы не выбрали тип!", "BigPack", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (NowClass.type == "1")
            {
                int countID = 0;
                if (MainList.SelectedItem.ToString()[3].ToString() == ".") {
                    countID = Convert.ToInt32(MainList.SelectedItem.ToString()[0].ToString() + MainList.SelectedItem.ToString()[1].ToString() + MainList.SelectedItem.ToString()[2].ToString());
                }
                else if (MainList.SelectedItem.ToString()[2].ToString() == ".") {
                    countID = Convert.ToInt32(MainList.SelectedItem.ToString()[0].ToString() + MainList.SelectedItem.ToString()[1].ToString());
                }
                else if (MainList.SelectedItem.ToString()[1].ToString() == ".") {
                    countID = Convert.ToInt32(MainList.SelectedItem.ToString()[0].ToString());
                }
                var r = App.BGDB.Material.Where(c => c.ID == countID).FirstOrDefault();
                if (r != null) { 
                    App.BGDB.Material.Remove(r);
                    App.BGDB.SaveChanges();
                    MessageBox.Show("Успешно удалено!", "BigPack", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else if (NowClass.type == "2")
            {

            }
            else if (NowClass.type == "3")
            {

            }
            else
            {
                MessageBox.Show("Вы не выбрали тип!", "BigPack", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var r = App.BGDB.Material.Where(c => c.Title.Contains(SearchText.Text)).ToList();

            MainList.ItemsSource = r.Select(v => v.ID + "." + "\n" + v.Title + "\nКоличество на складе: " + v.CountInStock + "\nКоличество в упаковке: " + v.CountInPack + "" +
            "\nЦена: " + v.Cost + "\nОписание: " + v.Description);
        }

        private void DownToUpCost_Click(object sender, RoutedEventArgs e)
        {
            int countDD=0;
            int[] vs = App.BGDB.Material.Select(v => v.ID).ToArray();
            var monkeyList = new List<string>();

            for (int i = 1; i < vs.Length; i++)
            {
                for (int j = 1; j < vs.Length-1; j++)
                {
                    if (App.BGDB.Material.Where(c => c.ID == i).FirstOrDefault().Cost > App.BGDB.Material.Where(c => c.ID == j+1).FirstOrDefault().Cost)
                    {
                        int t = vs[j];
                        vs[j] = vs[j+1];
                        vs[j+1] = t;
                    }
                }
            }


            for (int i = 0; i < vs.Length; i++)
            {
                countDD = vs[i];
                var m = App.BGDB.Material.Where(c => c.ID == countDD).FirstOrDefault();
                monkeyList.Add(m.ID + "." + "\n" + m.Title + "\nКоличество на складе: " + m.CountInStock + "\nКоличество в упаковке: " + m.CountInPack + "" +
                "\nЦена: " + m.Cost + "\nОписание: " + m.Description);
            }
            MainList.ItemsSource = monkeyList;
        }
    }
}
