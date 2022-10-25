﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities; 

[Table("INVENTORIES")]
public class Inventory {
    
    [Column("ID")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("NAME")]
    [Required]
    public string Name { get; set; }
    
    [Column("CREATED_AT")] 
    public DateTime CreatedAt { get; set; }
    
    [Column("LAST_EDIT")] 
    public DateTime LastEdit { get; set; }
}