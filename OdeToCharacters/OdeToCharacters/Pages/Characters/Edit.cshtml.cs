using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToCharacters.Core;
using OdeToCharacters.Data;
using System.Collections;
using System.Collections.Generic;

namespace OdeToCharacters.Pages.Characters
{
    public class EditModel : PageModel
    {
        private readonly ICharacterData characterData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Character Character { get; set; }
        public IEnumerable<SelectListItem> Races { get; set; }

        public EditModel(ICharacterData characterData,
                            IHtmlHelper htmlHelper)
        { 
            this.characterData = characterData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? characterId)
        {
            Races = htmlHelper.GetEnumSelectList<CharacterRace>();
            if (characterId.HasValue)
            {
                Character = characterData.GetById(characterId.Value);
            }
            else
            {
                Character = new Character();
            }

            if (Character == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Races = htmlHelper.GetEnumSelectList<CharacterRace>();
                return Page();
            }

            if(Character.Id > 0)
            {
                characterData.Update(Character);
            }
            else
            {
                characterData.AddCharacter(Character);
            }

            characterData.Commit();
            TempData["Message"] = "Your character has been ascimilated.";

            return RedirectToPage("./Detail", new { characterId = Character.Id });
        }
    }
}