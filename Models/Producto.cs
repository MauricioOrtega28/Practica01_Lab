using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practica01_Lab.Models
{
    [Table("t_producto")]
    public class Producto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("name")]
        public string name { get; set; }

        [Column("categoria")]
        public string categoria { get; set; }

        [Column("precio")]
        public string precio { get; set; }
        
        [Column("descuento")]
        public string descuento { get; set; }
    }
}