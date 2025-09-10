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
    /// Search knowledge bases
    /// </summary>
    /// <example><code>
    /// await client.Knowledge.SearchKnowledgeBasesAsync(new KnowledgeBaseSearchRequest());
    /// </code></example>
    public async Task<KnowledgeBasesResponse> SearchKnowledgeBasesAsync(
        KnowledgeBaseSearchRequest request,
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
                    Path = "/v1/knowledge/search",
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
                return JsonUtils.Deserialize<KnowledgeBasesResponse>(responseBody)!;
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
    /// await client.Knowledge.GetKnowledgeBaseAsync("help-center", new KnowledgeBaseGetRequest());
    /// </code></example>
    public async Task<KnowledgeBaseResponse> GetKnowledgeBaseAsync(
        string knowledgeBaseReferenceId,
        KnowledgeBaseGetRequest request,
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
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "/v1/knowledge/{0}",
                        ValueConvert.ToPathParameterString(knowledgeBaseReferenceId)
                    ),
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
    /// Update mutable knowledge base fields
    ///
    /// The `appId` field can be provided to update a knowledge base owned by a different app.
    /// All other fields will overwrite the existing value on the knowledge base only if provided.
    /// </summary>
    /// <example><code>
    /// await client.Knowledge.PatchKnowledgeBaseAsync(
    ///     "knowledgeBaseReferenceId",
    ///     new KnowledgeBasePatchRequest()
    /// );
    /// </code></example>
    public async Task<KnowledgeBaseResponse> PatchKnowledgeBaseAsync(
        string knowledgeBaseReferenceId,
        KnowledgeBasePatchRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethodExtensions.Patch,
                    Path = string.Format(
                        "/v1/knowledge/{0}",
                        ValueConvert.ToPathParameterString(knowledgeBaseReferenceId)
                    ),
                    Body = request,
                    ContentType = "application/merge-patch+json",
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
    ///     new KnowledgeBaseVersionRequest { Type = KnowledgeBaseVersionType.Full }
    /// );
    /// </code></example>
    public async Task<KnowledgeBaseVersion> CreateKnowledgeBaseVersionAsync(
        string knowledgeBaseReferenceId,
        KnowledgeBaseVersionRequest request,
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
    /// List all active versions for a knowledge base. Returns the most recent versions first.
    /// </summary>
    /// <example><code>
    /// await client.Knowledge.ListKnowledgeBaseVersionsAsync(
    ///     "knowledgeBaseReferenceId",
    ///     new KnowledgeBaseVersionsListRequest()
    /// );
    /// </code></example>
    public async Task<KnowledgeBaseVersionsListResponse> ListKnowledgeBaseVersionsAsync(
        string knowledgeBaseReferenceId,
        KnowledgeBaseVersionsListRequest request,
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
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "/v1/knowledge/{0}/versions",
                        ValueConvert.ToPathParameterString(knowledgeBaseReferenceId)
                    ),
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
                return JsonUtils.Deserialize<KnowledgeBaseVersionsListResponse>(responseBody)!;
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
    /// Search knowledge documents
    /// </summary>
    /// <example><code>
    /// await client.Knowledge.SearchKnowledgeDocumentsAsync(new KnowledgeDocumentSearchRequest());
    /// </code></example>
    public async Task<KnowledgeDocumentsResponse> SearchKnowledgeDocumentsAsync(
        KnowledgeDocumentSearchRequest request,
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
                    Path = "/v1/knowledge/documents/search",
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
                return JsonUtils.Deserialize<KnowledgeDocumentsResponse>(responseBody)!;
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
    /// Create or update a knowledge document. Requires an existing knowledge base with an in progress version.
    /// Will throw an exception if the latest version is not in progress.
    ///
    /// &lt;Tip&gt;
    /// This API maintains document version history. If for the same reference ID none of the `title`, `text`, `sourceUrl`, `metadata` fields
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
    /// Delete knowledge document from a specific version.
    /// Requires an existing knowledge base with an in progress version of type PARTIAL. Will throw an exception if the version is not in progress.
    /// </summary>
    /// <example><code>
    /// await client.Knowledge.DeleteKnowledgeDocumentAsync(
    ///     "help-center",
    ///     "getting-started",
    ///     new KnowledgeDeleteRequest
    ///     {
    ///         VersionId = new EntityIdWithoutAgent
    ///         {
    ///             Type = EntityType.KnowledgeBaseVersion,
    ///             AppId = "maven",
    ///             ReferenceId = "versionId",
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async global::System.Threading.Tasks.Task DeleteKnowledgeDocumentAsync(
        string knowledgeBaseReferenceId,
        string knowledgeDocumentReferenceId,
        KnowledgeDeleteRequest request,
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
                    Body = request,
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
    /// Get a knowledge document by its supplied version and document IDs. Response includes document content in markdown format.
    /// </summary>
    /// <example><code>
    /// await client.Knowledge.GetKnowledgeDocumentAsync(
    ///     "knowledgeBaseVersionReferenceId",
    ///     "knowledgeDocumentReferenceId",
    ///     new KnowledgeDocumentGetRequest { KnowledgeBaseVersionAppId = "knowledgeBaseVersionAppId" }
    /// );
    /// </code></example>
    public async Task<KnowledgeDocumentResponse> GetKnowledgeDocumentAsync(
        string knowledgeBaseVersionReferenceId,
        string knowledgeDocumentReferenceId,
        KnowledgeDocumentGetRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        _query["knowledgeBaseVersionAppId"] = request.KnowledgeBaseVersionAppId;
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "/v1/knowledge/versions/{0}/documents/{1}",
                        ValueConvert.ToPathParameterString(knowledgeBaseVersionReferenceId),
                        ValueConvert.ToPathParameterString(knowledgeDocumentReferenceId)
                    ),
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
}
