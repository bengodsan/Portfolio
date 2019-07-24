using System;
using System.Collections.Generic;
using System.Linq;
using OdeToCharacters.Core;

namespace OdeToCharacters.Data
{
    public class InMemoryCharacterData : ICharacterData
    {
        private readonly List<Character> characters;

        public InMemoryCharacterData()
        {
            characters = new List<Character>()
            {
                new Character { Id = 1, Name = "Elkwell Candlekeep", PlaceOfOrigin = "Daggerfall", Race = CharacterRace.Breton},
                new Character { Id = 2, Name = "Phaio Slatemoure", PlaceOfOrigin = "Gilneas", Race = CharacterRace.Human},
                new Character { Id = 3, Name = "Shaydis Snow", PlaceOfOrigin = "Wayrest", Race = CharacterRace.Breton}
            };
        }

        public Character GetById(int id)
        {
            return characters.SingleOrDefault(c => c.Id == id);
        }

        public Character AddCharacter(Character newCharacter)
        {
            characters.Add(newCharacter);
            newCharacter.Id = characters.Max(c => c.Id) + 1;
            return newCharacter;
        }

        public Character Update(Character updatedCharacter)
        {
            var character = characters.SingleOrDefault(c => c.Id == updatedCharacter.Id);
            if (character != null)
            {
                character.Name = updatedCharacter.Name;
                character.PlaceOfOrigin = updatedCharacter.PlaceOfOrigin;
                character.Race = updatedCharacter.Race;
            }
            return character;
        }

        public int Commit()
        {
            return 0;
        }

        public IEnumerable<Character> GetCharactersByName(string name = null)
        {
            return from c in characters
                   where string.IsNullOrEmpty(name) || c.Name.StartsWith(name)
                   orderby c.Name
                   select c;
        }

        public Character Delete(int id)
        {
            var character = characters.FirstOrDefault(c => c.Id == id);
            if (character != null)
            {
                characters.Remove(character);
            }
            return character;
        }

        public int GetCharactersCount()
        {
            return characters.Count();
        }
    }
}
