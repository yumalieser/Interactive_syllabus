using Interactive_Syllabus.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using Microsoft.EntityFrameworkCore;

namespace Interactive_Syllabus.Controllers
{
    [Authorize(Policy = "AcademicianOnly")]
	public class AcademicianController : Controller
	{
		Context _context = new Context();
		public IActionResult Panel()
		{
			return View();
		}

		/* PROFİL İŞLEMLERİ */
		public IActionResult Profile()
		{
			return View();
		}

		/* ÖĞRENCİ İŞLEMLERİ */
        [HttpGet]
        public IActionResult Students()
		{
			var ogrenciListele = _context.Students.ToList();
			return View(ogrenciListele);
		}
        [HttpGet]
        public IActionResult AddStudent()
        {
			ViewBag.Class = _context.StudentsClasses.ToList();
			ViewBag.Sections = _context.StudentsSections.ToList();
			return View();
        }
		[HttpPost]
		public async Task<IActionResult> AddStudent(AddStudentViewModel model)
		{
			if (ModelState.IsValid)
			{
				// Yeni bir Student nesnesi oluştur
				var newStudent = new Student
				{
					StudentName = model.StudentName,
					StudentSurname = model.StudentSurname,
					StudentEmail = model.StudentEmail,
					StudentPassword = model.StudentPassword
					// Burada StudentClass ve StudentsSection'ı atamayacağız
				};

				// Sınıf ve bölüm kontrolü
				var studentClass = await _context.StudentsClasses.FindAsync(model.StudentClassID);
				var studentSection = await _context.StudentsSections.FindAsync(model.StudentsSectionID);

				if (studentClass != null && studentSection != null)
				{
					// Sınıf ve bölüm var ise, öğrenci ekle
					newStudent.StudentClass = studentClass; // Navigasyon özelliği
					newStudent.StudentsSection = studentSection; // Navigasyon özelliği

					_context.Students.Add(newStudent);
					await _context.SaveChangesAsync();

					return RedirectToAction("Students");
				}
				else
				{
					ModelState.AddModelError("", "Geçersiz sınıf veya bölüm seçimi.");
				}
			}

			return View(model);
		}
		[HttpGet]
        public IActionResult AddMultipleStudent()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddMultipleStudentAsync(IFormFile fileUpload)
        {
            // EPPlus lisans kabulü
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            if (fileUpload != null && fileUpload.Length > 0)
            {
                var students = new List<Student>();

                using (var stream = new MemoryStream())
                {
                    await fileUpload.CopyToAsync(stream);
                    using (var package = new ExcelPackage(stream))
                    {
                        var worksheet = package.Workbook.Worksheets.FirstOrDefault();
                        if (worksheet != null)
                        {
                            var rowCount = worksheet.Dimension.Rows;

                            for (int row = 2; row <= rowCount; row++)
                            {
                                // Excel'deki ID alanlarını al
                                int studentClassId = int.Parse(worksheet.Cells[row, 5].Text);
                                int studentSectionId = int.Parse(worksheet.Cells[row, 6].Text);

                                // İlgili StudentClass ve StudentSection'ı veritabanından bul
                                var studentClass = await _context.StudentsClasses.FindAsync(studentClassId);
                                var studentSection = await _context.StudentsSections.FindAsync(studentSectionId);

                                if (studentClass != null && studentSection != null)
                                {
                                    // Öğrenci nesnesini oluştur ve ilişkili sınıf ve bölümü ata
                                    var student = new Student
                                    {
                                        StudentName = worksheet.Cells[row, 1].Text, // A sütunu
                                        StudentSurname = worksheet.Cells[row, 2].Text, // B sütunu
                                        StudentEmail = worksheet.Cells[row, 3].Text, // C sütunu
                                        StudentPassword = worksheet.Cells[row, 4].Text, // D sütunu
                                        StudentClass = studentClass,  // İlişkili sınıf nesnesi
                                        StudentsSection = studentSection // İlişkili bölüm nesnesi
                                    };

                                    students.Add(student);
                                }
                            }
                        }
                    }
                }

                // Veritabanına ekleme
                await _context.Students.AddRangeAsync(students);
                await _context.SaveChangesAsync();

                return RedirectToAction("Students"); // Başarıyla ekledikten sonra yönlendirme
            }

            return View(); // Hata durumu
        }

        /* DERS PROGRAMI İŞLEMLERİ */
        public IActionResult Syllabus()
		{
			return View();
		}
		public IActionResult Objections()
		{
			return View();
		}

		/* DERS İŞLEMLERİ */
		[HttpGet]
		public async Task<IActionResult> Lessons()
		{
            var lessons = await _context.Lessons
               .Include(l => l.Academician) // Akademisyen ile ilişkilendirilmiş veriyi dahil ediyoruz
               .ToListAsync();

            return View(lessons); // View'a listesi gönderiliyor
        }
        [HttpGet]
        public async Task<IActionResult> LessonsActivate()
        {
            var lessons = await _context.Lessons
               .Include(l => l.Academician) // Akademisyen ile ilişkilendirilmiş veriyi dahil ediyoruz
               .ToListAsync();

            return View(lessons); // View'a listesi gönderiliyor
        }
        [HttpGet]
        public IActionResult AddLesson()
        {
			ViewBag.Academicianes = _context.Academicianes.ToList();
            return View();
        }
		[HttpPost]
		public async Task<IActionResult> AddLesson(LessonViewModel model)
		{
            if (ModelState.IsValid)
			{
				var academician = await _context.Academicianes.FindAsync(model.LessonAcademicianID); // ForeignKey olan akademisyeni buluyoruz
				if (academician == null)
				{
					ModelState.AddModelError("", "Geçerli bir akademisyen seçilmedi.");
					return View(model);
				}

				var lesson = new Lesson
				{
					LessonID = model.LessonID,
					LessonName = model.LessonName,
					LessonCredit = model.LessonCredit,
					LessonAKTS = model.LessonAKTS,
					LessonDescription = model.LessonDescription,
					Academician = academician // Akademisyeni derse atıyoruz
				};

				_context.Lessons.Add(lesson);
				await _context.SaveChangesAsync();

				return RedirectToAction("Lessons"); // Başarılı kayıttan sonra yönlendirme
			}

			// Eğer ModelState geçersizse formu tekrar gösteriyoruz
			ViewBag.Academicianes = _context.Academicianes.ToList(); // Akademisyenleri tekrar doldurmak için
			return View(model);
		}
		[HttpGet]
        public IActionResult AddMultipleLesson()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddMultipleLesson(IFormFile file)
        {
            // EPPlus lisans kabulü
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            if (file == null || file.Length == 0)
            {
                ModelState.AddModelError("", "Lütfen geçerli bir Excel dosyası yükleyin.");
                return View();
            }

            using (var package = new ExcelPackage(file.OpenReadStream()))
            {
                var worksheet = package.Workbook.Worksheets.FirstOrDefault();
                if (worksheet == null)
                {
                    ModelState.AddModelError("", "Excel dosyası geçerli bir formatta değil.");
                    return View();
                }

                var rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++) // 1. satır başlık olduğu için 2. satırdan başlıyoruz
                {
                    var lessonId = worksheet.Cells[row, 1].Text;
                    var lessonName = worksheet.Cells[row, 2].Text;
                    var lessonCredit = int.Parse(worksheet.Cells[row, 3].Text);
                    var lessonAKTS = int.Parse(worksheet.Cells[row, 4].Text);
                    var lessonDescription = worksheet.Cells[row, 5].Text;
                    var academicianId = int.Parse(worksheet.Cells[row, 6].Text);

                    // Akademisyen kontrolü
                    var academician = await _context.Academicianes.FindAsync(academicianId);
                    if (academician == null)
                    {
                        ModelState.AddModelError("", $"Akademisyen ID: {academicianId} bulunamadı. Satır {row}");
                        continue; // Akademisyen bulunamazsa, o satırı atla
                    }

                    // Yeni ders oluştur
                    var lesson = new Lesson
                    {
                        LessonID = lessonId,
                        LessonName = lessonName,
                        LessonCredit = lessonCredit,
                        LessonAKTS = lessonAKTS,
                        LessonDescription = lessonDescription,
                        AcademicianID = academicianId,
                        Academician = academician
                    };

                    // Veritabanına ekle
                    _context.Lessons.Add(lesson);
                }

                // Tüm dersleri kaydet
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Lessons");
        }
        [HttpGet]
        public IActionResult AddLessonBaseScore()
        {
			return View();
        }
        [HttpPost]
        public IActionResult AddLessonBaseScore(int id)
        {
			return View();
        }
        public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Home", "Login");
		}
	}
}
