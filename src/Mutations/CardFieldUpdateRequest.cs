using System.Text.Json.Serialization;

namespace Axis.PipefySdk.Mutations
{
    public class CardFieldUpdateRequest
    {
        private static readonly string _query = EmbeddedManager.CommandDictionary[$"{typeof(CardFieldUpdateRequest).FullName}.ql"];
        private readonly string _cardId = "0";
        private readonly string _fieldid = string.Empty;
        private readonly string _newValue = string.Empty;

        public CardFieldUpdateRequest(long cardId, string fieldId, string newValue)
        : this(cardId.ToString(), fieldId, newValue) { }

        public CardFieldUpdateRequest(string cardId, string fieldId, string newValue)
        {
            _cardId = cardId;
            _fieldid = fieldId;
            _newValue = newValue;
        }

        [JsonPropertyName("query")]
        public string Query => _query.Replace(PipefyConsts.FilterParameters.CardId, _cardId)
            .Replace(PipefyConsts.FilterParameters.FieldId, _fieldid)
            .Replace(PipefyConsts.FilterParameters.NewValue, _newValue);
    }
}
