using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratory.DAL.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public int TitleId { get; set; }
        public Title Title { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public int Age { get; set; }
        public TimeSpan ArriveTime { get; set; }
        public string DoctorName { get; set; }
        public int RoomNr { get; set; }
        public int PhoneNr { get; set; }
        public string Diagnosis { get; set; }
        public int SexId { get; set; }
        public Sex Sex { get; set; }
    }
}
