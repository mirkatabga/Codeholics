namespace Codeholics.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Friendship
    {
        public Friendship()
        {
            this.Date = DateTime.Now;
            this.Approved = false;
        }

        public int Id { get; set; }

        //Foreign key for User
        public string FirstUserId { get; set; }

        [Required]
        public string SecondUserId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public bool Approved { get; set; }

        [ForeignKey("FirstUserId")]
        public virtual User User { get; set; }
    }
}
