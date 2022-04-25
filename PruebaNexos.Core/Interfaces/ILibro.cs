using PruebaNexos.Data.DTOs;
using PruebaNexos.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNexos.Core.Interfaces
{
    public interface ILibro
    {
        Task<List<LibroDTO>> ListAllLibros();
        Task<List<LibroDTO>> CreateLibro(Libro libro);
    }
}
