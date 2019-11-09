using System;
using System.Collections.Generic;
using System.Text;

namespace LocalizaAmigos.Domain.Interfaces
{
    public interface IRepositorioBase<TEntiti> where TEntiti : class
    {
        List<TEntiti> Listar();
    }
}
