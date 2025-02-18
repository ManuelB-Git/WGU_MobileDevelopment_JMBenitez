using System.Collections.ObjectModel;
using WGU_MobileDevelopment_JMBenitez.Models;
using WGU_MobileDevelopment_JMBenitez.Services;
using WGU_MobileDevelopment_JMBenitez.Views;

namespace WGU_MobileDevelopment_JMBenitez.Views;

public partial class TermDetailPage : ContentPage
{
    private readonly Term TermSent;
    ObservableCollection<Course> Courses = new ObservableCollection<Course>();
    public TermDetailPage(Term term)
    {
        InitializeComponent();
        TermSent = term;
        CoursesCollectionView.ItemsSource = Courses;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        OnAppearingAsync();
    }

    //Populate courses from term into Courses list
    private async void OnAppearingAsync()
    {
        var coursesFromDb = await DatabaseService.GetCoursesByTermAsync(TermSent.Id);
        Courses.Clear();
        foreach (var course in coursesFromDb)
        {
            Courses.Add(course);
        }
    }

    //Delete the term with a confirmation
    private async void DeleteTermBtn_Clicked(object sender, EventArgs e)
    {
        bool firstAnswer = await DisplayAlert("Delete Term", "Are you sure you want to delete this term?", "Yes", "No");

        if (firstAnswer)
        {
            Random random = new Random();
            int verificationCode = random.Next(1000, 9999);
            bool secondAnswer = await DisplayAlert("Delete Term", $"Please enter the following 4-digit code to confirm: {verificationCode}", "OK", "Cancel");

            if (secondAnswer)
            {
                string userInput = await DisplayPromptAsync("Delete Term", "Enter the 4-digit code:", "Confirm", "Cancel", "0000", 4, Keyboard.Numeric);

                if (userInput == verificationCode.ToString())
                {
                    await DatabaseService.DeleteTermAsync(TermSent);
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error", "Incorrect code. Term not deleted.", "OK");
                }
            }
        }
    }

    //Navigate to EditTermPage, passing the term to edit
    private async void EditTermBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EditTermPage(TermSent));
    }

    //Navigate to AddCoursePage, passing the term to add a course to
    private async void AddCourseBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddCoursePage(TermSent));
    }

    //Navigate to CourseDetailPage, passing the course to view
    private void CoursesCollectionView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
        {
            return;
        }
        Course course = (Course)e.SelectedItem;
        Navigation.PushAsync(new CourseDetailPage(course));
    }

    //Clearing the selected item
    private void CoursesCollectionView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
    }
}
