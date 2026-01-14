namespace _365EJSC.ERP.Infrastructure.DTOs.Email
{
    public class EmailRequest
    {
        public string ToEmail { get; set; }
        public string ToName { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
    }
}
