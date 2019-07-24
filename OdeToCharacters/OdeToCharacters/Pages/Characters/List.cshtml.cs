using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToCharacters.Core;
using OdeToCharacters.Data;

namespace OdeToCharacters.Pages.Characters
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly ICharacterData characterData;


        public string Message { get; set; }
        public IEnumerable<Character> Characters { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config, ICharacterData characterData)
        {
            this.config = config;
            this.characterData = characterData;
        }
        public void OnGet()
        {
            Message = config["Message"];
            Characters = characterData.GetCharactersByName(SearchTerm);
        }
    }
}