using System.IO;
using System.Threading.Tasks;

namespace Ivvy.Subscriptions.Handler
{
    public interface IMessageDecoder
    {
        Task<(IHandleResult, Message)> DecodeMessageAsync(Stream messageStream);
    }
}
