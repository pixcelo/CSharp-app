﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp.Classes.Models
{
    public class UserDataModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string? Id { get; set; }

        [Required]
        [MinLength(3)]
        public string? Name { get; set; }
    }
}
