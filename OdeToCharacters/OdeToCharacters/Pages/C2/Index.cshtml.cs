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
    public class IndexModel : PageModel
    {
        private readonly OdeToCharacters.Data.OdeToCharactersDbContext _context;

        public IndexModel(OdeToCharacters.Data.OdeToCharactersDbContext context)
        {
            _context = context;
        }

        public IList<Character> Character { get;set; }

        public async Task OnGetAsync()
        {
            Character = await _context.Characters.ToListAsync();
        }
    }
}
