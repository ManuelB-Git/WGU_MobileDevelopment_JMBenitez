using WGU_MobileDevelopment_JMBenitez.Models;
using WGU_MobileDevelopment_JMBenitez.Services;

namespace WGU_MobileDevelopment_JMBenitez.Views;

public partial class AddAssesspementPage : ContentPage
{
    Course course;
    Assessment? assessment; // Make assessment nullable
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

        if (AssessmentDate.Date >= course.EndDate)
        {
            await DisplayAlert("Validation Error", "Assessment due date must be before the course end date.", "OK");
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

    private void Button_Clicked_1(object sender, EventArgs e)
    {

    }
}
