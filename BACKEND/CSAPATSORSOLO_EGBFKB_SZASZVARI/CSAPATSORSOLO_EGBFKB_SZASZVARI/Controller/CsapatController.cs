using CSAPATSORSOLO_EGBFKB_SZASZVARI.Data;
using Microsoft.AspNetCore.Mvc;

namespace CSAPATSORSOLO_EGBFKB_SZASZVARI.Controller
{
    public class CsapatController
    {
        ICsapatRepository repo;
        public CsapatController(ICsapatRepository repo) 
        {
            this.repo = repo;
        }
    }
}
