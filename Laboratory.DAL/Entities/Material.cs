using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratory.DAL.Entities
{
    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Volume { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
