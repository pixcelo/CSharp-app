using DDD.Domain.Entities;
using System.Collections.Generic;

namespace DDD.Domain.Repositoriers
{
    public interface IAreasRepository
    {
        IReadOnlyList<AreaEntity> GetData();
    }
}
