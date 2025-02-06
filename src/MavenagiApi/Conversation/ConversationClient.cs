using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public partial class ConversationClient
{
    private RawClient _client;

    internal ConversationClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Initialize a new conversation. Only required if the ask request wishes to supply conversation level data or when syncing to external systems.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Conversation.InitializeAsync(
    ///     new ConversationRequest
    ///     {
    ///         ConversationId = new EntityIdBase { ReferenceId = "referenceId" },
    ///         Messages = new List&lt;ConversationMessageRequest&gt;()
    ///         {
    ///             new ConversationMessageRequest
    ///             {
    ///                 ConversationMessageId = new EntityIdBase { ReferenceId = "referenceId" },
    ///             },
    ///             new ConversationMessageRequest
    ///             {
    ///                 ConversationMessageId = new EntityIdBase { ReferenceId = "referenceId" },
    ///             },
    ///         },
    ///     }
    /// );
    /// </code>
    /// </example>
    public async Task<ConversationResponse> InitializeAsync(
        ConversationRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Post,
                Path = "/v1/conversations",
                Body = request,
                Options = options,
            },
            cancellationToken
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            try
            {
                return JsonUtils.Deserialize<ConversationResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new MavenAGIException("Failed to deserialize response", e);
            }
        }

        try
        {
            switch (response.StatusCode)
            {
                case 404:
                    throw new NotFoundError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
                case 400:
                    throw new BadRequestError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
                case 500:
                    throw new ServerError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
            }
        }
        catch (JsonException)
        {
            // unable to map error response, throwing generic error
        }
        throw new MavenAGIApiException(
            $"Error with status code {response.StatusCode}",
            response.StatusCode,
            responseBody
        );
    }

    /// <summary>
    /// Get a conversation
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Conversation.GetAsync("conversationId", new ConversationGetRequest());
    /// </code>
    /// </example>
    public async Task<ConversationResponse> GetAsync(
        string conversationId,
        ConversationGetRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.AppId != null)
        {
            _query["appId"] = request.AppId;
        }
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Get,
                Path = $"/v1/conversations/{conversationId}",
                Query = _query,
                Options = options,
            },
            cancellationToken
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            try
            {
                return JsonUtils.Deserialize<ConversationResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new MavenAGIException("Failed to deserialize response", e);
            }
        }

        try
        {
            switch (response.StatusCode)
            {
                case 404:
                    throw new NotFoundError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
                case 400:
                    throw new BadRequestError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
                case 500:
                    throw new ServerError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
            }
        }
        catch (JsonException)
        {
            // unable to map error response, throwing generic error
        }
        throw new MavenAGIApiException(
            $"Error with status code {response.StatusCode}",
            response.StatusCode,
            responseBody
        );
    }

    /// <summary>
    /// Wipes a conversation of all user data.
    /// The conversation ID will still exist and non-user specific data will still be retained.
    /// Attempts to modify or add messages to the conversation will throw an error.
    ///
    /// &lt;Warning&gt;This is a destructive operation and cannot be undone. &lt;br/&gt;&lt;br/&gt;
    /// The exact fields cleared include: the conversation subject, userRequest, agentResponse.
    /// As well as the text response, followup questions, and backend LLM prompt of all messages.&lt;/Warning&gt;
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Conversation.DeleteAsync(
    ///     "conversation-0",
    ///     new ConversationDeleteRequest { Reason = "GDPR deletion request 1234." }
    /// );
    /// </code>
    /// </example>
    public async Task DeleteAsync(
        string conversationId,
        ConversationDeleteRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        _query["reason"] = request.Reason;
        if (request.AppId != null)
        {
            _query["appId"] = request.AppId;
        }
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Delete,
                Path = $"/v1/conversations/{conversationId}",
                Query = _query,
                Options = options,
            },
            cancellationToken
        );
        if (response.StatusCode is >= 200 and < 400)
        {
            return;
        }
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        try
        {
            switch (response.StatusCode)
            {
                case 404:
                    throw new NotFoundError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
                case 400:
                    throw new BadRequestError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
                case 500:
                    throw new ServerError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
            }
        }
        catch (JsonException)
        {
            // unable to map error response, throwing generic error
        }
        throw new MavenAGIApiException(
            $"Error with status code {response.StatusCode}",
            response.StatusCode,
            responseBody
        );
    }

    /// <summary>
    /// Append messages to an existing conversation. The conversation must be initialized first. If a message with the same ID already exists, it will be ignored. Messages do not allow modification.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Conversation.AppendNewMessagesAsync(
    ///     "conversationId",
    ///     new List&lt;ConversationMessageRequest&gt;()
    ///     {
    ///         new ConversationMessageRequest
    ///         {
    ///             ConversationMessageId = new EntityIdBase { ReferenceId = "referenceId" },
    ///         },
    ///         new ConversationMessageRequest
    ///         {
    ///             ConversationMessageId = new EntityIdBase { ReferenceId = "referenceId" },
    ///         },
    ///     }
    /// );
    /// </code>
    /// </example>
    public async Task<ConversationResponse> AppendNewMessagesAsync(
        string conversationId,
        IEnumerable<ConversationMessageRequest> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Post,
                Path = $"/v1/conversations/{conversationId}/messages",
                Body = request,
                Options = options,
            },
            cancellationToken
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            try
            {
                return JsonUtils.Deserialize<ConversationResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new MavenAGIException("Failed to deserialize response", e);
            }
        }

        try
        {
            switch (response.StatusCode)
            {
                case 404:
                    throw new NotFoundError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
                case 400:
                    throw new BadRequestError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
                case 500:
                    throw new ServerError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
            }
        }
        catch (JsonException)
        {
            // unable to map error response, throwing generic error
        }
        throw new MavenAGIApiException(
            $"Error with status code {response.StatusCode}",
            response.StatusCode,
            responseBody
        );
    }

    /// <summary>
    /// Get an answer from Maven for a given user question. If the user question or its answer already exists,
    /// they will be reused and will not be updated. Messages do not allow modification once generated.
    ///
    /// Concurrency Behavior:
    /// - If another API call is made for the same user question while a response is mid-stream, partial answers may be returned.
    /// - The second caller will receive a truncated or partial response depending on where the first stream is in its processing. The first caller's stream will remain unaffected and continue delivering the full response.
    ///
    /// Known Limitation:
    /// - The API does not currently expose metadata indicating whether a response or message is incomplete. This will be addressed in a future update.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Conversation.AskAsync(
    ///     "conversation-0",
    ///     new AskRequest
    ///     {
    ///         ConversationMessageId = new EntityIdBase { ReferenceId = "message-0" },
    ///         UserId = new EntityIdBase { ReferenceId = "user-0" },
    ///         Text = "How do I reset my password?",
    ///         Attachments = new List&lt;Attachment&gt;()
    ///         {
    ///             new Attachment { Type = "image/png", Content = "iVBORw0KGgo..." },
    ///         },
    ///         TransientData = new Dictionary&lt;string, string&gt;()
    ///         {
    ///             { "userToken", "abcdef123" },
    ///             { "queryApiKey", "foobar456" },
    ///         },
    ///     }
    /// );
    /// </code>
    /// </example>
    public async Task<ConversationResponse> AskAsync(
        string conversationId,
        AskRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Post,
                Path = $"/v1/conversations/{conversationId}/ask",
                Body = request,
                Options = options,
            },
            cancellationToken
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            try
            {
                return JsonUtils.Deserialize<ConversationResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new MavenAGIException("Failed to deserialize response", e);
            }
        }

        try
        {
            switch (response.StatusCode)
            {
                case 404:
                    throw new NotFoundError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
                case 400:
                    throw new BadRequestError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
                case 500:
                    throw new ServerError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
            }
        }
        catch (JsonException)
        {
            // unable to map error response, throwing generic error
        }
        throw new MavenAGIApiException(
            $"Error with status code {response.StatusCode}",
            response.StatusCode,
            responseBody
        );
    }

    /// <summary>
    /// Get an answer from Maven for a given user question with a streaming response. The response will be sent as a stream of events.
    /// The text portions of stream responses should be concatenated to form the full response text.
    /// Action and metadata events should overwrite past data and do not need concatenation.
    ///
    /// If the user question or its answer already exists, they will be reused and will not be updated.
    /// Messages do not allow modification once generated.
    ///
    /// Concurrency Behavior:
    /// - If another API call is made for the same user question while a response is mid-stream, partial answers may be returned.
    /// - The second caller will receive a truncated or partial response depending on where the first stream is in its processing. The first caller's stream will remain unaffected and continue delivering the full response.
    ///
    /// Known Limitation:
    /// - The API does not currently expose metadata indicating whether a response or message is incomplete. This will be addressed in a future update.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Conversation.AskStreamAsync(
    ///     "conversation-0",
    ///     new AskRequest
    ///     {
    ///         ConversationMessageId = new EntityIdBase { ReferenceId = "message-0" },
    ///         UserId = new EntityIdBase { ReferenceId = "user-0" },
    ///         Text = "How do I reset my password?",
    ///         Attachments = new List&lt;Attachment&gt;()
    ///         {
    ///             new Attachment { Type = "image/png", Content = "iVBORw0KGgo..." },
    ///         },
    ///         TransientData = new Dictionary&lt;string, string&gt;()
    ///         {
    ///             { "userToken", "abcdef123" },
    ///             { "queryApiKey", "foobar456" },
    ///         },
    ///     }
    /// );
    /// </code>
    /// </example>
    public async Task AskStreamAsync(
        string conversationId,
        AskRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Post,
                Path = $"/v1/conversations/{conversationId}/ask_stream",
                Body = request,
                Options = options,
            },
            cancellationToken
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        try
        {
            switch (response.StatusCode)
            {
                case 404:
                    throw new NotFoundError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
                case 400:
                    throw new BadRequestError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
                case 500:
                    throw new ServerError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
            }
        }
        catch (JsonException)
        {
            // unable to map error response, throwing generic error
        }
        throw new MavenAGIApiException(
            $"Error with status code {response.StatusCode}",
            response.StatusCode,
            responseBody
        );
    }

    /// <summary>
    /// This method is deprecated and will be removed in a future release. Use either `ask` or `askStream` instead.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Conversation.GenerateMavenSuggestionsAsync(
    ///     "conversationId",
    ///     new GenerateMavenSuggestionsRequest
    ///     {
    ///         ConversationMessageIds = new List&lt;EntityIdBase&gt;()
    ///         {
    ///             new EntityIdBase { ReferenceId = "referenceId" },
    ///             new EntityIdBase { ReferenceId = "referenceId" },
    ///         },
    ///     }
    /// );
    /// </code>
    /// </example>
    public async Task<ConversationResponse> GenerateMavenSuggestionsAsync(
        string conversationId,
        GenerateMavenSuggestionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Post,
                Path = $"/v1/conversations/{conversationId}/generate_maven_suggestions",
                Body = request,
                Options = options,
            },
            cancellationToken
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            try
            {
                return JsonUtils.Deserialize<ConversationResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new MavenAGIException("Failed to deserialize response", e);
            }
        }

        try
        {
            switch (response.StatusCode)
            {
                case 404:
                    throw new NotFoundError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
                case 400:
                    throw new BadRequestError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
                case 500:
                    throw new ServerError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
            }
        }
        catch (JsonException)
        {
            // unable to map error response, throwing generic error
        }
        throw new MavenAGIApiException(
            $"Error with status code {response.StatusCode}",
            response.StatusCode,
            responseBody
        );
    }

    /// <summary>
    /// Uses an LLM flow to categorize the conversation. Experimental.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Conversation.CategorizeAsync("conversationId");
    /// </code>
    /// </example>
    public async Task<CategorizationResponse> CategorizeAsync(
        string conversationId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Post,
                Path = $"/v1/conversations/{conversationId}/categorize",
                Options = options,
            },
            cancellationToken
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            try
            {
                return JsonUtils.Deserialize<CategorizationResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new MavenAGIException("Failed to deserialize response", e);
            }
        }

        try
        {
            switch (response.StatusCode)
            {
                case 404:
                    throw new NotFoundError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
                case 400:
                    throw new BadRequestError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
                case 500:
                    throw new ServerError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
            }
        }
        catch (JsonException)
        {
            // unable to map error response, throwing generic error
        }
        throw new MavenAGIApiException(
            $"Error with status code {response.StatusCode}",
            response.StatusCode,
            responseBody
        );
    }

    /// <summary>
    /// Update feedback or create it if it doesn't exist
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Conversation.CreateFeedbackAsync(
    ///     new FeedbackRequest
    ///     {
    ///         FeedbackId = new EntityIdBase { ReferenceId = "feedback-0" },
    ///         UserId = new EntityIdBase { ReferenceId = "user-0" },
    ///         ConversationId = new EntityIdBase { ReferenceId = "conversation-0" },
    ///         ConversationMessageId = new EntityIdBase { ReferenceId = "message-1" },
    ///         Type = FeedbackType.ThumbsUp,
    ///         Text = "Great answer!",
    ///     }
    /// );
    /// </code>
    /// </example>
    public async Task<Feedback> CreateFeedbackAsync(
        FeedbackRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Post,
                Path = "/v1/conversations/feedback",
                Body = request,
                Options = options,
            },
            cancellationToken
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            try
            {
                return JsonUtils.Deserialize<Feedback>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new MavenAGIException("Failed to deserialize response", e);
            }
        }

        try
        {
            switch (response.StatusCode)
            {
                case 404:
                    throw new NotFoundError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
                case 400:
                    throw new BadRequestError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
                case 500:
                    throw new ServerError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
            }
        }
        catch (JsonException)
        {
            // unable to map error response, throwing generic error
        }
        throw new MavenAGIApiException(
            $"Error with status code {response.StatusCode}",
            response.StatusCode,
            responseBody
        );
    }

    /// <summary>
    /// Submit a filled out action form
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Conversation.SubmitActionFormAsync(
    ///     "conversationId",
    ///     new SubmitActionFormRequest
    ///     {
    ///         ActionFormId = "actionFormId",
    ///         Parameters = new Dictionary&lt;string, object&gt;()
    ///         {
    ///             {
    ///                 "parameters",
    ///                 new Dictionary&lt;object, object?&gt;() { { "key", "value" } }
    ///             },
    ///         },
    ///     }
    /// );
    /// </code>
    /// </example>
    public async Task<ConversationResponse> SubmitActionFormAsync(
        string conversationId,
        SubmitActionFormRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Post,
                Path = $"/v1/conversations/{conversationId}/submit-form",
                Body = request,
                Options = options,
            },
            cancellationToken
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            try
            {
                return JsonUtils.Deserialize<ConversationResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new MavenAGIException("Failed to deserialize response", e);
            }
        }

        try
        {
            switch (response.StatusCode)
            {
                case 404:
                    throw new NotFoundError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
                case 400:
                    throw new BadRequestError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
                case 500:
                    throw new ServerError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
            }
        }
        catch (JsonException)
        {
            // unable to map error response, throwing generic error
        }
        throw new MavenAGIApiException(
            $"Error with status code {response.StatusCode}",
            response.StatusCode,
            responseBody
        );
    }

    /// <summary>
    /// Add metadata to an existing conversation. If a metadata field already exists, it will be overwritten.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Conversation.AddConversationMetadataAsync(
    ///     "conversationId",
    ///     new Dictionary&lt;string, string&gt;() { { "string", "string" } }
    /// );
    /// </code>
    /// </example>
    public async Task<Dictionary<string, string>> AddConversationMetadataAsync(
        string conversationId,
        Dictionary<string, string> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Post,
                Path = $"/v1/conversations/{conversationId}/metadata",
                Body = request,
                Options = options,
            },
            cancellationToken
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            try
            {
                return JsonUtils.Deserialize<Dictionary<string, string>>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new MavenAGIException("Failed to deserialize response", e);
            }
        }

        try
        {
            switch (response.StatusCode)
            {
                case 404:
                    throw new NotFoundError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
                case 400:
                    throw new BadRequestError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
                case 500:
                    throw new ServerError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
            }
        }
        catch (JsonException)
        {
            // unable to map error response, throwing generic error
        }
        throw new MavenAGIApiException(
            $"Error with status code {response.StatusCode}",
            response.StatusCode,
            responseBody
        );
    }
}
