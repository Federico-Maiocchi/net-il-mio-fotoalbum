using System.ComponentModel.DataAnnotations;

namespace net_il_mio_fotoalbum.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Text { get; set; }

        public Message() { }

        public Message(string mail, string text)
        {
            Email = mail;
            Text = text;
        }

    }
}
