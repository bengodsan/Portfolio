using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdeToCharacters.Data;

namespace OdeToCharacters.Pages.ViewComponents
{
    public class CharacterCountViewComponent
        :ViewComponent
    {
        private readonly ICharacterData characterData;

        public CharacterCountViewComponent(ICharacterData characterData)
        {
            this.characterData = characterData;
        }

        public IViewComponentResult Invoke()
        {
            var count = characterData.GetCharactersCount();
            return View(count);
        }
    }
}
