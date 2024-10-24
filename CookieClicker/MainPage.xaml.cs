

namespace CookieClicker
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new CookieClickerViewModel();
        }


        private void CookieButton_Clicked(object sender, EventArgs e)
        {
            var viewModel = BindingContext as CookieClickerViewModel;
            viewModel?.IncrementCookie();
        }

        private void BuyGrandMotherButton_Clicked(object sender, EventArgs e)
        {
            var viewModel = BindingContext as CookieClickerViewModel;
            viewModel?.BuyGrandMother();
        }

        private void BuyHouseCandyButton_Clicked(object sender, EventArgs e)
        {
            var viewModel = BindingContext as CookieClickerViewModel;
            viewModel?.BuyHouseCandy();
        }
    }

}
