using System;
using System.Collections.Generic;
using System.Text;

namespace LocalizaAmigos.Application.Interfaces
{
    public interface IAppServiceBase<TEntiti> where TEntiti : class
    {
        List<TEntiti> Listar();
    }
}
