using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaPrimeiraApi.Entity
{
    internal class AssentoEntity
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public int Aviao_Id { get; set; }
    }
}
