namespace Laboratory.Domain.DTO
{
    public class Patient_TestDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public PatientDto Patient { get; set; }
        public int TestId { get; set; }
        public TestDto Test { get; set; }
        public string Result { get; set; }
    }
}
