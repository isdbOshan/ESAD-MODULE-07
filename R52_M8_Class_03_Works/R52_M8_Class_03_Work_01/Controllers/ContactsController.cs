using Microsoft.AspNetCore.Mvc;
using R52_M8_Class_03_Work_01.Models;
using R52_M8_Class_03_Work_01.ViewModels;

namespace R52_M8_Class_03_Work_01.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ContactDbContext db;
        private readonly IWebHostEnvironment env;

        public ContactsController(ContactDbContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ContactInputModel contact)
        {
            if (ModelState.IsValid)
            {
                var contactToInsert = new Contact
                {
                    Name = contact.Name,
                    Group = contact.Group,
                    Phone = contact.Phone,
                    Email = contact.Email

                };
                string ext = Path.GetExtension(contact.Picture.FileName);
                string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ext;
                string savePath = Path.Combine(this.env.WebRootPath, "Pictures", fileName);
                FileStream fs = new FileStream(savePath, FileMode.Create);
                await contact.Picture.CopyToAsync(fs);
                fs.Close();
                contactToInsert.Picture = fileName;
                await db.Contacts.AddAsync(contactToInsert);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(contact);
        }
    }
}
