using System.Collections.Generic;
using OdeToCharacters.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OdeToCharacters.Data
{
    public class SqlCharacterData : ICharacterData
    {
        private readonly OdeToCharactersDbContext db;

        public SqlCharacterData(OdeToCharactersDbContext db)
        {
            this.db = db;
        }
        public Character AddCharacter(Character newCharacter)
        {
            db.Add(newCharacter);
            return newCharacter;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Character Delete(int id)
        {
            var character = GetById(id);
            if(character != null)
            {
                db.Characters.Remove(character);
            }
            return character;
        }

        public Character GetById(int id)
        {
            return db.Characters.Find(id);
        }

        public IEnumerable<Character> GetCharactersByName(string name)
        {
            var query = from c in db.Characters
                        where c.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby c.Name
                        select c;
            return query;
        }

        public int GetCharactersCount()
        {
            return db.Characters.Count();
        }

        public Character Update(Character updatedCharacter)
        {
            var entity = db.Characters.Attach(updatedCharacter);
            entity.State = EntityState.Modified;
            return updatedCharacter;
        }
    }
}
