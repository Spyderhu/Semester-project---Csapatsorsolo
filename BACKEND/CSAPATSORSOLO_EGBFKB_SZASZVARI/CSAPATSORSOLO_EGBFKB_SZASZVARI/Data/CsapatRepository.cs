using CSAPATSORSOLO_EGBFKB_SZASZVARI.Models;

namespace CSAPATSORSOLO_EGBFKB_SZASZVARI.Data
{
    public class CsapatRepository : ICsapatRepository
    {
        public CsapatRepository()
        {
     
        }

        public IEnumerable<IEnumerable<Member>> GenerateTeams(TeamGenerator tg)
        {
            List<List<Member>> teams = new List<List<Member>>();
            for (int i = 0; i < tg.NumberOfTeams; i++)
            {
                List<Member> team = new List<Member>();
                teams.Add(team);
            }
            tg.Members = tg.Members.OrderBy(x => x.Age).ToList();
            for (int i = 0; i < tg.Members.Count; i++)
            {
                teams[i % tg.NumberOfTeams].Add(tg.Members[i]);
            }
            return teams;
        }
    }
}
