namespace Laboratory.Domain.DTO
{
    public class TestRangeDto
    {
        public int Id { get; set; }
        public int FromAge { get; set; }
        public int ToAge { get; set; }
        public int Range { get; set; }
        public int LowFrom { get; set; }
        public int HighFrom { get; set; }
        public int TestId { get; set; }
        public TestDto Test { get; set; }
        public int SexId { get; set; }
        public SexDto Sex { get; set; }
    }
}
