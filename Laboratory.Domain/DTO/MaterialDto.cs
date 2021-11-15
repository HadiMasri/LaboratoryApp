using System;

namespace Laboratory.Domain.DTO
{
    public class MaterialDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Volume { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
