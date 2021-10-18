using Lucrarea2.Models;
using Lucrarea2.Domanin.Models;
using System;
using static Lucrarea2.Models.Cos;
using static Lucrarea2.CosOperation;
using static Lucrarea2.Models.CosPublishedEvent;

namespace Lucrarea2
{
    public class PublishCosWorkflow
    {
        public static ICos Execute(PublishCosCommand command, Func<ProdusID, bool> checkCosExists)
        {
            UnvalidatedCos unvalidatedCos = new UnvalidatedCos(command.InputProduse, command.InputCosDetails);
            ICos cos = ValidatedCos(checkCosExists, unvalidatedCos, command.InputCosDetails);
            cos = PublishCos(cos);

            return cos.Match(
                    whenUnvalidatedCos: unvalidatedCos => (ICos)(new CosPublishFaildEvent("Unexpected unvalidated state") as ICosPublishedEvent),
                    whenInvalidatedCos: invalidCos => new CosPublishFaildEvent(invalidCos.Reason),
                    whenValidatedCos: validatedCos => new CosPublishFaildEvent("Unexpected validated state"),
                    whenPublishedCos: publishedCos => new CosPublishScucceededEvent(publishedCos.Cs, publishedCos.PublishedDate)
                );
        }
    }
}
