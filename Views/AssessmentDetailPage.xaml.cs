using System.Collections.ObjectModel;
using System.Linq;
using WGU_MobileDevelopment_JMBenitez.Models;
using WGU_MobileDevelopment_JMBenitez.Services;

namespace WGU_MobileDevelopment_JMBenitez.Views;

public partial class AssessmentDetailPage : ContentPage
{
    private ObservableCollection<Assessment> assessments = new();
    private Course course = new();

    public AssessmentDetailPage(Course course)
    {
        InitializeComponent();
        this.course = course;
     
 
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var assessmentsFromDb = await DatabaseService.GetAssessmentsByCourseAsync(course.Id);

        // Fixing the errors by converting the list to ObservableCollection
        assessments = new ObservableCollection<Assessment>(assessmentsFromDb);
        AssessmentsCollectionView.ItemsSource = assessments;
    }


    //Edit the assessment associated with
    private void EditBtn_Clicked(object sender, EventArgs e)
    {
        var assessment = (sender as Button)?.BindingContext as Assessment;
        if (assessment != null)
        {
            Navigation.PushAsync(new NewPage1(assessment));
        }

    }


    //Delete the assessment associated with
    private async void DeleteBtn_Clicked(object sender, EventArgs e)
    {
        var assessment = (sender as Button)?.BindingContext as Assessment;
        if (assessment != null)
        {
            bool isConfirmed = await DisplayAlert("Confirm Delete", "Are you sure you want to delete this assessment?", "Yes", "No");
            if (isConfirmed)
            {
                assessments.Remove(assessment);
                await DatabaseService.DeleteAssessmentAsync(assessment);
            }
        }
    }
}
