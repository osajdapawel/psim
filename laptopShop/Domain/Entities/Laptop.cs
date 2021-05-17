using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Laptop : BaseEntity<Guid>
    {
        [Key]
        public int Id { get; set; }
        /*  [Required]
          [Display(Name = "Procesor")]
          public int ProcessorId { get; set; }*/

        /* [Required]
         [Display(Name = "Grafika")]
         public int GraphicsCardId { get; set; }
 */
        [Required]
        [MaxLength(50)]
        public string Model { get; set; }

        [Required]
        [MaxLength(500)]
        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Ilość")]
        public int Quantity { get; set; }

/*        [Required]
        [Display(Name = "Cena")]
        public decimal Price { get; set; }*/

        /*[ForeignKey("ProcessorId")]
        [Display(Name = "Procesor")]
        public virtual Processor Processor { get; set; }
        [ForeignKey("GraphicsCardId")]
        [Display(Name = "Grafika")]
        public virtual GraphicsCard GraphicsCard { get; set; }

        public virtual ICollection<Suborder> Suborders { get; set; }*/

        public ICollection<LaptopRamRelationship> Rams { get; set; }


    }
}

/* 
 *  Błąd do decimala
 * Microsoft.EntityFrameworkCore.Model.Validation[30000]
      No type was specified for the decimal property 'Price' on entity type 'Laptop'. This will cause values to be silently truncated if they do not fit in the default precision and scale. Explicitly specify the SQL server column type that can accommodate all the values in 'OnModelCreating' using 'HasColumnType()', specify precision and scale using 'HasPrecision()' or configure a value converter using 'HasConversion()'.
Your target project 'WebAPI' doesn't match your migrations assembly 'Infrastructure'. Either change your target project or change your migrations assembly.
Change your migrations assembly by using DbContextOptionsBuilder. E.g. options.UseSqlServer(connection, b => b.MigrationsAssembly("WebAPI")). By default, the migrations assembly is the assembly containing the DbContext.
Change your target project to the migrations project by using the Package Manager Console's Default project drop-down list, or by executing "dotnet ef" from the directory containing the migrations project.
 * 
 */