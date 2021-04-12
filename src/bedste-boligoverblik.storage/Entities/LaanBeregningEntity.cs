using System;
using Azure;
using Azure.Data.Tables;

namespace bedste_boligoverblik.storage.Entities
{
    public class LaanberegningEntity : ITableEntity
    {
        public string BoligKey { get; init; }
        public string Produkt { get; init; }
        public long Pris { get; init; }
        public long Udbetaling { get; init; }
        public int Loebetid { get; init; }
        public int Afdragsfrihed { get; init; }
        public int LoebetidBank { get; init; }

        public string PartitionKey { get; set; } = "laanberegning";
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}