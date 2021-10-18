using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lucrarea2.Models
{
    public record ProdusID
    {
        private static readonly Regex ValidPattern = new("^LM[0-9]{5}$");

        public decimal Value { get; }

        private ProdusID(decimal value)
        {
            if (IsValid(value))
            {
                Value = value;
            }
            else
            {
                throw new InvalidProdusID("Invalid ProdusID");
            }
        }

        public override string ToString()
        {
            return $"{Value:0.##}";
        }


        public static bool TryParseProdusID(string produsIDString, out ProdusID produsID)
        {
            bool isValid = false;
            produsID = null;
            if (decimal.TryParse(produsIDString, out decimal numericProdusID))
            {
                if (IsValid(numericProdusID))
                {
                    isValid = true;
                    produsID = new(numericProdusID);
                }
            }

            return isValid;
        }

        private static bool IsValid(decimal numericProdusID) => numericProdusID > 1000 && numericProdusID <= 9999;
    }
}
