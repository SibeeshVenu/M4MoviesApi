using System;
using System.Collections.Generic;
using System.Text;

namespace M4Movie.Api.Data.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IMovieRepository Movies { get; set; }
        int Complete();
    }
}
