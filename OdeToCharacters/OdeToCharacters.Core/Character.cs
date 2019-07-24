using System.ComponentModel.DataAnnotations;

namespace OdeToCharacters.Core
{
    public class Character
    {
        public int Id { get; set; }

        [Required, StringLength(40)]
        public string Name { get; set; }

        [Required, StringLength(40)]
        public string PlaceOfOrigin { get; set; }

        public CharacterRace Race { get; set; }
    }
}
