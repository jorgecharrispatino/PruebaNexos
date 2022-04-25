using Microsoft.AspNetCore.Mvc;
using PruebaNexos.Core.Interfaces;
using PruebaNexos.Data.DTOs;
using PruebaNexos.Data.Entities;
using PruebaNexos.Data.Exeption;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaNexos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibro _libro;
        public LibroController(/*AppDbContext context,*/ ILibro libro)
        {
            //_context = context;
            _libro = libro;
        }
        // GET: api/<LibroController>
        [HttpGet("ListadoLibro")]
        public async Task<ActionResult<List<LibroDTO>>> Get()
        {
            try
            {
                List<LibroDTO> result = await _libro.ListAllLibros();
                return result;
            }
            catch (Exception ex)
            {
                return Unauthorized(new CodeErrorResponse(500, ex.Message));
            }
        }

        // GET api/<LibroController>/5
        [HttpPost("GuardarLibro")]
        public async Task<List<LibroDTO>> GuardarAutor([FromBody] object data)
        {
            Libro libro = new Libro();
            string prueba = data.ToString();
            prueba = prueba.Replace("\"", "");
            prueba = prueba.Replace("{data1:{", "");
            prueba = prueba.Replace("}}", "");
            var list = prueba.Split(',');
            int index = 0;
            List<string> lista = new List<string>();
            foreach (var item in list)
            {
                index = item.IndexOf(':');
                prueba = item.Substring(0, index + 1);
                string algo = item.Replace(prueba, "");
                lista.Add(algo);
            }

            libro.TITULO = lista[1];
            libro.ANO = Int32.Parse(lista[2]);
            libro.GENERO = lista[3];
            libro.NUMPAG = Int32.Parse(lista[4]);
            libro.AUTOR = lista[5];
            try
            {
                List<LibroDTO> result = await _libro.CreateLibro(libro);
                if(result.Count == 0)
                {
                    return null;
                }
                else
                {
                    return result;
                }
                
                //return Ok("success");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.InnerException);
            }
        }

        // PUT api/<LibroController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LibroController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
