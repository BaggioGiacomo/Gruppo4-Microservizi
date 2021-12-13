using Dapper.Contrib.Extensions;
using System;

namespace Gruppo4.Microservizi.AppCore.Models.ModelContrib
{
    [Table("Orders_Has_Product")]
    public class OrdersHasProductContrib
    {
        public OrdersHasProductContrib()
        {

        }

        [ExplicitKey]
        public Guid Orders_Id { get; set; }
        [ExplicitKey]
        public int Product_Id { get; set; }
        public decimal PriceAtTheMoment { get; set; }
        public int Quantity { get; set; }



    }
}
