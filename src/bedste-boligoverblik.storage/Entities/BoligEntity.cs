using System;
using Azure;
using Azure.Data.Tables;

namespace bedste_boligoverblik.storage.Entities
{
    public class BoligEntity : ITableEntity
    {
        public string UserKey { get; init; }
        public string Adresse { get; init; }
        public float X { get; init; }
        public float Y { get; init; }

        public string PartitionKey { get; set; } = "bolig";
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}