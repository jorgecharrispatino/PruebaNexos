using PruebaNexos.Core.Interfaces;
using PruebaNexos.Data.Context;
using PruebaNexos.Data.DTOs;
using PruebaNexos.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNexos.Core.Services
{
    public class SAutor : IAutor
    {
        private readonly AppDbContext _context;
        public SAutor(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<AutorDTO>> ListAll()
        {
            try
            {
                List<AutorDTO> list = new List<AutorDTO>();
                var result = _context.AUTOR.ToList();
                foreach (var item in result)
                {
                    list.Add(new AutorDTO
                    {
                        IDAUTOR = item.IDAUTOR,
                        NOMBRE = item.NOMBRE,
                        FECHANACI = item.FECHANACI,
                        CIUDAD = item.CIUDAD,
                        CORREO = item.CORREO,
                    });
                }

                return list;

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<List<AutorDTO>> CreateAutor(Autor autor)
        {
            try
            {
                List<AutorDTO> list = new List<AutorDTO>();
                int idmax = 0;
                var datatable = _context.AUTOR.ToList();
                if (datatable.Count == 0)
                {
                    idmax = 1;
                }
                else
                {
                    idmax = (from AUTOR in _context.AUTOR
                             select AUTOR.IDAUTOR).Max();
                }
                autor.IDAUTOR = idmax + 1;
                _context.AUTOR.Add(autor);
                await _context.SaveChangesAsync();

                list.Add(new AutorDTO
                {
                    IDAUTOR = autor.IDAUTOR,
                    NOMBRE = autor.NOMBRE,
                    FECHANACI = autor.FECHANACI,
                    CIUDAD = autor.CIUDAD,
                    CORREO = autor.CORREO,
                });
                return list;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        //public async Task<List<AutorDTO>> SearchAutor(string nombre)
        //{
        //    try
        //    {
        //        List<AutorDTO> list = new List<AutorDTO>();
        //        var result = _context.AUTOR.Where(a => a.NOMBRE == nombre).FirstOrDefault();

        //            list.Add(new AutorDTO
        //            {
        //                IDAUTOR = result.IDAUTOR,
        //                NOMBRE = result.NOMBRE,
        //                FECHANACI = result.FECHANACI,
        //                CIUDAD = result.CIUDAD,
        //                CORREO = result.CORREO,
        //            });

        //        return list;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ArgumentException(ex.Message);
        //    }
        //}



        //public async Task<List<AutorDTO>> UpdateAutor(int id, Autor autor)
        //{
        //    try
        //    {
        //        List<AutorDTO> list = new List<AutorDTO>();
        //        var employee = _context.AUTOR.FirstOrDefault(s => s.IDAUTOR == id);
        //        if (employee != null)
        //        {
        //            _context.SaveChanges();
        //        }
        //        return list;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ArgumentException(ex.Message);
        //    }
        //}
    }
}
