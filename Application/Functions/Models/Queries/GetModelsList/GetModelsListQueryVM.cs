using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Models.Queries.GetModelsList
{
    public class GetModelsListQueryVM
    {
        public int Id { get; set; }
        public string BrandName { get; set; } = string.Empty;
        public string ModelName { get; set; } = string.Empty;
        public int CarsCount { get; set; }
    }
}
