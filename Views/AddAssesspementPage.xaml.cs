using WGU_MobileDevelopment_JMBenitez.Models;
using WGU_MobileDevelopment_JMBenitez.Services;

namespace WGU_MobileDevelopment_JMBenitez.Views;

public partial class AddAssesspementPage : ContentPage
{
    private Course course;
    Assessment? assessment; 

    public AddAssesspementPage(Course course)
    {
        InitializeComponent();
        this.course = course;
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



        assessment = new Assessment
        {
            CourseId = course.Id,
            Name = AssessmentTitle.Text,
            Type = AssessmentTypePicker.SelectedItem?.ToString() ?? string.Empty,
            DueDate = AssessmentDate.Date
        };

        await DatabaseService.AddAssessmentAsync(assessment);


        await Navigation.PopAsync();
    }


}
