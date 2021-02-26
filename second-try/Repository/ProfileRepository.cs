using second_try.Interfaces;
using second_try.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace second_try.Repository
{
    public class ProfileRepository : RepositoryBase<Profile>
    {
        public ProfileRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
