namespace ChatApp.Domain.Entities
{
    public class Message
    {
        public int Id { get; set; }

        public int? ParentMessageId { get; set; }

        public string Text { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
