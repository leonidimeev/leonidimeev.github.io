using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDo.Data;
using ToDo.Models;

namespace ToDo.Pages.Goals
{
    public class CreateModel : PageModel
    {
        private readonly ToDo.Data.ToDoContext _context;

        public CreateModel(ToDo.Data.ToDoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Goal Goal { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Goal.Add(Goal);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
