namespace Survivor.Models
{
    public class Competitor : Base 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
