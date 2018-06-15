using System;
using System.Collections.Generic;
using System.Text;

namespace M4Movie.Api.Data.Interfaces
{
    public interface IAuthUnitOfWork: IDisposable
    {
        IUserRepository Users { get; set; }
        int Complete();
    }
}
