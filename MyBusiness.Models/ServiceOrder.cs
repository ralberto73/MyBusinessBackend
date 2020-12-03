using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusiness.Models
{
    public class ServiceOrder
    {
        public int  ServiceOrderId{ get; set; }
        public int ServiceOrderStatusId { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public int BrandId { get; set; }
        public string Model { get; set; }
        public string SubModel { get; set; }
        public int Year        { get; set; }
        public int ProductId { get; set; }
        public string PaymentMethod { get; set; }
        public int SupplierId { get; set; }
        public decimal BillableAmount { get; set; }
        public decimal LaborAmount { get; set; }
        public decimal PartCost { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }

    }
}
/*

 */