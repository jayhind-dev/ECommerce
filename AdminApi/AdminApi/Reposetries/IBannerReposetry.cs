using SharedModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApi.Reposetries
{
    public interface IBannerReposetry
    {
        bool SaveBanner(banner banner);
        List<banner> GeltAllBanner();
        banner BannerEdit(int id);
        bool BannerUpdate(banner banner);
        bool BannerDelete(int id);
    }
}
