using AutoMapper;
using books.core.Domain;
using books.infrastructure.DTO;

namespace books.infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<Book, BookDTO>();
            })
            .CreateMapper();
    }
}