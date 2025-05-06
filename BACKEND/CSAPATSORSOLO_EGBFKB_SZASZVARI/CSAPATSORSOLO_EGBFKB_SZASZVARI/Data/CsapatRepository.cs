using CSAPATSORSOLO_EGBFKB_SZASZVARI.Models;

namespace CSAPATSORSOLO_EGBFKB_SZASZVARI.Data
{
    public class CsapatRepository : ICsapatRepository
    {
        List<Member> members;
        public CsapatRepository()
        {
            members = new List<Member>();
        }

        public void Create(Member member)
        {
            this.members.Add(member);
        }

        public IEnumerable<Member> Read()
        {
            return this.members;
        }
    }
}
