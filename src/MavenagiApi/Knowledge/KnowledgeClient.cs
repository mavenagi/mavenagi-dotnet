using System.Net.Http;
using System.Text.Json;
using System.Threading;
using global::System.Threading.Tasks;
using MavenagiApi.Core;

namespace MavenagiApi;

public partial class KnowledgeClient
{
    private RawClient _client;

    internal KnowledgeClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Update a knowledge base or create it if it doesn't exist.
    /// </summary>
    /// <example><code>
    /// await client.Knowledge.CreateOrUpdateKnowledgeBaseAsync(
    ///     new KnowledgeBaseRequest
    ///     {
    ///         KnowledgeBaseId = new EntityIdBase { ReferenceId = "help-center" },
    ///         Name = "Help center",
    ///     }
    /// );
    /// </code></example>
    public async Task<KnowledgeBaseResponse> CreateOrUpdateKnowledgeBaseAsync(
        KnowledgeBaseRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Put,
                    Path = "/v1/knowledge",
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
                return JsonUtils.Deserialize<KnowledgeBaseResponse>(responseBody)!;
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
    /// Get an existing knowledge base by its supplied ID
    /// </summary>
    /// <example><code>
    /// await client.Knowledge.GetKnowledgeBaseAsync("help-center");
    /// </code></example>
    public async Task<KnowledgeBaseResponse> GetKnowledgeBaseAsync(
        string knowledgeBaseReferenceId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "/v1/knowledge/{0}",
                        ValueConvert.ToPathParameterString(knowledgeBaseReferenceId)
                    ),
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
                return JsonUtils.Deserialize<KnowledgeBaseResponse>(responseBody)!;
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
    /// Create a new knowledge base version.
    ///
    /// If an existing version is in progress, then that version will be finalized in an error state.
    /// </summary>
    /// <example><code>
    /// await client.Knowledge.CreateKnowledgeBaseVersionAsync(
    ///     "help-center",
    ///     new KnowledgeBaseVersion
    ///     {
    ///         VersionId = new EntityId
    ///         {
    ///             Type = EntityType.KnowledgeBaseVersion,
    ///             ReferenceId = "versionId",
    ///             AppId = "maven",
    ///             OrganizationId = "acme",
    ///             AgentId = "support",
    ///         },
    ///         Type = KnowledgeBaseVersionType.Full,
    ///         Status = KnowledgeBaseVersionStatus.InProgress,
    ///     }
    /// );
    /// </code></example>
    public async Task<KnowledgeBaseVersion> CreateKnowledgeBaseVersionAsync(
        string knowledgeBaseReferenceId,
        KnowledgeBaseVersion request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = string.Format(
                        "/v1/knowledge/{0}/version",
                        ValueConvert.ToPathParameterString(knowledgeBaseReferenceId)
                    ),
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
                return JsonUtils.Deserialize<KnowledgeBaseVersion>(responseBody)!;
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
    /// Finalize the latest knowledge base version. Required to indicate the version is complete. Will throw an exception if the latest version is not in progress.
    /// </summary>
    /// <example><code>
    /// await client.Knowledge.FinalizeKnowledgeBaseVersionAsync(
    ///     "help-center",
    ///     new FinalizeKnowledgeBaseVersionRequest
    ///     {
    ///         VersionId = new EntityIdWithoutAgent
    ///         {
    ///             Type = EntityType.KnowledgeBaseVersion,
    ///             ReferenceId = "versionId",
    ///             AppId = "maven",
    ///         },
    ///         Status = KnowledgeBaseVersionFinalizeStatus.Succeeded,
    ///     }
    /// );
    /// </code></example>
    public async Task<KnowledgeBaseVersion> FinalizeKnowledgeBaseVersionAsync(
        string knowledgeBaseReferenceId,
        FinalizeKnowledgeBaseVersionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = string.Format(
                        "/v1/knowledge/{0}/version/finalize",
                        ValueConvert.ToPathParameterString(knowledgeBaseReferenceId)
                    ),
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
                return JsonUtils.Deserialize<KnowledgeBaseVersion>(responseBody)!;
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
    /// Create knowledge document. Requires an existing knowledge base with an in progress version. Will throw an exception if the latest version is not in progress.
    ///
    /// &lt;Tip&gt;
    /// This API maintains document version history. If for the same reference ID neither the `title` nor `text` fields
    /// have changed, a new document version will not be created. The existing version will be reused.
    /// &lt;/Tip&gt;
    /// </summary>
    /// <example><code>
    /// await client.Knowledge.CreateKnowledgeDocumentAsync(
    ///     "help-center",
    ///     new KnowledgeDocumentRequest
    ///     {
    ///         KnowledgeDocumentId = new EntityIdBase { ReferenceId = "getting-started" },
    ///         VersionId = new EntityIdWithoutAgent
    ///         {
    ///             Type = EntityType.KnowledgeBaseVersion,
    ///             ReferenceId = "versionId",
    ///             AppId = "maven",
    ///         },
    ///         ContentType = KnowledgeDocumentContentType.Markdown,
    ///         Content = "## Getting started\\nThis is a getting started guide for the help center.",
    ///         Title = "Getting started",
    ///         Metadata = new Dictionary&lt;string, string&gt;() { { "category", "getting-started" } },
    ///     }
    /// );
    /// </code></example>
    public async Task<KnowledgeDocumentResponse> CreateKnowledgeDocumentAsync(
        string knowledgeBaseReferenceId,
        KnowledgeDocumentRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = string.Format(
                        "/v1/knowledge/{0}/document",
                        ValueConvert.ToPathParameterString(knowledgeBaseReferenceId)
                    ),
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
                return JsonUtils.Deserialize<KnowledgeDocumentResponse>(responseBody)!;
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
    /// Not yet implemented. Update knowledge document. Requires an existing knowledge base with an in progress version of type PARTIAL. Will throw an exception if the latest version is not in progress.
    /// </summary>
    /// <example><code>
    /// await client.Knowledge.UpdateKnowledgeDocumentAsync(
    ///     "help-center",
    ///     new KnowledgeDocumentRequest
    ///     {
    ///         KnowledgeDocumentId = new EntityIdBase { ReferenceId = "getting-started" },
    ///         VersionId = new EntityIdWithoutAgent
    ///         {
    ///             Type = EntityType.KnowledgeBaseVersion,
    ///             ReferenceId = "versionId",
    ///             AppId = "maven",
    ///         },
    ///         ContentType = KnowledgeDocumentContentType.Markdown,
    ///         Content = "## Getting started\\nThis is a getting started guide for the help center.",
    ///         Title = "Getting started",
    ///         Metadata = new Dictionary&lt;string, string&gt;() { { "category", "getting-started" } },
    ///     }
    /// );
    /// </code></example>
    public async Task<KnowledgeDocumentResponse> UpdateKnowledgeDocumentAsync(
        string knowledgeBaseReferenceId,
        KnowledgeDocumentRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Put,
                    Path = string.Format(
                        "/v1/knowledge/{0}/document",
                        ValueConvert.ToPathParameterString(knowledgeBaseReferenceId)
                    ),
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
                return JsonUtils.Deserialize<KnowledgeDocumentResponse>(responseBody)!;
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
    /// Not yet implemented. Delete knowledge document. Requires an existing knowledge base with an in progress version of type PARTIAL. Will throw an exception if the latest version is not in progress.
    /// </summary>
    /// <example><code>
    /// await client.Knowledge.DeleteKnowledgeDocumentAsync("help-center", "getting-started");
    /// </code></example>
    public async global::System.Threading.Tasks.Task DeleteKnowledgeDocumentAsync(
        string knowledgeBaseReferenceId,
        string knowledgeDocumentReferenceId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Delete,
                    Path = string.Format(
                        "/v1/knowledge/{0}/{1}/document",
                        ValueConvert.ToPathParameterString(knowledgeBaseReferenceId),
                        ValueConvert.ToPathParameterString(knowledgeDocumentReferenceId)
                    ),
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
}
