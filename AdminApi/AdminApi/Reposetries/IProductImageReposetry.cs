using SharedModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApi.Reposetries
{
    interface IProductImageReposetry
    {
        bool SaveProductImage(ProductImage productImage);
        List<ProductImage> GeltAllProductImage();
        ProductImage Edit(int id);
        bool Update(ProductImage productImage);
        bool Delete(int id);
    }
}
