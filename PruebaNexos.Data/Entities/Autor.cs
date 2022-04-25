using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNexos.Data.Entities
{
    public class Autor
    {
        [Key]
        public int IDAUTOR { get; set; }
        public string NOMBRE { get; set; }
        public string FECHANACI { get; set; }
        public string CIUDAD { get; set; }
        public string CORREO { get; set; }
    }
}
