using System;
using System.ComponentModel.DataAnnotations;

namespace TestApplication7.Models
{
        // RatingModel is model class needs to put model folder for M part of MVC.
        public class RatingModel
        {
            public decimal EstimatedCost { get; set; }
            [Range(1, 1000)]
            public int Length { get; set; }
            [Range(1, 1000)]
            public int Width { get; set; }
            [Range(1, 1000)]
            public int Height { get; set; }
            [Range(1, 1000)]
            public int Weight { get; set; }
            [Required]
            public string PostalCode { get; set; }

        }
    
}
