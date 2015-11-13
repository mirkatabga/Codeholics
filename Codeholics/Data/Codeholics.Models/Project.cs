namespace Codeholics.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common.Constants;

    public class Project
    {
        private ICollection<User> users;
        private ICollection<Technology> technologies;
        private ICollection<Category> categories;

        public Project()
        {
            this.StartDate = DateTime.Now;
            this.Deleted = false;
            this.users = new HashSet<User>();
            this.technologies = new HashSet<Technology>();
            this.categories = new HashSet<Category>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(Validations.MaxTitleLenght)]
        public string Title { get; set; }

        [Required]
        [MaxLength(Validations.MaxDescrioptionLenght)]
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? Deadline { get; set; }

        [Required]
        public string Creator { get; set; }

        [Required]
        public bool Deleted { get; set; }

        public virtual ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }

        public virtual ICollection<Technology> Technologies
        {
            get { return this.technologies; }
            set { this.technologies = value; }
        }

        public virtual ICollection<Category> Categories
        {
            get { return this.categories ; }
            set { this.categories = value; }
        }
    }
}
