using MusicShop.Business.Interface;
using MusicShop.Data.Entities.UserInfo;
using MusicShop.Infrastructure.Concrete;
using MusicShop.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Business.Concrete
{
    public class PersonBusiness: Business<Person>
    {
        protected readonly PersonRepository _personRepository;
        public PersonBusiness(
           IUnitOfWork unitOfWork,
           IGenericRepository<Person> genericRepository,
           PersonRepository personRepository) // << buradan al
           : base(unitOfWork, genericRepository)
        {
            _personRepository = personRepository; // << alana ata
        }

        public async Task<Person> GetByIdentityNoAsync(string identityNo)
        {
            return await _personRepository.GetByIdentityNoAsync(identityNo);
        }



    }
}
