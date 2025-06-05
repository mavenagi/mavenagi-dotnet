using System.Net.Http;
using System.Text.Json;
using System.Threading;
using global::System.Threading.Tasks;
using MavenagiApi.Core;

namespace MavenagiApi;

public partial class ConversationClient
{
    private RawClient _client;

    internal ConversationClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Initialize a new conversation.
    /// Only required if the ask request wishes to supply conversation level data or when syncing to external systems.
    ///
    /// Conversations can not be modified using this API. If the conversation already exists then the existing conversation will be returned.
    ///
    /// After initialization,
    /// - metadata can be changed using the `updateConversationMetadata` API.
    /// - messages can be added to the conversation with the `appendNewMessages` or `ask` APIs.
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
    ///                 UserId = new EntityIdBase { ReferenceId = "referenceId" },
    ///                 Text = "text",
    ///                 UserMessageType = UserConversationMessageType.User,
    ///                 ConversationMessageId = new EntityIdBase { ReferenceId = "referenceId" },
    ///             },
    ///             new ConversationMessageRequest
    ///             {
    ///                 UserId = new EntityIdBase { ReferenceId = "referenceId" },
    ///                 Text = "text",
    ///                 UserMessageType = UserConversationMessageType.User,
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
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "/v1/conversations",
                    Body = request,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<ConversationResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new MavenAGIException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                switch (response.StatusCode)
                {
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
                    case 400:
                        throw new BadRequestError(
                            JsonUtils.Deserialize<ErrorMessage>(responseBody)
                        );
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
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = $"/v1/conversations/{JsonUtils.SerializeAsString(conversationId)}",
                    Query = _query,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<ConversationResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new MavenAGIException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                switch (response.StatusCode)
                {
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
                    case 400:
                        throw new BadRequestError(
                            JsonUtils.Deserialize<ErrorMessage>(responseBody)
                        );
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
    public async global::System.Threading.Tasks.Task DeleteAsync(
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
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Delete,
                    Path = $"/v1/conversations/{JsonUtils.SerializeAsString(conversationId)}",
                    Query = _query,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            return;
        }
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                switch (response.StatusCode)
                {
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
                    case 400:
                        throw new BadRequestError(
                            JsonUtils.Deserialize<ErrorMessage>(responseBody)
                        );
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
    ///             UserId = new EntityIdBase { ReferenceId = "referenceId" },
    ///             Text = "text",
    ///             UserMessageType = UserConversationMessageType.User,
    ///             ConversationMessageId = new EntityIdBase { ReferenceId = "referenceId" },
    ///         },
    ///         new ConversationMessageRequest
    ///         {
    ///             UserId = new EntityIdBase { ReferenceId = "referenceId" },
    ///             Text = "text",
    ///             UserMessageType = UserConversationMessageType.User,
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
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path =
                        $"/v1/conversations/{JsonUtils.SerializeAsString(conversationId)}/messages",
                    Body = request,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<ConversationResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new MavenAGIException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                switch (response.StatusCode)
                {
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
                    case 400:
                        throw new BadRequestError(
                            JsonUtils.Deserialize<ErrorMessage>(responseBody)
                        );
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
    ///         Timezone = "America/New_York",
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
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = $"/v1/conversations/{JsonUtils.SerializeAsString(conversationId)}/ask",
                    Body = request,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<ConversationResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new MavenAGIException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                switch (response.StatusCode)
                {
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
                    case 400:
                        throw new BadRequestError(
                            JsonUtils.Deserialize<ErrorMessage>(responseBody)
                        );
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
    ///         Timezone = "America/New_York",
    ///     }
    /// );
    /// </code>
    /// </example>
    public async global::System.Threading.Tasks.Task AskStreamAsync(
        string conversationId,
        AskRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path =
                        $"/v1/conversations/{JsonUtils.SerializeAsString(conversationId)}/ask_stream",
                    Body = request,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                switch (response.StatusCode)
                {
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
                    case 400:
                        throw new BadRequestError(
                            JsonUtils.Deserialize<ErrorMessage>(responseBody)
                        );
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
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path =
                        $"/v1/conversations/{JsonUtils.SerializeAsString(conversationId)}/generate_maven_suggestions",
                    Body = request,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<ConversationResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new MavenAGIException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                switch (response.StatusCode)
                {
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
                    case 400:
                        throw new BadRequestError(
                            JsonUtils.Deserialize<ErrorMessage>(responseBody)
                        );
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

    /// <summary>
    /// Generate a structured object response based on a provided schema and user prompt.
    ///
    /// If the user question and object response already exist, they will be reused and not updated.
    ///
    /// Known Limitations:
    /// - Schema enforcement is best-effort and may not guarantee exact conformity.
    /// - This endpoint does not stream results. Use `askDataStream` (coming soon) for progressive rendering.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Conversation.GenerateObjectAsync(
    ///     "conversationId",
    ///     new GenerateObjectRequest
    ///     {
    ///         ConversationMessageId = new EntityIdBase { ReferenceId = "referenceId" },
    ///         UserId = new EntityIdBase { ReferenceId = "referenceId" },
    ///         Text = "text",
    ///         Schema = "schema",
    ///     }
    /// );
    /// </code>
    /// </example>
    public async Task<BotObjectResponse> GenerateObjectAsync(
        string conversationId,
        GenerateObjectRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path =
                        $"/v1/conversations/{JsonUtils.SerializeAsString(conversationId)}/generate_object",
                    Body = request,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<BotObjectResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new MavenAGIException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                switch (response.StatusCode)
                {
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
                    case 400:
                        throw new BadRequestError(
                            JsonUtils.Deserialize<ErrorMessage>(responseBody)
                        );
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
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path =
                        $"/v1/conversations/{JsonUtils.SerializeAsString(conversationId)}/categorize",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<CategorizationResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new MavenAGIException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                switch (response.StatusCode)
                {
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
                    case 400:
                        throw new BadRequestError(
                            JsonUtils.Deserialize<ErrorMessage>(responseBody)
                        );
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
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "/v1/conversations/feedback",
                    Body = request,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<Feedback>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new MavenAGIException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                switch (response.StatusCode)
                {
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
                    case 400:
                        throw new BadRequestError(
                            JsonUtils.Deserialize<ErrorMessage>(responseBody)
                        );
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
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path =
                        $"/v1/conversations/{JsonUtils.SerializeAsString(conversationId)}/submit-form",
                    Body = request,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<ConversationResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new MavenAGIException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                switch (response.StatusCode)
                {
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
                    case 400:
                        throw new BadRequestError(
                            JsonUtils.Deserialize<ErrorMessage>(responseBody)
                        );
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

    /// <summary>
    /// Replaced by `updateConversationMetadata`.
    ///
    /// Adds metadata to an existing conversation. If a metadata field already exists, it will be overwritten.
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
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path =
                        $"/v1/conversations/{JsonUtils.SerializeAsString(conversationId)}/metadata",
                    Body = request,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<Dictionary<string, string>>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new MavenAGIException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                switch (response.StatusCode)
                {
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
                    case 400:
                        throw new BadRequestError(
                            JsonUtils.Deserialize<ErrorMessage>(responseBody)
                        );
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

    /// <summary>
    /// Update metadata supplied by the calling application for an existing conversation.
    /// Does not modify metadata saved by other apps.
    ///
    /// If a metadata field already exists for the calling app, it will be overwritten.
    /// If it does not exist, it will be added. Will not remove metadata fields.
    ///
    /// Returns all metadata saved by any app on the conversation.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Conversation.UpdateConversationMetadataAsync(
    ///     "conversation-0",
    ///     new UpdateMetadataRequest
    ///     {
    ///         AppId = "conversation-owning-app",
    ///         Values = new Dictionary&lt;string, string&gt;() { { "key", "newValue" } },
    ///     }
    /// );
    /// </code>
    /// </example>
    public async Task<ConversationMetadata> UpdateConversationMetadataAsync(
        string conversationId,
        UpdateMetadataRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Put,
                    Path =
                        $"/v1/conversations/{JsonUtils.SerializeAsString(conversationId)}/metadata",
                    Body = request,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<ConversationMetadata>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new MavenAGIException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                switch (response.StatusCode)
                {
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
                    case 400:
                        throw new BadRequestError(
                            JsonUtils.Deserialize<ErrorMessage>(responseBody)
                        );
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

    /// <summary>
    /// Search conversations
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Conversation.SearchAsync(new ConversationsSearchRequest());
    /// </code>
    /// </example>
    public async Task<ConversationsResponse> SearchAsync(
        ConversationsSearchRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "/v1/conversations/search",
                    Body = request,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<ConversationsResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new MavenAGIException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                switch (response.StatusCode)
                {
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
                    case 400:
                        throw new BadRequestError(
                            JsonUtils.Deserialize<ErrorMessage>(responseBody)
                        );
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
}
