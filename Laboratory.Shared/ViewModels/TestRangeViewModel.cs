namespace Laboratory.Shared.ViewModels
{
    public class TestRangeViewModel
    {
        public int Id { get; set; }
        public int FromAge { get; set; }
        public int ToAge { get; set; }
        public int LowFrom { get; set; }
        public int HighFrom { get; set; }
        public int TestId { get; set; }
        public TestViewModel Test { get; set; }
        public int GenderId { get; set; }
        public GenderViewModel Gender { get; set; }
    }
}
