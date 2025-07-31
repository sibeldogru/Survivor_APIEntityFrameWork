using Microsoft.EntityFrameworkCore;

namespace Survivor.Models
{
    public class Category : Base
    {
        public string Name { get; set; }

        public List<Competitor> Competitors { get; set; }
    }
}
