using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.StreamDTO;
using api.Model;


namespace api.Mappers
{
    public static class StremMapper
    {
        public static Streams ToStreamListDTO(this Streams streamListDTO)
        {
            return new Streams
            {
                StreamId = streamListDTO.StreamId,
                StreamName = streamListDTO.StreamName,
                Description = streamListDTO.Description,
               Subjects = streamListDTO.Subjects.Select(x => x.ToSubjectListDTO()).ToList();
            };
        }

        public static Streams ToCreateStreamDTO(this CreateStreamDTO streamDTO)
        {
            return new Streams
            {
                StreamName = streamDTO.StreamName,
                Description = streamDTO.Description,
            };
        }

        public static Streams ToUpdateStreamDTO(this UpdateStreamDTO streamDTO)
        {
            return new Streams
            {
                StreamName = streamDTO.StreamName,
                Description = streamDTO.Description,
            };
        }
    }
}