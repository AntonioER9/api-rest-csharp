using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
  public class Beer
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Primary Key
    public int BeerID { get; set; }
    public string Name { get; set; }

    public int BrandID { get; set; }
    [ForeignKey("BrandID")]
    public virtual Brand Brand { get; set;}
  }
}