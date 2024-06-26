﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace RecipesAPI.Models
{
    public class Recipe
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public long? Id { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }

        public string Name { get; set; }

        public string? ImageURL { get; set; }

        [Required]
        public DateTime? CreatedAt { get; set; }

        [Required]
        public DateTime? UpdatedAt { get; set; }

        public long? UserId { get; set; }
        public User? User { get; set; } 

        public ICollection<Ingredient> Ingredients { get; set; }
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }

        public string? Description { get; set; }

        public long? PreparationTimeInSeconds { get; set; }

        public long? CookingTimeInSeconds { get; set; }

        public long? Servings { get; set; }

        public long? EnergyInKCal { get; set; }

        public ComplexityLevel? Level { get; set; }

        public ICollection<Step> Steps { get; set; }

    }
}
