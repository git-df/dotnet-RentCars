using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Common
{
    public class ListRequestOptions
    {
        private int page = 1;
        private int pageSize = 20;
        public string Search { get; set; }

        public int Page
        {
            get
            { 
                return page; 
            }
            set
            {
                page = value > 0 ? value : 1;
            }
        }

        public int PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                pageSize = value > 0 ? value : 20;
            }
        }
    }
}
