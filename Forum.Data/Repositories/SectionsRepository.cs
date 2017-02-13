using Forum.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Forum.Data.Repositories
{
    public class SectionsRepository : GenericRepository<Section>, ISectionsRepository
    {
        public SectionsRepository(DbContext context) : base(context)
        {
        }

        public IQueryable<Section> GetAllSections()
        {
            return this.All();
        }

        public Section GetSectionByName(string name)
        {
            return this.All().Where(x => x.Name == name).FirstOrDefault();
        }
    }
}
