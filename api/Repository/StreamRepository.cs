using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StreamRepository : IStreamRepository
    {
        private readonly ApplicationDbContext _context;

        public StreamRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Streams> CreateStreamAsync(Streams stream)
        {
            await _context.AddAsync(stream);
            await _context.SaveChangesAsync();
            return stream;
        }

        public async Task<Streams> DeleteStreamAsync(int id)
        {
            var stream = await _context.Streams.FirstOrDefaultAsync(s => s.StreamId == id);
            if (stream == null)
            {
                return null;
            }
            _context.Streams.Remove(stream);
            await _context.SaveChangesAsync();
            return stream;
        }

        public async Task<List<Streams>> GetAllStreamsAsync()
        {
            var streams = await _context.Streams.Include(x => x.Subjects).ToListAsync();
            return streams;
        }

        public async Task<Streams> GetStreamByIdAsync(int id)
        {
            var stream = await _context.Streams.Include(x => x.Subjects).FirstOrDefaultAsync(s => s.StreamId == id);
            if(stream == null)
            {
                return null;
            }
            return stream;
        }

        public async Task<Streams> UpdateStreamAsync(int id, Streams stream)
        {
            var existingStream = await _context.Streams.FirstOrDefaultAsync(s => s.StreamId == id);
            if (existingStream == null)
            {
                return null;
            }
            existingStream.StreamName = stream.StreamName;
            existingStream.Description = stream.Description;
            existingStream.Subjects = stream.Subjects;
            await _context.SaveChangesAsync();
            return existingStream;
        }
    }
}