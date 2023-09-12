using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_management.DTO;
using School_management.Interfaces;
using School_management.Models;
using schoolManagement.Interfaces;
using schoolManagement.Models;

namespace School_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly IGradeRepository gradeRepository;

        public GradesController( IGradeRepository gradeRepository)
        {
            this.gradeRepository = gradeRepository;
        }

        // GET: api/Grade
        [HttpGet]
        public ActionResult<IList<Grade>> GetGrades()
        {
            return gradeRepository.GetGrades().ToList();
        }

        // GET: api/Grade/5
        [HttpGet("{id}")]
        public ActionResult<Grade> GetGrade(int id)
        {
            var GradeInfo = gradeRepository.GetGrade(id);   

            if (GradeInfo == null)
            {
                return NotFound();
            }

            return GradeInfo;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutGradeInfo(int id, [FromForm] Gradeobj gradeInfo)
        {

            var ModifiedGrade = new Grade
            {
                Name = gradeInfo.Name,
                Description = gradeInfo.Description,    
            };
            gradeRepository.UpdateGrade(id, ModifiedGrade); 

            return Ok(ModifiedGrade);

        }

       
        [HttpPost]
        public ActionResult<Grade> PostGradeInfo([FromForm]Gradeobj gradeInfo)
        {
            var NewGrade = new Grade
            {
                Name = gradeInfo.Name,
                Description=gradeInfo.Description

            };

            gradeRepository.InsertGrade(NewGrade);

            return Ok(NewGrade);
        }

       
        [HttpDelete("{id}")]
        public IActionResult DeleteGrradeInfo(int id)
        {
            var gradeInfo = gradeRepository.DeleteGrade(id);
            if (gradeInfo == null)
            {
                return NotFound();
            }

            return Ok("  تم الحذف");
        }

       
    }
}
