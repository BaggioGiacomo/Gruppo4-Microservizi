using Dapper.Contrib.Extensions;

namespace Gruppo4.Microservizi.AppCore.Models.ModelContrib
{
    [Table("Customers")]
    public class CustomerContrib
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BusinessName { get; set; }
    }
}
