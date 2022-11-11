using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedModel.Models;

namespace newdesh.Models
{
    public interface ICommonAPI
    {
        Response Get(string url);

        Response Post(string url,object data);
    }
}
