using SharedModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApi.Reposetries
{
    public interface IProductReposetry
    {
        bool SaveProduct(Product product);
        List<Product> GetAllProducts();
        bool Delete(int id);
        Product Edit(int id);
        bool Update(Product product);
    }
}
