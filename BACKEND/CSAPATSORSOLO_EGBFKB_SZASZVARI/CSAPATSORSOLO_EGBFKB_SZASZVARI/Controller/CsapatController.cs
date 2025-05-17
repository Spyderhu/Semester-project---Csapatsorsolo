using CSAPATSORSOLO_EGBFKB_SZASZVARI.Data;
using CSAPATSORSOLO_EGBFKB_SZASZVARI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace CSAPATSORSOLO_EGBFKB_SZASZVARI.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class CsapatController : ControllerBase
    {
        ICsapatRepository repo;
        public CsapatController(ICsapatRepository repo) 
        {
            this.repo = repo;
        }

        [HttpPost]
        public IEnumerable<IEnumerable<Member>> Addplayer([FromBody] TeamGenerator tg)
        {
            //Response-ba vissza is adja a generált csapatokat
            return repo.GenerateTeams(tg);
        }

    }
}
