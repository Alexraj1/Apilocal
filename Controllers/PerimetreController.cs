using ApiLocal.BLL;
using ApiLocal.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiLocal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PerimetreController : ControllerBase
    {
        private LocationLogic bLL { get; set; }
        public PerimetreController()
        {
            bLL=new LocationLogic();
        }
        [HttpGet]
        [Route("GetLocation")]
        public IEnumerable<Properties> ListOfCity(string City)
        {
           return bLL.GetLocationAvailable(City);
        }

        [HttpGet]
        [Route("GetEntreprise")]
        public IEnumerable<Societe> GetEntreprise()
        {
            return bLL.GetEntrepriseInfo();
        }

        [HttpGet]
        [Route("GetEntrepriseByInsee")]
        public IEnumerable<Societe> GetEntrepriseByInsee(string insee)
        {
            return bLL.GetEntrepriseInfo(insee);
        }
    }
}
