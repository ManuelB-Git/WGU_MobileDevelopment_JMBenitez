using System.Collections.ObjectModel;
using WGU_MobileDevelopment_JMBenitez.Models;
using WGU_MobileDevelopment_JMBenitez.Services;

namespace WGU_MobileDevelopment_JMBenitez.Views;

public partial class TermDetailPage : ContentPage
{
    private readonly Term TermSent;
    ObservableCollection<Course> Courses = new ObservableCollection<Course>();
    public TermDetailPage(Term term)
    {
        InitializeComponent();
        TermSent = term;
        OnAppearing();
        CoursesCollectionView.ItemsSource = Courses;

    }



    //Populate courses from term into Courses list
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var coursesFromDb = await DatabaseService.GetCoursesByTermAsync(TermSent.Id);
        Courses.Clear();
        foreach (var course in coursesFromDb)
        {
            Courses.Add(course);
        }
    }

}
