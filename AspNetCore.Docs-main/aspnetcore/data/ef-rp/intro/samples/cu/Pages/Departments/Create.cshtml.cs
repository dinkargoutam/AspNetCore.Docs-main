using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;

namespace ContosoUniversity.Pages.Departments
{
    public class CreateModel : PageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public CreateModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            InstructorSL = new SelectList(_context.Instructors, "ID", 
                "FirstMidName");
            Department = new Department
            {
                Name = "Test",
                Budget = 666,
                StartDate = DateTime.Now,
                InstructorID = 2
        };
            return Page();
        }

        [BindProperty]
        public Department Department { get; set; }
        public SelectList InstructorSL { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Departments.Add(Department);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}