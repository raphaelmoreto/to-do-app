using System.Windows;
using ToDoApp.WPF.ViewModels;

namespace ToDoApp.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new TarefaViewModel();
        }
    }
}
