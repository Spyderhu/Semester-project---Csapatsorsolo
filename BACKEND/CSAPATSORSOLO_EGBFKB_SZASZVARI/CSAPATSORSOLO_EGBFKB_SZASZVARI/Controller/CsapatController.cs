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

        public static List<List<Member>> Distribute(List<Member> Members, int numTeams)
        {
            var sorted = Members.OrderBy(p => p.Age).ToList();
            var teams = new List<List<Member>>();

            for (int i = 0; i < numTeams; i++)
                teams.Add(new List<Member>());

            bool leftToRight = true;

            for (int i = 0; i < sorted.Count; i += numTeams)
            {
                var group = sorted.Skip(i).Take(numTeams).ToList();
                if (!leftToRight) group.Reverse();

                for (int j = 0; j < group.Count; j++)
                {
                    int target = leftToRight ? j : (numTeams - 1 - j);
                    teams[target].Add(group[j]);
                }

                leftToRight = !leftToRight;
            }

            return teams;
        }

    }
}
