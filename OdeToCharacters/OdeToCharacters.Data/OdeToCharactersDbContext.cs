using Microsoft.EntityFrameworkCore;
using OdeToCharacters.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToCharacters.Data
{
    public class OdeToCharactersDbContext : DbContext
    {
        public OdeToCharactersDbContext(DbContextOptions<OdeToCharactersDbContext> options)
            :base(options)
        {

        }
        public DbSet<Character> Characters { get; set; }
    }
}
