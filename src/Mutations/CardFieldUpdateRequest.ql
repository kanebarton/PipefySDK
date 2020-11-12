mutation {
  updateCardField(input: {card_id: @cardId field_id: "@fieldId", new_value: "@newValue"}) {
    clientMutationId
    success
  }
}