/*
 * V5ApiPublic
 *
 * Welcome to the Tiltify V5 API docmentation site.  This is the public API for Tiltify. It is intended to be used by third party developers to build integrations with Tiltify. Additional documentation may be found at the [Tiltify Developers](https://developers.tiltify.com) documentation site.  # OpenAPI Specification The API uses the OpenAPI Specification (OAS) to define the API. More information about the OpenAPI Specification can be found at [https://swagger.io/specification/](https://swagger.io/specification/).  # Authentication Tiltify uses OAuth 2.0 access tokens to authenticate API requests. You may get an Application `access_token` or a User `access_token`. To authenticate, you will need to create an application in the Tiltify User Dashboard, and use the generated credentials.  ## Getting an Application Access Token  The method to get an application access token follows the Client Credentials Oauth2 grant flow.  You may give the required parameters to the [Oauth Token Endpoint](#tag/oauth) to get an access token for use with the api directly.  ## Getting a User Access Token  The method to get a user access token follows the OAuth2 Authorization Grant flow. The following is a specific example of how to retrieve A User Access token using OAuth2  ### Getting the code  This example will be using the following values as needed. - Application ID: 1234 - Redirect https://www.example.com/redirect - Secret Key: asdf  To begin with, send a user in a browser to the Tiltify OAuth Authorization url. Include your Client ID, and the response type of `code` as query parameters. You may include your redirect URI if you have more than one. A space separated list of scopes may also be added, however, if not included, the `public` scope will be automatically selected.  ``` https://v5api.tiltify.com/oauth/authorize?&client_id=1234&response_type=code&redirect_uri=https%3A%2F%2Fwww.example.com%2Fredirect&scope=public ```  After signing in and authorizing, the user will be redirected back to your chosen redirect URI with a query parameter of `code`, containing the code used to fetch the access token.  ``` https://www.example.com/redirect?code=1234abcdef ```  The code should be passed to your server backend as the following steps require your secret key, which should not be exposed to the public.  ### Converting The Code To A User Access Token  To retrieve the User Access Token, a post request must be made to the Token URL. In the body of the url are the following fields in Form Data format. Note specifically that code is the code retrieved from the first step.  ``` client_id=1234 redirect_uri=https://www.example.com/redirect code=1234abcdef grant_type=authorization_code ```  Tiltify will return a response like the following:  ``` {      \"access_token\": \"ab6a592346444dea97170837e104d8a5ab6a592346444dea97170837e104d8a5\",     \"created_at\": \"2023-01-27T19:32:03Z\",     \"expires_in\": 7200,     \"refresh_token\": \"njjjytm3otetmgrjmi00yjawlwe4zgytzjixy2mzm2y3njawcg121231999393a3\",     \"scope\": \"public\",     \"token_type\": \"bearer\"  } ```  This access token may now be used as shown below to make requests. When used with the [/current-user](#tag/user/operation/V5ApiWeb.Public.UserController.current_user) endpoint, the full `user` object is returned.  ## Using Access Tokens  Add the Authorization header to your HTTP request.  ``` Authorization: Bearer <access_token> ```  Example:  ``` Authorization: Bearer ab6a592346444dea97170837e104d8a5ab6a592346444dea97170837e104d8a5 ```  ## Using Refresh Tokens  When an initial access token is created, a refresh token will be provided. The refresh token can be used to get a new access token when the current one expires. To do this, make a post request to the token url with grant_type set to `refresh_token`.  Example:  To refresh the User Access Token, a post request must be made to the Token URL. In the body of the url are the following fields in Form Data or json format.  ``` client_id=1234 client_secret=asdf grant_type=refresh_token refresh_token=njjjytm3otetmgrjmi00yjawlwe4zgytzjixy2mzm2y3njawcg121231999393a3 ```  <SecurityDefinitions />  # Webhooks  Tiltify provides a dashboard to subscribe and test campaign and campaign donation webhooks.  To register a webhook, visit the [Developer Dashboard](https://app.tiltify.com/developers)  ## Registering a webhook  In order to begin registering webhooks, you must first create an application.  In the application dashboard, there will be a side navigation option for `Webhooks`.  - Click the `Add Webhook` button - Create the webhook with an endpoint URL and an optional description. - Click edit on the newly created webhook - Click the `Events` submenu and add and event to subscribe to using the `Add event` button. - Enter your Campaign ID, this can be found in your campaign's dashboard under `Setup > Information` - Once created, click the `...` button and select Edit - Select the donation and/or Campaign events you would like to receive to your webhook endpoint and click `Update Event`. Including private data may include sensitive information, so please ensure that you secure your application.  You should now receive updates for those events on your webhook url.  <style>blockquote{border-left: 4px solid #F4CB14 !important; color: inherit !important;}</style> > Caution: > When we send a webhook we expect the endpoint to respond with a 200-299 status code. If we do not receive that, we deactivate the webhook after about an hour.   ## Testing  Once a webhook is created, you may send test messages through the `Testing` Submenu.  An example payload will be shown for each event type.  Click `Send Test` to initiate the test. 
 *
 * The version of the OpenAPI document: 1.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mime;
using TiltifyV5.Client;
using TiltifyV5.Model;

namespace TiltifyV5.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ITeamApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Get by ID
        /// </summary>
        /// <remarks>
        /// Returns a team by its ID
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamId">Team ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>TeamResponse1</returns>
        TeamResponse1 GetTeam(string teamId, int operationIndex = 0);

        /// <summary>
        /// Get by ID
        /// </summary>
        /// <remarks>
        /// Returns a team by its ID
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamId">Team ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of TeamResponse1</returns>
        ApiResponse<TeamResponse1> GetTeamWithHttpInfo(string teamId, int operationIndex = 0);
        /// <summary>
        /// Get by slug
        /// </summary>
        /// <remarks>
        /// Returns a team by its slug
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="slug">Team slug</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>TeamResponse1</returns>
        TeamResponse1 GetTeamBySlug(string slug, int operationIndex = 0);

        /// <summary>
        /// Get by slug
        /// </summary>
        /// <remarks>
        /// Returns a team by its slug
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="slug">Team slug</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of TeamResponse1</returns>
        ApiResponse<TeamResponse1> GetTeamBySlugWithHttpInfo(string slug, int operationIndex = 0);
        /// <summary>
        /// List Team Campaigns
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamId">Team ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>TeamCampaignPaginatedResponse1</returns>
        TeamCampaignPaginatedResponse1 GetTeamCampaigns(string teamId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);

        /// <summary>
        /// List Team Campaigns
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamId">Team ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of TeamCampaignPaginatedResponse1</returns>
        ApiResponse<TeamCampaignPaginatedResponse1> GetTeamCampaignsWithHttpInfo(string teamId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);
        /// <summary>
        /// List team members
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamId">Team ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>TeamMemberPaginatedResponse1</returns>
        TeamMemberPaginatedResponse1 GetTeamMembers(string teamId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);

        /// <summary>
        /// List team members
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamId">Team ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of TeamMemberPaginatedResponse1</returns>
        ApiResponse<TeamMemberPaginatedResponse1> GetTeamMembersWithHttpInfo(string teamId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ITeamApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Get by ID
        /// </summary>
        /// <remarks>
        /// Returns a team by its ID
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamId">Team ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TeamResponse1</returns>
        System.Threading.Tasks.Task<TeamResponse1> GetTeamAsync(string teamId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get by ID
        /// </summary>
        /// <remarks>
        /// Returns a team by its ID
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamId">Team ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TeamResponse1)</returns>
        System.Threading.Tasks.Task<ApiResponse<TeamResponse1>> GetTeamWithHttpInfoAsync(string teamId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get by slug
        /// </summary>
        /// <remarks>
        /// Returns a team by its slug
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="slug">Team slug</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TeamResponse1</returns>
        System.Threading.Tasks.Task<TeamResponse1> GetTeamBySlugAsync(string slug, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get by slug
        /// </summary>
        /// <remarks>
        /// Returns a team by its slug
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="slug">Team slug</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TeamResponse1)</returns>
        System.Threading.Tasks.Task<ApiResponse<TeamResponse1>> GetTeamBySlugWithHttpInfoAsync(string slug, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List Team Campaigns
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamId">Team ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TeamCampaignPaginatedResponse1</returns>
        System.Threading.Tasks.Task<TeamCampaignPaginatedResponse1> GetTeamCampaignsAsync(string teamId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List Team Campaigns
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamId">Team ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TeamCampaignPaginatedResponse1)</returns>
        System.Threading.Tasks.Task<ApiResponse<TeamCampaignPaginatedResponse1>> GetTeamCampaignsWithHttpInfoAsync(string teamId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List team members
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamId">Team ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TeamMemberPaginatedResponse1</returns>
        System.Threading.Tasks.Task<TeamMemberPaginatedResponse1> GetTeamMembersAsync(string teamId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List team members
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamId">Team ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TeamMemberPaginatedResponse1)</returns>
        System.Threading.Tasks.Task<ApiResponse<TeamMemberPaginatedResponse1>> GetTeamMembersWithHttpInfoAsync(string teamId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ITeamApi : ITeamApiSync, ITeamApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class TeamApi : ITeamApi
    {
        private TiltifyV5.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamApi"/> class.
        /// </summary>
        /// <returns></returns>
        public TeamApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamApi"/> class.
        /// </summary>
        /// <returns></returns>
        public TeamApi(string basePath)
        {
            this.Configuration = TiltifyV5.Client.Configuration.MergeConfigurations(
                TiltifyV5.Client.GlobalConfiguration.Instance,
                new TiltifyV5.Client.Configuration { BasePath = basePath }
            );
            this.Client = new TiltifyV5.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new TiltifyV5.Client.ApiClient(this.Configuration.BasePath);
            this.ExceptionFactory = TiltifyV5.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public TeamApi(TiltifyV5.Client.Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Configuration = TiltifyV5.Client.Configuration.MergeConfigurations(
                TiltifyV5.Client.GlobalConfiguration.Instance,
                configuration
            );
            this.Client = new TiltifyV5.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new TiltifyV5.Client.ApiClient(this.Configuration.BasePath);
            ExceptionFactory = TiltifyV5.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public TeamApi(TiltifyV5.Client.ISynchronousClient client, TiltifyV5.Client.IAsynchronousClient asyncClient, TiltifyV5.Client.IReadableConfiguration configuration)
        {
            if (client == null) throw new ArgumentNullException("client");
            if (asyncClient == null) throw new ArgumentNullException("asyncClient");
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Client = client;
            this.AsynchronousClient = asyncClient;
            this.Configuration = configuration;
            this.ExceptionFactory = TiltifyV5.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// The client for accessing this underlying API asynchronously.
        /// </summary>
        public TiltifyV5.Client.IAsynchronousClient AsynchronousClient { get; set; }

        /// <summary>
        /// The client for accessing this underlying API synchronously.
        /// </summary>
        public TiltifyV5.Client.ISynchronousClient Client { get; set; }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public string GetBasePath()
        {
            return this.Configuration.BasePath;
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public TiltifyV5.Client.IReadableConfiguration Configuration { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public TiltifyV5.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Get by ID Returns a team by its ID
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamId">Team ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>TeamResponse1</returns>
        public TeamResponse1 GetTeam(string teamId, int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<TeamResponse1> localVarResponse = GetTeamWithHttpInfo(teamId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get by ID Returns a team by its ID
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamId">Team ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of TeamResponse1</returns>
        public TiltifyV5.Client.ApiResponse<TeamResponse1> GetTeamWithHttpInfo(string teamId, int operationIndex = 0)
        {
            // verify the required parameter 'teamId' is set
            if (teamId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'teamId' when calling TeamApi->GetTeam");
            }

            TiltifyV5.Client.RequestOptions localVarRequestOptions = new TiltifyV5.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = TiltifyV5.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = TiltifyV5.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("team_id", TiltifyV5.Client.ClientUtils.ParameterToString(teamId)); // path parameter

            localVarRequestOptions.Operation = "TeamApi.GetTeam";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<TeamResponse1>("/api/public/teams/{team_id}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTeam", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get by ID Returns a team by its ID
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamId">Team ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TeamResponse1</returns>
        public async System.Threading.Tasks.Task<TeamResponse1> GetTeamAsync(string teamId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<TeamResponse1> localVarResponse = await GetTeamWithHttpInfoAsync(teamId, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get by ID Returns a team by its ID
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamId">Team ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TeamResponse1)</returns>
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<TeamResponse1>> GetTeamWithHttpInfoAsync(string teamId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'teamId' is set
            if (teamId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'teamId' when calling TeamApi->GetTeam");
            }


            TiltifyV5.Client.RequestOptions localVarRequestOptions = new TiltifyV5.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = TiltifyV5.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = TiltifyV5.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("team_id", TiltifyV5.Client.ClientUtils.ParameterToString(teamId)); // path parameter

            localVarRequestOptions.Operation = "TeamApi.GetTeam";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<TeamResponse1>("/api/public/teams/{team_id}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTeam", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get by slug Returns a team by its slug
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="slug">Team slug</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>TeamResponse1</returns>
        public TeamResponse1 GetTeamBySlug(string slug, int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<TeamResponse1> localVarResponse = GetTeamBySlugWithHttpInfo(slug);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get by slug Returns a team by its slug
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="slug">Team slug</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of TeamResponse1</returns>
        public TiltifyV5.Client.ApiResponse<TeamResponse1> GetTeamBySlugWithHttpInfo(string slug, int operationIndex = 0)
        {
            // verify the required parameter 'slug' is set
            if (slug == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'slug' when calling TeamApi->GetTeamBySlug");
            }

            TiltifyV5.Client.RequestOptions localVarRequestOptions = new TiltifyV5.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = TiltifyV5.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = TiltifyV5.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("slug", TiltifyV5.Client.ClientUtils.ParameterToString(slug)); // path parameter

            localVarRequestOptions.Operation = "TeamApi.GetTeamBySlug";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<TeamResponse1>("/api/public/teams/by/slug/{slug}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTeamBySlug", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get by slug Returns a team by its slug
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="slug">Team slug</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TeamResponse1</returns>
        public async System.Threading.Tasks.Task<TeamResponse1> GetTeamBySlugAsync(string slug, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<TeamResponse1> localVarResponse = await GetTeamBySlugWithHttpInfoAsync(slug, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get by slug Returns a team by its slug
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="slug">Team slug</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TeamResponse1)</returns>
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<TeamResponse1>> GetTeamBySlugWithHttpInfoAsync(string slug, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'slug' is set
            if (slug == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'slug' when calling TeamApi->GetTeamBySlug");
            }


            TiltifyV5.Client.RequestOptions localVarRequestOptions = new TiltifyV5.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = TiltifyV5.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = TiltifyV5.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("slug", TiltifyV5.Client.ClientUtils.ParameterToString(slug)); // path parameter

            localVarRequestOptions.Operation = "TeamApi.GetTeamBySlug";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<TeamResponse1>("/api/public/teams/by/slug/{slug}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTeamBySlug", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List Team Campaigns 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamId">Team ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>TeamCampaignPaginatedResponse1</returns>
        public TeamCampaignPaginatedResponse1 GetTeamCampaigns(string teamId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<TeamCampaignPaginatedResponse1> localVarResponse = GetTeamCampaignsWithHttpInfo(teamId, after, before, limit);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List Team Campaigns 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamId">Team ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of TeamCampaignPaginatedResponse1</returns>
        public TiltifyV5.Client.ApiResponse<TeamCampaignPaginatedResponse1> GetTeamCampaignsWithHttpInfo(string teamId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            // verify the required parameter 'teamId' is set
            if (teamId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'teamId' when calling TeamApi->GetTeamCampaigns");
            }

            TiltifyV5.Client.RequestOptions localVarRequestOptions = new TiltifyV5.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = TiltifyV5.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = TiltifyV5.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("team_id", TiltifyV5.Client.ClientUtils.ParameterToString(teamId)); // path parameter
            if (after != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "after", after));
            }
            if (before != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "before", before));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }

            localVarRequestOptions.Operation = "TeamApi.GetTeamCampaigns";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<TeamCampaignPaginatedResponse1>("/api/public/teams/{team_id}/team_campaigns", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTeamCampaigns", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List Team Campaigns 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamId">Team ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TeamCampaignPaginatedResponse1</returns>
        public async System.Threading.Tasks.Task<TeamCampaignPaginatedResponse1> GetTeamCampaignsAsync(string teamId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<TeamCampaignPaginatedResponse1> localVarResponse = await GetTeamCampaignsWithHttpInfoAsync(teamId, after, before, limit, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List Team Campaigns 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamId">Team ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TeamCampaignPaginatedResponse1)</returns>
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<TeamCampaignPaginatedResponse1>> GetTeamCampaignsWithHttpInfoAsync(string teamId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'teamId' is set
            if (teamId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'teamId' when calling TeamApi->GetTeamCampaigns");
            }


            TiltifyV5.Client.RequestOptions localVarRequestOptions = new TiltifyV5.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = TiltifyV5.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = TiltifyV5.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("team_id", TiltifyV5.Client.ClientUtils.ParameterToString(teamId)); // path parameter
            if (after != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "after", after));
            }
            if (before != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "before", before));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }

            localVarRequestOptions.Operation = "TeamApi.GetTeamCampaigns";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<TeamCampaignPaginatedResponse1>("/api/public/teams/{team_id}/team_campaigns", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTeamCampaigns", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List team members 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamId">Team ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>TeamMemberPaginatedResponse1</returns>
        public TeamMemberPaginatedResponse1 GetTeamMembers(string teamId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<TeamMemberPaginatedResponse1> localVarResponse = GetTeamMembersWithHttpInfo(teamId, after, before, limit);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List team members 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamId">Team ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of TeamMemberPaginatedResponse1</returns>
        public TiltifyV5.Client.ApiResponse<TeamMemberPaginatedResponse1> GetTeamMembersWithHttpInfo(string teamId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            // verify the required parameter 'teamId' is set
            if (teamId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'teamId' when calling TeamApi->GetTeamMembers");
            }

            TiltifyV5.Client.RequestOptions localVarRequestOptions = new TiltifyV5.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = TiltifyV5.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = TiltifyV5.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("team_id", TiltifyV5.Client.ClientUtils.ParameterToString(teamId)); // path parameter
            if (after != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "after", after));
            }
            if (before != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "before", before));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }

            localVarRequestOptions.Operation = "TeamApi.GetTeamMembers";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<TeamMemberPaginatedResponse1>("/api/public/teams/{team_id}/members", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTeamMembers", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List team members 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamId">Team ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TeamMemberPaginatedResponse1</returns>
        public async System.Threading.Tasks.Task<TeamMemberPaginatedResponse1> GetTeamMembersAsync(string teamId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<TeamMemberPaginatedResponse1> localVarResponse = await GetTeamMembersWithHttpInfoAsync(teamId, after, before, limit, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List team members 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamId">Team ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TeamMemberPaginatedResponse1)</returns>
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<TeamMemberPaginatedResponse1>> GetTeamMembersWithHttpInfoAsync(string teamId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'teamId' is set
            if (teamId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'teamId' when calling TeamApi->GetTeamMembers");
            }


            TiltifyV5.Client.RequestOptions localVarRequestOptions = new TiltifyV5.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = TiltifyV5.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = TiltifyV5.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("team_id", TiltifyV5.Client.ClientUtils.ParameterToString(teamId)); // path parameter
            if (after != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "after", after));
            }
            if (before != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "before", before));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }

            localVarRequestOptions.Operation = "TeamApi.GetTeamMembers";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<TeamMemberPaginatedResponse1>("/api/public/teams/{team_id}/members", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTeamMembers", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}
