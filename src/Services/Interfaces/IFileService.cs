using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ProjetoNibo.Services.Interfaces
{
    public interface IFileService
    {
        Task Upload(IFormFileCollection files);
    }
}
