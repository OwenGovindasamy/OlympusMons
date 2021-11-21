using OlympusMons.Models;

namespace OlympusMons.Logic
{
    public class DbModule
    {
        private readonly ApplicationDbContext _context;
        public DbModule(ApplicationDbContext context)
        {
            _context = context;
        }
        public void insertTest(Test test)
        {
            if(test == null) throw new ArgumentNullException(nameof(test));

            _context.Test?.Add(test);
           _context.SaveChanges();

        }
    }
}
