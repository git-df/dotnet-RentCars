using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CarsModel : AuditableEntity
    {
        public int Id { get; set; }
        public string BrandName { get; set; } = string.Empty;
        public string ModelName { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;

        public List<Car> Cars { get; set; } = new List<Car>();
    }
}
