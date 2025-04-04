using Examination.Models;
using Examination.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Examination.Controllers
{
    public class ExamsController : Controller
    {
        private readonly AppDbContext context;

        public ExamsController(AppDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var exams = context.Exams.OrderBy(e => e.EDate).ToList();
            return View(exams);
        }


        public IActionResult Create()
        {
            var lessons = context.Lessons.ToList(); 
            ViewBag.LessonList = new SelectList(lessons, "Id", "LCode");

            var pupils = context.Pupils.ToList();
            ViewBag.PupilList = new SelectList(pupils, "Id", "PCode");

            return View();
        }

        [HttpPost]
        public IActionResult Create(ExamDTO examdto)
        {
            if (!ModelState.IsValid)
            {
                return View(examdto);
            }

            Exam exam = new Exam()
            {
                LCode = examdto.LCode,
                PCode = examdto.PCode,
                EDate = examdto.EDate,
                EPrice = examdto.EPrice,
            };

            context.Exams.Add(exam);
            context.SaveChanges();

            return RedirectToAction("index", "Exams");
        }


        public IActionResult Modify(int id)
        {
            var exam = context.Exams.Find(id);
            if (exam == null)
            {
                return RedirectToAction("Index", "Exams");
            }

            var lessons = context.Lessons.ToList();
            ViewBag.LessonList = new SelectList(lessons, "Id", "LCode", exam.Id);

            var pupils = context.Pupils.ToList();
            ViewBag.PupilList = new SelectList(pupils, "Id", "PCode", exam.Id);

            var examdto = new ExamDTO()
            {
                LCode = exam.LCode,
                PCode = exam.PCode,
                EDate = exam.EDate,
                EPrice = exam.EPrice,
            };

            ViewData["ExamID"] = exam.Id;
            return View(examdto);
        }

        [HttpPost]
        public IActionResult Modify(int Id, ExamDTO examdto)
        {
            var exam = context.Exams.Find(Id);
            if (exam == null)
            {
                return RedirectToAction("Index", "Exams");
            }

            if (!ModelState.IsValid)
            {
                ViewData["ExamID"] = exam.Id;
                return View(examdto);
            }

            exam.LCode = examdto.LCode;
            exam.PCode = examdto.PCode;
            exam.EDate = examdto.EDate;
            exam.EPrice = examdto.EPrice;

            context.SaveChanges();
            return RedirectToAction("Index", "Exams");
        }


        public IActionResult Delete(int Id)
        {
            var exam = context.Exams.Find(Id);
            if (exam == null)
            {
                return RedirectToAction("Index", "Exams");
            }

            context.Exams.Remove(exam);
            context.SaveChanges(true);
            return RedirectToAction("Index", "Exams");
        }
    }
}
