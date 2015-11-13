using Codeholics.Common.Constants;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Codeholics.Models
{
    public class User : IdentityUser
    {
        private ICollection<Friendship> friendships;
        private ICollection<Skill> skills;
        private ICollection<Technology> technologies;
        private ICollection<Project> projects;
        private ICollection<Message> messages;
        private ICollection<Notification> notifications;

        public User()
        {
            this.Language = LanguageStatus.English;
            this.Deleted = false;
            this.friendships = new HashSet<Friendship>();
            this.skills = new HashSet<Skill>();
            this.technologies = new HashSet<Technology>();
            this.projects = new HashSet<Project>();
            this.messages = new HashSet<Message>();
            this.notifications = new HashSet<Notification>();
        }
        ///// We can add other fields here
        [Required]
        [MaxLength(Validations.MaxNameLenght)]
        public string FirstName { get; set; }

        [MaxLength(Validations.MaxNameLenght)]
        public string LastName { get; set; }

        [Range(0, Validations.MaxAge)]
        public int Age { get; set; }

        public LanguageStatus Language { get; set; }

        [Required]
        public bool Deleted { get; set; }

        public virtual ICollection<Friendship> Friendships
        {
            get { return this.friendships; }
            set { this.friendships = value; }
        }

        public virtual ICollection<Skill> Skills
        {
            get { return this.skills; }
            set { this.skills = value; }
        }

        public virtual ICollection<Technology> Technologies
        {
            get { return this.technologies; }
            set { this.technologies = value; }
        }

        public virtual ICollection<Project> Projects
        {
            get { return this.projects; }
            set { this.projects = value; }
        }

        public virtual ICollection<Message> Messages
        {
            get { return this.messages; }
            set { this.messages = value; }
        }

        public virtual ICollection<Notification> Notifications
        {
            get { return this.notifications; }
            set { this.notifications = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
