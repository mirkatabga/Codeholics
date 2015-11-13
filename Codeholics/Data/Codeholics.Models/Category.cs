namespace Codeholics.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    using Common.Constants;

    public class Category
    {
        private ICollection<Project> projects;

        public Category()
        {
            this.Deleted = false;
            this.projects = new HashSet<Project>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(Validations.MaxNameLenght)]
        public string Name { get; set; }

        [Required]
        public bool Deleted { get; set; }

        public virtual ICollection<Project> Projects
        {
            get { return this.projects; }
            set { this.projects = value; }
        }
    }
}