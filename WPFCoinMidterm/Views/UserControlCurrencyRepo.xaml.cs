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
using WPFCoinMidterm.ViewModels;
using WPFCoinMidterm.Models;

namespace WPFCoinMidterm.Views
{
    /// <summary>
    /// Interaction logic for UserControlCurrencyRepo.xaml
    /// </summary>
    public partial class UserControlCurrencyRepo : UserControl
    {
        CurrencyRepo repo;
        ViewModelCurrencyRepo ViewModelRepo;

        public UserControlCurrencyRepo():this(new ViewModelCurrencyRepo(new CurrencyRepo()))
        {
            InitializeComponent();
        }
        public UserControlCurrencyRepo(ViewModelCurrencyRepo ViewModelRepo)
        {
            InitializeComponent();
            this.ViewModelRepo = ViewModelRepo;
            repo = ViewModelRepo.wallet;
            this.DataContext = ViewModelRepo;
        }

        private void ButtonSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                repo = (CurrencyRepo)CurrencyRepo.CreateChange(Convert.ToDouble(txtAmount.Text));
                ViewModelRepo = new ViewModelCurrencyRepo(repo);
                this.DataContext = ViewModelRepo;
            }
            catch
            {
                txtAmount.Text = "Enter Amound Here! (Only Numberic Characters Allowed!)";
            }
        }

        private void TxtAmount_GotFocus(object sender, RoutedEventArgs e)
        {

        }
    }
}
