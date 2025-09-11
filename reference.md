# Reference
## Actions
<details><summary><code>client.Actions.<a href="/src/MavenagiApi/Actions/ActionsClient.cs">SearchAsync</a>(ActionsSearchRequest { ... }) -> ActionsResponse</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Actions.SearchAsync(new ActionsSearchRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ActionsSearchRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Actions.<a href="/src/MavenagiApi/Actions/ActionsClient.cs">CreateOrUpdateAsync</a>(ActionRequest { ... }) -> ActionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update an action or create it if it doesn't exist
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Actions.CreateOrUpdateAsync(
    new ActionRequest
    {
        ActionId = new EntityIdBase { ReferenceId = "get-balance" },
        Name = "Get the user's balance",
        Description = "This action calls an API to get the user's current balance.",
        UserInteractionRequired = false,
        UserFormParameters = new List<ActionParameter>() { },
        Precondition = new PreconditionGroup
        {
            Operator = PreconditionGroupOperator.And,
            Preconditions = new List<object>()
            {
                new MetadataPrecondition { Key = "userKey" },
                new MetadataPrecondition { Key = "userKey2" },
            },
        },
        Language = "en",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ActionRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Actions.<a href="/src/MavenagiApi/Actions/ActionsClient.cs">GetAsync</a>(actionReferenceId, ActionGetRequest { ... }) -> ActionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get an action by its supplied ID
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Actions.GetAsync("get-balance", new ActionGetRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**actionReferenceId:** `string` — The reference ID of the action to get. All other entity ID fields are inferred from the request.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ActionGetRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Actions.<a href="/src/MavenagiApi/Actions/ActionsClient.cs">PatchAsync</a>(actionReferenceId, ActionPatchRequest { ... }) -> ActionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update mutable action fields

The `appId` field can be provided to update an action owned by a different app. 
All other fields will overwrite the existing value on the action only if provided.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Actions.PatchAsync("actionReferenceId", new ActionPatchRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**actionReferenceId:** `string` — The reference ID of the action to patch.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ActionPatchRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Actions.<a href="/src/MavenagiApi/Actions/ActionsClient.cs">DeleteAsync</a>(actionReferenceId)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete an action
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Actions.DeleteAsync("get-balance");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**actionReferenceId:** `string` — The reference ID of the action to unregister. All other entity ID fields are inferred from the request.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## AgentCapabilities
<details><summary><code>client.AgentCapabilities.<a href="/src/MavenagiApi/AgentCapabilities/AgentCapabilitiesClient.cs">ListAsync</a>(AgentCapabilityListRequest { ... }) -> ListAgentCapabilitiesResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

List all capabilities for an agent.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.AgentCapabilities.ListAsync(new AgentCapabilityListRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `AgentCapabilityListRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.AgentCapabilities.<a href="/src/MavenagiApi/AgentCapabilities/AgentCapabilitiesClient.cs">GetAsync</a>(integrationId, capabilityId) -> object</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.AgentCapabilities.GetAsync("integrationId", "capabilityId");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**integrationId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**capabilityId:** `string` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.AgentCapabilities.<a href="/src/MavenagiApi/AgentCapabilities/AgentCapabilitiesClient.cs">PatchAsync</a>(integrationId, capabilityId, PatchAgentCapabilityRequest { ... }) -> object</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.AgentCapabilities.PatchAsync(
    "integrationId",
    "capabilityId",
    new PatchAgentCapabilityRequest()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**integrationId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**capabilityId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `PatchAgentCapabilityRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Agents
<details><summary><code>client.Agents.<a href="/src/MavenagiApi/Agents/AgentsClient.cs">SearchAsync</a>(AgentsSearchRequest { ... }) -> AgentsSearchResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Search for agents across all organizations.

<Tip>
This endpoint requires additional permissions. Contact support to request access.
</Tip>
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Agents.SearchAsync(new AgentsSearchRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `AgentsSearchRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Agents.<a href="/src/MavenagiApi/Agents/AgentsClient.cs">ListAsync</a>(organizationReferenceId) -> IEnumerable<Agent></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Lists all agents for an organization
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Agents.ListAsync("organizationReferenceId");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationReferenceId:** `string` — The ID of the organization.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Agents.<a href="/src/MavenagiApi/Agents/AgentsClient.cs">CreateAsync</a>(organizationReferenceId, agentReferenceId, CreateAgentRequest { ... }) -> Agent</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a new agent

<Tip>
This endpoint requires additional permissions. Contact support to request access.
</Tip>
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Agents.CreateAsync(
    "organizationReferenceId",
    "agentReferenceId",
    new CreateAgentRequest { Name = "name", Environment = AgentEnvironment.Demo }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationReferenceId:** `string` — The ID of the organization.
    
</dd>
</dl>

<dl>
<dd>

**agentReferenceId:** `string` — The ID of the agent.
    
</dd>
</dl>

<dl>
<dd>

**request:** `CreateAgentRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Agents.<a href="/src/MavenagiApi/Agents/AgentsClient.cs">GetAsync</a>(organizationReferenceId, agentReferenceId) -> Agent</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get an agent
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Agents.GetAsync("organizationReferenceId", "agentReferenceId");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationReferenceId:** `string` — The ID of the organization.
    
</dd>
</dl>

<dl>
<dd>

**agentReferenceId:** `string` — The ID of the agent.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Agents.<a href="/src/MavenagiApi/Agents/AgentsClient.cs">PatchAsync</a>(organizationReferenceId, agentReferenceId, AgentPatchRequest { ... }) -> Agent</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update mutable agent fields 
All fields will overwrite the existing value on the agent only if provided.

<Tip>
This endpoint requires additional permissions. Contact support to request access.
</Tip>
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Agents.PatchAsync(
    "organizationReferenceId",
    "agentReferenceId",
    new AgentPatchRequest()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationReferenceId:** `string` — The ID of the organization.
    
</dd>
</dl>

<dl>
<dd>

**agentReferenceId:** `string` — The ID of the agent.
    
</dd>
</dl>

<dl>
<dd>

**request:** `AgentPatchRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Agents.<a href="/src/MavenagiApi/Agents/AgentsClient.cs">DeleteAsync</a>(organizationReferenceId, agentReferenceId)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete an agent.

<Tip>
This endpoint requires additional permissions. Contact support to request access.
</Tip>
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Agents.DeleteAsync("organizationReferenceId", "agentReferenceId");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationReferenceId:** `string` — The ID of the organization.
    
</dd>
</dl>

<dl>
<dd>

**agentReferenceId:** `string` — The ID of the agent.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Analytics
<details><summary><code>client.Analytics.<a href="/src/MavenagiApi/Analytics/AnalyticsClient.cs">GetConversationTableAsync</a>(ConversationTableRequest { ... }) -> ConversationTableResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves structured conversation data formatted as a table, allowing users to group, filter, and define specific metrics to display as columns.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Analytics.GetConversationTableAsync(
    new ConversationTableRequest
    {
        ConversationFilter = new ConversationFilter
        {
            Languages = new List<string>() { "en", "es" },
        },
        TimeGrouping = TimeInterval.Day,
        FieldGroupings = new List<ConversationGroupBy>()
        {
            new ConversationGroupBy { Field = ConversationField.Category },
        },
        ColumnDefinitions = new List<ConversationColumnDefinition>()
        {
            new ConversationColumnDefinition { Header = "count", Metric = new ConversationCount() },
            new ConversationColumnDefinition
            {
                Header = "avg_first_response_time",
                Metric = new ConversationAverage
                {
                    TargetField = NumericConversationField.FirstResponseTime,
                },
            },
            new ConversationColumnDefinition
            {
                Header = "percentile_handle_time",
                Metric = new ConversationPercentile
                {
                    TargetField = NumericConversationField.HandleTime,
                    Percentile = 25,
                },
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ConversationTableRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Analytics.<a href="/src/MavenagiApi/Analytics/AnalyticsClient.cs">GetConversationChartAsync</a>(object { ... }) -> object</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Fetches conversation data visualized in a chart format. Supported chart types include pie chart, date histogram, and stacked bar charts.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Analytics.GetConversationChartAsync(
    new ConversationPieChartRequest
    {
        ConversationFilter = new ConversationFilter
        {
            Languages = new List<string>() { "en", "es" },
        },
        GroupBy = new ConversationGroupBy { Field = ConversationField.Category },
        Metric = new ConversationCount(),
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `object` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Analytics.<a href="/src/MavenagiApi/Analytics/AnalyticsClient.cs">GetFeedbackTableAsync</a>(FeedbackTableRequest { ... }) -> FeedbackTableResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves structured feedback data formatted as a table, allowing users to group, filter,  and define specific metrics to display as columns.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Analytics.GetFeedbackTableAsync(
    new FeedbackTableRequest
    {
        FeedbackFilter = new FeedbackFilter
        {
            Types = new List<FeedbackType>() { FeedbackType.ThumbsUp, FeedbackType.Insert },
        },
        FieldGroupings = new List<FeedbackGroupBy>()
        {
            new FeedbackGroupBy { Field = FeedbackField.CreatedBy },
        },
        ColumnDefinitions = new List<FeedbackColumnDefinition>()
        {
            new FeedbackColumnDefinition
            {
                Header = "feedback_count",
                Metric = new FeedbackCount(),
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `FeedbackTableRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## AppSettings
<details><summary><code>client.AppSettings.<a href="/src/MavenagiApi/AppSettings/AppSettingsClient.cs">SearchAsync</a>(SearchAppSettingsRequest { ... }) -> SearchAppSettingsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Search for app settings which have the `$index` key set to the provided value.

You can set the `$index` key using the Update app settings API.

<Warning>This API currently requires an organization ID and agent ID for any agent which is installed on the app. This requirement will be removed in a future update.</Warning>
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.AppSettings.SearchAsync(new SearchAppSettingsRequest { Index = "index" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SearchAppSettingsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.AppSettings.<a href="/src/MavenagiApi/AppSettings/AppSettingsClient.cs">GetAsync</a>() -> object</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get app settings set during installation
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.AppSettings.GetAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.AppSettings.<a href="/src/MavenagiApi/AppSettings/AppSettingsClient.cs">UpdateAsync</a>(object { ... }) -> object</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update app settings. Performs a merge of the provided settings with the existing app settings.

- If a new key is provided, it will be added to the app settings.
- If an existing key is provided, it will be updated.
- No keys will be removed.

Note that if an array value is provided it will fully replace an existing value as arrays cannot be merged.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.AppSettings.UpdateAsync(
    new Dictionary<string, object>()
    {
        {
            "string",
            new Dictionary<object, object?>() { { "key", "value" } }
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `object` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Assets
<details><summary><code>client.Assets.<a href="/src/MavenagiApi/Assets/AssetsClient.cs">InitiateUploadAsync</a>(InitiateAssetUploadRequest { ... }) -> InitiateAssetUploadResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Initiate an upload. 
Returns a pre-signed URL for direct file upload and an asset ID for subsequent operations.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Assets.InitiateUploadAsync(new InitiateAssetUploadRequest { Type = "type" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `InitiateAssetUploadRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Assets.<a href="/src/MavenagiApi/Assets/AssetsClient.cs">CommitUploadAsync</a>(assetReferenceId, CommitAssetUploadRequest { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Commit an upload after successful file transfer.
Updates the asset status and makes it available for use.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Assets.CommitUploadAsync("assetReferenceId", new CommitAssetUploadRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**assetReferenceId:** `string` — The reference ID of the asset to commit (provided by the initiate call). All other entity ID fields are inferred from the API request.
    
</dd>
</dl>

<dl>
<dd>

**request:** `CommitAssetUploadRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Conversation
<details><summary><code>client.Conversation.<a href="/src/MavenagiApi/Conversation/ConversationClient.cs">InitializeAsync</a>(ConversationRequest { ... }) -> ConversationResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Initialize a new conversation. 
Only required if the ask request wishes to supply conversation level data or when syncing to external systems.

Conversations can not be modified using this API. If the conversation already exists then the existing conversation will be returned.

After initialization,
- metadata can be changed using the `updateConversationMetadata` API.
- messages can be added to the conversation with the `appendNewMessages` or `ask` APIs.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Conversation.InitializeAsync(
    new ConversationRequest
    {
        ConversationId = new EntityIdBase { ReferenceId = "referenceId" },
        Messages = new List<ConversationMessageRequest>()
        {
            new ConversationMessageRequest
            {
                ConversationMessageId = new EntityIdBase { ReferenceId = "referenceId" },
                UserId = new EntityIdBase { ReferenceId = "referenceId" },
                Text = "text",
                UserMessageType = UserConversationMessageType.User,
            },
            new ConversationMessageRequest
            {
                ConversationMessageId = new EntityIdBase { ReferenceId = "referenceId" },
                UserId = new EntityIdBase { ReferenceId = "referenceId" },
                Text = "text",
                UserMessageType = UserConversationMessageType.User,
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ConversationRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Conversation.<a href="/src/MavenagiApi/Conversation/ConversationClient.cs">PatchAsync</a>(conversationId, ConversationPatchRequest { ... }) -> ConversationResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update mutable conversation fields. 

The `appId` field can be provided to update a conversation owned by a different app. 
All other fields will overwrite the existing value on the conversation only if provided.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Conversation.PatchAsync(
    "conversation-0",
    new ConversationPatchRequest { LlmEnabled = true }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**conversationId:** `string` — The ID of the conversation to patch
    
</dd>
</dl>

<dl>
<dd>

**request:** `ConversationPatchRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Conversation.<a href="/src/MavenagiApi/Conversation/ConversationClient.cs">GetAsync</a>(conversationId, ConversationGetRequest { ... }) -> ConversationResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get a conversation
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Conversation.GetAsync("conversationId", new ConversationGetRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**conversationId:** `string` — The ID of the conversation to get
    
</dd>
</dl>

<dl>
<dd>

**request:** `ConversationGetRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Conversation.<a href="/src/MavenagiApi/Conversation/ConversationClient.cs">DeleteAsync</a>(conversationId, ConversationDeleteRequest { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Wipes a conversation of all user data. 
The conversation ID will still exist and non-user specific data will still be retained. 
Attempts to modify or add messages to the conversation will throw an error. 

<Warning>This is a destructive operation and cannot be undone. <br/><br/>
The exact fields cleared include: the conversation subject, userRequest, agentResponse. 
As well as the text response, followup questions, and backend LLM prompt of all messages.</Warning>
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Conversation.DeleteAsync(
    "conversation-0",
    new ConversationDeleteRequest { Reason = "GDPR deletion request 1234." }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**conversationId:** `string` — The ID of the conversation to delete
    
</dd>
</dl>

<dl>
<dd>

**request:** `ConversationDeleteRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Conversation.<a href="/src/MavenagiApi/Conversation/ConversationClient.cs">AppendNewMessagesAsync</a>(conversationId, IEnumerable<ConversationMessageRequest> { ... }) -> ConversationResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Append messages to an existing conversation. The conversation must be initialized first. If a message with the same ID already exists, it will be ignored. Messages do not allow modification.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Conversation.AppendNewMessagesAsync(
    "conversationId",
    new List<ConversationMessageRequest>()
    {
        new ConversationMessageRequest
        {
            ConversationMessageId = new EntityIdBase { ReferenceId = "referenceId" },
            UserId = new EntityIdBase { ReferenceId = "referenceId" },
            Text = "text",
            UserMessageType = UserConversationMessageType.User,
        },
        new ConversationMessageRequest
        {
            ConversationMessageId = new EntityIdBase { ReferenceId = "referenceId" },
            UserId = new EntityIdBase { ReferenceId = "referenceId" },
            Text = "text",
            UserMessageType = UserConversationMessageType.User,
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**conversationId:** `string` — The ID of the conversation to append messages to
    
</dd>
</dl>

<dl>
<dd>

**request:** `IEnumerable<ConversationMessageRequest>` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Conversation.<a href="/src/MavenagiApi/Conversation/ConversationClient.cs">AskAsync</a>(conversationId, AskRequest { ... }) -> ConversationResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get an answer from Maven for a given user question. If the user question or its answer already exists, 
they will be reused and will not be updated. Messages do not allow modification once generated. 

Concurrency Behavior:
- If another API call is made for the same user question while a response is mid-stream, partial answers may be returned.
- The second caller will receive a truncated or partial response depending on where the first stream is in its processing. The first caller's stream will remain unaffected and continue delivering the full response.

Known Limitation:
- The API does not currently expose metadata indicating whether a response or message is incomplete. This will be addressed in a future update.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Conversation.AskAsync(
    "conversation-0",
    new AskRequest
    {
        ConversationMessageId = new EntityIdBase { ReferenceId = "message-0" },
        UserId = new EntityIdBase { ReferenceId = "user-0" },
        Text = "How do I reset my password?",
        Attachments = new List<AttachmentRequest>()
        {
            new AttachmentRequest { Type = "image/png", Content = "iVBORw0KGgo..." },
        },
        TransientData = new Dictionary<string, string>()
        {
            { "userToken", "abcdef123" },
            { "queryApiKey", "foobar456" },
        },
        Timezone = "America/New_York",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**conversationId:** `string` — The ID of a new or existing conversation to use as context for the question
    
</dd>
</dl>

<dl>
<dd>

**request:** `AskRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Conversation.<a href="/src/MavenagiApi/Conversation/ConversationClient.cs">AskStreamAsync</a>(conversationId, AskRequest { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get an answer from Maven for a given user question with a streaming response. The response will be sent as a stream of events. 
The text portions of stream responses should be concatenated to form the full response text. 
Action and metadata events should overwrite past data and do not need concatenation.

If the user question or its answer already exists, they will be reused and will not be updated. 
Messages do not allow modification once generated.
        
Concurrency Behavior:
- If another API call is made for the same user question while a response is mid-stream, partial answers may be returned.
- The second caller will receive a truncated or partial response depending on where the first stream is in its processing. The first caller's stream will remain unaffected and continue delivering the full response.

Known Limitation:
- The API does not currently expose metadata indicating whether a response or message is incomplete. This will be addressed in a future update.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Conversation.AskStreamAsync(
    "conversation-0",
    new AskRequest
    {
        ConversationMessageId = new EntityIdBase { ReferenceId = "message-0" },
        UserId = new EntityIdBase { ReferenceId = "user-0" },
        Text = "How do I reset my password?",
        Attachments = new List<AttachmentRequest>()
        {
            new AttachmentRequest { Type = "image/png", Content = "iVBORw0KGgo..." },
        },
        TransientData = new Dictionary<string, string>()
        {
            { "userToken", "abcdef123" },
            { "queryApiKey", "foobar456" },
        },
        Timezone = "America/New_York",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**conversationId:** `string` — The ID of a new or existing conversation to use as context for the question
    
</dd>
</dl>

<dl>
<dd>

**request:** `AskRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Conversation.<a href="/src/MavenagiApi/Conversation/ConversationClient.cs">GenerateMavenSuggestionsAsync</a>(conversationId, GenerateMavenSuggestionsRequest { ... }) -> ConversationResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This method is deprecated and will be removed in a future release. Use either `ask` or `askStream` instead.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Conversation.GenerateMavenSuggestionsAsync(
    "conversationId",
    new GenerateMavenSuggestionsRequest
    {
        ConversationMessageIds = new List<EntityIdBase>()
        {
            new EntityIdBase { ReferenceId = "referenceId" },
            new EntityIdBase { ReferenceId = "referenceId" },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**conversationId:** `string` — The ID of a conversation the messages belong to
    
</dd>
</dl>

<dl>
<dd>

**request:** `GenerateMavenSuggestionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Conversation.<a href="/src/MavenagiApi/Conversation/ConversationClient.cs">AskObjectStreamAsync</a>(conversationId, AskObjectRequest { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Generate a structured object response based on a provided schema and user prompt with a streaming response. 
The response will be sent as a stream of events containing text, start, and end events.
The text portions of stream responses should be concatenated to form the full response text.

If the user question and object response already exist, they will be reused and not updated.

Concurrency Behavior:
- If another API call is made for the same user question while a response is mid-stream, partial answers may be returned.
- The second caller will receive a truncated or partial response depending on where the first stream is in its processing. The first caller's stream will remain unaffected and continue delivering the full response.

Known Limitations:
- Schema enforcement is best-effort and may not guarantee exact conformity.
- The API does not currently expose metadata indicating whether a response or message is incomplete. This will be addressed in a future update.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Conversation.AskObjectStreamAsync(
    "conversationId",
    new AskObjectRequest
    {
        Schema = "schema",
        ConversationMessageId = new EntityIdBase { ReferenceId = "referenceId" },
        UserId = new EntityIdBase { ReferenceId = "referenceId" },
        Text = "text",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**conversationId:** `string` — The ID of a new or existing conversation to use as context for the object generation request
    
</dd>
</dl>

<dl>
<dd>

**request:** `AskObjectRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Conversation.<a href="/src/MavenagiApi/Conversation/ConversationClient.cs">CategorizeAsync</a>(conversationId) -> CategorizationResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Uses an LLM flow to categorize the conversation. Experimental.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Conversation.CategorizeAsync("conversationId");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**conversationId:** `string` — The ID of the conversation to categorize
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Conversation.<a href="/src/MavenagiApi/Conversation/ConversationClient.cs">CreateFeedbackAsync</a>(FeedbackRequest { ... }) -> Feedback</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update feedback or create it if it doesn't exist
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Conversation.CreateFeedbackAsync(
    new FeedbackRequest
    {
        FeedbackId = new EntityIdBase { ReferenceId = "feedback-0" },
        UserId = new EntityIdBase { ReferenceId = "user-0" },
        ConversationId = new EntityIdBase { ReferenceId = "conversation-0" },
        ConversationMessageId = new EntityIdBase { ReferenceId = "message-1" },
        Type = FeedbackType.ThumbsUp,
        Text = "Great answer!",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `FeedbackRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Conversation.<a href="/src/MavenagiApi/Conversation/ConversationClient.cs">SubmitActionFormAsync</a>(conversationId, SubmitActionFormRequest { ... }) -> ConversationResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Submit a filled out action form
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Conversation.SubmitActionFormAsync(
    "conversationId",
    new SubmitActionFormRequest
    {
        ActionFormId = "actionFormId",
        Parameters = new Dictionary<string, OneOf<object, ActionFormAttachment>>()
        {
            {
                "parameters",
                new Dictionary<object, object?>() { { "key", "value" } }
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**conversationId:** `string` — The ID of a conversation the form being submitted belongs to
    
</dd>
</dl>

<dl>
<dd>

**request:** `SubmitActionFormRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Conversation.<a href="/src/MavenagiApi/Conversation/ConversationClient.cs">AddConversationMetadataAsync</a>(conversationId, Dictionary<string, string> { ... }) -> Dictionary<string, string></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Replaced by `updateConversationMetadata`. 

Adds metadata to an existing conversation. If a metadata field already exists, it will be overwritten.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Conversation.AddConversationMetadataAsync(
    "conversationId",
    new Dictionary<string, string>() { { "string", "string" } }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**conversationId:** `string` — The ID of a conversation the metadata being added belongs to
    
</dd>
</dl>

<dl>
<dd>

**request:** `Dictionary<string, string>` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Conversation.<a href="/src/MavenagiApi/Conversation/ConversationClient.cs">UpdateConversationMetadataAsync</a>(conversationId, UpdateMetadataRequest { ... }) -> ConversationMetadata</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update metadata supplied by the calling application for an existing conversation. 
Does not modify metadata saved by other apps.

If a metadata field already exists for the calling app, it will be overwritten. 
If it does not exist, it will be added. Will not remove metadata fields.

Returns all metadata saved by any app on the conversation.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Conversation.UpdateConversationMetadataAsync(
    "conversation-0",
    new UpdateMetadataRequest
    {
        AppId = "conversation-owning-app",
        Values = new Dictionary<string, string>() { { "key", "newValue" } },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**conversationId:** `string` — The ID of the conversation to modify metadata for
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdateMetadataRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Conversation.<a href="/src/MavenagiApi/Conversation/ConversationClient.cs">SearchAsync</a>(ConversationsSearchRequest { ... }) -> ConversationsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Search conversations
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Conversation.SearchAsync(new ConversationsSearchRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ConversationsSearchRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Conversation.<a href="/src/MavenagiApi/Conversation/ConversationClient.cs">DeliverMessageAsync</a>(object { ... }) -> DeliverMessageResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deliver a message to a user or conversation.

<Warning>
Currently, messages can only be successfully delivered to conversations with the `ASYNC` capability that are `open`. 
User message delivery is not yet supported.
</Warning>
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Conversation.DeliverMessageAsync(
    new DeliverUserMessageRequest
    {
        UserId = new EntityIdWithoutAgent
        {
            Type = EntityType.Agent,
            AppId = "appId",
            ReferenceId = "referenceId",
        },
        Message = new ConversationMessageRequest
        {
            ConversationMessageId = new EntityIdBase { ReferenceId = "referenceId" },
            UserId = new EntityIdBase { ReferenceId = "referenceId" },
            Text = "text",
            UserMessageType = UserConversationMessageType.User,
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `object` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Events
<details><summary><code>client.Events.<a href="/src/MavenagiApi/Events/EventsClient.cs">CreateAsync</a>(object { ... }) -> object</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a new event
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Events.CreateAsync(
    new NovelUserEvent
    {
        Id = new EntityIdBase { ReferenceId = "referenceId" },
        EventName = UserEventName.ButtonClicked,
        UserInfo = new EventUserInfoBase { Id = new EntityIdBase { ReferenceId = "referenceId" } },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `object` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Events.<a href="/src/MavenagiApi/Events/EventsClient.cs">SearchAsync</a>(EventsSearchRequest { ... }) -> EventsSearchResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Search events
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Events.SearchAsync(new EventsSearchRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `EventsSearchRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Inbox
<details><summary><code>client.Inbox.<a href="/src/MavenagiApi/Inbox/InboxClient.cs">SearchAsync</a>(InboxSearchRequest { ... }) -> InboxSearchResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a paginated list of inbox items for an agent.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Inbox.SearchAsync(new InboxSearchRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `InboxSearchRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Inbox.<a href="/src/MavenagiApi/Inbox/InboxClient.cs">GetAsync</a>(inboxItemId, InboxItemRequest { ... }) -> object</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve details of a specific inbox item by its ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Inbox.GetAsync("inboxItemId", new InboxItemRequest { AppId = "appId" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**inboxItemId:** `string` — The ID of the inbox item to get. All other entity ID fields are inferred from the request.
    
</dd>
</dl>

<dl>
<dd>

**request:** `InboxItemRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Inbox.<a href="/src/MavenagiApi/Inbox/InboxClient.cs">GetFixAsync</a>(inboxItemFixId, InboxItemFixRequest { ... }) -> object</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a suggested fix. Includes document information if the fix is a Missing Knowledge suggestion.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Inbox.GetFixAsync("inboxItemFixId", new InboxItemFixRequest { AppId = "appId" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**inboxItemFixId:** `string` — Unique identifier for the inbox fix.
    
</dd>
</dl>

<dl>
<dd>

**request:** `InboxItemFixRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Inbox.<a href="/src/MavenagiApi/Inbox/InboxClient.cs">ApplyFixesAsync</a>(inboxItemId, ApplyFixesRequest { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Apply a list of fixes belonging to an inbox item.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Inbox.ApplyFixesAsync(
    "inboxItemId",
    new ApplyFixesRequest
    {
        AppId = "appId",
        FixReferenceIds = new List<string>() { "fixReferenceIds", "fixReferenceIds" },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**inboxItemId:** `string` — Unique identifier for the inbox item.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ApplyFixesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Inbox.<a href="/src/MavenagiApi/Inbox/InboxClient.cs">IgnoreAsync</a>(inboxItemId, InboxItemIgnoreRequest { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Ignore a specific inbox item by its ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Inbox.IgnoreAsync("inboxItemId", new InboxItemIgnoreRequest { AppId = "appId" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**inboxItemId:** `string` — Unique identifier for the inbox item.
    
</dd>
</dl>

<dl>
<dd>

**request:** `InboxItemIgnoreRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Knowledge
<details><summary><code>client.Knowledge.<a href="/src/MavenagiApi/Knowledge/KnowledgeClient.cs">SearchKnowledgeBasesAsync</a>(KnowledgeBaseSearchRequest { ... }) -> KnowledgeBasesResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Search knowledge bases
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Knowledge.SearchKnowledgeBasesAsync(new KnowledgeBaseSearchRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `KnowledgeBaseSearchRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Knowledge.<a href="/src/MavenagiApi/Knowledge/KnowledgeClient.cs">CreateOrUpdateKnowledgeBaseAsync</a>(KnowledgeBaseRequest { ... }) -> KnowledgeBaseResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update a knowledge base or create it if it doesn't exist.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Knowledge.CreateOrUpdateKnowledgeBaseAsync(
    new KnowledgeBaseRequest
    {
        KnowledgeBaseId = new EntityIdBase { ReferenceId = "help-center" },
        Name = "Help center",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `KnowledgeBaseRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Knowledge.<a href="/src/MavenagiApi/Knowledge/KnowledgeClient.cs">GetKnowledgeBaseAsync</a>(knowledgeBaseReferenceId, KnowledgeBaseGetRequest { ... }) -> KnowledgeBaseResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get an existing knowledge base by its supplied ID
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Knowledge.GetKnowledgeBaseAsync("help-center", new KnowledgeBaseGetRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**knowledgeBaseReferenceId:** `string` — The reference ID of the knowledge base to get. All other entity ID fields are inferred from the request.
    
</dd>
</dl>

<dl>
<dd>

**request:** `KnowledgeBaseGetRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Knowledge.<a href="/src/MavenagiApi/Knowledge/KnowledgeClient.cs">PatchKnowledgeBaseAsync</a>(knowledgeBaseReferenceId, KnowledgeBasePatchRequest { ... }) -> KnowledgeBaseResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update mutable knowledge base fields

The `appId` field can be provided to update a knowledge base owned by a different app. 
All other fields will overwrite the existing value on the knowledge base only if provided.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Knowledge.PatchKnowledgeBaseAsync(
    "knowledgeBaseReferenceId",
    new KnowledgeBasePatchRequest()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**knowledgeBaseReferenceId:** `string` — The reference ID of the knowledge base to patch.
    
</dd>
</dl>

<dl>
<dd>

**request:** `KnowledgeBasePatchRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Knowledge.<a href="/src/MavenagiApi/Knowledge/KnowledgeClient.cs">CreateKnowledgeBaseVersionAsync</a>(knowledgeBaseReferenceId, KnowledgeBaseVersionRequest { ... }) -> KnowledgeBaseVersion</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a new knowledge base version.

If an existing version is in progress, then that version will be finalized in an error state.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Knowledge.CreateKnowledgeBaseVersionAsync(
    "help-center",
    new KnowledgeBaseVersionRequest { Type = KnowledgeBaseVersionType.Full }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**knowledgeBaseReferenceId:** `string` — The reference ID of the knowledge base to create a version for. All other entity ID fields are inferred from the request.
    
</dd>
</dl>

<dl>
<dd>

**request:** `KnowledgeBaseVersionRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Knowledge.<a href="/src/MavenagiApi/Knowledge/KnowledgeClient.cs">FinalizeKnowledgeBaseVersionAsync</a>(knowledgeBaseReferenceId, FinalizeKnowledgeBaseVersionRequest { ... }) -> KnowledgeBaseVersion</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Finalize the latest knowledge base version. Required to indicate the version is complete. Will throw an exception if the latest version is not in progress.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Knowledge.FinalizeKnowledgeBaseVersionAsync(
    "help-center",
    new FinalizeKnowledgeBaseVersionRequest
    {
        VersionId = new EntityIdWithoutAgent
        {
            Type = EntityType.KnowledgeBaseVersion,
            ReferenceId = "versionId",
            AppId = "maven",
        },
        Status = KnowledgeBaseVersionFinalizeStatus.Succeeded,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**knowledgeBaseReferenceId:** `string` — The reference ID of the knowledge base to finalize a version for. All other entity ID fields are inferred from the request.
    
</dd>
</dl>

<dl>
<dd>

**request:** `FinalizeKnowledgeBaseVersionRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Knowledge.<a href="/src/MavenagiApi/Knowledge/KnowledgeClient.cs">ListKnowledgeBaseVersionsAsync</a>(knowledgeBaseReferenceId, KnowledgeBaseVersionsListRequest { ... }) -> KnowledgeBaseVersionsListResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

List all active versions for a knowledge base. Returns the most recent versions first.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Knowledge.ListKnowledgeBaseVersionsAsync(
    "knowledgeBaseReferenceId",
    new KnowledgeBaseVersionsListRequest()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**knowledgeBaseReferenceId:** `string` — The reference ID of the knowledge base to list versions for. All other entity ID fields are inferred from the request.
    
</dd>
</dl>

<dl>
<dd>

**request:** `KnowledgeBaseVersionsListRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Knowledge.<a href="/src/MavenagiApi/Knowledge/KnowledgeClient.cs">SearchKnowledgeDocumentsAsync</a>(KnowledgeDocumentSearchRequest { ... }) -> KnowledgeDocumentsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Search knowledge documents
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Knowledge.SearchKnowledgeDocumentsAsync(new KnowledgeDocumentSearchRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `KnowledgeDocumentSearchRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Knowledge.<a href="/src/MavenagiApi/Knowledge/KnowledgeClient.cs">CreateKnowledgeDocumentAsync</a>(knowledgeBaseReferenceId, KnowledgeDocumentRequest { ... }) -> KnowledgeDocumentResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create or update a knowledge document. Requires an existing knowledge base with an in progress version. 
Will throw an exception if the latest version is not in progress.
        
<Tip>
This API maintains document version history. If for the same reference ID none of the `title`, `text`, `sourceUrl`, `metadata` fields 
have changed, a new document version will not be created. The existing version will be reused.
</Tip>
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Knowledge.CreateKnowledgeDocumentAsync(
    "help-center",
    new KnowledgeDocumentRequest
    {
        KnowledgeDocumentId = new EntityIdBase { ReferenceId = "getting-started" },
        VersionId = new EntityIdWithoutAgent
        {
            Type = EntityType.KnowledgeBaseVersion,
            ReferenceId = "versionId",
            AppId = "maven",
        },
        ContentType = KnowledgeDocumentContentType.Markdown,
        Content = "## Getting started\\nThis is a getting started guide for the help center.",
        Title = "Getting started",
        Metadata = new Dictionary<string, string>() { { "category", "getting-started" } },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**knowledgeBaseReferenceId:** `string` — The reference ID of the knowledge base to create a document for. All other entity ID fields are inferred from the request.
    
</dd>
</dl>

<dl>
<dd>

**request:** `KnowledgeDocumentRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Knowledge.<a href="/src/MavenagiApi/Knowledge/KnowledgeClient.cs">DeleteKnowledgeDocumentAsync</a>(knowledgeBaseReferenceId, knowledgeDocumentReferenceId, KnowledgeDeleteRequest { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete knowledge document from a specific version. 
Requires an existing knowledge base with an in progress version of type PARTIAL. Will throw an exception if the version is not in progress.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Knowledge.DeleteKnowledgeDocumentAsync(
    "help-center",
    "getting-started",
    new KnowledgeDeleteRequest
    {
        VersionId = new EntityIdWithoutAgent
        {
            Type = EntityType.KnowledgeBaseVersion,
            AppId = "maven",
            ReferenceId = "versionId",
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**knowledgeBaseReferenceId:** `string` — The reference ID of the knowledge base that contains the document to delete. All other entity ID fields are inferred from the request
    
</dd>
</dl>

<dl>
<dd>

**knowledgeDocumentReferenceId:** `string` — The reference ID of the knowledge document to delete. All other entity ID fields are inferred from the request.
    
</dd>
</dl>

<dl>
<dd>

**request:** `KnowledgeDeleteRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Knowledge.<a href="/src/MavenagiApi/Knowledge/KnowledgeClient.cs">GetKnowledgeDocumentAsync</a>(knowledgeBaseVersionReferenceId, knowledgeDocumentReferenceId, KnowledgeDocumentGetRequest { ... }) -> KnowledgeDocumentResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get a knowledge document by its supplied version and document IDs. Response includes document content in markdown format.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Knowledge.GetKnowledgeDocumentAsync(
    "knowledgeBaseVersionReferenceId",
    "knowledgeDocumentReferenceId",
    new KnowledgeDocumentGetRequest { KnowledgeBaseVersionAppId = "knowledgeBaseVersionAppId" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**knowledgeBaseVersionReferenceId:** `string` — The reference ID of the knowledge base version that contains the document. All other entity ID fields are inferred from the request.
    
</dd>
</dl>

<dl>
<dd>

**knowledgeDocumentReferenceId:** `string` — The reference ID of the knowledge document to get. All other entity ID fields are inferred from the request.
    
</dd>
</dl>

<dl>
<dd>

**request:** `KnowledgeDocumentGetRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Organizations
<details><summary><code>client.Organizations.<a href="/src/MavenagiApi/Organizations/OrganizationsClient.cs">CreateAsync</a>(organizationReferenceId, CreateOrganizationRequest { ... }) -> Organization</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a new organization.

<Tip>
This endpoint requires additional permissions. Contact support to request access.
</Tip>
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.CreateAsync(
    "organizationReferenceId",
    new CreateOrganizationRequest { Name = "name", DefaultLanguage = "defaultLanguage" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationReferenceId:** `string` — The reference ID of the organization.
    
</dd>
</dl>

<dl>
<dd>

**request:** `CreateOrganizationRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.<a href="/src/MavenagiApi/Organizations/OrganizationsClient.cs">GetAsync</a>(organizationReferenceId) -> Organization</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get an organization by ID
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.GetAsync("organizationReferenceId");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationReferenceId:** `string` — The reference ID of the organization.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.<a href="/src/MavenagiApi/Organizations/OrganizationsClient.cs">PatchAsync</a>(organizationReferenceId, OrganizationPatchRequest { ... }) -> Organization</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update mutable organization fields.
All fields will overwrite the existing value on the organization only if provided.

<Tip>
This endpoint requires additional permissions. Contact support to request access.
</Tip>
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.PatchAsync("organizationReferenceId", new OrganizationPatchRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationReferenceId:** `string` — The reference ID of the organization.
    
</dd>
</dl>

<dl>
<dd>

**request:** `OrganizationPatchRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.<a href="/src/MavenagiApi/Organizations/OrganizationsClient.cs">DeleteAsync</a>(organizationReferenceId)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete an organization.

<Tip>
This endpoint requires additional permissions. Contact support to request access.
</Tip>
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.DeleteAsync("organizationReferenceId");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationReferenceId:** `string` — The reference ID of the organization.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.<a href="/src/MavenagiApi/Organizations/OrganizationsClient.cs">GetConversationTableAsync</a>(ConversationTableRequest { ... }) -> ConversationTableResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves structured conversation data across all organizations, formatted as a table, 
allowing users to group, filter, and define specific metrics to display as columns.

<Tip>
This endpoint requires additional permissions. Contact support to request access.
</Tip>
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.GetConversationTableAsync(
    new ConversationTableRequest
    {
        ConversationFilter = new ConversationFilter
        {
            Languages = new List<string>() { "en", "es" },
        },
        TimeGrouping = TimeInterval.Day,
        FieldGroupings = new List<ConversationGroupBy>()
        {
            new ConversationGroupBy { Field = ConversationField.Category },
        },
        ColumnDefinitions = new List<ConversationColumnDefinition>()
        {
            new ConversationColumnDefinition { Header = "count", Metric = new ConversationCount() },
            new ConversationColumnDefinition
            {
                Header = "avg_first_response_time",
                Metric = new ConversationAverage
                {
                    TargetField = NumericConversationField.FirstResponseTime,
                },
            },
            new ConversationColumnDefinition
            {
                Header = "percentile_handle_time",
                Metric = new ConversationPercentile
                {
                    TargetField = NumericConversationField.HandleTime,
                    Percentile = 25,
                },
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ConversationTableRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.<a href="/src/MavenagiApi/Organizations/OrganizationsClient.cs">GetConversationChartAsync</a>(object { ... }) -> object</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Fetches conversation data across all organizations, visualized in a chart format. 
Supported chart types include pie chart, date histogram, and stacked bar charts.

<Tip>
This endpoint requires additional permissions. Contact support to request access.
</Tip>
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.GetConversationChartAsync(
    new ConversationPieChartRequest
    {
        ConversationFilter = new ConversationFilter
        {
            Languages = new List<string>() { "en", "es" },
        },
        GroupBy = new ConversationGroupBy { Field = ConversationField.Category },
        Metric = new ConversationCount(),
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `object` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Segments
<details><summary><code>client.Segments.<a href="/src/MavenagiApi/Segments/SegmentsClient.cs">SearchAsync</a>(SegmentsSearchRequest { ... }) -> SegmentsSearchResponse</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Segments.SearchAsync(new SegmentsSearchRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SegmentsSearchRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Segments.<a href="/src/MavenagiApi/Segments/SegmentsClient.cs">CreateOrUpdateAsync</a>(SegmentRequest { ... }) -> SegmentResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update a segment or create it if it doesn't exist.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Segments.CreateOrUpdateAsync(
    new SegmentRequest
    {
        SegmentId = new EntityIdBase { ReferenceId = "admin-users" },
        Name = "Admin users",
        Precondition = new PreconditionGroup
        {
            Operator = PreconditionGroupOperator.And,
            Preconditions = new List<object>()
            {
                new MetadataPrecondition { Key = "userKey" },
                new MetadataPrecondition { Key = "userKey2" },
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SegmentRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Segments.<a href="/src/MavenagiApi/Segments/SegmentsClient.cs">GetAsync</a>(segmentReferenceId, SegmentGetRequest { ... }) -> SegmentResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get a segment by its supplied ID
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Segments.GetAsync("admin-users", new SegmentGetRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**segmentReferenceId:** `string` — The reference ID of the segment to get. All other entity ID fields are inferred from the request.
    
</dd>
</dl>

<dl>
<dd>

**request:** `SegmentGetRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Segments.<a href="/src/MavenagiApi/Segments/SegmentsClient.cs">PatchAsync</a>(segmentReferenceId, SegmentPatchRequest { ... }) -> SegmentResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update mutable segment fields

The `appId` field can be provided to update a segment owned by a different app. 
All other fields will overwrite the existing value on the segment only if provided.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Segments.PatchAsync("segmentReferenceId", new SegmentPatchRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**segmentReferenceId:** `string` — The reference ID of the segment to update. All other entity ID fields are inferred from the request.
    
</dd>
</dl>

<dl>
<dd>

**request:** `SegmentPatchRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Translations
<details><summary><code>client.Translations.<a href="/src/MavenagiApi/Translations/TranslationsClient.cs">TranslateAsync</a>(TranslationRequest { ... }) -> TranslationResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Translate text from one language to another
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Translations.TranslateAsync(
    new TranslationRequest { Text = "Hello world", TargetLanguage = "es" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `TranslationRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Triggers
<details><summary><code>client.Triggers.<a href="/src/MavenagiApi/Triggers/TriggersClient.cs">SearchAsync</a>(EventTriggersSearchRequest { ... }) -> EventTriggersSearchResponse</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Triggers.SearchAsync(new EventTriggersSearchRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `EventTriggersSearchRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Triggers.<a href="/src/MavenagiApi/Triggers/TriggersClient.cs">CreateOrUpdateAsync</a>(EventTriggerRequest { ... }) -> EventTriggerResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update an event trigger or create it if it doesn't exist.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Triggers.CreateOrUpdateAsync(
    new EventTriggerRequest
    {
        TriggerId = new EntityIdBase { ReferenceId = "store-in-snowflake" },
        Description = "Stores conversation data in Snowflake",
        Type = EventTriggerType.ConversationCreated,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `EventTriggerRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Triggers.<a href="/src/MavenagiApi/Triggers/TriggersClient.cs">GetAsync</a>(triggerReferenceId) -> EventTriggerResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get an event trigger by its supplied ID
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Triggers.GetAsync("store-in-snowflake");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**triggerReferenceId:** `string` — The reference ID of the event trigger to get. All other entity ID fields are inferred from the request.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Triggers.<a href="/src/MavenagiApi/Triggers/TriggersClient.cs">DeleteAsync</a>(triggerReferenceId)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete an event trigger
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Triggers.DeleteAsync("store-in-snowflake");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**triggerReferenceId:** `string` — The reference ID of the event trigger to delete. All other entity ID fields are inferred from the request.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Triggers.<a href="/src/MavenagiApi/Triggers/TriggersClient.cs">PartialUpdateAsync</a>(triggerReferenceId, PartialUpdateRequest { ... }) -> EventTriggerResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates an event trigger. Only the enabled field is editable.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Triggers.PartialUpdateAsync(
    "triggerReferenceId",
    new PartialUpdateRequest { Body = new TriggerPartialUpdate() }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**triggerReferenceId:** `string` — The reference ID of the event trigger to update. All other entity ID fields are inferred from the request.
    
</dd>
</dl>

<dl>
<dd>

**request:** `PartialUpdateRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Users
<details><summary><code>client.Users.<a href="/src/MavenagiApi/Users/UsersClient.cs">SearchAsync</a>(AgentUserSearchRequest { ... }) -> AgentUserSearchResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Search across all agent users on an agent.

Agent users are a merged view of the users created by individual apps.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.SearchAsync(new AgentUserSearchRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `AgentUserSearchRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.<a href="/src/MavenagiApi/Users/UsersClient.cs">GetAgentUserAsync</a>(userId) -> AgentUser</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get an agent user by its supplied ID.

Agent users are a merged view of the users created by individual apps.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.GetAgentUserAsync("userId");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**userId:** `string` — The ID of the agent user to get.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.<a href="/src/MavenagiApi/Users/UsersClient.cs">CreateOrUpdateAsync</a>(AppUserRequest { ... }) -> AppUserResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update an app user or create it if it doesn't exist.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.CreateOrUpdateAsync(
    new AppUserRequest
    {
        UserId = new EntityIdBase { ReferenceId = "user-0" },
        Identifiers = new HashSet<AppUserIdentifier>()
        {
            new AppUserIdentifier
            {
                Value = "joe@myapp.com",
                Type = AppUserIdentifyingPropertyType.Email,
            },
        },
        Data = new Dictionary<string, UserData>()
        {
            {
                "name",
                new UserData { Value = "Joe", Visibility = VisibilityType.Visible }
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `AppUserRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.<a href="/src/MavenagiApi/Users/UsersClient.cs">GetAsync</a>(userId, UserGetRequest { ... }) -> AppUserResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get an app user by its supplied ID
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.GetAsync("user-0", new UserGetRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**userId:** `string` — The reference ID of the app user to get. All other entity ID fields are inferred from the request.
    
</dd>
</dl>

<dl>
<dd>

**request:** `UserGetRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.<a href="/src/MavenagiApi/Users/UsersClient.cs">DeleteAsync</a>(userId, UserDeleteRequest { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes all identifiers and user data saved by the specified app. 
Does not modify data or identifiers saved by other apps.

If this user is linked to a user from another app, it will not be unlinked. Unlinking of users is not yet supported.

<Warning>This is a destructive operation and cannot be undone.</Warning>
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.DeleteAsync("user-0", new UserDeleteRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**userId:** `string` — The reference ID of the app user to delete. All other entity ID fields are inferred from the request.
    
</dd>
</dl>

<dl>
<dd>

**request:** `UserDeleteRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>
