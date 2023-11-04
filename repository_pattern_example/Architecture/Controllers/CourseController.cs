using Architecture.Models;
using Architecture.ViewModel;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Reflection.Metadata.Ecma335;

namespace Architecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }


        /* C */
        [HttpPost]
        [Route("AddCourse")]
        public async Task<IActionResult> AddCourse(CourseViewModel course)
        {
            try
            {
                var results = await _courseRepository.AddCourseAsync(course);
                if (results == 200)
                {
                    var res = new OkObjectResult(new { message = "Successfully Added " + course.Course.Name, currentDate = DateTime.Now, StatusCode = 200 });
                    return res;
                }
                else
                {
                    var res = new OkObjectResult(new { message = "Failed To Add Course Please check your code", currentDate = DateTime.Now, StatusCode = 501 });
                    return res;
                }

            }
            catch (Exception)
            {
                var res = new OkObjectResult(new { message = "Internal Server Error. Please contact support.", currentDate = DateTime.Now, StatusCode = 500 });
                return res;

            }
        }


        /* R - ALL */
        [HttpGet]
        [Route("GetAllCourses")]
        public async Task<IActionResult> GetAllCourses()
        {
            try
            {
                var results = await _courseRepository.GetAllCourseAsync();
                return Ok(results);
            }
            catch (Exception)
            {
                return StatusCode(500,"Internal Server Error. Please contact support.");
            }
        }


        /* R - One */
        [HttpGet]
        [Route("GetCourse/{CourseId}")]
        public async Task<IActionResult> GetCourses(int CourseId)
        {
            try
            {
                var result = await _courseRepository.GetCourseAsync(CourseId);
                if(result.response == 404)
                {
                    return StatusCode(404, "Cannot Find Specified Course");
                }
                else if (result.response == 200)
                {
                    return Ok(result);
                }
                else
                {
                    return Ok("idk fam");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error. Please contact support.");
            }
        }

        /* U */
        [HttpPut]
        [Route("UpdateCourse/{CourseId}")]
        public async Task<IActionResult> UpdateCourse(int CourseId,CourseViewModel course)
        {
            try
            {
                var result = await _courseRepository.UpdateCourseAsync(CourseId,course);
                if (result == 200)
                {
                    var res = new OkObjectResult(new { message = "Successfully Updated " + course.Course.Name, currentDate = DateTime.Now, StatusCode = 200 });
                    return res;
                }
                else if(result == 404)
                {
                    var res = new OkObjectResult(new { message = "Failed To Update Course Record Not Found", currentDate = DateTime.Now, StatusCode = 404 });
                    return res;

                }
                else
                {
                    var res = new OkObjectResult(new { message = "Failed To Update Course Please check your code", currentDate = DateTime.Now, StatusCode = 501 });
                    return res;
                }
            }
            catch (Exception)
            {
                var res = new OkObjectResult(new { message = "Internal Server Error. Please contact support.", currentDate = DateTime.Now, StatusCode = 501 });
                return res;
            }
        }


        /* D */
        [HttpDelete]
        [Route("DeleteCourse/{CourseId}")]
        public async Task<IActionResult> DeleteCourse(int CourseId)
        {

            try
            {
                var result = await _courseRepository.DeleteCourseAsync(CourseId);
                if (result == 200)
                {
  
                    var res = new OkObjectResult(new { message = "Successfully Deleted Record with ID" + CourseId, currentDate = DateTime.Now, StatusCode = 200 });
                    return res;
                }
                else if (result == 404)
                {
                    var res = new OkObjectResult(new { message = "Failed To Update Course Record Not Found", currentDate = DateTime.Now, StatusCode = 404 });
                    return res;
                }
                else
                {
                    var res = new OkObjectResult(new { message = "Failed To Update Course Please check your code", currentDate = DateTime.Now, StatusCode = 401 });
                    return res;

                }
            }
            catch (Exception)
            {
                var res = new OkObjectResult(new { message = "Internal Server Error. Please contact support.", currentDate = DateTime.Now, StatusCode = 500 });
                return res;
            }
        }



        [HttpGet]
        [Route("CalvinIsTheBestTutorInTheWorld")]
        public async Task<List<Student>> tqwyfetwqhfetyqweyq()
        {
            return await _courseRepository.GetAllStudents();

        }

        [HttpGet]
        public async Task<IActionResult>  GetCoursesByDurationType()
        {
            try
            {
                var info = _courseRepository.GetCoursesByDurationType();
                return new OkObjectResult(info);
            }
            catch(Exception ex )
            {
                string Message = "";
                var statusCode = ex as WebException;        
                if((statusCode.Response as HttpWebResponse)?.StatusCode == HttpStatusCode.InternalServerError)
                { 
                    Message = "Internal Server Error Something Bad Happened Go Home ";
                }
                else if ((statusCode.Response as HttpWebResponse)?.StatusCode == HttpStatusCode.NotFound)
                {
                    Message = "Cannot Find Any Data ";
                }
                else
                {
                    Message = ex.Message;
                }
                return new OkObjectResult(new {messsage = Message});
            }
        }
    }
}
