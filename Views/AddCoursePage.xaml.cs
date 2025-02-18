using System.Text.RegularExpressions;
using WGU_MobileDevelopment_JMBenitez.Models;
using WGU_MobileDevelopment_JMBenitez.Services;

namespace WGU_MobileDevelopment_JMBenitez.Views;

public partial class AddCoursePage : ContentPage
{
    private Term TermToAddCourseTo;
    private Course CourseToAdd;

    public AddCoursePage(Term term)
    {
        InitializeComponent();
        TermToAddCourseTo = term;
        CourseToAdd = new Course(); // Assuming a default constructor exists
    }

    private async void SaveBtn_Clicked(object sender, EventArgs e)
    {
        // Validate required fields
        if (string.IsNullOrWhiteSpace(CourseTitleEntry.Text) ||
            string.IsNullOrWhiteSpace(InstructorEntry.Text) ||
            string.IsNullOrWhiteSpace(InstructorPhoneEntry.Text) ||
            string.IsNullOrWhiteSpace(InstructorEmailEntry.Text) ||
            StatusPicker.SelectedItem == null)
        {
            await DisplayAlert("Validation Error", "Please fill in all required fields.", "OK");
            return;
        }

        // Validate date range
        if (StartDateEntry.Date > EndDateEntry.Date)
        {
            await DisplayAlert("Validation Error", "Start date cannot be after end date.", "OK");
            return;
        }

        // Validate phone number (format: 123-456-7890)
        if (!Regex.IsMatch(InstructorPhoneEntry.Text, @"^\d{3}-\d{3}-\d{4}$"))
        {
            await DisplayAlert("Validation Error", "Please enter a valid phone number (e.g., 123-456-7890).", "OK");
            return;
        }

        // Validate email address
        if (!Regex.IsMatch(InstructorEmailEntry.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            await DisplayAlert("Validation Error", "Please enter a valid email address.", "OK");
            return;
        }

        // Set course properties
        CourseToAdd.TermId = TermToAddCourseTo.Id;
        CourseToAdd.Title = CourseTitleEntry.Text;
        CourseToAdd.StartDate = StartDateEntry.Date;
        CourseToAdd.EndDate = EndDateEntry.Date;
        CourseToAdd.Status = StatusPicker.SelectedItem?.ToString() ?? string.Empty;
        CourseToAdd.InstructorName = InstructorEntry.Text;
        CourseToAdd.InstructorPhone = InstructorPhoneEntry.Text;
        CourseToAdd.InstructorEmail = InstructorEmailEntry.Text;
        CourseToAdd.Notes = NotesEntry.Text;

        // Save to database
        await DatabaseService.AddCourseAsync(CourseToAdd);
        await Navigation.PopAsync();
    }
}
