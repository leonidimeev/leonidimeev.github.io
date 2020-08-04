using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDo.Data;
using ToDo.Models;

namespace ToDo.Pages.Goals
{
    public class DeleteModel : PageModel
    {
        private readonly ToDo.Data.ToDoContext _context;

        public DeleteModel(ToDo.Data.ToDoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Goal Goal { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Goal = await _context.Goal.FirstOrDefaultAsync(m => m.ID == id);

            if (Goal == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Goal = await _context.Goal.FindAsync(id);

            if (Goal != null)
            {
                _context.Goal.Remove(Goal);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
