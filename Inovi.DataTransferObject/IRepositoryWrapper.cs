using Inovi.DataTransferObject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inovi.DataTransferObject
{
    public interface IRepositoryWrapper
    {
        public IUserRepo UserRepo { get; }

    }
}
