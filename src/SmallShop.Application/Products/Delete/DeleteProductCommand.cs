using SmallShop.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallShop.Application.Products.Delete
{
    public class DeleteProductCommand : IBaseCommand
    {
        public Guid Id { get; set; }
        //to be set in the api
        public Guid? UserId { get; set; }
    }
}
