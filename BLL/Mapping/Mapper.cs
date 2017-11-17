namespace BLL.Mapping
{
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Core.DTOs.UserDTOs;
    using DAL.Entities;

    public class Mapper : IMapper
    {
        private MapperConfiguration configurations;

        private AutoMapper.IMapper mapper;

        public Mapper()
        {
            configurations = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserEntity, UserDTO>().ReverseMap();
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

        public void Map<TSource, TDest>(TSource source, TDest dest)
        {
            mapper.Map(source, dest);
        }
    }
}
