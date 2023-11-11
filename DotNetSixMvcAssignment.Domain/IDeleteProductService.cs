using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetSixMvcAssignment.Domain
{
    public interface IDeleteProductService
    {
        public int Execute(int productId);
    }
}
