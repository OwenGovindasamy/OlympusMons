using OlympusMons.Interfaces;
using OlympusMons.Models;

namespace OlympusMons.Logic
{
    public class DbModule : IDbModule
    {
        private readonly ApplicationDbContext _context;
        public DbModule(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool insertTest(Test test)
        {
            if (test == null) throw new ArgumentNullException(nameof(test));

            try
            {
                _context.Test?.Add(test);

                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                //TODO:log errors
                return false;
            }
        }
    }
}
