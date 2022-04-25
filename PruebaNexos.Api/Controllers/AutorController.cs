using Microsoft.AspNetCore.Mvc;
using PruebaNexos.Core.Interfaces;
using PruebaNexos.Data.Context;
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
    public class AutorController : ControllerBase
    {
        //private readonly AppDbContext _context;
        private readonly IAutor _autor;
        public AutorController(/*AppDbContext context,*/ IAutor autor)
        {
            //_context = context;
            _autor = autor;
        }

        // GET: api/<AutorController>
        [HttpGet("ListadoAutor")]
        public async Task<ActionResult<List<AutorDTO>>> Get()
        {
            try
            {
                List<AutorDTO> result = await _autor.ListAll();
                return result;
            }
            catch (Exception ex)
            {
                return Unauthorized(new CodeErrorResponse(500, ex.Message));
            }
        }

        // GET api/<AutorController>/5
        //[HttpGet("{nombre}", Name = "BuscarAutor")]
        //public async Task<ActionResult<List<AutorDTO>>> GetAsync(string nombre)
        //{
        //    try
        //    {
        //        List<AutorDTO> result = await _autor.SearchAutor(nombre);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        // POST api/<AutorController>
        [HttpPost("GuardarAutor")]
        public async Task<ActionResult> GuardarAutor([FromBody] object data)
        {
            Autor autor = new Autor();
            string prueba = data.ToString();
            prueba = prueba.Replace("\"","");
            prueba = prueba.Replace("{data1:{","");
            prueba = prueba.Replace("}}", "");
            var list = prueba.Split(',');
            int index = 0;
            List<string> lista = new List<string>();
            foreach (var item in list)
            {
               index = item.IndexOf(':');
               prueba = item.Substring(0, index+1);
               string algo = item.Replace(prueba, "");
                lista.Add(algo);
            }
            autor.NOMBRE = lista[1];
            autor.FECHANACI = lista[2];
            autor.CIUDAD = lista[3];
            autor.CORREO = lista[4];
            try
            {
                    List<AutorDTO> result = await _autor.CreateAutor(autor);
                    return Ok("success");            
            }
            catch (Exception ex)
            {
                return Unauthorized(new CodeErrorResponse(500, ex.Message));
            }
        }

        // PUT api/<AutorController>/5
        //[HttpPost("UpdateAutor")]
        //public async Task<ActionResult<List<AutorDTO>>> UpdateAutor(int Id, Autor autor)
        //{
        //    List<AutorDTO> result =  await _autor.UpdateAutor(Id, autor);
        //    return result;
        //}

        // DELETE api/<AutorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
