const initialState = {}
  
  // Use the initialState as a default value
  export default function appReducer(state = initialState, action: { type: any }) {
    // The reducer normally looks at the action type field to decide what happens
    switch (action.type) {
      // Do something here based on the different types of actions
      case 'organization/login':
          return {
            ...state,
            username: "MattsOrg6"
          };
      default:
        // If this reducer doesn't recognize the action type, or doesn't
        // care about this specific action, return the existing state unchanged
        return state
    }
  }