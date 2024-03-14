using Microsoft.EntityFrameworkCore;
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
using task2.Forms;
using task2.Model;

namespace task2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        bool isAdmin = false;

        public MainWindow()
        {
            InitializeComponent();

            cbSort.Items.Add("По алфавиту (а-я)");
            cbSort.Items.Add("По алфавиту (я-а)");
            cbSort.Items.Add("По убыванию цены");
            cbSort.Items.Add("По возрастанию цены");

            cbFiltr.Items.Add("Все");
            cbFiltr.Items.Add("0-5%");
            cbFiltr.Items.Add("5-15%");
            cbFiltr.Items.Add("15-30%");
            cbFiltr.Items.Add("30-70%");
            cbFiltr.Items.Add("70-100%");

            cbSort.SelectedIndex = 0;
            cbFiltr.SelectedIndex = 0;

        }

        private void adminButton_Click(object sender, RoutedEventArgs e)
        {
            if(isAdmin)
            {
                adminButton.Content = "Режим администратора";
                isAdmin = !isAdmin;
            } else
            {
                Window1 s = new Window1(this);
            }
        }

        public void update()
        {
            IEnumerable<Model.Service> services = EfModel.Init().Services
                .Where(p => p.Title.Contains(tbSearch.Text) || p.Description.Contains(tbSearch.Text));

            switch(cbSort.SelectedIndex)
            {
                case 0:
                    services = services.OrderBy(p => p.Title);
                    break;
                case 1:
                    services = services.OrderByDescending(p => p.Title);
                    break;
                case 2:
                    services = services.OrderBy(p => p.Cost);
                        break;
                case 3:
                    services = services.OrderByDescending(p => p.Cost);
                    break;
            }

            switch(cbFiltr.SelectedIndex)
            {
                case 0:
                    services = services.Where(p => p.Discount >= 0 && p.Discount < 5);
                    break;

            }


            lvServices.ItemsSource = services.ToList();

        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            update();
        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            update();
        }

        private void cbFiltr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            update();
        }
    }
}
