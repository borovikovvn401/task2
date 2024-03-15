using System;
using System.Collections.Generic;

namespace task2.Model
{
    public partial class ClientService
    {
        public ClientService()
        {
            DocumentByServices = new HashSet<DocumentByService>();
            ProductSales = new HashSet<ProductSale>();
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ServiceId { get; set; }
        public DateTime StartTime { get; set; }
        public string? Comment { get; set; }

        public string time => StartTime.Day + "-" + StartTime.Month + "-" + StartTime.Year + " " + StartTime.TimeOfDay;

        public virtual Client Client { get; set; } = null!;
        public virtual Service Service { get; set; } = null!;
        public virtual ICollection<DocumentByService> DocumentByServices { get; set; }
        public virtual ICollection<ProductSale> ProductSales { get; set; }
    }
}
