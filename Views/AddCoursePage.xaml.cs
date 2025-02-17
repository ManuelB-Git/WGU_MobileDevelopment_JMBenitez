using System.Text.RegularExpressions;
using WGU_MobileDevelopment_JMBenitez.Models;
using WGU_MobileDevelopment_JMBenitez.Services;

namespace WGU_MobileDevelopment_JMBenitez.Views;

public partial class AddCoursePage : ContentPage
{
    Term TermToAddCourseTo;
    Course CourseToAdd;
    public AddCoursePage(Term term)
    {
        InitializeComponent();
        TermToAddCourseTo = term;
        CourseToAdd = new Course(); // Assuming a default constructor exists
    }

    private async void SaveBtn_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(CourseTitleEntry.Text) ||
            string.IsNullOrWhiteSpace(InstructorEntry.Text) ||
            string.IsNullOrWhiteSpace(InstructorPhoneEntry.Text) ||
            string.IsNullOrWhiteSpace(InstructorEmailEntry.Text) ||
            StatusPicker.SelectedItem == null)
        {
            await DisplayAlert("Validation Error", "Please fill in all required fields.", "OK");
            return;
        }

        if (StartDateEntry.Date > EndDateEntry.Date)
        {
            await DisplayAlert("Validation Error", "Start date cannot be after end date.", "OK");
            return;
        }

        if (!Regex.IsMatch(InstructorPhoneEntry.Text, @"^\d{3}-\d{3}-\d{4}$"))
        {
            await DisplayAlert("Validation Error", "Please enter a valid phone number.", "OK");
            return;
        }

        if (!Regex.IsMatch(InstructorEmailEntry.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            await DisplayAlert("Validation Error", "Please enter a valid email address.", "OK");
            return;
        }

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


