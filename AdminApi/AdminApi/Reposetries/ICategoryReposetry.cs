using SharedModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApi.Reposetries
{
    public interface ICategoryReposetry
    {
        bool SaveCategory(Category category);
        List<Category> GetAllCategories();
        bool Delete(int id);
        bool Update(Category category);
    }
}
