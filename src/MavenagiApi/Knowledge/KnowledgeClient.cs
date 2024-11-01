using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MavenagiApi.Core;

#nullable enable

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
    /// <example>
    /// <code>
    /// await client.Knowledge.CreateOrUpdateKnowledgeBaseAsync(
    ///     new KnowledgeBaseRequest
    ///     {
    ///         KnowledgeBaseId = new EntityIdBase { ReferenceId = "help-center" },
    ///         Name = "Help center",
    ///         Type = KnowledgeBaseType.Api,
    ///     }
    /// );
    /// </code>
    /// </example>
    public async Task<KnowledgeBaseResponse> CreateOrUpdateKnowledgeBaseAsync(
        KnowledgeBaseRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Put,
                Path = "/v1/knowledge",
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
                return JsonUtils.Deserialize<KnowledgeBaseResponse>(responseBody)!;
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
    /// Get an existing knowledge base by its supplied ID
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Knowledge.GetKnowledgeBaseAsync("help-center");
    /// </code>
    /// </example>
    public async Task<KnowledgeBaseResponse> GetKnowledgeBaseAsync(
        string knowledgeBaseReferenceId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Get,
                Path = $"/v1/knowledge/{knowledgeBaseReferenceId}",
                Options = options,
            },
            cancellationToken
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            try
            {
                return JsonUtils.Deserialize<KnowledgeBaseResponse>(responseBody)!;
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
    /// Create a new knowledge base version. Only supported on API knowledge bases. Will throw an exception if there is an existing version in progress.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Knowledge.CreateKnowledgeBaseVersionAsync(
    ///     "help-center",
    ///     new KnowledgeBaseVersion { Type = KnowledgeBaseVersionType.Full }
    /// );
    /// </code>
    /// </example>
    public async Task<KnowledgeBaseVersion> CreateKnowledgeBaseVersionAsync(
        string knowledgeBaseReferenceId,
        KnowledgeBaseVersion request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Post,
                Path = $"/v1/knowledge/{knowledgeBaseReferenceId}/version",
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
                return JsonUtils.Deserialize<KnowledgeBaseVersion>(responseBody)!;
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
    /// Finalize the latest knowledge base version. Required to indicate the version is complete. Will throw an exception if the latest version is not in progress.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Knowledge.FinalizeKnowledgeBaseVersionAsync("help-center");
    /// </code>
    /// </example>
    public async Task FinalizeKnowledgeBaseVersionAsync(
        string knowledgeBaseReferenceId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Post,
                Path = $"/v1/knowledge/{knowledgeBaseReferenceId}/version/finalize",
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
    /// Create knowledge document. Requires an existing knowledge base with an in progress version. Will throw an exception if the latest version is not in progress.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Knowledge.CreateKnowledgeDocumentAsync(
    ///     "help-center",
    ///     new KnowledgeDocumentRequest
    ///     {
    ///         KnowledgeDocumentId = new EntityIdBase { ReferenceId = "getting-started" },
    ///         ContentType = KnowledgeDocumentContentType.Markdown,
    ///         Content = "## Getting started\\nThis is a getting started guide for the help center.",
    ///         Title = "Getting started",
    ///     }
    /// );
    /// </code>
    /// </example>
    public async Task<KnowledgeDocumentResponse> CreateKnowledgeDocumentAsync(
        string knowledgeBaseReferenceId,
        KnowledgeDocumentRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Post,
                Path = $"/v1/knowledge/{knowledgeBaseReferenceId}/document",
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
                return JsonUtils.Deserialize<KnowledgeDocumentResponse>(responseBody)!;
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
    /// Not yet implemented. Update knowledge document. Requires an existing knowledge base with an in progress version of type PARTIAL. Will throw an exception if the latest version is not in progress.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Knowledge.UpdateKnowledgeDocumentAsync(
    ///     "help-center",
    ///     new KnowledgeDocumentRequest
    ///     {
    ///         KnowledgeDocumentId = new EntityIdBase { ReferenceId = "getting-started" },
    ///         ContentType = KnowledgeDocumentContentType.Markdown,
    ///         Content = "## Getting started\\nThis is a getting started guide for the help center.",
    ///         Title = "Getting started",
    ///     }
    /// );
    /// </code>
    /// </example>
    public async Task<KnowledgeDocumentResponse> UpdateKnowledgeDocumentAsync(
        string knowledgeBaseReferenceId,
        KnowledgeDocumentRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Put,
                Path = $"/v1/knowledge/{knowledgeBaseReferenceId}/document",
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
                return JsonUtils.Deserialize<KnowledgeDocumentResponse>(responseBody)!;
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
    /// Not yet implemented. Delete knowledge document. Requires an existing knowledge base with an in progress version of type PARTIAL. Will throw an exception if the latest version is not in progress.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Knowledge.DeleteKnowledgeDocumentAsync("help-center", "getting-started");
    /// </code>
    /// </example>
    public async Task DeleteKnowledgeDocumentAsync(
        string knowledgeBaseReferenceId,
        string knowledgeDocumentReferenceId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Delete,
                Path =
                    $"/v1/knowledge/{knowledgeBaseReferenceId}/{knowledgeDocumentReferenceId}/document",
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
}
