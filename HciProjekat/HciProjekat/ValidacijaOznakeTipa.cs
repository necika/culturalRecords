using PrimerCas4.Table;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HciProjekat
{
    public class ValidacijaOznakeTipa : ValidationRule
    {
        public Type ValidationType { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Console.WriteLine("dsadad");
            String oznaka = value as String;
            oznaka = oznaka.Trim();
            if (oznaka.Equals(""))
            {
                return new ValidationResult(false, "Morate uneti oznaku tipa.");
            }
            else
            {
                if (oznaka.Length < 3)
                {
                    return new ValidationResult(false, "Oznaka tipa mora imati najmanje 3 karaktera.");
                }
            }

            if (PrikazTipaSpomenika.Tipovi != null) {
                foreach (Model3 ts in PrikazTipaSpomenika.Tipovi)
                {
                    if (ts.Oznaka.Equals(oznaka))
                    {
                        return new ValidationResult(false, "Ovakva oznaka tipa vec postoji.");
                    }
                }
            }
            return ValidationResult.ValidResult;
        }
    }
    
}
