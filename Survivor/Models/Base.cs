using Microsoft.EntityFrameworkCore; 
namespace Survivor.Models;

public class Base
{
    public Base()
    {
        CreatedDate = DateTime.Now; 
        ModifiedDate = DateTime.Now;
    }
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }

    public DateTime ModifiedDate { get; set; }

    public bool IsDeleted { get; set; }
}
