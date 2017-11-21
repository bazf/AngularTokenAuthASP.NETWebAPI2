namespace BLL.Mapping
{
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Core.DTOs.UserDTOs;
    using DAL.Entities;
    using Core.DTOs.UserNoteDTOs;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class Mapper : IMapper
    {
        private MapperConfiguration configurations;

        private AutoMapper.IMapper mapper;

        public Mapper()
        {
            configurations = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserEntity, UserDTO>();
                cfg.CreateMap<Task<List<UserEntity>>, Task<List<UserDTO>>>();

                cfg.CreateMap<UserNoteEntity, UserNoteDTO>().ReverseMap();
                cfg.CreateMap<NewUserNoteDTO, UserNoteEntity>();
            });

            mapper = configurations.CreateMapper();
        }

        public IQueryable<TDest> Map<TSource, TDest>(IQueryable<TSource> query)
        {
            return query.ProjectTo<TDest>(configurations);
        }

        public TDest Map<TSource, TDest>(TSource source)
        {
            return mapper.Map<TSource, TDest>(source);
        }

        public TDest Map<TSource, TDest>(TSource source, TDest dest)
        {
            return mapper.Map(source, dest);
        }
    }
}
