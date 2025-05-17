using CSAPATSORSOLO_EGBFKB_SZASZVARI.Models;

namespace CSAPATSORSOLO_EGBFKB_SZASZVARI.Data
{
    public interface ICsapatRepository
    {
        public IEnumerable<IEnumerable<Member>> GenerateTeams(TeamGenerator tg);
    }
}