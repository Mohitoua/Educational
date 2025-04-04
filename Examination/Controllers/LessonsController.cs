using Examination.Models;
using Examination.Services;
using Microsoft.AspNetCore.Mvc;

namespace Examination.Controllers
{
    public class LessonsController : Controller
    {
        private readonly AppDbContext context;

        public LessonsController(AppDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var lessons = context.Lessons.ToList();
            return View(lessons);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(LessonDTO lessondto)
        {
            if (!ModelState.IsValid)
            {
                return View(lessondto);
            }

            Lesson lesson = new Lesson()
            {
                LCode = lessondto.LCode,
                LName = lessondto.LName,
                LGrade = lessondto.LGrade,
                LTeacherName = lessondto.LTeacherName,
                LTeacherSurname = lessondto.LTeacherSurname,
            };

            context.Lessons.Add(lesson);
            context.SaveChanges();

            return RedirectToAction("index", "Lessons");
        }


        public IActionResult Modify(int id)
        {
            var lesson = context.Lessons.Find(id);
            if (lesson == null)
            {
                return RedirectToAction("Index", "Lessons");
            }

            var lessondto = new LessonDTO()
            {
                LCode = lesson.LCode,
                LName = lesson.LName,
                LGrade = lesson.LGrade,
                LTeacherName = lesson.LTeacherName,
                LTeacherSurname = lesson.LTeacherSurname,
            };

            ViewData["LessonID"] = lesson.Id;
            return View(lessondto);
        }

        [HttpPost]
        public IActionResult Modify(int Id, LessonDTO lessondto)
        {
            var lesson = context.Lessons.Find(Id);
            if (lesson==null)
            {
                return RedirectToAction("Index", "Lessons");
            }

            if (!ModelState.IsValid)
            {
                ViewData["LessonID"] = lesson.Id;
                return View(lessondto);
            }

            lesson.LCode = lessondto.LCode;
            lesson.LName = lessondto.LName;
            lesson.LGrade = lessondto.LGrade;
            lesson.LTeacherName = lessondto.LTeacherName;
            lesson.LTeacherSurname = lessondto.LTeacherSurname;

            context.SaveChanges();
            return RedirectToAction("Index", "Lessons");
        }


        public IActionResult Delete(int Id)
        {
            var lesson = context.Lessons.Find(Id);
            if (lesson == null)
            {
                return RedirectToAction("Index", "Lessons");
            }

            context.Lessons.Remove(lesson);
            context.SaveChanges(true);
            return RedirectToAction("Index", "Lessons");
        }
    }
}
