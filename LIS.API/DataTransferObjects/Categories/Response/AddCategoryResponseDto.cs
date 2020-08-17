using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIS.API.DataTransferObjects.Categories.Response
{
    public sealed class AddCategoryResponseDto
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }
}
