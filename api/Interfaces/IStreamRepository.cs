using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Interfaces
{
    public interface IStreamRepository
    {
       Task<List<Stream>> GetAllStreams();
       Task<Stream> GetStreamById(int id);
        Task<Stream> CreateStream(Stream stream);
        Task<Stream> UpdateStream(int id, Stream stream);
        Task<Stream> DeleteStream(int id);
    }
}