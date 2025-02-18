using System.Collections.ObjectModel;
using WGU_MobileDevelopment_JMBenitez.Models;
using WGU_MobileDevelopment_JMBenitez.Services;
using WGU_MobileDevelopment_JMBenitez.Views;

namespace WGU_MobileDevelopment_JMBenitez
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Term> Terms { get; set; } = new ObservableCollection<Term>();

        public MainPage()
        {
            InitializeComponent();
            TermsCollectionView.ItemsSource = Terms;
        }

        // Loads data from the database and updates the observable collection.
        private async Task LoadTermsAsync()
        {
            Terms.Clear();
            var termsFromDb = await DatabaseService.GetTermsAsync();
            foreach (var term in termsFromDb)
            {
                Terms.Add(term);
            }
        }

        // Method for the add term button.
        private async void AddTermBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTermPage());
        }

        // New event handler for tapping on a term (via TapGestureRecognizer).
        private async void OnTermTapped(object sender, EventArgs e)
        {
            if (sender is Frame frame && frame.BindingContext is Term tappedTerm)
            {
                await Navigation.PushAsync(new TermDetailPage(tappedTerm));
            }
        }

        // Optional: You can still handle SelectionChanged if needed.
        private async void TermsCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection is IList<object> currentSelection && currentSelection.Count > 0)
            {
                if (currentSelection[0] is Term selectedTerm)
                {
                    // Clear the selection so the same item can be tapped again.
                    ((CollectionView)sender).SelectedItem = null;
                    await Navigation.PushAsync(new TermDetailPage(selectedTerm));
                }
            }
        }

        // When the page appears, refresh the list.
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadTermsAsync();
        }
    }
}
