using DotNetSixMvcAssignment.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetSixMvcAssignment.Data
{
    public interface ICategoryRepository
    {
        public IEnumerable<Category> GetAll();
    }
}
