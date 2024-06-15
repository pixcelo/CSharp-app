namespace DDD.Domain.Entities
{
    public sealed class AreaEntity
    {
        public AreaEntity(int areaId, string areaName)
        {
            this.AreaId = areaId;
            this.AreaName = areaName;
        }

        public int AreaId { get; }
        public string AreaName { get; }
    }
}
