using System;

namespace Laboratory.Shared.ViewModels
{
    public class MaterialViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Volume { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime ExpireDate { get; set; }

    }
}
