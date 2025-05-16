using CSAPATSORSOLO_EGBFKB_SZASZVARI.Data;
using CSAPATSORSOLO_EGBFKB_SZASZVARI.Models;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IEnumerable<Member> GetMembers()
        {
            return this.repo.Read();
        }

        [HttpPost]
        public ActionResult<Member> CreateMember([FromBody] string name, int age)
        {
            if (age <= 8)
            {
                return BadRequest("Too young! Should be older than 8!");
            }
            Member member = new Member();
            member.Name = name;
            member.Age = age;
            this.repo.Create(member);
            return member;
        }

        [HttpPost("Create")]
        public void CreateMembers(string input)
        {
            string[] inputs = input.Trim().Split(';');
            foreach (var item in inputs)
            {
                CreateMember(item.Split(',')[0], int.Parse(item.Split(',')[1]));
            }
        }

        [HttpPost("Distribute")]
        public List<List<Member>> Distribute(int numTeams)
        {
            var sorted = this.repo.Read().OrderBy(p => p.Age).ToList();
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
