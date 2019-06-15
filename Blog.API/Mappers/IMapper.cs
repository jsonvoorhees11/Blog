using System;

namespace Blog.Mappers{
    public interface IMapper<EntityType, DtoType> where EntityType:class
    {
        DtoType MapEntityToDto(EntityType entity);
        EntityType MapDtoToEntity(DtoType dto);
    }
}
