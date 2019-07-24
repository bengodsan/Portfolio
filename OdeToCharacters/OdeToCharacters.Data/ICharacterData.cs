using System.Collections.Generic;
using System.Text;
using OdeToCharacters.Core;

namespace OdeToCharacters.Data
{
    public interface ICharacterData
    {
        IEnumerable<Character> GetCharactersByName(string name);

        Character GetById(int id);

        Character Update(Character updateCharacter);

        Character AddCharacter(Character newCharacter);

        Character Delete(int id);

        int GetCharactersCount();

        int Commit();
    }
}
