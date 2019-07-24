using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OdeToCharacters.Core;
using OdeToCharacters.Data;

namespace OdeToCharacters.Pages.C2
{
    public class DetailsModel : PageModel
    {
        private readonly OdeToCharacters.Data.OdeToCharactersDbContext _context;

        public DetailsModel(OdeToCharacters.Data.OdeToCharactersDbContext context)
        {
            _context = context;
        }

        public Character Character { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Character = await _context.Characters.FirstOrDefaultAsync(m => m.Id == id);

            if (Character == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
