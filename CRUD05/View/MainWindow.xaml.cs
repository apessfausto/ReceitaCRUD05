using CRUD05.ViewModel;
using System.Windows;

namespace CRUD05
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new ReceitaViewModel();
        }
    }
}
