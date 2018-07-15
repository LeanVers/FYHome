using System;
using System.Collections.Generic;
using System.Text;

namespace FYHomeV1.Models
{
    public class Photo
    {
        public int PhotoId { get; set; }
        public string Name { get; set; }

        public ResidencialProperty ResidencialProperty { get; set; }
    }
}
