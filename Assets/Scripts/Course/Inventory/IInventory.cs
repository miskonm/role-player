namespace Course.Inventory
{
    public interface IInventory
    {
        IInventoryStorage RawStorage { get; }
    }
}
