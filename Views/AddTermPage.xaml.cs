using WGU_MobileDevelopment_JMBenitez.Models;
using WGU_MobileDevelopment_JMBenitez.Services;
namespace WGU_MobileDevelopment_JMBenitez.Views;


public partial class AddTermPage : ContentPage
{
    //Term class from models.
    public Term Term { get; set; } = new Term();

    public AddTermPage()
    {
        InitializeComponent();
    }

    private async void SaveBtn_Clicked(object sender, EventArgs e)
    {
        if (EndDateEntry.Date < StartDateEntry.Date)
        {
            await DisplayAlert("Invalid Date", "End date cannot be before the start date.", "OK");
            return;
        }
        Term.Title = TermTitleEntry.Text;
        Term.StartDate = StartDateEntry.Date;
        Term.EndDate = EndDateEntry.Date;


        await DatabaseService.AddTermAsync(Term);

        await Navigation.PopAsync();
    }
}
