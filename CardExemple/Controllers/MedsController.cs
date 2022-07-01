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

        [HttpGet("faturamentototal")]
        public ActionResult<IEnumerable<MedicationSale>> GetFaturamentoTotal()
        {
            IEnumerable<MedicationSale> listaDeFaturamentos = _repository.Get();

            double soma = listaDeFaturamentos.Sum(x => x.Price);

            return Ok(soma);

        }

        [HttpGet("faturamentoPorAno")]
        public ActionResult<IEnumerable<MedicationSale>> GetFaturamentoPorAno([FromQuery] int dateYear)
        {
            IEnumerable<MedicationSale> listaDeFaturamentos = _repository.Get();

            double somaDoAno = listaDeFaturamentos.Where(x => x.SaleDate.Year == dateYear).Sum(x => x.Price);

            return Ok(somaDoAno);
        }

        [HttpGet("lucroluquidototal")]
        public ActionResult<IEnumerable<MedicationSale>> GetLucroLiquidoTotal()
        {
            IEnumerable<MedicationSale> listaDeFaturamentos = _repository.Get();

            var lucrototal = listaDeFaturamentos.Select(x => x.Price * x.Amount - x.IncurredCosts).Sum(x => x);

            return Ok(lucrototal);

        }

        [HttpGet("lucroluquidototalporano")]
        public ActionResult<IEnumerable<MedicationSale>> GetLucroLiquidoTotalporano([FromQuery] int dateYear)
        {
            IEnumerable<MedicationSale> listaDeFaturamentos = _repository.Get();

            var lucrototal = listaDeFaturamentos.Where(x => x.SaleDate.Year == dateYear).Select(x => x.Price * x.Amount - x.IncurredCosts).Sum(x => x);

            return Ok(lucrototal);

        }

        //[HttpGet("remediomaisvendido")]
        //public ActionResult<IEnumerable<MedicationSale>> GetRemedioMaisVendido()
        //{
        //    IEnumerable<MedicationSale> listaDeFaturamentos = _repository.Get();

        //    string remedioMaisVendido = listaDeFaturamentos.Select(x => x.MedicationName.Count(y => y));

        //}



    }
}
