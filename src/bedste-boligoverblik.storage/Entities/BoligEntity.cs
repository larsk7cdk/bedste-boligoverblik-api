using System;
using Azure;
using Azure.Data.Tables;

namespace bedste_boligoverblik.storage.Entities
{
    public class BoligEntity : ITableEntity
    {
        public string UserKey { get; init; }
        public string Vejnavn { get; init; }
        public string Husnummer { get; init; }
        public int Postnummer { get; init; }
        public string X { get; set; }
        public string Y { get; set; }

        public string Adresse { get; set; }

        public string PartitionKey { get; set; } = "bolig";
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}