using CSAPATSORSOLO_EGBFKB_SZASZVARI.Data;
using CSAPATSORSOLO_EGBFKB_SZASZVARI.Models;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public IEnumerable<Member> GetMembers()
        {
            return this.repo.Read();
        }

        [HttpPost]
        public ActionResult<Member> CreateMember([FromBody] Member member)
        {
            if (member.Age <= 8)
            {
                return BadRequest("Too young! Should be older than 8!");
            }
            this.repo.Create(member);
            return member;
        }
    }
}
