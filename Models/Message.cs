using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CVProjekt1._0.Models;

namespace CVProjekt1._0.Models
{
    public class Message
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageId { get; set; }
        public string? SenderId { get; set; } //Främmande nyckel
        public string ReceiverId { get; set; } //Främmande nyckel
        [Required]
        public string MessageText { get; set; }
        public bool IsRead { get; set; }
        public DateTime DateSent { get; set; }

        [ForeignKey(nameof(SenderId))]
        public virtual User? Sender { get; set; }

        [ForeignKey(nameof(ReceiverId))]
        public virtual User Receiver { get; set; }
    }
}