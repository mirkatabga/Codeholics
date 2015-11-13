namespace Codeholics.Api.Models.Project
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Common.Constants;

    public class ProjectRequestModel
    {
        [Required]
        [MinLength(Validations.MinTitleLenght)]
        [MaxLength(Validations.MaxTitleLenght)]
        public string Title { get; set; }

        [Required]
        [MinLength(Validations.MinDescrioptionLenght)]
        [MaxLength(Validations.MaxDescrioptionLenght)]
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? Deadline { get; set; }

        [Required]
        public string Creator { get; set; }
    }
}
