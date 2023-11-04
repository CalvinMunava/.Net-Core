using Architecture.ViewModel;

namespace Architecture.Models
{
    public interface ICourseRepository
    {
        // Course

        Task<int> AddCourseAsync(CourseViewModel course);
       
        Task<Course[]> GetAllCourseAsync();

        Task<CourseViewModel> GetCourseAsync(int CourseId);

        Task<int> UpdateCourseAsync(int courseId, CourseViewModel course);

        Task<int> DeleteCourseAsync(int courseId);

        //Students
        Task<List<Student>> GetAllStudents();



        //Users



        //Sales



        ///SDNFKJSDNFKJSFS

    }
}
