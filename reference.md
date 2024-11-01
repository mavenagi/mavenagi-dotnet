# Reference
## Actions
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

<details><summary><code>client.Actions.<a href="/src/MavenagiApi/Actions/ActionsClient.cs">GetAsync</a>(actionReferenceId) -> ActionResponse</code></summary>
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
await client.Actions.GetAsync("get-balance");
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

## AppSettings
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

## Conversation
<details><summary><code>client.Conversation.<a href="/src/MavenagiApi/Conversation/ConversationClient.cs">InitializeAsync</a>(ConversationRequest { ... }) -> ConversationResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Initialize a new conversation. Only required if the ask request wishes to supply conversation level data or when syncing to external systems.
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
        ConversationId = new EntityIdBase { ReferenceId = "string" },
        Messages = new List<ConversationMessageRequest>()
        {
            new ConversationMessageRequest
            {
                ConversationMessageId = new EntityIdBase { ReferenceId = "string" },
                UserId = new EntityIdBase { ReferenceId = "string" },
                Text = "string",
                UserMessageType = UserConversationMessageType.User,
                CreatedAt = new DateTime(2024, 01, 15, 09, 30, 00, 000),
                UpdatedAt = new DateTime(2024, 01, 15, 09, 30, 00, 000),
            },
        },
        ResponseConfig = new ResponseConfig
        {
            Capabilities = new List<Capability>() { Capability.Markdown },
            IsCopilot = true,
            ResponseLength = ResponseLength.Short,
        },
        Subject = "string",
        Url = "string",
        CreatedAt = new DateTime(2024, 01, 15, 09, 30, 00, 000),
        UpdatedAt = new DateTime(2024, 01, 15, 09, 30, 00, 000),
        Tags = new HashSet<string>() { "string" },
        Metadata = new Dictionary<string, string>() { { "string", "string" } },
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
await client.Conversation.GetAsync("string", new ConversationGetRequest { AppId = "string" });
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

<details><summary><code>client.Conversation.<a href="/src/MavenagiApi/Conversation/ConversationClient.cs">AppendNewMessagesAsync</a>(conversationId, IEnumerable<ConversationMessageRequest> { ... }) -> ConversationResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Append messages to an existing conversation. The conversation must be initialized first. If a message with the same id already exists, it will be ignored.
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
    "string",
    new List<ConversationMessageRequest>()
    {
        new ConversationMessageRequest
        {
            ConversationMessageId = new EntityIdBase { ReferenceId = "string" },
            UserId = new EntityIdBase { ReferenceId = "string" },
            Text = "string",
            UserMessageType = UserConversationMessageType.User,
            CreatedAt = new DateTime(2024, 01, 15, 09, 30, 00, 000),
            UpdatedAt = new DateTime(2024, 01, 15, 09, 30, 00, 000),
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

Ask a question
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
    "string",
    new AskRequest
    {
        ConversationMessageId = new EntityIdBase { ReferenceId = "message-1" },
        UserId = new EntityIdBase { ReferenceId = "user-1" },
        Text = "How do I reset my password?",
        Attachments = new List<Attachment>()
        {
            new Attachment { Type = "image/png", Content = "iVBORw0KGgo..." },
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

Ask a question with a streaming response. The response will be sent as a stream of events. The text portions of stream responses should be concatenated to form the full response text. Action and metadata events should overwrite past data and do not need concatenation.
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
        ConversationMessageId = new EntityIdBase { ReferenceId = "message-1" },
        UserId = new EntityIdBase { ReferenceId = "user-1" },
        Text = "How do I reset my password?",
        Attachments = new List<Attachment>()
        {
            new Attachment { Type = "image/png", Content = "iVBORw0KGgo..." },
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

Generate a response suggestion for each requested message id in a conversation
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
    "string",
    new GenerateMavenSuggestionsRequest
    {
        ConversationMessageIds = new List<EntityIdBase>()
        {
            new EntityIdBase { ReferenceId = "string" },
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
await client.Conversation.CategorizeAsync("string");
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

Create feedback
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
        FeedbackId = new EntityIdBase { ReferenceId = "string" },
        ConversationId = new EntityIdBase { ReferenceId = "string" },
        ConversationMessageId = new EntityIdBase { ReferenceId = "string" },
        Type = FeedbackType.ThumbsUp,
        Text = "string",
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
    "string",
    new SubmitActionFormRequest
    {
        ActionFormId = "string",
        Parameters = new Dictionary<string, object>()
        {
            {
                "string",
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

Add metadata to an existing conversation. If a metadata field already exists, it will be overwritten.
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
    "string",
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

## Knowledge
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
        Type = KnowledgeBaseType.Api,
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

<details><summary><code>client.Knowledge.<a href="/src/MavenagiApi/Knowledge/KnowledgeClient.cs">GetKnowledgeBaseAsync</a>(knowledgeBaseReferenceId) -> KnowledgeBaseResponse</code></summary>
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
await client.Knowledge.GetKnowledgeBaseAsync("help-center");
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
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Knowledge.<a href="/src/MavenagiApi/Knowledge/KnowledgeClient.cs">CreateKnowledgeBaseVersionAsync</a>(knowledgeBaseReferenceId, KnowledgeBaseVersion { ... }) -> KnowledgeBaseVersion</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a new knowledge base version. Only supported on API knowledge bases. Will throw an exception if there is an existing version in progress.
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
    new KnowledgeBaseVersion { Type = KnowledgeBaseVersionType.Full }
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

**request:** `KnowledgeBaseVersion` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Knowledge.<a href="/src/MavenagiApi/Knowledge/KnowledgeClient.cs">FinalizeKnowledgeBaseVersionAsync</a>(knowledgeBaseReferenceId)</code></summary>
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
await client.Knowledge.FinalizeKnowledgeBaseVersionAsync("help-center");
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

Create knowledge document. Requires an existing knowledge base with an in progress version. Will throw an exception if the latest version is not in progress.
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
        ContentType = KnowledgeDocumentContentType.Markdown,
        Content = "## Getting started\\nThis is a getting started guide for the help center.",
        Title = "Getting started",
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

<details><summary><code>client.Knowledge.<a href="/src/MavenagiApi/Knowledge/KnowledgeClient.cs">UpdateKnowledgeDocumentAsync</a>(knowledgeBaseReferenceId, KnowledgeDocumentRequest { ... }) -> KnowledgeDocumentResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Not yet implemented. Update knowledge document. Requires an existing knowledge base with an in progress version of type PARTIAL. Will throw an exception if the latest version is not in progress.
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
await client.Knowledge.UpdateKnowledgeDocumentAsync(
    "help-center",
    new KnowledgeDocumentRequest
    {
        KnowledgeDocumentId = new EntityIdBase { ReferenceId = "getting-started" },
        ContentType = KnowledgeDocumentContentType.Markdown,
        Content = "## Getting started\\nThis is a getting started guide for the help center.",
        Title = "Getting started",
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

**knowledgeBaseReferenceId:** `string` — The reference ID of the knowledge base that contains the document to update. All other entity ID fields are inferred from the request.
    
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

<details><summary><code>client.Knowledge.<a href="/src/MavenagiApi/Knowledge/KnowledgeClient.cs">DeleteKnowledgeDocumentAsync</a>(knowledgeBaseReferenceId, knowledgeDocumentReferenceId)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Not yet implemented. Delete knowledge document. Requires an existing knowledge base with an in progress version of type PARTIAL. Will throw an exception if the latest version is not in progress.
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
await client.Knowledge.DeleteKnowledgeDocumentAsync("help-center", "getting-started");
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

## Users
<details><summary><code>client.Users.<a href="/src/MavenagiApi/Users/UsersClient.cs">CreateOrUpdateAsync</a>(AppUserRequest { ... }) -> AppUserResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update a user or create it if it doesn't exist.
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

<details><summary><code>client.Users.<a href="/src/MavenagiApi/Users/UsersClient.cs">GetAsync</a>(userId) -> AppUserResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get a user by its supplied ID
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
await client.Users.GetAsync("user-0");
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

**userId:** `string` — The reference ID of the user to get. All other entity ID fields are inferred from the request.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>
