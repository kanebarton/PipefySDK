using Axis.PipefySdk.Models.Common;
using System;
using System.Text.Json.Serialization;

namespace Axis.PipefySdk.Models
{
    public class CardFieldModel
    {
        public string ValueAsUsaDate => DateValue?.ToString("MM/dd/yyyy");
        public string ValueAsDisplayDate => DateValue?.ToString("dd MMM yyyy");
        public int ValueAsInteger => DoubleValue.HasValue ? int.Parse(DoubleValue.Value.ToString("N0")) : 0;
        public string Index => PhaseField?.Id ?? IndexName;

        [JsonPropertyName("date_value")]
        public DateTime? DateValue { get; set; }

        [JsonPropertyName("datetime_value")]
        public DateTimeOffset? DateTimeValue { get; set; }

        [JsonPropertyName("filled_at")]
        public DateTimeOffset? FilledAt { get; set; }

        [JsonPropertyName("float_value")]
        public double? DoubleValue { get; set; }

        [JsonPropertyName("indexName")]
        public string IndexName { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("report_value")]
        public string ReportValue { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("phase_field")]
        public PipefyIdModel PhaseField { get; set; }
    }
}
