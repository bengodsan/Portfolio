using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToCharacters.Core;
using OdeToCharacters.Data;

namespace OdeToCharacters.Pages.Characters
{
    public class DetailModel : PageModel
    {
        private readonly ICharacterData characterData;

        [TempData]
        public string Message { get; set; }
        public Character Character { get; set; }

        public DetailModel(ICharacterData characterData)
        {
            this.characterData = characterData;
        }
        public IActionResult OnGet(int characterId)
        {
            Character = characterData.GetById(characterId);
            if (Character == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            {
                return Page();
            }
        }
    }
}