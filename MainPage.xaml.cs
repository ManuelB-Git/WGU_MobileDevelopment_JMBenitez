using WGU_MobileDevelopment_JMBenitez.Views;
namespace WGU_MobileDevelopment_JMBenitez
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void AddTermBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTermPage());
        }
    }

}
