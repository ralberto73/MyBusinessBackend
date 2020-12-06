namespace MyBusiness.DataAccess
{
    public interface IDataRepository
    {
         BrandRepository Brand { get; }
         InsuranceRepository Insurances { get; }
        SupplierRepository   Suppliers { get; }
        ProductsRepository   Products { get; }
       // WorkOrderRepository WorkOrders { get; }
        ServiceOrderRepository ServiceOrders { get; }

        ServiceOrderStatusRepository ServiceOrdersStatus { get; }


    }
}