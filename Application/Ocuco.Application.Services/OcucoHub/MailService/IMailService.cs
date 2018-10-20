namespace Ocuco.Application.Services.OcucoHub.MailService
{
    public interface IMailService
    {
        void SendMessage(string to, string subject, string body);
    }
}