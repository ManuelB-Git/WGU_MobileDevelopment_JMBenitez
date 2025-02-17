using System.Collections.ObjectModel;
using WGU_MobileDevelopment_JMBenitez.Models;
using WGU_MobileDevelopment_JMBenitez.Services;
using WGU_MobileDevelopment_JMBenitez.Views;
namespace WGU_MobileDevelopment_JMBenitez
{
    public partial class MainPage : ContentPage
    {
        // ObservableCollection is a collection that provides notifications when items get added, removed, or when the whole list is refreshed.
        public ObservableCollection<Term> Terms { get; set; } = new ObservableCollection<Term>();

        //The Main Page
        public MainPage()
        {
            InitializeComponent();

            TermsCollectionView.ItemsSource = Terms;
        }

        //Loads data from the database and updates the observable collection.
        private async Task LoadTermsAsync()
        {
            Terms.Clear();
            var termsFromDb = await DatabaseService.GetTermsAsync();
            foreach (var term in termsFromDb)
            {
                Terms.Add(term);
            }

        }

        //When the page appears, refresh the page.
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadTermsAsync();

        }

        // Method for the add term button. This will navigate to the AddTermPage.
        private async void AddTermBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTermPage());
        }


        //Method will go to the TermDetailPage and pass the selected term.

        private void TermsCollectionView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Term term)
            {
                Navigation.PushAsync(new TermDetailPage(term));
            }

        }

        //Method will clear the selected item.
        private void TermsCollectionView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            TermsCollectionView.SelectedItem = null;

        }






    }

}
