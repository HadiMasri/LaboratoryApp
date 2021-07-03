namespace Laboratory.Domain.DTO
{
    public class TestDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Result { get; set; }
        public double Price { get; set; }
        public string AppearName { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }
        public string Note { get; set; }

    }
}
