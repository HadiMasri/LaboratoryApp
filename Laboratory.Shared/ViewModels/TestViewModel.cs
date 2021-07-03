namespace Laboratory.Shared.ViewModels
{
    public class TestViewModel
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int PatientTestId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Range { get; set; }
        public string Result { get; set; }
        public string AppearName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public CategoryViewModel Category { get; set; }
        public string Note { get; set; }
    }
}
