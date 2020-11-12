using System.Text.Json.Serialization;

namespace Axis.PipefySdk.Mutations
{
    public class CardTitleUpdateRequest
    {
        private static readonly string _query = EmbeddedManager.CommandDictionary[$"{typeof(CardTitleUpdateRequest).FullName}.ql"];
        private readonly string _cardId = "0";
        private readonly string _Title = string.Empty;

        public CardTitleUpdateRequest(long cardId, string title)
        : this(cardId.ToString(), title) { }

        public CardTitleUpdateRequest(string cardId, string title)
        {
            _cardId = cardId;
            _Title = title;
        }

        [JsonPropertyName("query")]
        public string Query => _query.Replace(PipefyConsts.FilterParameters.CardId, _cardId)
            .Replace(PipefyConsts.FilterParameters.Title, _Title);
    }
}
