using Architecture.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Architecture.Models
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext db;

        public CourseRepository(AppDbContext appDbContext)
        {
                db = appDbContext;
        }
        public async Task<Course[]> GetAllCourseAsync()
        {
            IQueryable<Course> query = db.Courses;
            return await query.ToArrayAsync();
        }

        public async Task<CourseViewModel> GetCourseAsync(int CourseId)
        {
            CourseViewModel course = new CourseViewModel();

            Course query = await db.Courses.Where(x=> x.CourseId == CourseId).FirstOrDefaultAsync();

            if(query == null)
            {
                course.response = 404;
            }
            else
            {
                course.Course.CourseId = query.CourseId;
                course.Course.Name = query.Name;
                course.Course.Description = query.Description;
                course.Course.Duration = query.Duration;
                course.response = 200;
            }
            return course;

        }

        public async Task<int> AddCourseAsync(CourseViewModel course)
        {
            int code = 200;
            try
            {
                Course courseAdd = new Course();
                courseAdd.Name = course.Course.Name;
                courseAdd.Duration = course.Course.Duration;
                courseAdd.Description = course.Course.Description;
                courseAdd.Duration = course.Course.Duration;
                await db.Courses.AddAsync(courseAdd);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                code = 500;
            }
            return code;
        }

        public async Task<int> UpdateCourseAsync(int courseId, CourseViewModel course)
        {
            int code = 200;
            //Find the object in the db 
            Course attemptToFindInDb = await db.Courses.Where(x => x.CourseId == courseId).FirstOrDefaultAsync();
            if(attemptToFindInDb == null)
            {
                code = 404;
            }
            else
            {
                attemptToFindInDb.Name = course.Course.Name;
                attemptToFindInDb.Duration= course.Course.Duration;
                attemptToFindInDb.Description = course.Course.Description;
                db.Courses.Update(attemptToFindInDb);
                await db.SaveChangesAsync();
            }
            return code;
        }

        public async Task<int> DeleteCourseAsync(int courseId)
        {
            int code = 200;

            //Find the object in the db 
            Course attemptToFindInDb = await db.Courses.Where(x => x.CourseId == courseId).FirstOrDefaultAsync();

            if (attemptToFindInDb == null)
            {
                code = 404;
            }
            else 
            { 
                db.Courses.Remove(attemptToFindInDb);
                await db.SaveChangesAsync();
            }
            return code;
        }


        // Students
        public async Task<List<Student>> GetAllStudents()
        {
            return await db.Students.ToListAsync();
        }


        public async Task<List<Course>> GetCoursesByDurationType()
        {
            return await db.Courses.Where(x=> x.Duration == "Year").ToListAsync();
        }










    }
}
