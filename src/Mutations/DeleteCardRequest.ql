mutation { 
 deleteCard(input: { id: @cardId }) {
   clientMutationId
   success
 }
}