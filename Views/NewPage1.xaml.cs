using WGU_MobileDevelopment_JMBenitez.Models;
using WGU_MobileDevelopment_JMBenitez.Services;

namespace WGU_MobileDevelopment_JMBenitez.Views;

public partial class NewPage1 : ContentPage
{
    private Assessment assessmenttoedit;

    public NewPage1(Assessment assessment)
    {
        InitializeComponent();
        assessmenttoedit = assessment;
        BindingContext = assessmenttoedit;

        AssessmentTitle.Text = assessmenttoedit.Name;
        AssessmentTypePicker.SelectedItem = assessmenttoedit.Type;
        AssessmentDate.Date = assessmenttoedit.DueDate;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(AssessmentTitle.Text))
        {
            await DisplayAlert("Validation Error", "Assessment title cannot be empty.", "OK");
            return;
        }
        if (AssessmentTypePicker.SelectedItem == null)
        {
            await DisplayAlert("Validation Error", "Please select an assessment type.", "OK");
            return;
        }



        assessmenttoedit.Name = AssessmentTitle.Text;
        assessmenttoedit.Type = AssessmentTypePicker.SelectedItem?.ToString() ?? string.Empty;
        assessmenttoedit.DueDate = AssessmentDate.Date;
        await DatabaseService.UpdateAssessmentAsync(assessmenttoedit);

        await Navigation.PopAsync();
    }
}
