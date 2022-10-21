using SharedModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApi.Reposetries
{
    public interface IAddressReposetry
    {
        bool SaveAddress(Address address);
        List<Address> GetAllCategories();
        bool Update(Address address);
        Address Edit(int id);
        bool Delete(int id);
    }
}
