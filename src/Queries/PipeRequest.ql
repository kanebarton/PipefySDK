{
  pipe(id: @pipeId) {
    cards_count
    created_at
    description
    phases {
      id
      name
      cards_count
      description
    }
    labels {
      id
      color
      name
    }
  }
}
