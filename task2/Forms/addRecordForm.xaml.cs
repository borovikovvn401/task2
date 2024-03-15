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
    /// Логика взаимодействия для addRecordForm.xaml
    /// </summary>
    public partial class addRecordForm : Window
    {

        Service service;
        MainWindow mainWindow;
        ClientService clientService;

        public addRecordForm(Service s, MainWindow mw)
        {
            this.service = s;
            this.mainWindow = mw;
            clientService = new ClientService();
            InitializeComponent();
            DataContext = clientService;
            serviceName.Text = service.Title;
            serviceDuration.Text = (service.DurationInSeconds / 60) + " минут.";
            this.Title = "Запись клиента";
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            EfModel.Init().Entry(clientService).Reload();
            this.Close();
            mainWindow.IsEnabled = true;
        }
    }
}
