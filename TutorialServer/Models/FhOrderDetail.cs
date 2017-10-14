using System;
using System.Collections.Generic;

namespace TutorialServer.Models
{
    public partial class FhOrderDetail
    {
        public string VendorId { get; set; }
        public string PortalId { get; set; }
        public string OrderNumber { get; set; }
        public string PurchaseOrder { get; set; }
        public string OrderDate { get; set; }
        public string Contact { get; set; }
        public string Name { get; set; }
        public string Addr1 { get; set; }
        public string Addr2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Carrier { get; set; }
        public string Scac { get; set; }
        public string PolineNum { get; set; }
        public string Sku { get; set; }
        public string Upc { get; set; }
        public string Descr { get; set; }
        public string Quantity { get; set; }
        public bool? Processed { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? TransDetailId { get; set; }
    }
}
