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
using Microsoft.EntityFrameworkCore;
using task2.Model;

namespace task2.Forms
{
    /// <summary>
    /// Логика взаимодействия для RecordListForm.xaml
    /// </summary>
    public partial class RecordListForm : Window
    {
        public RecordListForm()
        {
            InitializeComponent();

            dg.ItemsSource = EfModel.Init().ClientServices.Include(p => p.Client).Include(p => p.Service).ToList();
        }
    }
}
