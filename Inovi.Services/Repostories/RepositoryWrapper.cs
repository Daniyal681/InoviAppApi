using Inovi.DataAccessLayer.Models;
using Inovi.DataTransferObject;
using Inovi.DataTransferObject.Interfaces;


namespace Inovi.Services.Repostories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private QueryPro _context;
        private IUserRepo _userRepo;
        public RepositoryWrapper(QueryPro context)
        {
            _context = context;
        }

        public IUserRepo UserRepo
        { 
        get {
                if (_userRepo != null)
                {
                    _userRepo = new UserRepo(_context);
                } 
                return _userRepo;
            }
        }
    }
}
