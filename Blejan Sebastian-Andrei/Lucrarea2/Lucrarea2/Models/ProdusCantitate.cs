using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lucrarea2.Models
{
    public record  ProdusCantitate
    {
        private static readonly Regex ValidPattern = new("^LM[0-9]{5}$");
        public string Value { get; }

        private ProdusCantitate(string value)
        {
            if (IsValid(value))
            {
                Value = value;
            }
            else
            {
                throw new InvalidProdusCantitate("WRONG INPUT");
            }
        }

        public override string ToString()
        {
            return Value;
        }


        private static bool IsValid(string stringValue) => ValidPattern.IsMatch(stringValue) && (!decimal.TryParse(stringValue, out decimal numericValue).Equals(0));

        public static bool TryParseProdusCantitate(string stringValue, out ProdusCantitate produsCantitate)
        {
            bool isValid = false;
            produsCantitate = null;

            if (IsValid(stringValue))
            {
                isValid = true;
                produsCantitate = new(stringValue);
            }

            return isValid;
        }
    }
   
}
