using PruebaNexos.Data.DTOs;
using PruebaNexos.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNexos.Core.Interfaces
{
    public interface IAutor
    {
        Task<List<AutorDTO>> ListAll();
        Task<List<AutorDTO>> CreateAutor(Autor autor);
        //Task<List<AutorDTO>> SearchAutor(string nombre);

        //Task<List<AutorDTO>> UpdateAutor(int id, Autor autor);
    }
}
