using SharedModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApi.Reposetries
{
    interface ILoginReposetry
    {
        bool SaveLogin(Login login);
        List<Login> GeltAllLogin();
        bool Update(Login login);
        Login Edit(int id);
        bool Delete(int id);
    }
}
