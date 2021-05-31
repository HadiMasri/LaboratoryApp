

namespace Laboratory.DAL.Entities
{
    public class TestRange
    {
        public int Id { get; set; }
        public int FromAge { get; set; }
        public int ToAge { get; set; }
        public int Range { get; set; }
        public int LowFrom { get; set; }
        public int HighFrom { get; set; }
        public int TestId { get; set; }
        public Test Test { get; set; }
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
    }
}
