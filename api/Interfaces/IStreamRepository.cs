using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Model;

namespace api.Interfaces
{
    public interface IStreamRepository
    {
        Task<List<Streams>> GetAllStreamsAsync();
        Task<Streams> GetStreamByIdAsync(int id);
        Task<Streams> CreateStreamAsync(Streams stream);
        Task<Streams> UpdateStreamAsync(int id, Streams stream);
        Task<Streams> DeleteStreamAsync(int id);
    }
}