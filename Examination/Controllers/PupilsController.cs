using Examination.Models;
using Examination.Services;
using Microsoft.AspNetCore.Mvc;

namespace Examination.Controllers
{
    public class PupilsController : Controller    
    {
        private readonly AppDbContext context;

        public PupilsController(AppDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var pupils = context.Pupils.ToList();
            return View(pupils);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PupilDTO pupildto)
        {
            if (!ModelState.IsValid)
            {
                return View(pupildto);
            }

            Pupil pupil = new Pupil()
            {
                PCode = pupildto.PCode,
                PName = pupildto.PName,
                PSurname = pupildto.PSurname,
                PGrade = pupildto.PGrade,
            };

            context.Pupils.Add(pupil);
            context.SaveChanges();

            return RedirectToAction("index", "Pupils");
        }


        public IActionResult Modify(int id)
        {
            var pupil = context.Pupils.Find(id);
            if (pupil == null)
            {
                return RedirectToAction("Index", "Pupils");
            }

            var pupildto = new PupilDTO()
            {
                PCode = pupil.PCode,
                PName = pupil.PName,
                PSurname = pupil.PSurname,
                PGrade = pupil.PGrade,
            };

            ViewData["PupilID"] = pupil.Id;
            return View(pupildto);
        }

        [HttpPost]
        public IActionResult Modify(int Id, PupilDTO pupildto)
        {
            var pupil = context.Pupils.Find(Id);
            if (pupil == null)
            {
                return RedirectToAction("Index", "Pupils");
            }

            if (!ModelState.IsValid)
            {
                ViewData["PupilID"] = pupil.Id;
                return View(pupildto);
            }

            pupil.PCode = pupildto.PCode;
            pupil.PName = pupildto.PName;
            pupil.PSurname = pupildto.PSurname;
            pupil.PGrade = pupildto.PGrade;

            context.SaveChanges();
            return RedirectToAction("Index", "Pupils");
        }


        public IActionResult Delete(int Id)
        {
            var pupil = context.Pupils.Find(Id);
            if (pupil == null)
            {
                return RedirectToAction("Index", "Pupils");
            }

            context.Pupils.Remove(pupil);
            context.SaveChanges(true);
            return RedirectToAction("Index", "Pupils");
        }
    }
}
