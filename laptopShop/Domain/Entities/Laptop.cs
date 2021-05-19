﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Laptop : BaseEntity
    {
        [Required]
        [Display(Name = "Procesor")]
        public Guid ProcessorId { get; set; }

        [Required]
        [Display(Name = "Grafika")]
        public Guid GraphicsCardId { get; set; }

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

        [Required]
        [Display(Name = "Cena")]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [ForeignKey("ProcessorId")]
        [Display(Name = "Procesor")]
        public virtual Processor Processor { get; set; }
        [ForeignKey("GraphicsCardId")]
        [Display(Name = "Grafika")]
        public virtual GraphicsCard GraphicsCard { get; set; }

        public virtual ICollection<Suborder> Suborders { get; set; }

        // Marcin a czy tu nie powinno być virtual???????????
        public ICollection<LaptopRamRelationship> Rams { get; set; }

        public Laptop(Guid processorId, Guid graphicsCardId, string model, string description, int quantity, decimal price, Processor processor, GraphicsCard graphicsCard, ICollection<Suborder> suborders, ICollection<LaptopRamRelationship> rams)
        {
            Created

            ProcessorId = processorId;
            GraphicsCardId = graphicsCardId;
            Model = model;
            Description = description;
            Quantity = quantity;
            Price = price;
           
            Rams = rams;    
        }
    }
}

// Tu będzie problem z ramem






/* 
 *  Błąd do decimala
 * Microsoft.EntityFrameworkCore.Model.Validation[30000]
      No type was specified for the decimal property 'Price' on entity type 'Laptop'. This will cause values to be silently truncated if they do not fit in the default precision and scale. Explicitly specify the SQL server column type that can accommodate all the values in 'OnModelCreating' using 'HasColumnType()', specify precision and scale using 'HasPrecision()' or configure a value converter using 'HasConversion()'.
Your target project 'WebAPI' doesn't match your migrations assembly 'Infrastructure'. Either change your target project or change your migrations assembly.
Change your migrations assembly by using DbContextOptionsBuilder. E.g. options.UseSqlServer(connection, b => b.MigrationsAssembly("WebAPI")). By default, the migrations assembly is the assembly containing the DbContext.
Change your target project to the migrations project by using the Package Manager Console's Default project drop-down list, or by executing "dotnet ef" from the directory containing the migrations project.
 * 
 */