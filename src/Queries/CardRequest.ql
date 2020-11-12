{
  card(id: @cardId) {
    id
    title
    done
    due_date
    comments_count
    url
    createdAt
    createdBy {
      id
    }
    creatorEmail
    current_phase_age
    updated_at
    age
    attachments_count
    expiration {
      expiredAt
      shouldExpireAt
    }
    expired
    finished_at
    late
    started_current_phase_at
    uuid
    pipe {
      id
      name
    }
    cardAssignees {
      id
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
    assignees {
      id
      name
      username
    }
    comments {
      text
    }
    current_phase {
      name
    }
    labels {
      id
      name
    }
    phases_history {
      phase {
        name
      }
      firstTimeIn
      lastTimeOut
    }
  }
}
