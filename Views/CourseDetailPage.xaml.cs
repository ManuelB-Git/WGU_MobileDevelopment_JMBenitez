using WGU_MobileDevelopment_JMBenitez.Models;
using WGU_MobileDevelopment_JMBenitez.Services;

namespace WGU_MobileDevelopment_JMBenitez.Views;

public partial class CourseDetailPage : ContentPage
{
    private Course course;

    public CourseDetailPage(Course course)
    {
        InitializeComponent();
        this.course = course;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        BindingContext = course;
    }

    private void AddAssessmentBtn_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AddAssesspementPage(course));
    }

    private async void EditCourseBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EditCoursePage(course));
    }

    private async void DeleteCourseBtn_Clicked(object sender, EventArgs e)
    {
        bool confirm = await DisplayAlert("Delete Course", "Are you sure you want to delete this course?", "Yes", "No");
        if (confirm)
        {
            await DatabaseService.DeleteCourseAsync(course);
            await Navigation.PopAsync();
        }
    }

    // Share the course notes using the Share plugin.
    private async void ShareNotesBtn_Clicked(object sender, EventArgs e)
    {
        await ShareText(course.Notes);
    }

    public static async Task ShareText(string text)
    {
        await Share.Default.RequestAsync(new ShareTextRequest
        {
            Text = text,
            Title = "Share Notes"
        });
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AssessmentDetailPage(course));
    }
}
