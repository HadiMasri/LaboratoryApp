namespace Laboratory.Shared.ViewModels
{
    public class Patient_TestViewModel
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public PatientViewModel Patient { get; set; }
        public int TestId { get; set; }
        public TestViewModel Test { get; set; }
        public string Result { get; set; }
    }
}
