using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp2.Models;

namespace WpfApp2
{

    public partial class MainWindow : Window
    {
        public TaskViewModel ViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            
            ViewModel = new TaskViewModel();
            DataContext = ViewModel;
        }

        
        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.IsAddTaskVisible = true; 
        }

        
        private void SaveTaskButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.AddNewTask(); 
        }
    }
}