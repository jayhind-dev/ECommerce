using SharedModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApi.Reposetries
{
    public interface IUserReposetries
    {
        List<User> SaveUserDetails(User user);
        List<User> GeltAllUserDetails();
        bool Update(User user);
        User Edit(int user_id);
        bool Delete(int user_id);
    }
}
