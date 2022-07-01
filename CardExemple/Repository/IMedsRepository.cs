using CardExemple.Models;

namespace CardExemple.Repository
{
    public interface IMedsRepository
    {
        IEnumerable<MedicationSale> Get();
    }
}
