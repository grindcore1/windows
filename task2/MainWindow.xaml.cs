
using System.Windows;
using EmployeeApp.ViewModels;

namespace EmployeeApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new EmployeeViewModel();
        }
    }
}
