using System.ComponentModel.DataAnnotations;

namespace DashboardDoorfl.Models
{
    public class MessagesModel
    {
        [Key]
        public int IncomingMessageID { get; set; }
        public string RegNum { get; set; }
        public DateTime RegDate { get; set; }
        public string Sender { get; set; }
        public string Reciever { get; set; }
        public string Status { get; set; }
        public string FinalExecutor { get; set; }
        public string Comment { get; set; }
        public string Deal { get; set; }
        public string ResolutionAuthor { get; set; }
        public string DocumentIsProcessedBy { get; set; }
        public string DocumentState { get; set; }
        public string OutgoingOrganiztaion { get; set; }
        public string Theme { get; set; }
        public string IncomingType { get; set; }
        public string IsAnswerNeeded { get; set; }
        public string Deadline { get; set; }
        public string IsUnderControl { get; set; }
        public string MainExecutor { get; set; }
        public string ResolutionText { get; set; }
        public string Title { get; set; }
        public string LotusID { get; set; }
    }
}
