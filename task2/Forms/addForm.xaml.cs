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
using task2.Model;

namespace task2.Forms
{
    /// <summary>
    /// Логика взаимодействия для addForm.xaml
    /// </summary>
    public partial class addForm : Window
    {

        Service service1;
        MainWindow mainWindow;

        public addForm(Service service, MainWindow mw)
        {
            InitializeComponent();

            this.service1 = service;
            this.mainWindow = mw;

            if(service1.Id == 0)
            {
                this.service1 = new Service();
            }

            DataContext = service1;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if (service1.Id == 0) {

                EfModel.Init().Services.Add(service1);
                EfModel.save();
            } else
            {
                EfModel.Init().Entry(service1).Reload();
                this.Close();
            }

            mainWindow.update();
            mainWindow.IsEnabled = true;
            EfModel.save();

        }
    }
}
