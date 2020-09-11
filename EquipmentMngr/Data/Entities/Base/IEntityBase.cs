namespace EquipmentMngr.Data.Entities.Base
{
    public interface IEntityBase<out TId>
    {
        TId Id { get; }
    }
}