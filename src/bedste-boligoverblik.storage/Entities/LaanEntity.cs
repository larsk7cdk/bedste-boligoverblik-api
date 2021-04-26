using System;
using Azure;
using Azure.Data.Tables;

namespace bedste_boligoverblik.storage.Entities
{
    public class LaanEntity : ITableEntity
    {
        public string BoligKey { get; init; }
        public string Request { get; init; }
        public string Result { get; init; }

        public string PartitionKey { get; set; } = "laan";
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}