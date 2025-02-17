using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WGU_MobileDevelopment_JMBenitez.Models;

namespace WGU_MobileDevelopment_JMBenitez.Services
{
    public class DatabaseService
    {
        //Database path
        private static SQLiteAsyncConnection? _database;

        //Initialize the database
        private static async Task Init()
        {
            if (_database != null)
            {
                return;
            }
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "WGU_MobileDevelopment_JMBenitez.db");
            _database = new SQLiteAsyncConnection(databasePath);
            await _database.CreateTableAsync<Term>();
            await _database.CreateTableAsync<Course>();
            await _database.CreateTableAsync<Assessment>();
        }

        //Get all terms
        public static async Task<List<Term>> GetTermsAsync()
        {
            await Init();
            if (_database == null)
            {
                throw new InvalidOperationException("Database not initialized.");
            }
            return await _database.Table<Term>().ToListAsync();
        }

        //Add a term
        public static async Task AddTermAsync(Term term)
        {
            await Init();
            if (_database == null)
            {
                throw new InvalidOperationException("Database not initialized.");
            }
            await _database.InsertAsync(term);
        }


        //Update a term
        public static async Task UpdateTermAsync(Term term)
        {
            await Init();
            if (_database == null)
            {
                throw new InvalidOperationException("Database not initialized.");
            }
            await _database.UpdateAsync(term);
        }


        //Delete a term
        public static async Task DeleteTermAsync(Term term)
        {
            await Init();
            if (_database == null)
            {
                throw new InvalidOperationException("Database not initialized.");
            }
            await _database.DeleteAsync(term);
        }


        //Get course by term
        public static async Task<List<Course>> GetCoursesByTermAsync(int termId)
        {
            await Init();
            if (_database == null)
            {
                throw new InvalidOperationException("Database not initialized.");
            }
            return await _database.Table<Course>().Where(c => c.TermId == termId).ToListAsync();
        }


        //Add a course
        public static async Task AddCourseAsync(Course course)
        {
            await Init();
            if (_database == null)
            {
                throw new InvalidOperationException("Database not initialized.");
            }
            await _database.InsertAsync(course);
        }


        //Update a course
        public static async Task UpdateCourseAsync(Course course)
        {
            await Init();
            if (_database == null)
            {
                throw new InvalidOperationException("Database not initialized.");
            }
            await _database.UpdateAsync(course);
        }

        //Delete a course
        public static async Task DeleteCourseAsync(Course course)
        {
            await Init();
            if (_database == null)
            {
                throw new InvalidOperationException("Database not initialized.");
            }
            await _database.DeleteAsync(course);
        }



        //Get assessments by course
        public static async Task<List<Assessment>> GetAssessmentsByCourseAsync(int courseId)
        {
            await Init();
            if (_database == null)
            {
                throw new InvalidOperationException("Database not initialized.");
            }
            return await _database.Table<Assessment>().Where(a => a.CourseId == courseId).ToListAsync();
        }


        //Add an assessment
        public static async Task AddAssessmentAsync(Assessment assessment)
        {
            await Init();
            if (_database == null)
            {
                throw new InvalidOperationException("Database not initialized.");
            }
            await _database.InsertAsync(assessment);
        }


        //Update an assessment
        public static async Task UpdateAssessmentAsync(Assessment assessment)
        {
            await Init();
            if (_database == null)
            {
                throw new InvalidOperationException("Database not initialized.");
            }
            await _database.UpdateAsync(assessment);
        }

        //Delete an assessment
        public static async Task DeleteAssessmentAsync(Assessment assessment)
        {
            await Init();
            if (_database == null)
            {
                throw new InvalidOperationException("Database not initialized.");
            }
            await _database.DeleteAsync(assessment);
        }






        public static async Task SeedDataAsync()
        {
            await Init();

            //Check if there are any terms
            var terms = await GetTermsAsync();

            if(terms.Count == 0)
            {
                //Create on term
                var term = new Term
                {
                    Title = "Term 1",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(120)
                };

                await AddTermAsync(term);

                //Create one course for the term
                var course = new Course
                {
                    TermId = term.Id,
                    Title = "Introduction to Software Engineering",
                    StartDate = DateTime.Today,
                    EndDate = DateTime.Today.AddMonths(4),
                    Status = "In Progress",
                    InstructorName = "Anika Patel",
                    InstructorPhone = "555-123-4567",
                    InstructorEmail = "anika.patel@strimeuniversity.edu",
                    Notes = "Remember to review the syllabus."
                };
                await AddCourseAsync(course);


                // Create two assessments for this course: one objective and one performance.
                var objectiveAssessment = new Assessment
                {
                    CourseId = course.Id,
                    Type = AssessmentType.Objective,
                    Name = "Objective Test",
                    DueDate = DateTime.Today.AddMonths(2)
                };

                var performanceAssessment = new Assessment
                {
                    CourseId = course.Id,
                    Type = AssessmentType.Performance,
                    Name = "Performance Project",
                    DueDate = DateTime.Today.AddMonths(3)
                };

                await AddAssessmentAsync(objectiveAssessment);
                await AddAssessmentAsync(performanceAssessment);
            }


        }

    }
}
