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
    public class DeleteModel : PageModel
    {
        private readonly ICharacterData characterData;

        public Character Character { get; set; }

        public DeleteModel(ICharacterData characterData)
        {
            this.characterData = characterData;
        }

        public IActionResult OnGet(int characterId)
        {
            Character = characterData.GetById(characterId);
            if(Character == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int characterId)
        {
            var character = characterData.Delete(characterId);
            characterData.Commit();
            
            if(character == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{character.Name} has been deleted.";
            return RedirectToPage("./List");
        }
    }
}