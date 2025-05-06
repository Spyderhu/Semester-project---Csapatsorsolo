using CSAPATSORSOLO_EGBFKB_SZASZVARI.Models;

namespace CSAPATSORSOLO_EGBFKB_SZASZVARI.Data
{
    public interface ICsapatRepository
    {
        void Create(Member member);
        IEnumerable<Member> Read();
    }
}