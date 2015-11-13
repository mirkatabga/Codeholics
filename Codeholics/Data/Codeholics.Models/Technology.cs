namespace Codeholics.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Technology
    {
        private ICollection<User> users;
        private ICollection<Project> projects;

        public Technology()
        {     
            this.Deleted = false;
            this.users = new HashSet<User>();
            this.projects = new HashSet<Project>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public bool Deleted { get; set; }

        public virtual ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }

        public virtual ICollection<Project> Projects
        {
            get { return this.projects; }
            set { this.projects = value; }
        }
    }
}
