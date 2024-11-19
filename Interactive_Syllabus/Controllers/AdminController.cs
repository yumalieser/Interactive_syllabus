using Interactive_Syllabus.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace Virtual_Shopping.Controllers
{
	[Authorize(Policy = "AdminOnly")]
	public class AdminController : Controller
	{
		Context _context = new Context();

		public IActionResult Panel()
		{
			//var admin = _context.Admins.FirstOrDefault();	
			return View(/*admin*/);
		}

		/* PROFİL İŞLEMLERİ */
		public IActionResult Profile()
		{
			return View();
		}
		/* ÜRÜN İŞLEMLERİ */
		[HttpGet]
		public IActionResult Students()
		{
			var products = _context.Students.ToList();
			return View(products);
		}
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

		/* SATICI İŞLEMLERİ */
		[HttpGet]
		public IActionResult Academicianes()
		{
			var seller = _context.Academicianes.ToList();
			return View(seller);
		}
		[HttpGet]
		public IActionResult AddAcademician()
		{
			ViewBag.Sections = _context.StudentsSections.ToList();
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> AddAcademician(AddAcademicianViewModel model)
		{
			if (ModelState.IsValid)
			{
				var newAcademician = new Academician
				{
					AcademicianName = model.AcademicianName,
					AcademicianEmail = model.AcademicianEmail,
					AcademicianPassword = model.AcademicainPassword,
				};

				var studentSection = await _context.StudentsSections.FindAsync(model.StudentsSectionID);


				if (studentSection != null)
				{
					// Sınıf ve bölüm var ise, öğrenci ekle
					newAcademician.AcademicianSection = studentSection.StudentsSectionName; // Navigasyon özelliği

					_context.Academicianes.Add(newAcademician);
					await _context.SaveChangesAsync();

					return RedirectToAction("Academicianes");
				}
				else
				{
					ModelState.AddModelError("", "Geçersiz sınıf veya bölüm seçimi.");
				}


			}

			return View(model);

		}
		[HttpGet]
		public IActionResult AddMultipleAcademician()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> AddMultipleAcademicianAsync(IFormFile fileUpload)
		{
			// EPPlus lisans kabulü
			ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

			if (fileUpload != null && fileUpload.Length > 0)
			{
				var academicians = new List<Academician>();

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

								string AcademicianSection = worksheet.Cells[row, 4].Text;

								// İlgili StudentClass ve StudentSection'ı veritabanından bul
								var AcademicianSectionID = await _context.StudentsSections.FindAsync(AcademicianSection);

								if (AcademicianSectionID != null)
								{
									// Öğrenci nesnesini oluştur ve ilişkili sınıf ve bölümü ata
									var newAcademician = new Academician
									{
										AcademicianName = worksheet.Cells[row, 1].Text, // A sütunu
										AcademicianEmail = worksheet.Cells[row, 2].Text, // C sütunu
										AcademicianPassword = worksheet.Cells[row, 3].Text, // D sütunu
										AcademicianSection = AcademicianSection // İlişkili bölüm nesnesi
									};

									academicians.Add(newAcademician);
								}
							}
						}
					}
				}

				// Veritabanına ekleme
				await _context.Academicianes.AddRangeAsync(academicians);
				await _context.SaveChangesAsync();

				return RedirectToAction("Academician"); // Başarıyla ekledikten sonra yönlendirme
			}

			return View(); // Hata durumu
		}

        public IActionResult Objections()
        {
            return View();
        }

        [HttpPost]
		public IActionResult SearchAcademician(string searchTerm)
		{
			var academician = _context.Academicianes
				.Where(s => s.AcademicianName.Contains(searchTerm))
				.ToList();
			return View("Academicines", academician);
		}
		[HttpPost]
		public IActionResult SearchStudent(string searchTerm)
		{
			var student = _context.Students
				.Where(s => s.StudentName.Contains(searchTerm))
				.ToList();
			return View("Students", student);
		}

		[HttpPost]
		public IActionResult DeleteAcademician(int id)
		{
			var product = _context.Academicianes.Find(id);
			if (product != null)
			{
				_context.Academicianes.Remove(product);
				_context.SaveChanges();
			}
			return RedirectToAction("Products");
		}



		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Login", "Login");
		}
	}
}
