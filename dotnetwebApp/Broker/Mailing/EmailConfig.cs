namespace Broker.Mailing
{
    public class EmailConfig
    {
        public string From { get; set; }
        //simple mail trasfer protocol
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
