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
    public interface IUserApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Get by ID
        /// </summary>
        /// <remarks>
        /// Returns a user by its ID
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">User ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>UserResponse1</returns>
        UserResponse1 GetUser(string userId, int operationIndex = 0);

        /// <summary>
        /// Get by ID
        /// </summary>
        /// <remarks>
        /// Returns a user by its ID
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">User ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of UserResponse1</returns>
        ApiResponse<UserResponse1> GetUserWithHttpInfo(string userId, int operationIndex = 0);
        /// <summary>
        /// List campaigns
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">User ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>TeamPaginatedResponse1</returns>
        TeamPaginatedResponse1 GetUserCampaigns(string userId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);

        /// <summary>
        /// List campaigns
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">User ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of TeamPaginatedResponse1</returns>
        ApiResponse<TeamPaginatedResponse1> GetUserCampaignsWithHttpInfo(string userId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);
        /// <summary>
        /// List all Campaigns and Team Campaigns by User ID
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">User ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>EventPaginatedResponse1</returns>
        EventPaginatedResponse1 GetUserCampaignsAndTeamCampaigns(string userId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);

        /// <summary>
        /// List all Campaigns and Team Campaigns by User ID
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">User ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of EventPaginatedResponse1</returns>
        ApiResponse<EventPaginatedResponse1> GetUserCampaignsAndTeamCampaignsWithHttpInfo(string userId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);
        /// <summary>
        /// List teams
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">User ID</param>
        /// <param name="role">Returns only teams where a user has a specific role (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>TeamPaginatedResponse1</returns>
        TeamPaginatedResponse1 GetUserTeams(string userId, string? role = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);

        /// <summary>
        /// List teams
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">User ID</param>
        /// <param name="role">Returns only teams where a user has a specific role (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of TeamPaginatedResponse1</returns>
        ApiResponse<TeamPaginatedResponse1> GetUserTeamsWithHttpInfo(string userId, string? role = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);
        /// <summary>
        /// Gets the current user for an access token
        /// </summary>
        /// <remarks>
        /// Returns a user for a given oauth access token
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>NullableUserResponse1</returns>
        NullableUserResponse1 V5ApiWebPublicUserControllerCurrentUser(int operationIndex = 0);

        /// <summary>
        /// Gets the current user for an access token
        /// </summary>
        /// <remarks>
        /// Returns a user for a given oauth access token
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of NullableUserResponse1</returns>
        ApiResponse<NullableUserResponse1> V5ApiWebPublicUserControllerCurrentUserWithHttpInfo(int operationIndex = 0);
        /// <summary>
        /// Get by slug
        /// </summary>
        /// <remarks>
        /// Returns a user by its slug
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="slug">User slug</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>UserResponse1</returns>
        UserResponse1 V5ApiWebPublicUserControllerShowSlug(string slug, int operationIndex = 0);

        /// <summary>
        /// Get by slug
        /// </summary>
        /// <remarks>
        /// Returns a user by its slug
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="slug">User slug</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of UserResponse1</returns>
        ApiResponse<UserResponse1> V5ApiWebPublicUserControllerShowSlugWithHttpInfo(string slug, int operationIndex = 0);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IUserApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Get by ID
        /// </summary>
        /// <remarks>
        /// Returns a user by its ID
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">User ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of UserResponse1</returns>
        System.Threading.Tasks.Task<UserResponse1> GetUserAsync(string userId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get by ID
        /// </summary>
        /// <remarks>
        /// Returns a user by its ID
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">User ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (UserResponse1)</returns>
        System.Threading.Tasks.Task<ApiResponse<UserResponse1>> GetUserWithHttpInfoAsync(string userId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List campaigns
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">User ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TeamPaginatedResponse1</returns>
        System.Threading.Tasks.Task<TeamPaginatedResponse1> GetUserCampaignsAsync(string userId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List campaigns
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">User ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TeamPaginatedResponse1)</returns>
        System.Threading.Tasks.Task<ApiResponse<TeamPaginatedResponse1>> GetUserCampaignsWithHttpInfoAsync(string userId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List all Campaigns and Team Campaigns by User ID
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">User ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of EventPaginatedResponse1</returns>
        System.Threading.Tasks.Task<EventPaginatedResponse1> GetUserCampaignsAndTeamCampaignsAsync(string userId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List all Campaigns and Team Campaigns by User ID
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">User ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (EventPaginatedResponse1)</returns>
        System.Threading.Tasks.Task<ApiResponse<EventPaginatedResponse1>> GetUserCampaignsAndTeamCampaignsWithHttpInfoAsync(string userId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List teams
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">User ID</param>
        /// <param name="role">Returns only teams where a user has a specific role (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TeamPaginatedResponse1</returns>
        System.Threading.Tasks.Task<TeamPaginatedResponse1> GetUserTeamsAsync(string userId, string? role = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List teams
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">User ID</param>
        /// <param name="role">Returns only teams where a user has a specific role (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TeamPaginatedResponse1)</returns>
        System.Threading.Tasks.Task<ApiResponse<TeamPaginatedResponse1>> GetUserTeamsWithHttpInfoAsync(string userId, string? role = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Gets the current user for an access token
        /// </summary>
        /// <remarks>
        /// Returns a user for a given oauth access token
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of NullableUserResponse1</returns>
        System.Threading.Tasks.Task<NullableUserResponse1> V5ApiWebPublicUserControllerCurrentUserAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Gets the current user for an access token
        /// </summary>
        /// <remarks>
        /// Returns a user for a given oauth access token
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (NullableUserResponse1)</returns>
        System.Threading.Tasks.Task<ApiResponse<NullableUserResponse1>> V5ApiWebPublicUserControllerCurrentUserWithHttpInfoAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get by slug
        /// </summary>
        /// <remarks>
        /// Returns a user by its slug
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="slug">User slug</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of UserResponse1</returns>
        System.Threading.Tasks.Task<UserResponse1> V5ApiWebPublicUserControllerShowSlugAsync(string slug, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get by slug
        /// </summary>
        /// <remarks>
        /// Returns a user by its slug
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="slug">User slug</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (UserResponse1)</returns>
        System.Threading.Tasks.Task<ApiResponse<UserResponse1>> V5ApiWebPublicUserControllerShowSlugWithHttpInfoAsync(string slug, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IUserApi : IUserApiSync, IUserApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class UserApi : IUserApi
    {
        private TiltifyV5.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserApi"/> class.
        /// </summary>
        /// <returns></returns>
        public UserApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserApi"/> class.
        /// </summary>
        /// <returns></returns>
        public UserApi(string basePath)
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
        /// Initializes a new instance of the <see cref="UserApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public UserApi(TiltifyV5.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="UserApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public UserApi(TiltifyV5.Client.ISynchronousClient client, TiltifyV5.Client.IAsynchronousClient asyncClient, TiltifyV5.Client.IReadableConfiguration configuration)
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
        /// Get by ID Returns a user by its ID
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">User ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>UserResponse1</returns>
        public UserResponse1 GetUser(string userId, int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<UserResponse1> localVarResponse = GetUserWithHttpInfo(userId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get by ID Returns a user by its ID
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">User ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of UserResponse1</returns>
        public TiltifyV5.Client.ApiResponse<UserResponse1> GetUserWithHttpInfo(string userId, int operationIndex = 0)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'userId' when calling UserApi->GetUser");
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

            localVarRequestOptions.PathParameters.Add("user_id", TiltifyV5.Client.ClientUtils.ParameterToString(userId)); // path parameter

            localVarRequestOptions.Operation = "UserApi.GetUser";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<UserResponse1>("/api/public/users/{user_id}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetUser", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get by ID Returns a user by its ID
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">User ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of UserResponse1</returns>
        public async System.Threading.Tasks.Task<UserResponse1> GetUserAsync(string userId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<UserResponse1> localVarResponse = await GetUserWithHttpInfoAsync(userId, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get by ID Returns a user by its ID
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">User ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (UserResponse1)</returns>
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<UserResponse1>> GetUserWithHttpInfoAsync(string userId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'userId' when calling UserApi->GetUser");
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

            localVarRequestOptions.PathParameters.Add("user_id", TiltifyV5.Client.ClientUtils.ParameterToString(userId)); // path parameter

            localVarRequestOptions.Operation = "UserApi.GetUser";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<UserResponse1>("/api/public/users/{user_id}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetUser", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List campaigns 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">User ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>TeamPaginatedResponse1</returns>
        public TeamPaginatedResponse1 GetUserCampaigns(string userId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<TeamPaginatedResponse1> localVarResponse = GetUserCampaignsWithHttpInfo(userId, after, before, limit);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List campaigns 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">User ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of TeamPaginatedResponse1</returns>
        public TiltifyV5.Client.ApiResponse<TeamPaginatedResponse1> GetUserCampaignsWithHttpInfo(string userId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'userId' when calling UserApi->GetUserCampaigns");
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

            localVarRequestOptions.PathParameters.Add("user_id", TiltifyV5.Client.ClientUtils.ParameterToString(userId)); // path parameter
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

            localVarRequestOptions.Operation = "UserApi.GetUserCampaigns";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<TeamPaginatedResponse1>("/api/public/users/{user_id}/campaigns", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetUserCampaigns", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List campaigns 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">User ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TeamPaginatedResponse1</returns>
        public async System.Threading.Tasks.Task<TeamPaginatedResponse1> GetUserCampaignsAsync(string userId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<TeamPaginatedResponse1> localVarResponse = await GetUserCampaignsWithHttpInfoAsync(userId, after, before, limit, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List campaigns 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">User ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TeamPaginatedResponse1)</returns>
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<TeamPaginatedResponse1>> GetUserCampaignsWithHttpInfoAsync(string userId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'userId' when calling UserApi->GetUserCampaigns");
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

            localVarRequestOptions.PathParameters.Add("user_id", TiltifyV5.Client.ClientUtils.ParameterToString(userId)); // path parameter
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

            localVarRequestOptions.Operation = "UserApi.GetUserCampaigns";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<TeamPaginatedResponse1>("/api/public/users/{user_id}/campaigns", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetUserCampaigns", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List all Campaigns and Team Campaigns by User ID 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">User ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>EventPaginatedResponse1</returns>
        public EventPaginatedResponse1 GetUserCampaignsAndTeamCampaigns(string userId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<EventPaginatedResponse1> localVarResponse = GetUserCampaignsAndTeamCampaignsWithHttpInfo(userId, after, before, limit);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List all Campaigns and Team Campaigns by User ID 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">User ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of EventPaginatedResponse1</returns>
        public TiltifyV5.Client.ApiResponse<EventPaginatedResponse1> GetUserCampaignsAndTeamCampaignsWithHttpInfo(string userId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'userId' when calling UserApi->GetUserCampaignsAndTeamCampaigns");
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

            localVarRequestOptions.PathParameters.Add("user_id", TiltifyV5.Client.ClientUtils.ParameterToString(userId)); // path parameter
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

            localVarRequestOptions.Operation = "UserApi.GetUserCampaignsAndTeamCampaigns";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<EventPaginatedResponse1>("/api/public/users/{user_id}/integration_events", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetUserCampaignsAndTeamCampaigns", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List all Campaigns and Team Campaigns by User ID 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">User ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of EventPaginatedResponse1</returns>
        public async System.Threading.Tasks.Task<EventPaginatedResponse1> GetUserCampaignsAndTeamCampaignsAsync(string userId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<EventPaginatedResponse1> localVarResponse = await GetUserCampaignsAndTeamCampaignsWithHttpInfoAsync(userId, after, before, limit, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List all Campaigns and Team Campaigns by User ID 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">User ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (EventPaginatedResponse1)</returns>
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<EventPaginatedResponse1>> GetUserCampaignsAndTeamCampaignsWithHttpInfoAsync(string userId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'userId' when calling UserApi->GetUserCampaignsAndTeamCampaigns");
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

            localVarRequestOptions.PathParameters.Add("user_id", TiltifyV5.Client.ClientUtils.ParameterToString(userId)); // path parameter
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

            localVarRequestOptions.Operation = "UserApi.GetUserCampaignsAndTeamCampaigns";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<EventPaginatedResponse1>("/api/public/users/{user_id}/integration_events", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetUserCampaignsAndTeamCampaigns", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List teams 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">User ID</param>
        /// <param name="role">Returns only teams where a user has a specific role (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>TeamPaginatedResponse1</returns>
        public TeamPaginatedResponse1 GetUserTeams(string userId, string? role = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<TeamPaginatedResponse1> localVarResponse = GetUserTeamsWithHttpInfo(userId, role, after, before, limit);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List teams 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">User ID</param>
        /// <param name="role">Returns only teams where a user has a specific role (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of TeamPaginatedResponse1</returns>
        public TiltifyV5.Client.ApiResponse<TeamPaginatedResponse1> GetUserTeamsWithHttpInfo(string userId, string? role = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'userId' when calling UserApi->GetUserTeams");
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

            localVarRequestOptions.PathParameters.Add("user_id", TiltifyV5.Client.ClientUtils.ParameterToString(userId)); // path parameter
            if (role != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "role", role));
            }
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

            localVarRequestOptions.Operation = "UserApi.GetUserTeams";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<TeamPaginatedResponse1>("/api/public/users/{user_id}/teams", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetUserTeams", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List teams 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">User ID</param>
        /// <param name="role">Returns only teams where a user has a specific role (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TeamPaginatedResponse1</returns>
        public async System.Threading.Tasks.Task<TeamPaginatedResponse1> GetUserTeamsAsync(string userId, string? role = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<TeamPaginatedResponse1> localVarResponse = await GetUserTeamsWithHttpInfoAsync(userId, role, after, before, limit, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List teams 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">User ID</param>
        /// <param name="role">Returns only teams where a user has a specific role (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TeamPaginatedResponse1)</returns>
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<TeamPaginatedResponse1>> GetUserTeamsWithHttpInfoAsync(string userId, string? role = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'userId' when calling UserApi->GetUserTeams");
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

            localVarRequestOptions.PathParameters.Add("user_id", TiltifyV5.Client.ClientUtils.ParameterToString(userId)); // path parameter
            if (role != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "role", role));
            }
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

            localVarRequestOptions.Operation = "UserApi.GetUserTeams";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<TeamPaginatedResponse1>("/api/public/users/{user_id}/teams", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetUserTeams", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Gets the current user for an access token Returns a user for a given oauth access token
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>NullableUserResponse1</returns>
        public NullableUserResponse1 V5ApiWebPublicUserControllerCurrentUser(int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<NullableUserResponse1> localVarResponse = V5ApiWebPublicUserControllerCurrentUserWithHttpInfo();
            return localVarResponse.Data;
        }

        /// <summary>
        /// Gets the current user for an access token Returns a user for a given oauth access token
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of NullableUserResponse1</returns>
        public TiltifyV5.Client.ApiResponse<NullableUserResponse1> V5ApiWebPublicUserControllerCurrentUserWithHttpInfo(int operationIndex = 0)
        {
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


            localVarRequestOptions.Operation = "UserApi.V5ApiWebPublicUserControllerCurrentUser";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<NullableUserResponse1>("/api/public/current-user", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V5ApiWebPublicUserControllerCurrentUser", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Gets the current user for an access token Returns a user for a given oauth access token
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of NullableUserResponse1</returns>
        public async System.Threading.Tasks.Task<NullableUserResponse1> V5ApiWebPublicUserControllerCurrentUserAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<NullableUserResponse1> localVarResponse = await V5ApiWebPublicUserControllerCurrentUserWithHttpInfoAsync(operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Gets the current user for an access token Returns a user for a given oauth access token
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (NullableUserResponse1)</returns>
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<NullableUserResponse1>> V5ApiWebPublicUserControllerCurrentUserWithHttpInfoAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

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


            localVarRequestOptions.Operation = "UserApi.V5ApiWebPublicUserControllerCurrentUser";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<NullableUserResponse1>("/api/public/current-user", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V5ApiWebPublicUserControllerCurrentUser", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get by slug Returns a user by its slug
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="slug">User slug</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>UserResponse1</returns>
        public UserResponse1 V5ApiWebPublicUserControllerShowSlug(string slug, int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<UserResponse1> localVarResponse = V5ApiWebPublicUserControllerShowSlugWithHttpInfo(slug);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get by slug Returns a user by its slug
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="slug">User slug</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of UserResponse1</returns>
        public TiltifyV5.Client.ApiResponse<UserResponse1> V5ApiWebPublicUserControllerShowSlugWithHttpInfo(string slug, int operationIndex = 0)
        {
            // verify the required parameter 'slug' is set
            if (slug == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'slug' when calling UserApi->V5ApiWebPublicUserControllerShowSlug");
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

            localVarRequestOptions.Operation = "UserApi.V5ApiWebPublicUserControllerShowSlug";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<UserResponse1>("/api/public/users/by/slug/{slug}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V5ApiWebPublicUserControllerShowSlug", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get by slug Returns a user by its slug
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="slug">User slug</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of UserResponse1</returns>
        public async System.Threading.Tasks.Task<UserResponse1> V5ApiWebPublicUserControllerShowSlugAsync(string slug, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<UserResponse1> localVarResponse = await V5ApiWebPublicUserControllerShowSlugWithHttpInfoAsync(slug, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get by slug Returns a user by its slug
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="slug">User slug</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (UserResponse1)</returns>
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<UserResponse1>> V5ApiWebPublicUserControllerShowSlugWithHttpInfoAsync(string slug, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'slug' is set
            if (slug == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'slug' when calling UserApi->V5ApiWebPublicUserControllerShowSlug");
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

            localVarRequestOptions.Operation = "UserApi.V5ApiWebPublicUserControllerShowSlug";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<UserResponse1>("/api/public/users/by/slug/{slug}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V5ApiWebPublicUserControllerShowSlug", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}
