using CardExemple.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace CardExemple.Repository
{
    public class MedsRepository : IMedsRepository
    {
        private IEnumerable<MedicationSale> _medicationSale;

        public MedsRepository()
        {
            _medicationSale = new List<MedicationSale>();
        }

        public IEnumerable<MedicationSale> Get()
        {
            string[] csvLines = File.ReadAllLines(@"C:\Users\rodrigo.caetano\source\repos\CardExemple\CardExemple\Venda_Medicamentos.csv");

            List<MedicationSale> teste = new List<MedicationSale>();

            for (int i = 1; i < csvLines.Length; i++)
            {
                string[] rowData = csvLines[i].Split(';');

                MedicationSale testeSale = new MedicationSale();
                testeSale.SaleDate = Convert.ToDateTime(rowData[0]);
                testeSale.MedicationName = rowData[1];
                testeSale.CityName = rowData[2];
                testeSale.SellerName = rowData[3];
                testeSale.IncurredCosts = Convert.ToDouble(rowData[4]);
                testeSale.Amount = Convert.ToInt32(rowData[5]);
                testeSale.Price = Convert.ToDouble(rowData[6]);
                teste.Add(testeSale);

            }
            return teste;

            
        }
    } //passar tudo para o ctor e dentro do get só chamar o IEnumerable
}
