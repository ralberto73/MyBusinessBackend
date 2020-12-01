namespace MyBusiness.DataAccess
{
    public interface IDataRepository
    {
        ProductsRepository Products { get; }
        WorkOrderRepository WorkOrders { get; }

        BrandRepository Brand { get; }
    }
}