using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Axis.PipefySdk.Queries
{
    public class CardRequest : PipefyRequestBase
    {
        private static readonly string _query = EmbeddedManager.CommandDictionary[$"{typeof(CardRequest).FullName}.ql"];
        private readonly string _cardId = "0";

        public CardRequest(long cardId)
        : this(cardId.ToString()) { }

        public CardRequest(string cardId)
        {
            _cardId = cardId;
        }

        [JsonPropertyName("query")]
        public string Query => _query.Replace(PipefyConsts.FilterParameters.GraphFilters, GetGraphFilters()).Replace(PipefyConsts.FilterParameters.CardId, _cardId);
    }
}
