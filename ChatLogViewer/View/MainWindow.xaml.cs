using ChatLogViewer.ViewModels;
using System.Windows;

namespace ChatLogViewer.Views
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel viewModel = new();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            viewModel.LoadFromFile();
        }
    }
}
