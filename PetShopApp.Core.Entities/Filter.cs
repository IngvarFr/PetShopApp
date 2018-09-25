using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.Entities
{
    public class Filter
    {
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
    }
}
