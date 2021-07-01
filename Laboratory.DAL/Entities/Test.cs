

namespace Laboratory.DAL.Entities
{
    public class Test
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string AppearName { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Note { get; set; }
    }
}
