using second_try.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace second_try.Repository
{
    public class TagRepository : RepositoryBase<Tag>
    {
        public TagRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
