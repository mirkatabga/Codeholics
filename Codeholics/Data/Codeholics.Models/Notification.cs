namespace Codeholics.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Notification
    {
        private ICollection<User> users;

        public Notification()
        {
            this.Deleted = false;
            this.Date = DateTime.Now;
            this.Seen = false;
            this.users = new HashSet<User>();
        }

        public int Id { get; set; }

        [Required]
        public NotificationType NotificationType { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public bool Seen { get; set; }

        [Required]
        public bool Deleted { get; set; }

        public virtual ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }
    }
}
