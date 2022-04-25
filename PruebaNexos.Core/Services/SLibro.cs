using PruebaNexos.Core.Interfaces;
using PruebaNexos.Data.Context;
using PruebaNexos.Data.DTOs;
using PruebaNexos.Data.Entities;
using PruebaNexos.Data.Exeption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNexos.Core.Services
{
    public class SLibro : ILibro
    {
        private readonly AppDbContext _context;
        public SLibro(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<LibroDTO>> ListAllLibros()
        {
            try
            {
                List<LibroDTO> list = new List<LibroDTO>();
                var result = _context.LIBRO.ToList();
                foreach (var item in result)
                {
                    list.Add(new LibroDTO
                    {
                        IDLIBRO = item.IDLIBRO,
                        TITULO = item.TITULO,
                        ANO = item.ANO,
                        GENERO = item.GENERO,
                        NUMPAG = item.NUMPAG,
                        AUTOR = item.AUTOR,
                    });
                }

                return list;

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<List<LibroDTO>> CreateLibro(Libro libro)
        {
            try
            {
                int idmax = 0;
                List<LibroDTO> list = new List<LibroDTO>();
                bool existe = false;
                List<string> consultNomLib = _context.AUTOR.Select(a=>a.NOMBRE).ToList();

                foreach (var item in consultNomLib)
                {
                    if (item == libro.AUTOR)
                    {
                        existe = true;
                    }
                    else
                    {
                        existe = false;
                    }
                }
                
                var datatable = _context.LIBRO.ToList();
                if (datatable.Count == 0)
                {
                    idmax = 1;
                }
                else
                {
                    idmax = (from LIBRO in _context.LIBRO
                             select LIBRO.IDLIBRO).Max();
                }
                if (idmax <= 10)
                {
                    if (existe)
                    {
                        libro.IDLIBRO = idmax + 1;
                        _context.LIBRO.Add(libro);
                        await _context.SaveChangesAsync();

                        list.Add(new LibroDTO
                        {
                            IDLIBRO = libro.IDLIBRO,
                            TITULO = libro.TITULO,
                            ANO = libro.ANO,
                            GENERO = libro.GENERO,
                            NUMPAG = libro.NUMPAG,
                            AUTOR = libro.AUTOR,
                        });
                    }                
                }
                else
                {
                    return (list);
                }
                
                return list;

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
