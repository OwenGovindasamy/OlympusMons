using AutoMapper;
using OlympusMons.Interfaces;
using OlympusMons.Models;
using OlympusMons.ViewModels;

namespace OlympusMons.Logic
{
    //TODO: cleanup
    public class DbModule : IDbModule
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public DbModule(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
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

        //public bool EditTest(int id)
        //{
        //    var DbRecord = _context.Test?.Find(id);

        //    if (DbRecord == null) return false;

        //    var model = _mapper.Map<TestVM>(DbRecord);

        //    return 
        //}
    }
}
