mutation { 
 createCard(input: { pipe_id: @pipeId, title: "@title", fields_attributes: [ @fieldArray ] }) {
    card {
      id
    }
 }
}