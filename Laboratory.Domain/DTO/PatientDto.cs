﻿using System;


namespace Laboratory.Domain.DTO
{
    public class PatientDto
    {
        public int Id { get; set; }
        public int TitleId { get; set; }
        public TitleDto Title { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public int Age { get; set; }
        public string ArriveTime { get; set; }
        public string DoctorName { get; set; }
        public string RoomNr { get; set; }
        public string PhoneNr { get; set; }
        public string Diagnosis { get; set; }
        public int SexId { get; set; }
        public SexDto Sex { get; set; }
    }
}
