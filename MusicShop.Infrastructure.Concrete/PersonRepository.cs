using Microsoft.EntityFrameworkCore;
using MusicShop.Data.Context.Context;
using MusicShop.Data.Entities.Song;
using MusicShop.Data.Entities.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Infrastructure.Concrete
{
    public class PersonRepository:GenericRepository<Person>
    {
        protected readonly MusicShopContext _context;
        private readonly DbSet<Person> _dbSet;

        public PersonRepository(MusicShopContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<Person>();
        }

        public async Task<Person> GetByIdentityNoAsync(string identityNo)
        {
            return await _context.Persons.FirstOrDefaultAsync(p => p.IdentityNo == identityNo);
        }

    }
}
