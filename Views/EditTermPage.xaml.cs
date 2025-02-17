using WGU_MobileDevelopment_JMBenitez.Models;
using WGU_MobileDevelopment_JMBenitez.Services;

namespace WGU_MobileDevelopment_JMBenitez.Views;

public partial class EditTermPage : ContentPage
{
    Term TermToEdit;

    public EditTermPage(Term term)
    {
        InitializeComponent();

        TermToEdit = term;
        OnAppearing();
    }


    //Populate the fields with the term's data
    protected override void OnAppearing()
    {
        base.OnAppearing();
        TermTitleEntry.Text = TermToEdit.Title;
        StartDateEntry.Date = TermToEdit.StartDate;
        EndDateEntry.Date = TermToEdit.EndDate;

    }

    private async void SaveBtn_Clicked(object sender, EventArgs e)
    {
        if (EndDateEntry.Date < StartDateEntry.Date)
        {
            await DisplayAlert("Invalid Date", "End date cannot be before the start date.", "OK");
            return;
        }

        TermToEdit.Title = TermTitleEntry.Text;
        TermToEdit.StartDate = StartDateEntry.Date;
        TermToEdit.EndDate = EndDateEntry.Date;
        await DatabaseService.UpdateTermAsync(TermToEdit);
    }
}
