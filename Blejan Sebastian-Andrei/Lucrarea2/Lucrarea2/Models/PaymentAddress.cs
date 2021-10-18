using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lucrarea2.Models
{
    public record PaymentAddress
    {
        
        public string Value { get; }

        public PaymentAddress(string value)
        { 
                Value = value;
        }

        public override string ToString()
        {
            return Value;
        }


        private static bool IsValid(string stringValue) => (string.IsNullOrEmpty(stringValue));

        public static bool TryParsePaymentAddress(string stringValue, out PaymentAddress paymentAddress)
        {
            bool isValid = false;
            paymentAddress = null;

            if (IsValid(stringValue))
            {
                isValid = true;
                paymentAddress = new(stringValue);
            }

            return isValid;
        }
    }
}
