# WorkflowEngine

A minimal backend workflow engine built with ASP.NET Core (.NET 6+). This project demonstrates a configurable state machine API for defining, running, and tracking workflow instances.

---

## Quick Start

### Prerequisites
- [.NET 6 SDK or later](https://dotnet.microsoft.com/download)

### Clone and Run
```sh
# Navigate to the project root
cd WorkflowEngine

# Restore dependencies (if needed)
dotnet restore

# Build the project
dotnet build

# Run the project
dotnet run
```

### Access the API
- Open your browser and go to: [http://localhost:5287/swagger](http://localhost:5287/swagger)
- Use the Swagger UI to interact with the API endpoints.

---

## How to Use This API

### 1. Create a Workflow Definition
- **Endpoint:** `POST /api/WorkflowDefinitions`
- **Sample Request Body:**
  ```json
  {
    "id": "doc-review",
    "name": "Document Review",
    "states": [
      { "id": "draft", "name": "Draft", "isInitial": true, "isFinal": false, "enabled": true },
      { "id": "review", "name": "In Review", "isInitial": false, "isFinal": false, "enabled": true },
      { "id": "approved", "name": "Approved", "isInitial": false, "isFinal": true, "enabled": true },
      { "id": "rejected", "name": "Rejected", "isInitial": false, "isFinal": true, "enabled": true }
    ],
    "actions": [
      { "id": "submit", "name": "Submit", "enabled": true, "fromStates": ["draft"], "toState": "review" },
      { "id": "approve", "name": "Approve", "enabled": true, "fromStates": ["review"], "toState": "approved" },
      { "id": "reject", "name": "Reject", "enabled": true, "fromStates": ["review"], "toState": "rejected" }
    ]
  }
  ```

### 2. Start a Workflow Instance
- **Endpoint:** `POST /api/workflows/{workflowDefinitionId}/instances`
- **Path Parameter:** `workflowDefinitionId` (e.g., `doc-review`)
- **Response:** Contains the new instance's `id`.

### 3. Execute an Action on an Instance
- **Endpoint:** `POST /api/WorkflowInstances/{id}/actions`
- **Path Parameter:** `id` (instance ID from previous step)
- **Sample Request Body:**
  ```json
  { "actionId": "submit" }
  ```

### 4. Get Instance State and History
- **Endpoint:** `GET /api/WorkflowInstances/{id}`
- **Path Parameter:** `id` (instance ID)
- **Response:** Shows the current state and action history for the instance.

---

## API Overview

- **Define workflows** as state machines (states + actions)
- **Start workflow instances** from a definition
- **Execute actions** to move an instance between states (with validation)
- **Inspect/list** states, actions, definitions, and running instances

---

## Environment Notes
- Designed for local development and demonstration.
- Uses in-memory storage (data is lost on restart).
- No database or external dependencies required.
- Tested on Windows 10+ with .NET 6 SDK.

---

## Assumptions & Shortcuts
- Only one initial state is allowed per workflow definition.
- All referenced states in actions must exist in the workflow definition.
- No authentication or authorization is implemented.
- No persistent storage: all data is lost when the app stops.
- Minimal validation is performed for workflow and action creation.
- The API is not optimized for high concurrency or production use.

---

## Known Limitations
- **Persistence:** All data is in-memory; restarting the app erases all workflows and instances.
- **Scalability:** Not suitable for production or multi-user environments.
- **Validation:** Only basic validation is implemented; more complex business rules may require extension.
- **Error Handling:** Minimal error handling; responses may be generic.
- **Extensibility:** Designed for clarity and learning, not for feature completeness.

---

## Example Usage

1. **Create a workflow definition** using `POST /api/WorkflowDefinitions` (see Swagger UI for sample JSON).
2. **Start a workflow instance** using `POST /api/workflows/{workflowDefinitionId}/instances`.
3. **Execute an action** using `POST /api/WorkflowInstances/{id}/actions`.
4. **Get instance state/history** using `GET /api/WorkflowInstances/{id}`.

---

## License
This project is for demonstration and educational purposes only. 