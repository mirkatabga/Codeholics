namespace Codeholics.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Common.Constants;

    public class Message
    {
        public Message()
        {
            this.Deleted = false;
            this.Seen = false;
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(Validations.MaxMessageLenght)]
        public string Content { get; set; }

        // Foreign key for User
        public string SenderId { get; set; }

        [Required]
        public string RecieverId { get; set; }

        public bool Seen { get; set; }

        [Required]
        public bool Deleted { get; set; }

        [ForeignKey("SenderId")]
        public virtual User User { get; set; }
    }
}
