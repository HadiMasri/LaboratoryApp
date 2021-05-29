using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratory.DAL.Entities
{
    public class Patient_Test
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int TestId { get; set; }
        public Test Test { get; set; }
    }
}
