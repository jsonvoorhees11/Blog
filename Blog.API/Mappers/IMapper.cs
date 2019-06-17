using System;
using System.Collections.Generic;

namespace Blog.Mappers{
    public interface IMapper<EntityType, DtoType> where EntityType:class
    {
        DtoType MapEntityToDto(EntityType entity);
        EntityType MapDtoToEntity(DtoType dto);
        IEnumerable<DtoType> MapEntityToDto(IEnumerable<EntityType> entities);
        IEnumerable<EntityType> MapDtoToEntity(IEnumerable<DtoType> entities);
    }
}
