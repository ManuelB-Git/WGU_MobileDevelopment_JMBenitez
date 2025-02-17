using WGU_MobileDevelopment_JMBenitez.Services;

namespace WGU_MobileDevelopment_JMBenitez
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            // Initialize the database
            InitializeDatabaseAsync();
        }

        private async void InitializeDatabaseAsync()
        {
            await DatabaseService.SeedDataAsync();
        }
    }
}
