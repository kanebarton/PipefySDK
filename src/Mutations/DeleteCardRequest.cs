using System.Text.Json.Serialization;

namespace Axis.PipefySdk.Mutations
{
    public class DeleteCardRequest
    {
        private static readonly string _query = EmbeddedManager.CommandDictionary[$"{typeof(DeleteCardRequest).FullName}.ql"];
        private readonly string _cardId = "0";

        public DeleteCardRequest(long cardId)
        : this(cardId.ToString()) { }

        public DeleteCardRequest(string cardId)
        {
            _cardId = cardId;
        }

        [JsonPropertyName("query")]
        public string Query => _query.Replace(PipefyConsts.FilterParameters.CardId, _cardId);
    }
}
