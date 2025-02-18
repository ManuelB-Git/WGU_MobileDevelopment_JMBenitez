using System.Text.RegularExpressions;
using WGU_MobileDevelopment_JMBenitez.Models;
using WGU_MobileDevelopment_JMBenitez.Services;

namespace WGU_MobileDevelopment_JMBenitez.Views;

public partial class EditCoursePage : ContentPage
{
    private Course _course;

    public EditCoursePage(Course course)
    {
        InitializeComponent();
        _course = course;
        BindingContext = _course;
    }

    // Save the course after performing validations.
    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TitleEntry.Text) ||
            string.IsNullOrWhiteSpace(InstructorNameEntry.Text) ||
            string.IsNullOrWhiteSpace(InstructorPhoneEntry.Text) ||
            string.IsNullOrWhiteSpace(InstructorEmailEntry.Text))
        {
            await DisplayAlert("Validation Error", "Please fill in all required fields.", "OK");
            return;
        }

        if (StartDatePicker.Date >= EndDatePicker.Date)
        {
            await DisplayAlert("Validation Error", "Start date must be before end date.", "OK");
            return;
        }

        if (!Regex.IsMatch(InstructorEmailEntry.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            await DisplayAlert("Validation Error", "Please enter a valid email address.", "OK");
            return;
        }

        if (!Regex.IsMatch(InstructorPhoneEntry.Text, @"^\d{3}-\d{3}-\d{4}$"))
        {
            await DisplayAlert("Validation Error", "Please enter a valid phone number. Format: 123-456-7890.", "OK");
            return;
        }

        // Update the course object with new values.
        _course.Title = TitleEntry.Text;
        _course.StartDate = StartDatePicker.Date;
        _course.EndDate = EndDatePicker.Date;
        _course.Status = StatusPicker.SelectedItem?.ToString() ?? string.Empty;
        _course.InstructorName = InstructorNameEntry.Text;
        _course.InstructorPhone = InstructorPhoneEntry.Text;
        _course.InstructorEmail = InstructorEmailEntry.Text;
        _course.Notes = NotesEditor.Text;

        // Save updates to the database.
        await DatabaseService.UpdateCourseAsync(_course);
        await Navigation.PopAsync();
    }
}
