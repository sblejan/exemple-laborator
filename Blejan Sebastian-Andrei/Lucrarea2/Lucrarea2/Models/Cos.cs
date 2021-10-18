using System;
using System.Collections.Generic;
using CSharp.Choices;

namespace Lucrarea2.Models
{
    [AsChoice]
    public static partial class Cos
    {
        public interface ICos
        {
            void Match(Func<object, object> whenExamCosPublishFaildEvent, Func<object, object> whenExamCossPublishScucceededEvent);
        }

        public record UnvalidatedCos: ICos
        {
            public UnvalidatedCos(IReadOnlyCollection<UnvalidatedProduse> produseList, CosDetails cosDetails)
            {
                ProduseList = produseList;
                CosDetails = cosDetails;
            }

            public IReadOnlyCollection<UnvalidatedProduse> ProduseList { get; }
            public CosDetails CosDetails { get; }
        }

        public record InvalidatedCos : ICos
        {
            internal InvalidatedCos(IReadOnlyCollection<UnvalidatedProduse> produseList, string reason)
            {
                ProduseList = produseList;
                Reason = reason;
            }

            public IReadOnlyCollection<UnvalidatedProduse> ProduseList { get; }
            public string Reason { get; }
        }

        public record GolCos: ICos
        {
            internal GolCos(IReadOnlyCollection<UnvalidatedProduse> produseList, string reason)
            {
                ProdusList = null;
                Reason = reason;
            }

            public IReadOnlyCollection<GolCos> ProdusList { get; }
            public string Reason { get; }
        }
        
        public record ValidatedCos : ICos
        {
            internal ValidatedCos(IReadOnlyCollection<ValidatedProduse> produseList, CosDetails cosDetails)
            {
                ProduseList = produseList;
                CosDetails  = cosDetails;
            }

            public IReadOnlyCollection<ValidatedProduse> ProduseList { get; }
            public CosDetails CosDetails { get; }
        }

        public record CosPlatit: ICos
        {
            internal CosPlatit(IReadOnlyCollection<ValidatedProduse> produseList, CosDetails cosDetails, DateTime publishedDate)
            {
                ProduseList = produseList;
                CosDetails = cosDetails;
                PublishedDate = publishedDate;
            }
            public IReadOnlyCollection<ValidatedProduse> ProduseList { get; }
            public CosDetails CosDetails { get; }
            public DateTime PublishedDate { get; }
        }


        public record PublishedCos : ICos
        {
            internal PublishedCos(IReadOnlyCollection<CosPlatit> cosPlatit, string csv, DateTime publishedDate)
            {
                CosPlatit = cosPlatit;
                PublishedDate = publishedDate;
                Csv = csv;
            }

            public IReadOnlyCollection<CosPlatit> CosPlatit { get; }
            public DateTime PublishedDate { get; }
            public string Csv { get; }
        }

    }
}
