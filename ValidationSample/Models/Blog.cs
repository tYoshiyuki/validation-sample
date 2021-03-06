﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ValidationSample.Attributes;

namespace ValidationSample.Models
{
    public class Blog
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [AlphaNumeric]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        public string Author { get; set; }
    }
}
