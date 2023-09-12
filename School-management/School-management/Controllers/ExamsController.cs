//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using School_management.DataAccess;
//using School_management.Models;

//namespace School_management.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ExamsController : ControllerBase
//    {

//        private readonly MyAppContext _context;
//        public ExamsController(MyAppContext context)
//        {
//            _context = context;
//        }
//        // GET: api/exams
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Exam>>> GetExams()
//        {
//            return await _context.Exams.ToListAsync();
//        }
//        // GET: api/exams/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Exam>> GetExam(int id)
//        {
//            var exam = await _context.Exams.FindAsync(id);
//            if (exam == null)
//            {
//                return NotFound();
//            }
//            return exam;
//        }
//        // POST: api/exams
//        [HttpPost]
//        public async Task<ActionResult<Exam>> PostExam(Exam exam)
//        {
//            _context.Exams.Add(exam);
//            await _context.SaveChangesAsync();
//            return CreatedAtAction("GetExam", new { id = exam.Id }, exam);
//        }
//        // PUT: api/Exams/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutExam(int id, Exam exam)
//        {
//            if (id != exam.Id)
//            {
//                return BadRequest();
//            }
//            _context.Entry(exam).State = EntityState.Modified;
//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!ExamExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }
//            return NoContent();
//        }
//        // DELETE: api/Exams/5
//        [HttpDelete("{id}")]
//        public async Task<ActionResult<Exam>> DeleteExam(int id)
//        {
//            var exam = await _context.Exams.FindAsync(id);
//            if (exam == null)
//            {
//                return NotFound();
//            }
//            _context.Exams.Remove(exam);
//            await _context.SaveChangesAsync();
//            return exam;
//        }
//        private bool ExamExists(int id)
//        {
//            return _context.Exams.Any(e => e.Id == id);
//        }

//    }
//}
