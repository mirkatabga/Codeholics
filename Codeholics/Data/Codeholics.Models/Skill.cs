namespace Codeholics.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common.Constants;

    public class Skill
    {
        private ICollection<User> users;

        public Skill()
        {
            this.Deleted = false;
            this.users = new HashSet<User>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(Validations.MaxSkillLenght)]
        public string Name { get; set; }

        [Required]
        public bool Deleted { get; set; }

        public virtual ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }
    }
}
