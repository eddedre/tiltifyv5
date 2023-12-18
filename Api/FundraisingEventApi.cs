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
    public interface IFundraisingEventApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Get by ID
        /// </summary>
        /// <remarks>
        /// Returns a fundraising event by its ID
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>FundraisingEventResponse1</returns>
        FundraisingEventResponse1 GetFundraisingEvent(string fundraisingEventId, int operationIndex = 0);

        /// <summary>
        /// Get by ID
        /// </summary>
        /// <remarks>
        /// Returns a fundraising event by its ID
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of FundraisingEventResponse1</returns>
        ApiResponse<FundraisingEventResponse1> GetFundraisingEventWithHttpInfo(string fundraisingEventId, int operationIndex = 0);
        /// <summary>
        /// List configured leaderboards
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">fundraising event id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ConfiguredLeaderboardResponse1</returns>
        [Obsolete]
        ConfiguredLeaderboardResponse1 GetFundraisingEventConfiguredLeaderboards(string fundraisingEventId, int operationIndex = 0);

        /// <summary>
        /// List configured leaderboards
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">fundraising event id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ConfiguredLeaderboardResponse1</returns>
        [Obsolete]
        ApiResponse<ConfiguredLeaderboardResponse1> GetFundraisingEventConfiguredLeaderboardsWithHttpInfo(string fundraisingEventId, int operationIndex = 0);
        /// <summary>
        /// List donations
        /// </summary>
        /// <remarks>
        ///  This endpoint will list donations for a given Fundraising Event. Contact  support for access to this endpoint. 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">FundraisingEvent ID or legacy ID</param>
        /// <param name="completedBefore">Returns only donations that have been completed before the given moment in ISO8601 format (optional)</param>
        /// <param name="completedAfter">Returns only donations that have been completed after the given moment in ISO8601 format (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>DonationPaginatedResponse1</returns>
        [Obsolete]
        DonationPaginatedResponse1 GetFundraisingEventDonations(string fundraisingEventId, string? completedBefore = default(string?), string? completedAfter = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);

        /// <summary>
        /// List donations
        /// </summary>
        /// <remarks>
        ///  This endpoint will list donations for a given Fundraising Event. Contact  support for access to this endpoint. 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">FundraisingEvent ID or legacy ID</param>
        /// <param name="completedBefore">Returns only donations that have been completed before the given moment in ISO8601 format (optional)</param>
        /// <param name="completedAfter">Returns only donations that have been completed after the given moment in ISO8601 format (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of DonationPaginatedResponse1</returns>
        [Obsolete]
        ApiResponse<DonationPaginatedResponse1> GetFundraisingEventDonationsWithHttpInfo(string fundraisingEventId, string? completedBefore = default(string?), string? completedAfter = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);
        /// <summary>
        /// List campaigns
        /// </summary>
        /// <remarks>
        /// Returns supporting campaigns by Fundraising Event ID
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising event ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>EventPaginatedResponse1</returns>
        EventPaginatedResponse1 GetFundraisingEventSupportingEvents(string fundraisingEventId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);

        /// <summary>
        /// List campaigns
        /// </summary>
        /// <remarks>
        /// Returns supporting campaigns by Fundraising Event ID
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising event ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of EventPaginatedResponse1</returns>
        ApiResponse<EventPaginatedResponse1> GetFundraisingEventSupportingEventsWithHttpInfo(string fundraisingEventId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);
        /// <summary>
        /// List top donors
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>LeaderboardEntryPaginatedResponse1</returns>
        LeaderboardEntryPaginatedResponse1 V5ApiWebPublicFundraisingEventLeaderboardControllerDonor(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);

        /// <summary>
        /// List top donors
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of LeaderboardEntryPaginatedResponse1</returns>
        ApiResponse<LeaderboardEntryPaginatedResponse1> V5ApiWebPublicFundraisingEventLeaderboardControllerDonorWithHttpInfo(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);
        /// <summary>
        /// List top teams
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>LeaderboardEntryPaginatedResponse1</returns>
        LeaderboardEntryPaginatedResponse1 V5ApiWebPublicFundraisingEventLeaderboardControllerTeam(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);

        /// <summary>
        /// List top teams
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of LeaderboardEntryPaginatedResponse1</returns>
        ApiResponse<LeaderboardEntryPaginatedResponse1> V5ApiWebPublicFundraisingEventLeaderboardControllerTeamWithHttpInfo(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);
        /// <summary>
        /// List top teams fitness distances
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>LeaderboardEntryPaginatedResponse1</returns>
        LeaderboardEntryPaginatedResponse1 V5ApiWebPublicFundraisingEventLeaderboardControllerTeamFitnessDistance(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);

        /// <summary>
        /// List top teams fitness distances
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of LeaderboardEntryPaginatedResponse1</returns>
        ApiResponse<LeaderboardEntryPaginatedResponse1> V5ApiWebPublicFundraisingEventLeaderboardControllerTeamFitnessDistanceWithHttpInfo(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);
        /// <summary>
        /// List top teams fitness times
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>LeaderboardEntryPaginatedResponse1</returns>
        LeaderboardEntryPaginatedResponse1 V5ApiWebPublicFundraisingEventLeaderboardControllerTeamFitnessTime(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);

        /// <summary>
        /// List top teams fitness times
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of LeaderboardEntryPaginatedResponse1</returns>
        ApiResponse<LeaderboardEntryPaginatedResponse1> V5ApiWebPublicFundraisingEventLeaderboardControllerTeamFitnessTimeWithHttpInfo(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);
        /// <summary>
        /// List top fundraisers
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>LeaderboardEntryPaginatedResponse1</returns>
        LeaderboardEntryPaginatedResponse1 V5ApiWebPublicFundraisingEventLeaderboardControllerUser(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);

        /// <summary>
        /// List top fundraisers
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of LeaderboardEntryPaginatedResponse1</returns>
        ApiResponse<LeaderboardEntryPaginatedResponse1> V5ApiWebPublicFundraisingEventLeaderboardControllerUserWithHttpInfo(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);
        /// <summary>
        /// List top users fitness distances
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>LeaderboardEntryPaginatedResponse1</returns>
        LeaderboardEntryPaginatedResponse1 V5ApiWebPublicFundraisingEventLeaderboardControllerUserFitnessDistance(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);

        /// <summary>
        /// List top users fitness distances
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of LeaderboardEntryPaginatedResponse1</returns>
        ApiResponse<LeaderboardEntryPaginatedResponse1> V5ApiWebPublicFundraisingEventLeaderboardControllerUserFitnessDistanceWithHttpInfo(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);
        /// <summary>
        /// List top users fitness times
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>LeaderboardEntryPaginatedResponse1</returns>
        LeaderboardEntryPaginatedResponse1 V5ApiWebPublicFundraisingEventLeaderboardControllerUserFitnessTime(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);

        /// <summary>
        /// List top users fitness times
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of LeaderboardEntryPaginatedResponse1</returns>
        ApiResponse<LeaderboardEntryPaginatedResponse1> V5ApiWebPublicFundraisingEventLeaderboardControllerUserFitnessTimeWithHttpInfo(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IFundraisingEventApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Get by ID
        /// </summary>
        /// <remarks>
        /// Returns a fundraising event by its ID
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of FundraisingEventResponse1</returns>
        System.Threading.Tasks.Task<FundraisingEventResponse1> GetFundraisingEventAsync(string fundraisingEventId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get by ID
        /// </summary>
        /// <remarks>
        /// Returns a fundraising event by its ID
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (FundraisingEventResponse1)</returns>
        System.Threading.Tasks.Task<ApiResponse<FundraisingEventResponse1>> GetFundraisingEventWithHttpInfoAsync(string fundraisingEventId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List configured leaderboards
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">fundraising event id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ConfiguredLeaderboardResponse1</returns>
        [Obsolete]
        System.Threading.Tasks.Task<ConfiguredLeaderboardResponse1> GetFundraisingEventConfiguredLeaderboardsAsync(string fundraisingEventId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List configured leaderboards
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">fundraising event id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ConfiguredLeaderboardResponse1)</returns>
        [Obsolete]
        System.Threading.Tasks.Task<ApiResponse<ConfiguredLeaderboardResponse1>> GetFundraisingEventConfiguredLeaderboardsWithHttpInfoAsync(string fundraisingEventId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List donations
        /// </summary>
        /// <remarks>
        ///  This endpoint will list donations for a given Fundraising Event. Contact  support for access to this endpoint. 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">FundraisingEvent ID or legacy ID</param>
        /// <param name="completedBefore">Returns only donations that have been completed before the given moment in ISO8601 format (optional)</param>
        /// <param name="completedAfter">Returns only donations that have been completed after the given moment in ISO8601 format (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DonationPaginatedResponse1</returns>
        [Obsolete]
        System.Threading.Tasks.Task<DonationPaginatedResponse1> GetFundraisingEventDonationsAsync(string fundraisingEventId, string? completedBefore = default(string?), string? completedAfter = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List donations
        /// </summary>
        /// <remarks>
        ///  This endpoint will list donations for a given Fundraising Event. Contact  support for access to this endpoint. 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">FundraisingEvent ID or legacy ID</param>
        /// <param name="completedBefore">Returns only donations that have been completed before the given moment in ISO8601 format (optional)</param>
        /// <param name="completedAfter">Returns only donations that have been completed after the given moment in ISO8601 format (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DonationPaginatedResponse1)</returns>
        [Obsolete]
        System.Threading.Tasks.Task<ApiResponse<DonationPaginatedResponse1>> GetFundraisingEventDonationsWithHttpInfoAsync(string fundraisingEventId, string? completedBefore = default(string?), string? completedAfter = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List campaigns
        /// </summary>
        /// <remarks>
        /// Returns supporting campaigns by Fundraising Event ID
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising event ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of EventPaginatedResponse1</returns>
        System.Threading.Tasks.Task<EventPaginatedResponse1> GetFundraisingEventSupportingEventsAsync(string fundraisingEventId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List campaigns
        /// </summary>
        /// <remarks>
        /// Returns supporting campaigns by Fundraising Event ID
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising event ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (EventPaginatedResponse1)</returns>
        System.Threading.Tasks.Task<ApiResponse<EventPaginatedResponse1>> GetFundraisingEventSupportingEventsWithHttpInfoAsync(string fundraisingEventId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List top donors
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of LeaderboardEntryPaginatedResponse1</returns>
        System.Threading.Tasks.Task<LeaderboardEntryPaginatedResponse1> V5ApiWebPublicFundraisingEventLeaderboardControllerDonorAsync(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List top donors
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (LeaderboardEntryPaginatedResponse1)</returns>
        System.Threading.Tasks.Task<ApiResponse<LeaderboardEntryPaginatedResponse1>> V5ApiWebPublicFundraisingEventLeaderboardControllerDonorWithHttpInfoAsync(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List top teams
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of LeaderboardEntryPaginatedResponse1</returns>
        System.Threading.Tasks.Task<LeaderboardEntryPaginatedResponse1> V5ApiWebPublicFundraisingEventLeaderboardControllerTeamAsync(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List top teams
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (LeaderboardEntryPaginatedResponse1)</returns>
        System.Threading.Tasks.Task<ApiResponse<LeaderboardEntryPaginatedResponse1>> V5ApiWebPublicFundraisingEventLeaderboardControllerTeamWithHttpInfoAsync(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List top teams fitness distances
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of LeaderboardEntryPaginatedResponse1</returns>
        System.Threading.Tasks.Task<LeaderboardEntryPaginatedResponse1> V5ApiWebPublicFundraisingEventLeaderboardControllerTeamFitnessDistanceAsync(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List top teams fitness distances
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (LeaderboardEntryPaginatedResponse1)</returns>
        System.Threading.Tasks.Task<ApiResponse<LeaderboardEntryPaginatedResponse1>> V5ApiWebPublicFundraisingEventLeaderboardControllerTeamFitnessDistanceWithHttpInfoAsync(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List top teams fitness times
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of LeaderboardEntryPaginatedResponse1</returns>
        System.Threading.Tasks.Task<LeaderboardEntryPaginatedResponse1> V5ApiWebPublicFundraisingEventLeaderboardControllerTeamFitnessTimeAsync(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List top teams fitness times
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (LeaderboardEntryPaginatedResponse1)</returns>
        System.Threading.Tasks.Task<ApiResponse<LeaderboardEntryPaginatedResponse1>> V5ApiWebPublicFundraisingEventLeaderboardControllerTeamFitnessTimeWithHttpInfoAsync(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List top fundraisers
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of LeaderboardEntryPaginatedResponse1</returns>
        System.Threading.Tasks.Task<LeaderboardEntryPaginatedResponse1> V5ApiWebPublicFundraisingEventLeaderboardControllerUserAsync(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List top fundraisers
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (LeaderboardEntryPaginatedResponse1)</returns>
        System.Threading.Tasks.Task<ApiResponse<LeaderboardEntryPaginatedResponse1>> V5ApiWebPublicFundraisingEventLeaderboardControllerUserWithHttpInfoAsync(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List top users fitness distances
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of LeaderboardEntryPaginatedResponse1</returns>
        System.Threading.Tasks.Task<LeaderboardEntryPaginatedResponse1> V5ApiWebPublicFundraisingEventLeaderboardControllerUserFitnessDistanceAsync(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List top users fitness distances
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (LeaderboardEntryPaginatedResponse1)</returns>
        System.Threading.Tasks.Task<ApiResponse<LeaderboardEntryPaginatedResponse1>> V5ApiWebPublicFundraisingEventLeaderboardControllerUserFitnessDistanceWithHttpInfoAsync(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List top users fitness times
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of LeaderboardEntryPaginatedResponse1</returns>
        System.Threading.Tasks.Task<LeaderboardEntryPaginatedResponse1> V5ApiWebPublicFundraisingEventLeaderboardControllerUserFitnessTimeAsync(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List top users fitness times
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (LeaderboardEntryPaginatedResponse1)</returns>
        System.Threading.Tasks.Task<ApiResponse<LeaderboardEntryPaginatedResponse1>> V5ApiWebPublicFundraisingEventLeaderboardControllerUserFitnessTimeWithHttpInfoAsync(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IFundraisingEventApi : IFundraisingEventApiSync, IFundraisingEventApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class FundraisingEventApi : IFundraisingEventApi
    {
        private TiltifyV5.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="FundraisingEventApi"/> class.
        /// </summary>
        /// <returns></returns>
        public FundraisingEventApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FundraisingEventApi"/> class.
        /// </summary>
        /// <returns></returns>
        public FundraisingEventApi(string basePath)
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
        /// Initializes a new instance of the <see cref="FundraisingEventApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public FundraisingEventApi(TiltifyV5.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="FundraisingEventApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public FundraisingEventApi(TiltifyV5.Client.ISynchronousClient client, TiltifyV5.Client.IAsynchronousClient asyncClient, TiltifyV5.Client.IReadableConfiguration configuration)
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
        /// Get by ID Returns a fundraising event by its ID
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>FundraisingEventResponse1</returns>
        public FundraisingEventResponse1 GetFundraisingEvent(string fundraisingEventId, int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<FundraisingEventResponse1> localVarResponse = GetFundraisingEventWithHttpInfo(fundraisingEventId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get by ID Returns a fundraising event by its ID
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of FundraisingEventResponse1</returns>
        public TiltifyV5.Client.ApiResponse<FundraisingEventResponse1> GetFundraisingEventWithHttpInfo(string fundraisingEventId, int operationIndex = 0)
        {
            // verify the required parameter 'fundraisingEventId' is set
            if (fundraisingEventId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'fundraisingEventId' when calling FundraisingEventApi->GetFundraisingEvent");
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

            localVarRequestOptions.PathParameters.Add("fundraising_event_id", TiltifyV5.Client.ClientUtils.ParameterToString(fundraisingEventId)); // path parameter

            localVarRequestOptions.Operation = "FundraisingEventApi.GetFundraisingEvent";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<FundraisingEventResponse1>("/api/public/fundraising_events/{fundraising_event_id}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetFundraisingEvent", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get by ID Returns a fundraising event by its ID
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of FundraisingEventResponse1</returns>
        public async System.Threading.Tasks.Task<FundraisingEventResponse1> GetFundraisingEventAsync(string fundraisingEventId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<FundraisingEventResponse1> localVarResponse = await GetFundraisingEventWithHttpInfoAsync(fundraisingEventId, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get by ID Returns a fundraising event by its ID
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (FundraisingEventResponse1)</returns>
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<FundraisingEventResponse1>> GetFundraisingEventWithHttpInfoAsync(string fundraisingEventId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'fundraisingEventId' is set
            if (fundraisingEventId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'fundraisingEventId' when calling FundraisingEventApi->GetFundraisingEvent");
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

            localVarRequestOptions.PathParameters.Add("fundraising_event_id", TiltifyV5.Client.ClientUtils.ParameterToString(fundraisingEventId)); // path parameter

            localVarRequestOptions.Operation = "FundraisingEventApi.GetFundraisingEvent";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<FundraisingEventResponse1>("/api/public/fundraising_events/{fundraising_event_id}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetFundraisingEvent", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List configured leaderboards 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">fundraising event id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ConfiguredLeaderboardResponse1</returns>
        [Obsolete]
        public ConfiguredLeaderboardResponse1 GetFundraisingEventConfiguredLeaderboards(string fundraisingEventId, int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<ConfiguredLeaderboardResponse1> localVarResponse = GetFundraisingEventConfiguredLeaderboardsWithHttpInfo(fundraisingEventId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List configured leaderboards 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">fundraising event id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ConfiguredLeaderboardResponse1</returns>
        [Obsolete]
        public TiltifyV5.Client.ApiResponse<ConfiguredLeaderboardResponse1> GetFundraisingEventConfiguredLeaderboardsWithHttpInfo(string fundraisingEventId, int operationIndex = 0)
        {
            // verify the required parameter 'fundraisingEventId' is set
            if (fundraisingEventId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'fundraisingEventId' when calling FundraisingEventApi->GetFundraisingEventConfiguredLeaderboards");
            }

            TiltifyV5.Client.RequestOptions localVarRequestOptions = new TiltifyV5.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json",
                "appliction/json"
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

            localVarRequestOptions.PathParameters.Add("fundraising_event_id", TiltifyV5.Client.ClientUtils.ParameterToString(fundraisingEventId)); // path parameter

            localVarRequestOptions.Operation = "FundraisingEventApi.GetFundraisingEventConfiguredLeaderboards";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<ConfiguredLeaderboardResponse1>("/api/public/fundraising_events/{fundraising_event_id}/configured_leaderboard", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetFundraisingEventConfiguredLeaderboards", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List configured leaderboards 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">fundraising event id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ConfiguredLeaderboardResponse1</returns>
        [Obsolete]
        public async System.Threading.Tasks.Task<ConfiguredLeaderboardResponse1> GetFundraisingEventConfiguredLeaderboardsAsync(string fundraisingEventId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<ConfiguredLeaderboardResponse1> localVarResponse = await GetFundraisingEventConfiguredLeaderboardsWithHttpInfoAsync(fundraisingEventId, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List configured leaderboards 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">fundraising event id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ConfiguredLeaderboardResponse1)</returns>
        [Obsolete]
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<ConfiguredLeaderboardResponse1>> GetFundraisingEventConfiguredLeaderboardsWithHttpInfoAsync(string fundraisingEventId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'fundraisingEventId' is set
            if (fundraisingEventId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'fundraisingEventId' when calling FundraisingEventApi->GetFundraisingEventConfiguredLeaderboards");
            }


            TiltifyV5.Client.RequestOptions localVarRequestOptions = new TiltifyV5.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json",
                "appliction/json"
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

            localVarRequestOptions.PathParameters.Add("fundraising_event_id", TiltifyV5.Client.ClientUtils.ParameterToString(fundraisingEventId)); // path parameter

            localVarRequestOptions.Operation = "FundraisingEventApi.GetFundraisingEventConfiguredLeaderboards";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<ConfiguredLeaderboardResponse1>("/api/public/fundraising_events/{fundraising_event_id}/configured_leaderboard", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetFundraisingEventConfiguredLeaderboards", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List donations  This endpoint will list donations for a given Fundraising Event. Contact  support for access to this endpoint. 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">FundraisingEvent ID or legacy ID</param>
        /// <param name="completedBefore">Returns only donations that have been completed before the given moment in ISO8601 format (optional)</param>
        /// <param name="completedAfter">Returns only donations that have been completed after the given moment in ISO8601 format (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>DonationPaginatedResponse1</returns>
        [Obsolete]
        public DonationPaginatedResponse1 GetFundraisingEventDonations(string fundraisingEventId, string? completedBefore = default(string?), string? completedAfter = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<DonationPaginatedResponse1> localVarResponse = GetFundraisingEventDonationsWithHttpInfo(fundraisingEventId, completedBefore, completedAfter, after, before, limit);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List donations  This endpoint will list donations for a given Fundraising Event. Contact  support for access to this endpoint. 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">FundraisingEvent ID or legacy ID</param>
        /// <param name="completedBefore">Returns only donations that have been completed before the given moment in ISO8601 format (optional)</param>
        /// <param name="completedAfter">Returns only donations that have been completed after the given moment in ISO8601 format (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of DonationPaginatedResponse1</returns>
        [Obsolete]
        public TiltifyV5.Client.ApiResponse<DonationPaginatedResponse1> GetFundraisingEventDonationsWithHttpInfo(string fundraisingEventId, string? completedBefore = default(string?), string? completedAfter = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            // verify the required parameter 'fundraisingEventId' is set
            if (fundraisingEventId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'fundraisingEventId' when calling FundraisingEventApi->GetFundraisingEventDonations");
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

            localVarRequestOptions.PathParameters.Add("fundraising_event_id", TiltifyV5.Client.ClientUtils.ParameterToString(fundraisingEventId)); // path parameter
            if (completedBefore != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "completed_before", completedBefore));
            }
            if (completedAfter != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "completed_after", completedAfter));
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

            localVarRequestOptions.Operation = "FundraisingEventApi.GetFundraisingEventDonations";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<DonationPaginatedResponse1>("/api/public/fundraising_events/{fundraising_event_id}/donations", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetFundraisingEventDonations", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List donations  This endpoint will list donations for a given Fundraising Event. Contact  support for access to this endpoint. 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">FundraisingEvent ID or legacy ID</param>
        /// <param name="completedBefore">Returns only donations that have been completed before the given moment in ISO8601 format (optional)</param>
        /// <param name="completedAfter">Returns only donations that have been completed after the given moment in ISO8601 format (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DonationPaginatedResponse1</returns>
        [Obsolete]
        public async System.Threading.Tasks.Task<DonationPaginatedResponse1> GetFundraisingEventDonationsAsync(string fundraisingEventId, string? completedBefore = default(string?), string? completedAfter = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<DonationPaginatedResponse1> localVarResponse = await GetFundraisingEventDonationsWithHttpInfoAsync(fundraisingEventId, completedBefore, completedAfter, after, before, limit, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List donations  This endpoint will list donations for a given Fundraising Event. Contact  support for access to this endpoint. 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">FundraisingEvent ID or legacy ID</param>
        /// <param name="completedBefore">Returns only donations that have been completed before the given moment in ISO8601 format (optional)</param>
        /// <param name="completedAfter">Returns only donations that have been completed after the given moment in ISO8601 format (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DonationPaginatedResponse1)</returns>
        [Obsolete]
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<DonationPaginatedResponse1>> GetFundraisingEventDonationsWithHttpInfoAsync(string fundraisingEventId, string? completedBefore = default(string?), string? completedAfter = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'fundraisingEventId' is set
            if (fundraisingEventId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'fundraisingEventId' when calling FundraisingEventApi->GetFundraisingEventDonations");
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

            localVarRequestOptions.PathParameters.Add("fundraising_event_id", TiltifyV5.Client.ClientUtils.ParameterToString(fundraisingEventId)); // path parameter
            if (completedBefore != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "completed_before", completedBefore));
            }
            if (completedAfter != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "completed_after", completedAfter));
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

            localVarRequestOptions.Operation = "FundraisingEventApi.GetFundraisingEventDonations";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<DonationPaginatedResponse1>("/api/public/fundraising_events/{fundraising_event_id}/donations", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetFundraisingEventDonations", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List campaigns Returns supporting campaigns by Fundraising Event ID
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising event ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>EventPaginatedResponse1</returns>
        public EventPaginatedResponse1 GetFundraisingEventSupportingEvents(string fundraisingEventId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<EventPaginatedResponse1> localVarResponse = GetFundraisingEventSupportingEventsWithHttpInfo(fundraisingEventId, after, before, limit);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List campaigns Returns supporting campaigns by Fundraising Event ID
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising event ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of EventPaginatedResponse1</returns>
        public TiltifyV5.Client.ApiResponse<EventPaginatedResponse1> GetFundraisingEventSupportingEventsWithHttpInfo(string fundraisingEventId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            // verify the required parameter 'fundraisingEventId' is set
            if (fundraisingEventId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'fundraisingEventId' when calling FundraisingEventApi->GetFundraisingEventSupportingEvents");
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

            localVarRequestOptions.PathParameters.Add("fundraising_event_id", TiltifyV5.Client.ClientUtils.ParameterToString(fundraisingEventId)); // path parameter
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

            localVarRequestOptions.Operation = "FundraisingEventApi.GetFundraisingEventSupportingEvents";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<EventPaginatedResponse1>("/api/public/fundraising_events/{fundraising_event_id}/supporting_events", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetFundraisingEventSupportingEvents", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List campaigns Returns supporting campaigns by Fundraising Event ID
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising event ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of EventPaginatedResponse1</returns>
        public async System.Threading.Tasks.Task<EventPaginatedResponse1> GetFundraisingEventSupportingEventsAsync(string fundraisingEventId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<EventPaginatedResponse1> localVarResponse = await GetFundraisingEventSupportingEventsWithHttpInfoAsync(fundraisingEventId, after, before, limit, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List campaigns Returns supporting campaigns by Fundraising Event ID
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising event ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (EventPaginatedResponse1)</returns>
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<EventPaginatedResponse1>> GetFundraisingEventSupportingEventsWithHttpInfoAsync(string fundraisingEventId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'fundraisingEventId' is set
            if (fundraisingEventId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'fundraisingEventId' when calling FundraisingEventApi->GetFundraisingEventSupportingEvents");
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

            localVarRequestOptions.PathParameters.Add("fundraising_event_id", TiltifyV5.Client.ClientUtils.ParameterToString(fundraisingEventId)); // path parameter
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

            localVarRequestOptions.Operation = "FundraisingEventApi.GetFundraisingEventSupportingEvents";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<EventPaginatedResponse1>("/api/public/fundraising_events/{fundraising_event_id}/supporting_events", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetFundraisingEventSupportingEvents", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List top donors 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>LeaderboardEntryPaginatedResponse1</returns>
        public LeaderboardEntryPaginatedResponse1 V5ApiWebPublicFundraisingEventLeaderboardControllerDonor(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<LeaderboardEntryPaginatedResponse1> localVarResponse = V5ApiWebPublicFundraisingEventLeaderboardControllerDonorWithHttpInfo(fundraisingEventId, timeType, after, before, limit);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List top donors 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of LeaderboardEntryPaginatedResponse1</returns>
        public TiltifyV5.Client.ApiResponse<LeaderboardEntryPaginatedResponse1> V5ApiWebPublicFundraisingEventLeaderboardControllerDonorWithHttpInfo(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            // verify the required parameter 'fundraisingEventId' is set
            if (fundraisingEventId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'fundraisingEventId' when calling FundraisingEventApi->V5ApiWebPublicFundraisingEventLeaderboardControllerDonor");
            }

            TiltifyV5.Client.RequestOptions localVarRequestOptions = new TiltifyV5.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json",
                "appliction/json"
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

            localVarRequestOptions.PathParameters.Add("fundraising_event_id", TiltifyV5.Client.ClientUtils.ParameterToString(fundraisingEventId)); // path parameter
            if (timeType != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "time_type", timeType));
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

            localVarRequestOptions.Operation = "FundraisingEventApi.V5ApiWebPublicFundraisingEventLeaderboardControllerDonor";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<LeaderboardEntryPaginatedResponse1>("/api/public/fundraising_events/{fundraising_event_id}/donor_leaderboard", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V5ApiWebPublicFundraisingEventLeaderboardControllerDonor", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List top donors 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of LeaderboardEntryPaginatedResponse1</returns>
        public async System.Threading.Tasks.Task<LeaderboardEntryPaginatedResponse1> V5ApiWebPublicFundraisingEventLeaderboardControllerDonorAsync(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<LeaderboardEntryPaginatedResponse1> localVarResponse = await V5ApiWebPublicFundraisingEventLeaderboardControllerDonorWithHttpInfoAsync(fundraisingEventId, timeType, after, before, limit, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List top donors 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (LeaderboardEntryPaginatedResponse1)</returns>
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<LeaderboardEntryPaginatedResponse1>> V5ApiWebPublicFundraisingEventLeaderboardControllerDonorWithHttpInfoAsync(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'fundraisingEventId' is set
            if (fundraisingEventId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'fundraisingEventId' when calling FundraisingEventApi->V5ApiWebPublicFundraisingEventLeaderboardControllerDonor");
            }


            TiltifyV5.Client.RequestOptions localVarRequestOptions = new TiltifyV5.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json",
                "appliction/json"
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

            localVarRequestOptions.PathParameters.Add("fundraising_event_id", TiltifyV5.Client.ClientUtils.ParameterToString(fundraisingEventId)); // path parameter
            if (timeType != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "time_type", timeType));
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

            localVarRequestOptions.Operation = "FundraisingEventApi.V5ApiWebPublicFundraisingEventLeaderboardControllerDonor";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<LeaderboardEntryPaginatedResponse1>("/api/public/fundraising_events/{fundraising_event_id}/donor_leaderboard", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V5ApiWebPublicFundraisingEventLeaderboardControllerDonor", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List top teams 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>LeaderboardEntryPaginatedResponse1</returns>
        public LeaderboardEntryPaginatedResponse1 V5ApiWebPublicFundraisingEventLeaderboardControllerTeam(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<LeaderboardEntryPaginatedResponse1> localVarResponse = V5ApiWebPublicFundraisingEventLeaderboardControllerTeamWithHttpInfo(fundraisingEventId, timeType, after, before, limit);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List top teams 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of LeaderboardEntryPaginatedResponse1</returns>
        public TiltifyV5.Client.ApiResponse<LeaderboardEntryPaginatedResponse1> V5ApiWebPublicFundraisingEventLeaderboardControllerTeamWithHttpInfo(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            // verify the required parameter 'fundraisingEventId' is set
            if (fundraisingEventId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'fundraisingEventId' when calling FundraisingEventApi->V5ApiWebPublicFundraisingEventLeaderboardControllerTeam");
            }

            TiltifyV5.Client.RequestOptions localVarRequestOptions = new TiltifyV5.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json",
                "appliction/json"
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

            localVarRequestOptions.PathParameters.Add("fundraising_event_id", TiltifyV5.Client.ClientUtils.ParameterToString(fundraisingEventId)); // path parameter
            if (timeType != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "time_type", timeType));
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

            localVarRequestOptions.Operation = "FundraisingEventApi.V5ApiWebPublicFundraisingEventLeaderboardControllerTeam";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<LeaderboardEntryPaginatedResponse1>("/api/public/fundraising_events/{fundraising_event_id}/team_leaderboard", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V5ApiWebPublicFundraisingEventLeaderboardControllerTeam", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List top teams 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of LeaderboardEntryPaginatedResponse1</returns>
        public async System.Threading.Tasks.Task<LeaderboardEntryPaginatedResponse1> V5ApiWebPublicFundraisingEventLeaderboardControllerTeamAsync(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<LeaderboardEntryPaginatedResponse1> localVarResponse = await V5ApiWebPublicFundraisingEventLeaderboardControllerTeamWithHttpInfoAsync(fundraisingEventId, timeType, after, before, limit, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List top teams 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (LeaderboardEntryPaginatedResponse1)</returns>
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<LeaderboardEntryPaginatedResponse1>> V5ApiWebPublicFundraisingEventLeaderboardControllerTeamWithHttpInfoAsync(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'fundraisingEventId' is set
            if (fundraisingEventId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'fundraisingEventId' when calling FundraisingEventApi->V5ApiWebPublicFundraisingEventLeaderboardControllerTeam");
            }


            TiltifyV5.Client.RequestOptions localVarRequestOptions = new TiltifyV5.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json",
                "appliction/json"
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

            localVarRequestOptions.PathParameters.Add("fundraising_event_id", TiltifyV5.Client.ClientUtils.ParameterToString(fundraisingEventId)); // path parameter
            if (timeType != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "time_type", timeType));
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

            localVarRequestOptions.Operation = "FundraisingEventApi.V5ApiWebPublicFundraisingEventLeaderboardControllerTeam";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<LeaderboardEntryPaginatedResponse1>("/api/public/fundraising_events/{fundraising_event_id}/team_leaderboard", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V5ApiWebPublicFundraisingEventLeaderboardControllerTeam", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List top teams fitness distances 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>LeaderboardEntryPaginatedResponse1</returns>
        public LeaderboardEntryPaginatedResponse1 V5ApiWebPublicFundraisingEventLeaderboardControllerTeamFitnessDistance(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<LeaderboardEntryPaginatedResponse1> localVarResponse = V5ApiWebPublicFundraisingEventLeaderboardControllerTeamFitnessDistanceWithHttpInfo(fundraisingEventId, timeType, after, before, limit);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List top teams fitness distances 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of LeaderboardEntryPaginatedResponse1</returns>
        public TiltifyV5.Client.ApiResponse<LeaderboardEntryPaginatedResponse1> V5ApiWebPublicFundraisingEventLeaderboardControllerTeamFitnessDistanceWithHttpInfo(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            // verify the required parameter 'fundraisingEventId' is set
            if (fundraisingEventId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'fundraisingEventId' when calling FundraisingEventApi->V5ApiWebPublicFundraisingEventLeaderboardControllerTeamFitnessDistance");
            }

            TiltifyV5.Client.RequestOptions localVarRequestOptions = new TiltifyV5.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json",
                "appliction/json"
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

            localVarRequestOptions.PathParameters.Add("fundraising_event_id", TiltifyV5.Client.ClientUtils.ParameterToString(fundraisingEventId)); // path parameter
            if (timeType != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "time_type", timeType));
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

            localVarRequestOptions.Operation = "FundraisingEventApi.V5ApiWebPublicFundraisingEventLeaderboardControllerTeamFitnessDistance";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<LeaderboardEntryPaginatedResponse1>("/api/public/fundraising_events/{fundraising_event_id}/team_fitness_distance_leaderboard", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V5ApiWebPublicFundraisingEventLeaderboardControllerTeamFitnessDistance", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List top teams fitness distances 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of LeaderboardEntryPaginatedResponse1</returns>
        public async System.Threading.Tasks.Task<LeaderboardEntryPaginatedResponse1> V5ApiWebPublicFundraisingEventLeaderboardControllerTeamFitnessDistanceAsync(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<LeaderboardEntryPaginatedResponse1> localVarResponse = await V5ApiWebPublicFundraisingEventLeaderboardControllerTeamFitnessDistanceWithHttpInfoAsync(fundraisingEventId, timeType, after, before, limit, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List top teams fitness distances 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (LeaderboardEntryPaginatedResponse1)</returns>
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<LeaderboardEntryPaginatedResponse1>> V5ApiWebPublicFundraisingEventLeaderboardControllerTeamFitnessDistanceWithHttpInfoAsync(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'fundraisingEventId' is set
            if (fundraisingEventId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'fundraisingEventId' when calling FundraisingEventApi->V5ApiWebPublicFundraisingEventLeaderboardControllerTeamFitnessDistance");
            }


            TiltifyV5.Client.RequestOptions localVarRequestOptions = new TiltifyV5.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json",
                "appliction/json"
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

            localVarRequestOptions.PathParameters.Add("fundraising_event_id", TiltifyV5.Client.ClientUtils.ParameterToString(fundraisingEventId)); // path parameter
            if (timeType != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "time_type", timeType));
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

            localVarRequestOptions.Operation = "FundraisingEventApi.V5ApiWebPublicFundraisingEventLeaderboardControllerTeamFitnessDistance";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<LeaderboardEntryPaginatedResponse1>("/api/public/fundraising_events/{fundraising_event_id}/team_fitness_distance_leaderboard", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V5ApiWebPublicFundraisingEventLeaderboardControllerTeamFitnessDistance", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List top teams fitness times 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>LeaderboardEntryPaginatedResponse1</returns>
        public LeaderboardEntryPaginatedResponse1 V5ApiWebPublicFundraisingEventLeaderboardControllerTeamFitnessTime(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<LeaderboardEntryPaginatedResponse1> localVarResponse = V5ApiWebPublicFundraisingEventLeaderboardControllerTeamFitnessTimeWithHttpInfo(fundraisingEventId, timeType, after, before, limit);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List top teams fitness times 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of LeaderboardEntryPaginatedResponse1</returns>
        public TiltifyV5.Client.ApiResponse<LeaderboardEntryPaginatedResponse1> V5ApiWebPublicFundraisingEventLeaderboardControllerTeamFitnessTimeWithHttpInfo(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            // verify the required parameter 'fundraisingEventId' is set
            if (fundraisingEventId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'fundraisingEventId' when calling FundraisingEventApi->V5ApiWebPublicFundraisingEventLeaderboardControllerTeamFitnessTime");
            }

            TiltifyV5.Client.RequestOptions localVarRequestOptions = new TiltifyV5.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json",
                "appliction/json"
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

            localVarRequestOptions.PathParameters.Add("fundraising_event_id", TiltifyV5.Client.ClientUtils.ParameterToString(fundraisingEventId)); // path parameter
            if (timeType != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "time_type", timeType));
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

            localVarRequestOptions.Operation = "FundraisingEventApi.V5ApiWebPublicFundraisingEventLeaderboardControllerTeamFitnessTime";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<LeaderboardEntryPaginatedResponse1>("/api/public/fundraising_events/{fundraising_event_id}/team_fitness_time_leaderboard", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V5ApiWebPublicFundraisingEventLeaderboardControllerTeamFitnessTime", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List top teams fitness times 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of LeaderboardEntryPaginatedResponse1</returns>
        public async System.Threading.Tasks.Task<LeaderboardEntryPaginatedResponse1> V5ApiWebPublicFundraisingEventLeaderboardControllerTeamFitnessTimeAsync(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<LeaderboardEntryPaginatedResponse1> localVarResponse = await V5ApiWebPublicFundraisingEventLeaderboardControllerTeamFitnessTimeWithHttpInfoAsync(fundraisingEventId, timeType, after, before, limit, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List top teams fitness times 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (LeaderboardEntryPaginatedResponse1)</returns>
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<LeaderboardEntryPaginatedResponse1>> V5ApiWebPublicFundraisingEventLeaderboardControllerTeamFitnessTimeWithHttpInfoAsync(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'fundraisingEventId' is set
            if (fundraisingEventId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'fundraisingEventId' when calling FundraisingEventApi->V5ApiWebPublicFundraisingEventLeaderboardControllerTeamFitnessTime");
            }


            TiltifyV5.Client.RequestOptions localVarRequestOptions = new TiltifyV5.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json",
                "appliction/json"
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

            localVarRequestOptions.PathParameters.Add("fundraising_event_id", TiltifyV5.Client.ClientUtils.ParameterToString(fundraisingEventId)); // path parameter
            if (timeType != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "time_type", timeType));
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

            localVarRequestOptions.Operation = "FundraisingEventApi.V5ApiWebPublicFundraisingEventLeaderboardControllerTeamFitnessTime";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<LeaderboardEntryPaginatedResponse1>("/api/public/fundraising_events/{fundraising_event_id}/team_fitness_time_leaderboard", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V5ApiWebPublicFundraisingEventLeaderboardControllerTeamFitnessTime", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List top fundraisers 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>LeaderboardEntryPaginatedResponse1</returns>
        public LeaderboardEntryPaginatedResponse1 V5ApiWebPublicFundraisingEventLeaderboardControllerUser(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<LeaderboardEntryPaginatedResponse1> localVarResponse = V5ApiWebPublicFundraisingEventLeaderboardControllerUserWithHttpInfo(fundraisingEventId, timeType, after, before, limit);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List top fundraisers 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of LeaderboardEntryPaginatedResponse1</returns>
        public TiltifyV5.Client.ApiResponse<LeaderboardEntryPaginatedResponse1> V5ApiWebPublicFundraisingEventLeaderboardControllerUserWithHttpInfo(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            // verify the required parameter 'fundraisingEventId' is set
            if (fundraisingEventId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'fundraisingEventId' when calling FundraisingEventApi->V5ApiWebPublicFundraisingEventLeaderboardControllerUser");
            }

            TiltifyV5.Client.RequestOptions localVarRequestOptions = new TiltifyV5.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json",
                "appliction/json"
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

            localVarRequestOptions.PathParameters.Add("fundraising_event_id", TiltifyV5.Client.ClientUtils.ParameterToString(fundraisingEventId)); // path parameter
            if (timeType != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "time_type", timeType));
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

            localVarRequestOptions.Operation = "FundraisingEventApi.V5ApiWebPublicFundraisingEventLeaderboardControllerUser";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<LeaderboardEntryPaginatedResponse1>("/api/public/fundraising_events/{fundraising_event_id}/user_leaderboard", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V5ApiWebPublicFundraisingEventLeaderboardControllerUser", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List top fundraisers 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of LeaderboardEntryPaginatedResponse1</returns>
        public async System.Threading.Tasks.Task<LeaderboardEntryPaginatedResponse1> V5ApiWebPublicFundraisingEventLeaderboardControllerUserAsync(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<LeaderboardEntryPaginatedResponse1> localVarResponse = await V5ApiWebPublicFundraisingEventLeaderboardControllerUserWithHttpInfoAsync(fundraisingEventId, timeType, after, before, limit, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List top fundraisers 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (LeaderboardEntryPaginatedResponse1)</returns>
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<LeaderboardEntryPaginatedResponse1>> V5ApiWebPublicFundraisingEventLeaderboardControllerUserWithHttpInfoAsync(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'fundraisingEventId' is set
            if (fundraisingEventId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'fundraisingEventId' when calling FundraisingEventApi->V5ApiWebPublicFundraisingEventLeaderboardControllerUser");
            }


            TiltifyV5.Client.RequestOptions localVarRequestOptions = new TiltifyV5.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json",
                "appliction/json"
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

            localVarRequestOptions.PathParameters.Add("fundraising_event_id", TiltifyV5.Client.ClientUtils.ParameterToString(fundraisingEventId)); // path parameter
            if (timeType != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "time_type", timeType));
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

            localVarRequestOptions.Operation = "FundraisingEventApi.V5ApiWebPublicFundraisingEventLeaderboardControllerUser";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<LeaderboardEntryPaginatedResponse1>("/api/public/fundraising_events/{fundraising_event_id}/user_leaderboard", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V5ApiWebPublicFundraisingEventLeaderboardControllerUser", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List top users fitness distances 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>LeaderboardEntryPaginatedResponse1</returns>
        public LeaderboardEntryPaginatedResponse1 V5ApiWebPublicFundraisingEventLeaderboardControllerUserFitnessDistance(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<LeaderboardEntryPaginatedResponse1> localVarResponse = V5ApiWebPublicFundraisingEventLeaderboardControllerUserFitnessDistanceWithHttpInfo(fundraisingEventId, timeType, after, before, limit);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List top users fitness distances 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of LeaderboardEntryPaginatedResponse1</returns>
        public TiltifyV5.Client.ApiResponse<LeaderboardEntryPaginatedResponse1> V5ApiWebPublicFundraisingEventLeaderboardControllerUserFitnessDistanceWithHttpInfo(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            // verify the required parameter 'fundraisingEventId' is set
            if (fundraisingEventId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'fundraisingEventId' when calling FundraisingEventApi->V5ApiWebPublicFundraisingEventLeaderboardControllerUserFitnessDistance");
            }

            TiltifyV5.Client.RequestOptions localVarRequestOptions = new TiltifyV5.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json",
                "appliction/json"
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

            localVarRequestOptions.PathParameters.Add("fundraising_event_id", TiltifyV5.Client.ClientUtils.ParameterToString(fundraisingEventId)); // path parameter
            if (timeType != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "time_type", timeType));
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

            localVarRequestOptions.Operation = "FundraisingEventApi.V5ApiWebPublicFundraisingEventLeaderboardControllerUserFitnessDistance";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<LeaderboardEntryPaginatedResponse1>("/api/public/fundraising_events/{fundraising_event_id}/user_fitness_distance_leaderboard", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V5ApiWebPublicFundraisingEventLeaderboardControllerUserFitnessDistance", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List top users fitness distances 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of LeaderboardEntryPaginatedResponse1</returns>
        public async System.Threading.Tasks.Task<LeaderboardEntryPaginatedResponse1> V5ApiWebPublicFundraisingEventLeaderboardControllerUserFitnessDistanceAsync(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<LeaderboardEntryPaginatedResponse1> localVarResponse = await V5ApiWebPublicFundraisingEventLeaderboardControllerUserFitnessDistanceWithHttpInfoAsync(fundraisingEventId, timeType, after, before, limit, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List top users fitness distances 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (LeaderboardEntryPaginatedResponse1)</returns>
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<LeaderboardEntryPaginatedResponse1>> V5ApiWebPublicFundraisingEventLeaderboardControllerUserFitnessDistanceWithHttpInfoAsync(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'fundraisingEventId' is set
            if (fundraisingEventId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'fundraisingEventId' when calling FundraisingEventApi->V5ApiWebPublicFundraisingEventLeaderboardControllerUserFitnessDistance");
            }


            TiltifyV5.Client.RequestOptions localVarRequestOptions = new TiltifyV5.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json",
                "appliction/json"
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

            localVarRequestOptions.PathParameters.Add("fundraising_event_id", TiltifyV5.Client.ClientUtils.ParameterToString(fundraisingEventId)); // path parameter
            if (timeType != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "time_type", timeType));
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

            localVarRequestOptions.Operation = "FundraisingEventApi.V5ApiWebPublicFundraisingEventLeaderboardControllerUserFitnessDistance";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<LeaderboardEntryPaginatedResponse1>("/api/public/fundraising_events/{fundraising_event_id}/user_fitness_distance_leaderboard", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V5ApiWebPublicFundraisingEventLeaderboardControllerUserFitnessDistance", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List top users fitness times 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>LeaderboardEntryPaginatedResponse1</returns>
        public LeaderboardEntryPaginatedResponse1 V5ApiWebPublicFundraisingEventLeaderboardControllerUserFitnessTime(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<LeaderboardEntryPaginatedResponse1> localVarResponse = V5ApiWebPublicFundraisingEventLeaderboardControllerUserFitnessTimeWithHttpInfo(fundraisingEventId, timeType, after, before, limit);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List top users fitness times 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of LeaderboardEntryPaginatedResponse1</returns>
        public TiltifyV5.Client.ApiResponse<LeaderboardEntryPaginatedResponse1> V5ApiWebPublicFundraisingEventLeaderboardControllerUserFitnessTimeWithHttpInfo(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            // verify the required parameter 'fundraisingEventId' is set
            if (fundraisingEventId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'fundraisingEventId' when calling FundraisingEventApi->V5ApiWebPublicFundraisingEventLeaderboardControllerUserFitnessTime");
            }

            TiltifyV5.Client.RequestOptions localVarRequestOptions = new TiltifyV5.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json",
                "appliction/json"
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

            localVarRequestOptions.PathParameters.Add("fundraising_event_id", TiltifyV5.Client.ClientUtils.ParameterToString(fundraisingEventId)); // path parameter
            if (timeType != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "time_type", timeType));
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

            localVarRequestOptions.Operation = "FundraisingEventApi.V5ApiWebPublicFundraisingEventLeaderboardControllerUserFitnessTime";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<LeaderboardEntryPaginatedResponse1>("/api/public/fundraising_events/{fundraising_event_id}/user_fitness_time_leaderboard", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V5ApiWebPublicFundraisingEventLeaderboardControllerUserFitnessTime", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List top users fitness times 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of LeaderboardEntryPaginatedResponse1</returns>
        public async System.Threading.Tasks.Task<LeaderboardEntryPaginatedResponse1> V5ApiWebPublicFundraisingEventLeaderboardControllerUserFitnessTimeAsync(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<LeaderboardEntryPaginatedResponse1> localVarResponse = await V5ApiWebPublicFundraisingEventLeaderboardControllerUserFitnessTimeWithHttpInfoAsync(fundraisingEventId, timeType, after, before, limit, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List top users fitness times 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="fundraisingEventId">Fundraising Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (LeaderboardEntryPaginatedResponse1)</returns>
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<LeaderboardEntryPaginatedResponse1>> V5ApiWebPublicFundraisingEventLeaderboardControllerUserFitnessTimeWithHttpInfoAsync(string fundraisingEventId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'fundraisingEventId' is set
            if (fundraisingEventId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'fundraisingEventId' when calling FundraisingEventApi->V5ApiWebPublicFundraisingEventLeaderboardControllerUserFitnessTime");
            }


            TiltifyV5.Client.RequestOptions localVarRequestOptions = new TiltifyV5.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json",
                "appliction/json"
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

            localVarRequestOptions.PathParameters.Add("fundraising_event_id", TiltifyV5.Client.ClientUtils.ParameterToString(fundraisingEventId)); // path parameter
            if (timeType != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "time_type", timeType));
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

            localVarRequestOptions.Operation = "FundraisingEventApi.V5ApiWebPublicFundraisingEventLeaderboardControllerUserFitnessTime";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<LeaderboardEntryPaginatedResponse1>("/api/public/fundraising_events/{fundraising_event_id}/user_fitness_time_leaderboard", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V5ApiWebPublicFundraisingEventLeaderboardControllerUserFitnessTime", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}
