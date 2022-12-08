
using System.Threading.Tasks;

namespace Rehoboth.Service
{
	public interface IMailService
	{
		Task SendEmailAsync(MailRequest mailRequest, string body);
	}
}