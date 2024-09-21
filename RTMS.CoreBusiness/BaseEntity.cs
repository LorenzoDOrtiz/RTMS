using System.ComponentModel.DataAnnotations;

namespace RTMS.CoreBusiness
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }

}
