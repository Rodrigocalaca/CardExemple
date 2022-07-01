using CardExemple.Models;
using CardExemple.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CardExemple.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedsController : Controller
    {
        IMedsRepository _repository;

        public MedsController(IMedsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MedicationSale>> Get()
        {
            return Ok(_repository.Get());
        }
    }
}
