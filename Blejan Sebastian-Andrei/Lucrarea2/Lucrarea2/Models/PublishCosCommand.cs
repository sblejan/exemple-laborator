using Lucrarea2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucrarea2.Models;
using static Lucrarea2.Models.Cos;

namespace Lucrarea2.Domanin.Models
{
    public record PublishCosCommand
    {
        public PublishCosCommand(UnvalidatedProduse[] listOfCoss)
        {
        }

        public PublishCosCommand(IReadOnlyCollection<UnvalidatedProduse> inputProduse, CosDetails inputCosDetails)
        {
            InputProduse = inputProduse;
            InputCosDetails = inputCosDetails;
        }
        public IReadOnlyCollection<UnvalidatedProduse> InputProduse { get; }
        public CosDetails InputCosDetails { get; }
    }
}
