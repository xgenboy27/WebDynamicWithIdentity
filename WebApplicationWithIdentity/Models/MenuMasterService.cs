using WebApplicationWithIdentity.Data;

namespace WebApplicationWithIdentity.Models
{
    public class MenuMasterService : IMenuMasterService
    {
        private readonly ApplicationDbContext _dbContext;

        public MenuMasterService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<MenuMaster> GetMenuMaster()
        {
            return _dbContext.MenuMaster.AsEnumerable();
        }

        public IEnumerable<MenuMaster> GetMenuMaster(string UserRole)
        {
            var result = _dbContext.MenuMaster.Where(m => m.User_Roll == UserRole).ToList();
            return result;
        }
    }
}
