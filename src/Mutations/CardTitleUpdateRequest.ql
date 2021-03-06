mutation{
  updateCard(input: { id: @cardId, title: "@title" }) {
    clientMutationId
  }
}