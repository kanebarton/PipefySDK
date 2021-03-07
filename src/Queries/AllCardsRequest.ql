{
  allCards(pipeId: @pipeId @graphFilters) {
    pageInfo {
      startCursor
      endCursor
      hasNextPage
      hasPreviousPage
    }
    edges {
      cursor
      node {
        id
        title
        url
        done
        assignees {
          id
          name
          username
        }
        current_phase {
          id
          name
        }
        fields {
          date_value
          datetime_value
          filled_at
          float_value
          indexName
          name
          report_value
          updated_at
          value
          phase_field {
            id
          }
        }
      }
    }
  }
}