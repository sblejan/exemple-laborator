using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucrarea2.Models
{
    [AsChoice]
    public static partial class CosPublishedEvent
    {
        public interface ICosPublishedEvent { }

        public record CosPublishScucceededEvent : ICosPublishedEvent
        {
            public string Csv { get; }
            public DateTime PublishedDate { get; }

            internal CosPublishScucceededEvent(string csv, DateTime publishedDate)
            {
                Csv = csv;
                PublishedDate = publishedDate;
            }
        }

        public record CosPublishFaildEvent : ICosPublishedEvent
        {
            public string Reason { get; }

            internal CosPublishFaildEvent(string reason)
            {
                Reason = reason;
            }
        }
    }
}
