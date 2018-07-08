using System;

namespace A4Auth.Api.Data.Interfaces
{
    public interface IAuthUnitOfWork: IDisposable
    {
        IUserRepository Users { get; set; }
        int Complete();
    }
}
