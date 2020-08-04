using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ToDo.Data;
using ToDo.Models;

namespace ToDo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ToDo.Data.ToDoContext _context;
        public IndexModel(ILogger<IndexModel> logger, ToDo.Data.ToDoContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public Person Person { get; set; }
        public async Task<IActionResult> OnPostAsync(string login, string password)
        {
            if (login == null)
            {
                return NotFound();
            }

            Person = await _context.Person.FindAsync(login);

            if (Person != null)
            {
                if (IPerson.LoginIn(_context, Person.Login, password) != null) 
                {
                    return RedirectToPage("./Goals");
                }
                else
                {
                    return NotFound();
                }
            }
            return RedirectToPage("./Index");
        }
    }
}
