using System.Linq;

namespace Forum.Data.Repositories
{
    public interface ISectionsRepository
    {
        IQueryable<Section> GetAllSections();

        Section GetSectionByName(string name);
    }
}