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
                teams.Add(new List<Member>());
            }

            tg.Members = tg.Members.OrderBy(x => x.Age).ToList();

            bool forward = true;
            int teamIndex = 0;

            foreach (var member in tg.Members)
            {
                teams[teamIndex].Add(member);

                if (forward)
                {
                    teamIndex++;
                    if (teamIndex == tg.NumberOfTeams)
                    {
                        forward = false;
                        teamIndex = tg.NumberOfTeams - 1;
                    }
                }
                else
                {
                    teamIndex--;
                    if (teamIndex < 0)
                    {
                        forward = true;
                        teamIndex = 0;
                    }
                }
            }

            return teams;
        }
    }
}
