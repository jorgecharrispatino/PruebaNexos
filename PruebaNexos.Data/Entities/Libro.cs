using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNexos.Data.Entities
{
    public class Libro
    {
        [Key]
        public int IDLIBRO { get; set; }
        public string TITULO { get; set; }
        public int ANO { get; set; }
        public string GENERO { get; set; }
        public int NUMPAG { get; set; }
        public string AUTOR { get; set; }

    }
}
