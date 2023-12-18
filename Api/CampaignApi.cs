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
    public interface ICampaignApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Get by ID
        /// </summary>
        /// <remarks>
        /// Returns a campaign by its ID
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>CampaignResponse1</returns>
        CampaignResponse1 GetCampaign(string campaignId, int operationIndex = 0);

        /// <summary>
        /// Get by ID
        /// </summary>
        /// <remarks>
        /// Returns a campaign by its ID
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of CampaignResponse1</returns>
        ApiResponse<CampaignResponse1> GetCampaignWithHttpInfo(string campaignId, int operationIndex = 0);
        /// <summary>
        /// List donation matches
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="createdBefore">Returns only donation matches that have been updated before the given moment in ISO8601 format (optional)</param>
        /// <param name="createdAfter">Returns only donation matches that have been updated after the given moment in ISO8601 format (optional)</param>
        /// <param name="updatedBefore">Returns only donation matches that have been updated before the given moment in ISO8601 format (optional)</param>
        /// <param name="updatedAfter">Returns only donation matches that have been updated after the given moment in ISO8601 format (optional)</param>
        /// <param name="status">Status of the donation match. One of: active, or completed (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>DonationMatchPaginatedResponse1</returns>
        DonationMatchPaginatedResponse1 GetCampaignDonationMatches(string campaignId, string? createdBefore = default(string?), string? createdAfter = default(string?), string? updatedBefore = default(string?), string? updatedAfter = default(string?), string? status = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);

        /// <summary>
        /// List donation matches
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="createdBefore">Returns only donation matches that have been updated before the given moment in ISO8601 format (optional)</param>
        /// <param name="createdAfter">Returns only donation matches that have been updated after the given moment in ISO8601 format (optional)</param>
        /// <param name="updatedBefore">Returns only donation matches that have been updated before the given moment in ISO8601 format (optional)</param>
        /// <param name="updatedAfter">Returns only donation matches that have been updated after the given moment in ISO8601 format (optional)</param>
        /// <param name="status">Status of the donation match. One of: active, or completed (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of DonationMatchPaginatedResponse1</returns>
        ApiResponse<DonationMatchPaginatedResponse1> GetCampaignDonationMatchesWithHttpInfo(string campaignId, string? createdBefore = default(string?), string? createdAfter = default(string?), string? updatedBefore = default(string?), string? updatedAfter = default(string?), string? status = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);
        /// <summary>
        /// List donations
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="completedBefore">Returns only donations that have been completed before the given moment in ISO8601 format (optional)</param>
        /// <param name="completedAfter">Returns only donations that have been completed after the given moment in ISO8601 format (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>DonationPaginatedResponse1</returns>
        DonationPaginatedResponse1 GetCampaignDonations(string campaignId, string? completedBefore = default(string?), string? completedAfter = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);

        /// <summary>
        /// List donations
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="completedBefore">Returns only donations that have been completed before the given moment in ISO8601 format (optional)</param>
        /// <param name="completedAfter">Returns only donations that have been completed after the given moment in ISO8601 format (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of DonationPaginatedResponse1</returns>
        ApiResponse<DonationPaginatedResponse1> GetCampaignDonationsWithHttpInfo(string campaignId, string? completedBefore = default(string?), string? completedAfter = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);
        /// <summary>
        /// List milestones
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="includeDisabled">Returns disabled milestones. Defaults to false (optional)</param>
        /// <param name="createdBefore">Returns only milestones that have been updated before the given moment in ISO8601 format (optional)</param>
        /// <param name="createdAfter">Returns only milestones that have been updated after the given moment in ISO8601 format (optional)</param>
        /// <param name="updatedBefore">Returns only milestones that have been updated before the given moment in ISO8601 format (optional)</param>
        /// <param name="updatedAfter">Returns only milestones that have been updated after the given moment in ISO8601 format (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>MilestonePaginatedResponse1</returns>
        MilestonePaginatedResponse1 GetCampaignMilestones(string campaignId, bool? includeDisabled = default(bool?), string? createdBefore = default(string?), string? createdAfter = default(string?), string? updatedBefore = default(string?), string? updatedAfter = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);

        /// <summary>
        /// List milestones
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="includeDisabled">Returns disabled milestones. Defaults to false (optional)</param>
        /// <param name="createdBefore">Returns only milestones that have been updated before the given moment in ISO8601 format (optional)</param>
        /// <param name="createdAfter">Returns only milestones that have been updated after the given moment in ISO8601 format (optional)</param>
        /// <param name="updatedBefore">Returns only milestones that have been updated before the given moment in ISO8601 format (optional)</param>
        /// <param name="updatedAfter">Returns only milestones that have been updated after the given moment in ISO8601 format (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of MilestonePaginatedResponse1</returns>
        ApiResponse<MilestonePaginatedResponse1> GetCampaignMilestonesWithHttpInfo(string campaignId, bool? includeDisabled = default(bool?), string? createdBefore = default(string?), string? createdAfter = default(string?), string? updatedBefore = default(string?), string? updatedAfter = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);
        /// <summary>
        /// Get campaign poll by ID
        /// </summary>
        /// <remarks>
        /// Returns a poll by its ID
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="pollId">Poll ID</param>
        /// <param name="campaignId">Campaign ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>PollResponse1</returns>
        PollResponse1 GetCampaignPollbyId(string pollId, string campaignId, int operationIndex = 0);

        /// <summary>
        /// Get campaign poll by ID
        /// </summary>
        /// <remarks>
        /// Returns a poll by its ID
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="pollId">Poll ID</param>
        /// <param name="campaignId">Campaign ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of PollResponse1</returns>
        ApiResponse<PollResponse1> GetCampaignPollbyIdWithHttpInfo(string pollId, string campaignId, int operationIndex = 0);
        /// <summary>
        /// List polls
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>PollPaginatedResponse1</returns>
        PollPaginatedResponse1 GetCampaignPolls(string campaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);

        /// <summary>
        /// List polls
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of PollPaginatedResponse1</returns>
        ApiResponse<PollPaginatedResponse1> GetCampaignPollsWithHttpInfo(string campaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);
        /// <summary>
        /// List rewards
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>RewardPaginatedResponse1</returns>
        RewardPaginatedResponse1 GetCampaignRewards(string campaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);

        /// <summary>
        /// List rewards
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of RewardPaginatedResponse1</returns>
        ApiResponse<RewardPaginatedResponse1> GetCampaignRewardsWithHttpInfo(string campaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);
        /// <summary>
        /// List schedules
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>SchedulePaginatedResponse1</returns>
        SchedulePaginatedResponse1 GetCampaignSchedules(string campaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);

        /// <summary>
        /// List schedules
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of SchedulePaginatedResponse1</returns>
        ApiResponse<SchedulePaginatedResponse1> GetCampaignSchedulesWithHttpInfo(string campaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);
        /// <summary>
        /// List targets
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>TargetPaginatedResponse1</returns>
        TargetPaginatedResponse1 GetCampaignTargets(string campaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);

        /// <summary>
        /// List targets
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of TargetPaginatedResponse1</returns>
        ApiResponse<TargetPaginatedResponse1> GetCampaignTargetsWithHttpInfo(string campaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);
        /// <summary>
        /// List top donors
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>LeaderboardEntryPaginatedResponse1</returns>
        LeaderboardEntryPaginatedResponse1 GetCampaignTopDonors(string campaignId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);

        /// <summary>
        /// List top donors
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of LeaderboardEntryPaginatedResponse1</returns>
        ApiResponse<LeaderboardEntryPaginatedResponse1> GetCampaignTopDonorsWithHttpInfo(string campaignId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);
        /// <summary>
        /// Get campaign by user slug and campaign slug
        /// </summary>
        /// <remarks>
        /// Returns a Campaign by its user slug and campaign slug
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userSlug">User Slug</param>
        /// <param name="campaignSlug">Campaign Slug</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>CampaignResponse1</returns>
        CampaignResponse1 V5ApiWebPublicCampaignControllerShowSlug(string userSlug, string campaignSlug, int operationIndex = 0);

        /// <summary>
        /// Get campaign by user slug and campaign slug
        /// </summary>
        /// <remarks>
        /// Returns a Campaign by its user slug and campaign slug
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userSlug">User Slug</param>
        /// <param name="campaignSlug">Campaign Slug</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of CampaignResponse1</returns>
        ApiResponse<CampaignResponse1> V5ApiWebPublicCampaignControllerShowSlugWithHttpInfo(string userSlug, string campaignSlug, int operationIndex = 0);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ICampaignApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Get by ID
        /// </summary>
        /// <remarks>
        /// Returns a campaign by its ID
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CampaignResponse1</returns>
        System.Threading.Tasks.Task<CampaignResponse1> GetCampaignAsync(string campaignId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get by ID
        /// </summary>
        /// <remarks>
        /// Returns a campaign by its ID
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CampaignResponse1)</returns>
        System.Threading.Tasks.Task<ApiResponse<CampaignResponse1>> GetCampaignWithHttpInfoAsync(string campaignId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List donation matches
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="createdBefore">Returns only donation matches that have been updated before the given moment in ISO8601 format (optional)</param>
        /// <param name="createdAfter">Returns only donation matches that have been updated after the given moment in ISO8601 format (optional)</param>
        /// <param name="updatedBefore">Returns only donation matches that have been updated before the given moment in ISO8601 format (optional)</param>
        /// <param name="updatedAfter">Returns only donation matches that have been updated after the given moment in ISO8601 format (optional)</param>
        /// <param name="status">Status of the donation match. One of: active, or completed (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DonationMatchPaginatedResponse1</returns>
        System.Threading.Tasks.Task<DonationMatchPaginatedResponse1> GetCampaignDonationMatchesAsync(string campaignId, string? createdBefore = default(string?), string? createdAfter = default(string?), string? updatedBefore = default(string?), string? updatedAfter = default(string?), string? status = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List donation matches
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="createdBefore">Returns only donation matches that have been updated before the given moment in ISO8601 format (optional)</param>
        /// <param name="createdAfter">Returns only donation matches that have been updated after the given moment in ISO8601 format (optional)</param>
        /// <param name="updatedBefore">Returns only donation matches that have been updated before the given moment in ISO8601 format (optional)</param>
        /// <param name="updatedAfter">Returns only donation matches that have been updated after the given moment in ISO8601 format (optional)</param>
        /// <param name="status">Status of the donation match. One of: active, or completed (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DonationMatchPaginatedResponse1)</returns>
        System.Threading.Tasks.Task<ApiResponse<DonationMatchPaginatedResponse1>> GetCampaignDonationMatchesWithHttpInfoAsync(string campaignId, string? createdBefore = default(string?), string? createdAfter = default(string?), string? updatedBefore = default(string?), string? updatedAfter = default(string?), string? status = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List donations
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="completedBefore">Returns only donations that have been completed before the given moment in ISO8601 format (optional)</param>
        /// <param name="completedAfter">Returns only donations that have been completed after the given moment in ISO8601 format (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DonationPaginatedResponse1</returns>
        System.Threading.Tasks.Task<DonationPaginatedResponse1> GetCampaignDonationsAsync(string campaignId, string? completedBefore = default(string?), string? completedAfter = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List donations
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="completedBefore">Returns only donations that have been completed before the given moment in ISO8601 format (optional)</param>
        /// <param name="completedAfter">Returns only donations that have been completed after the given moment in ISO8601 format (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DonationPaginatedResponse1)</returns>
        System.Threading.Tasks.Task<ApiResponse<DonationPaginatedResponse1>> GetCampaignDonationsWithHttpInfoAsync(string campaignId, string? completedBefore = default(string?), string? completedAfter = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List milestones
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="includeDisabled">Returns disabled milestones. Defaults to false (optional)</param>
        /// <param name="createdBefore">Returns only milestones that have been updated before the given moment in ISO8601 format (optional)</param>
        /// <param name="createdAfter">Returns only milestones that have been updated after the given moment in ISO8601 format (optional)</param>
        /// <param name="updatedBefore">Returns only milestones that have been updated before the given moment in ISO8601 format (optional)</param>
        /// <param name="updatedAfter">Returns only milestones that have been updated after the given moment in ISO8601 format (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of MilestonePaginatedResponse1</returns>
        System.Threading.Tasks.Task<MilestonePaginatedResponse1> GetCampaignMilestonesAsync(string campaignId, bool? includeDisabled = default(bool?), string? createdBefore = default(string?), string? createdAfter = default(string?), string? updatedBefore = default(string?), string? updatedAfter = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List milestones
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="includeDisabled">Returns disabled milestones. Defaults to false (optional)</param>
        /// <param name="createdBefore">Returns only milestones that have been updated before the given moment in ISO8601 format (optional)</param>
        /// <param name="createdAfter">Returns only milestones that have been updated after the given moment in ISO8601 format (optional)</param>
        /// <param name="updatedBefore">Returns only milestones that have been updated before the given moment in ISO8601 format (optional)</param>
        /// <param name="updatedAfter">Returns only milestones that have been updated after the given moment in ISO8601 format (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (MilestonePaginatedResponse1)</returns>
        System.Threading.Tasks.Task<ApiResponse<MilestonePaginatedResponse1>> GetCampaignMilestonesWithHttpInfoAsync(string campaignId, bool? includeDisabled = default(bool?), string? createdBefore = default(string?), string? createdAfter = default(string?), string? updatedBefore = default(string?), string? updatedAfter = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get campaign poll by ID
        /// </summary>
        /// <remarks>
        /// Returns a poll by its ID
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="pollId">Poll ID</param>
        /// <param name="campaignId">Campaign ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PollResponse1</returns>
        System.Threading.Tasks.Task<PollResponse1> GetCampaignPollbyIdAsync(string pollId, string campaignId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get campaign poll by ID
        /// </summary>
        /// <remarks>
        /// Returns a poll by its ID
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="pollId">Poll ID</param>
        /// <param name="campaignId">Campaign ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PollResponse1)</returns>
        System.Threading.Tasks.Task<ApiResponse<PollResponse1>> GetCampaignPollbyIdWithHttpInfoAsync(string pollId, string campaignId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List polls
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PollPaginatedResponse1</returns>
        System.Threading.Tasks.Task<PollPaginatedResponse1> GetCampaignPollsAsync(string campaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List polls
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PollPaginatedResponse1)</returns>
        System.Threading.Tasks.Task<ApiResponse<PollPaginatedResponse1>> GetCampaignPollsWithHttpInfoAsync(string campaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List rewards
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of RewardPaginatedResponse1</returns>
        System.Threading.Tasks.Task<RewardPaginatedResponse1> GetCampaignRewardsAsync(string campaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List rewards
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (RewardPaginatedResponse1)</returns>
        System.Threading.Tasks.Task<ApiResponse<RewardPaginatedResponse1>> GetCampaignRewardsWithHttpInfoAsync(string campaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List schedules
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of SchedulePaginatedResponse1</returns>
        System.Threading.Tasks.Task<SchedulePaginatedResponse1> GetCampaignSchedulesAsync(string campaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List schedules
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (SchedulePaginatedResponse1)</returns>
        System.Threading.Tasks.Task<ApiResponse<SchedulePaginatedResponse1>> GetCampaignSchedulesWithHttpInfoAsync(string campaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List targets
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TargetPaginatedResponse1</returns>
        System.Threading.Tasks.Task<TargetPaginatedResponse1> GetCampaignTargetsAsync(string campaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List targets
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TargetPaginatedResponse1)</returns>
        System.Threading.Tasks.Task<ApiResponse<TargetPaginatedResponse1>> GetCampaignTargetsWithHttpInfoAsync(string campaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List top donors
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of LeaderboardEntryPaginatedResponse1</returns>
        System.Threading.Tasks.Task<LeaderboardEntryPaginatedResponse1> GetCampaignTopDonorsAsync(string campaignId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List top donors
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (LeaderboardEntryPaginatedResponse1)</returns>
        System.Threading.Tasks.Task<ApiResponse<LeaderboardEntryPaginatedResponse1>> GetCampaignTopDonorsWithHttpInfoAsync(string campaignId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get campaign by user slug and campaign slug
        /// </summary>
        /// <remarks>
        /// Returns a Campaign by its user slug and campaign slug
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userSlug">User Slug</param>
        /// <param name="campaignSlug">Campaign Slug</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CampaignResponse1</returns>
        System.Threading.Tasks.Task<CampaignResponse1> V5ApiWebPublicCampaignControllerShowSlugAsync(string userSlug, string campaignSlug, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get campaign by user slug and campaign slug
        /// </summary>
        /// <remarks>
        /// Returns a Campaign by its user slug and campaign slug
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userSlug">User Slug</param>
        /// <param name="campaignSlug">Campaign Slug</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CampaignResponse1)</returns>
        System.Threading.Tasks.Task<ApiResponse<CampaignResponse1>> V5ApiWebPublicCampaignControllerShowSlugWithHttpInfoAsync(string userSlug, string campaignSlug, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ICampaignApi : ICampaignApiSync, ICampaignApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class CampaignApi : ICampaignApi
    {
        private TiltifyV5.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="CampaignApi"/> class.
        /// </summary>
        /// <returns></returns>
        public CampaignApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CampaignApi"/> class.
        /// </summary>
        /// <returns></returns>
        public CampaignApi(string basePath)
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
        /// Initializes a new instance of the <see cref="CampaignApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public CampaignApi(TiltifyV5.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="CampaignApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public CampaignApi(TiltifyV5.Client.ISynchronousClient client, TiltifyV5.Client.IAsynchronousClient asyncClient, TiltifyV5.Client.IReadableConfiguration configuration)
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
        /// Get by ID Returns a campaign by its ID
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>CampaignResponse1</returns>
        public CampaignResponse1 GetCampaign(string campaignId, int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<CampaignResponse1> localVarResponse = GetCampaignWithHttpInfo(campaignId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get by ID Returns a campaign by its ID
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of CampaignResponse1</returns>
        public TiltifyV5.Client.ApiResponse<CampaignResponse1> GetCampaignWithHttpInfo(string campaignId, int operationIndex = 0)
        {
            // verify the required parameter 'campaignId' is set
            if (campaignId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'campaignId' when calling CampaignApi->GetCampaign");
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

            localVarRequestOptions.PathParameters.Add("campaign_id", TiltifyV5.Client.ClientUtils.ParameterToString(campaignId)); // path parameter

            localVarRequestOptions.Operation = "CampaignApi.GetCampaign";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<CampaignResponse1>("/api/public/campaigns/{campaign_id}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetCampaign", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get by ID Returns a campaign by its ID
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CampaignResponse1</returns>
        public async System.Threading.Tasks.Task<CampaignResponse1> GetCampaignAsync(string campaignId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<CampaignResponse1> localVarResponse = await GetCampaignWithHttpInfoAsync(campaignId, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get by ID Returns a campaign by its ID
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CampaignResponse1)</returns>
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<CampaignResponse1>> GetCampaignWithHttpInfoAsync(string campaignId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'campaignId' is set
            if (campaignId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'campaignId' when calling CampaignApi->GetCampaign");
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

            localVarRequestOptions.PathParameters.Add("campaign_id", TiltifyV5.Client.ClientUtils.ParameterToString(campaignId)); // path parameter

            localVarRequestOptions.Operation = "CampaignApi.GetCampaign";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<CampaignResponse1>("/api/public/campaigns/{campaign_id}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetCampaign", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List donation matches 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="createdBefore">Returns only donation matches that have been updated before the given moment in ISO8601 format (optional)</param>
        /// <param name="createdAfter">Returns only donation matches that have been updated after the given moment in ISO8601 format (optional)</param>
        /// <param name="updatedBefore">Returns only donation matches that have been updated before the given moment in ISO8601 format (optional)</param>
        /// <param name="updatedAfter">Returns only donation matches that have been updated after the given moment in ISO8601 format (optional)</param>
        /// <param name="status">Status of the donation match. One of: active, or completed (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>DonationMatchPaginatedResponse1</returns>
        public DonationMatchPaginatedResponse1 GetCampaignDonationMatches(string campaignId, string? createdBefore = default(string?), string? createdAfter = default(string?), string? updatedBefore = default(string?), string? updatedAfter = default(string?), string? status = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<DonationMatchPaginatedResponse1> localVarResponse = GetCampaignDonationMatchesWithHttpInfo(campaignId, createdBefore, createdAfter, updatedBefore, updatedAfter, status, after, before, limit);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List donation matches 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="createdBefore">Returns only donation matches that have been updated before the given moment in ISO8601 format (optional)</param>
        /// <param name="createdAfter">Returns only donation matches that have been updated after the given moment in ISO8601 format (optional)</param>
        /// <param name="updatedBefore">Returns only donation matches that have been updated before the given moment in ISO8601 format (optional)</param>
        /// <param name="updatedAfter">Returns only donation matches that have been updated after the given moment in ISO8601 format (optional)</param>
        /// <param name="status">Status of the donation match. One of: active, or completed (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of DonationMatchPaginatedResponse1</returns>
        public TiltifyV5.Client.ApiResponse<DonationMatchPaginatedResponse1> GetCampaignDonationMatchesWithHttpInfo(string campaignId, string? createdBefore = default(string?), string? createdAfter = default(string?), string? updatedBefore = default(string?), string? updatedAfter = default(string?), string? status = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            // verify the required parameter 'campaignId' is set
            if (campaignId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'campaignId' when calling CampaignApi->GetCampaignDonationMatches");
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

            localVarRequestOptions.PathParameters.Add("campaign_id", TiltifyV5.Client.ClientUtils.ParameterToString(campaignId)); // path parameter
            if (createdBefore != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "created_before", createdBefore));
            }
            if (createdAfter != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "created_after", createdAfter));
            }
            if (updatedBefore != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "updated_before", updatedBefore));
            }
            if (updatedAfter != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "updated_after", updatedAfter));
            }
            if (status != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "status", status));
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

            localVarRequestOptions.Operation = "CampaignApi.GetCampaignDonationMatches";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<DonationMatchPaginatedResponse1>("/api/public/campaigns/{campaign_id}/donation_matches", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetCampaignDonationMatches", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List donation matches 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="createdBefore">Returns only donation matches that have been updated before the given moment in ISO8601 format (optional)</param>
        /// <param name="createdAfter">Returns only donation matches that have been updated after the given moment in ISO8601 format (optional)</param>
        /// <param name="updatedBefore">Returns only donation matches that have been updated before the given moment in ISO8601 format (optional)</param>
        /// <param name="updatedAfter">Returns only donation matches that have been updated after the given moment in ISO8601 format (optional)</param>
        /// <param name="status">Status of the donation match. One of: active, or completed (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DonationMatchPaginatedResponse1</returns>
        public async System.Threading.Tasks.Task<DonationMatchPaginatedResponse1> GetCampaignDonationMatchesAsync(string campaignId, string? createdBefore = default(string?), string? createdAfter = default(string?), string? updatedBefore = default(string?), string? updatedAfter = default(string?), string? status = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<DonationMatchPaginatedResponse1> localVarResponse = await GetCampaignDonationMatchesWithHttpInfoAsync(campaignId, createdBefore, createdAfter, updatedBefore, updatedAfter, status, after, before, limit, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List donation matches 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="createdBefore">Returns only donation matches that have been updated before the given moment in ISO8601 format (optional)</param>
        /// <param name="createdAfter">Returns only donation matches that have been updated after the given moment in ISO8601 format (optional)</param>
        /// <param name="updatedBefore">Returns only donation matches that have been updated before the given moment in ISO8601 format (optional)</param>
        /// <param name="updatedAfter">Returns only donation matches that have been updated after the given moment in ISO8601 format (optional)</param>
        /// <param name="status">Status of the donation match. One of: active, or completed (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DonationMatchPaginatedResponse1)</returns>
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<DonationMatchPaginatedResponse1>> GetCampaignDonationMatchesWithHttpInfoAsync(string campaignId, string? createdBefore = default(string?), string? createdAfter = default(string?), string? updatedBefore = default(string?), string? updatedAfter = default(string?), string? status = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'campaignId' is set
            if (campaignId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'campaignId' when calling CampaignApi->GetCampaignDonationMatches");
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

            localVarRequestOptions.PathParameters.Add("campaign_id", TiltifyV5.Client.ClientUtils.ParameterToString(campaignId)); // path parameter
            if (createdBefore != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "created_before", createdBefore));
            }
            if (createdAfter != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "created_after", createdAfter));
            }
            if (updatedBefore != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "updated_before", updatedBefore));
            }
            if (updatedAfter != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "updated_after", updatedAfter));
            }
            if (status != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "status", status));
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

            localVarRequestOptions.Operation = "CampaignApi.GetCampaignDonationMatches";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<DonationMatchPaginatedResponse1>("/api/public/campaigns/{campaign_id}/donation_matches", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetCampaignDonationMatches", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List donations 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="completedBefore">Returns only donations that have been completed before the given moment in ISO8601 format (optional)</param>
        /// <param name="completedAfter">Returns only donations that have been completed after the given moment in ISO8601 format (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>DonationPaginatedResponse1</returns>
        public DonationPaginatedResponse1 GetCampaignDonations(string campaignId, string? completedBefore = default(string?), string? completedAfter = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<DonationPaginatedResponse1> localVarResponse = GetCampaignDonationsWithHttpInfo(campaignId, completedBefore, completedAfter, after, before, limit);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List donations 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="completedBefore">Returns only donations that have been completed before the given moment in ISO8601 format (optional)</param>
        /// <param name="completedAfter">Returns only donations that have been completed after the given moment in ISO8601 format (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of DonationPaginatedResponse1</returns>
        public TiltifyV5.Client.ApiResponse<DonationPaginatedResponse1> GetCampaignDonationsWithHttpInfo(string campaignId, string? completedBefore = default(string?), string? completedAfter = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            // verify the required parameter 'campaignId' is set
            if (campaignId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'campaignId' when calling CampaignApi->GetCampaignDonations");
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

            localVarRequestOptions.PathParameters.Add("campaign_id", TiltifyV5.Client.ClientUtils.ParameterToString(campaignId)); // path parameter
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

            localVarRequestOptions.Operation = "CampaignApi.GetCampaignDonations";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<DonationPaginatedResponse1>("/api/public/campaigns/{campaign_id}/donations", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetCampaignDonations", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List donations 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="completedBefore">Returns only donations that have been completed before the given moment in ISO8601 format (optional)</param>
        /// <param name="completedAfter">Returns only donations that have been completed after the given moment in ISO8601 format (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DonationPaginatedResponse1</returns>
        public async System.Threading.Tasks.Task<DonationPaginatedResponse1> GetCampaignDonationsAsync(string campaignId, string? completedBefore = default(string?), string? completedAfter = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<DonationPaginatedResponse1> localVarResponse = await GetCampaignDonationsWithHttpInfoAsync(campaignId, completedBefore, completedAfter, after, before, limit, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List donations 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="completedBefore">Returns only donations that have been completed before the given moment in ISO8601 format (optional)</param>
        /// <param name="completedAfter">Returns only donations that have been completed after the given moment in ISO8601 format (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DonationPaginatedResponse1)</returns>
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<DonationPaginatedResponse1>> GetCampaignDonationsWithHttpInfoAsync(string campaignId, string? completedBefore = default(string?), string? completedAfter = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'campaignId' is set
            if (campaignId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'campaignId' when calling CampaignApi->GetCampaignDonations");
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

            localVarRequestOptions.PathParameters.Add("campaign_id", TiltifyV5.Client.ClientUtils.ParameterToString(campaignId)); // path parameter
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

            localVarRequestOptions.Operation = "CampaignApi.GetCampaignDonations";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<DonationPaginatedResponse1>("/api/public/campaigns/{campaign_id}/donations", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetCampaignDonations", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List milestones 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="includeDisabled">Returns disabled milestones. Defaults to false (optional)</param>
        /// <param name="createdBefore">Returns only milestones that have been updated before the given moment in ISO8601 format (optional)</param>
        /// <param name="createdAfter">Returns only milestones that have been updated after the given moment in ISO8601 format (optional)</param>
        /// <param name="updatedBefore">Returns only milestones that have been updated before the given moment in ISO8601 format (optional)</param>
        /// <param name="updatedAfter">Returns only milestones that have been updated after the given moment in ISO8601 format (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>MilestonePaginatedResponse1</returns>
        public MilestonePaginatedResponse1 GetCampaignMilestones(string campaignId, bool? includeDisabled = default(bool?), string? createdBefore = default(string?), string? createdAfter = default(string?), string? updatedBefore = default(string?), string? updatedAfter = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<MilestonePaginatedResponse1> localVarResponse = GetCampaignMilestonesWithHttpInfo(campaignId, includeDisabled, createdBefore, createdAfter, updatedBefore, updatedAfter, after, before, limit);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List milestones 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="includeDisabled">Returns disabled milestones. Defaults to false (optional)</param>
        /// <param name="createdBefore">Returns only milestones that have been updated before the given moment in ISO8601 format (optional)</param>
        /// <param name="createdAfter">Returns only milestones that have been updated after the given moment in ISO8601 format (optional)</param>
        /// <param name="updatedBefore">Returns only milestones that have been updated before the given moment in ISO8601 format (optional)</param>
        /// <param name="updatedAfter">Returns only milestones that have been updated after the given moment in ISO8601 format (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of MilestonePaginatedResponse1</returns>
        public TiltifyV5.Client.ApiResponse<MilestonePaginatedResponse1> GetCampaignMilestonesWithHttpInfo(string campaignId, bool? includeDisabled = default(bool?), string? createdBefore = default(string?), string? createdAfter = default(string?), string? updatedBefore = default(string?), string? updatedAfter = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            // verify the required parameter 'campaignId' is set
            if (campaignId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'campaignId' when calling CampaignApi->GetCampaignMilestones");
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

            localVarRequestOptions.PathParameters.Add("campaign_id", TiltifyV5.Client.ClientUtils.ParameterToString(campaignId)); // path parameter
            if (includeDisabled != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "include_disabled", includeDisabled));
            }
            if (createdBefore != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "created_before", createdBefore));
            }
            if (createdAfter != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "created_after", createdAfter));
            }
            if (updatedBefore != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "updated_before", updatedBefore));
            }
            if (updatedAfter != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "updated_after", updatedAfter));
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

            localVarRequestOptions.Operation = "CampaignApi.GetCampaignMilestones";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<MilestonePaginatedResponse1>("/api/public/campaigns/{campaign_id}/milestones", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetCampaignMilestones", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List milestones 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="includeDisabled">Returns disabled milestones. Defaults to false (optional)</param>
        /// <param name="createdBefore">Returns only milestones that have been updated before the given moment in ISO8601 format (optional)</param>
        /// <param name="createdAfter">Returns only milestones that have been updated after the given moment in ISO8601 format (optional)</param>
        /// <param name="updatedBefore">Returns only milestones that have been updated before the given moment in ISO8601 format (optional)</param>
        /// <param name="updatedAfter">Returns only milestones that have been updated after the given moment in ISO8601 format (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of MilestonePaginatedResponse1</returns>
        public async System.Threading.Tasks.Task<MilestonePaginatedResponse1> GetCampaignMilestonesAsync(string campaignId, bool? includeDisabled = default(bool?), string? createdBefore = default(string?), string? createdAfter = default(string?), string? updatedBefore = default(string?), string? updatedAfter = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<MilestonePaginatedResponse1> localVarResponse = await GetCampaignMilestonesWithHttpInfoAsync(campaignId, includeDisabled, createdBefore, createdAfter, updatedBefore, updatedAfter, after, before, limit, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List milestones 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="includeDisabled">Returns disabled milestones. Defaults to false (optional)</param>
        /// <param name="createdBefore">Returns only milestones that have been updated before the given moment in ISO8601 format (optional)</param>
        /// <param name="createdAfter">Returns only milestones that have been updated after the given moment in ISO8601 format (optional)</param>
        /// <param name="updatedBefore">Returns only milestones that have been updated before the given moment in ISO8601 format (optional)</param>
        /// <param name="updatedAfter">Returns only milestones that have been updated after the given moment in ISO8601 format (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (MilestonePaginatedResponse1)</returns>
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<MilestonePaginatedResponse1>> GetCampaignMilestonesWithHttpInfoAsync(string campaignId, bool? includeDisabled = default(bool?), string? createdBefore = default(string?), string? createdAfter = default(string?), string? updatedBefore = default(string?), string? updatedAfter = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'campaignId' is set
            if (campaignId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'campaignId' when calling CampaignApi->GetCampaignMilestones");
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

            localVarRequestOptions.PathParameters.Add("campaign_id", TiltifyV5.Client.ClientUtils.ParameterToString(campaignId)); // path parameter
            if (includeDisabled != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "include_disabled", includeDisabled));
            }
            if (createdBefore != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "created_before", createdBefore));
            }
            if (createdAfter != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "created_after", createdAfter));
            }
            if (updatedBefore != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "updated_before", updatedBefore));
            }
            if (updatedAfter != null)
            {
                localVarRequestOptions.QueryParameters.Add(TiltifyV5.Client.ClientUtils.ParameterToMultiMap("", "updated_after", updatedAfter));
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

            localVarRequestOptions.Operation = "CampaignApi.GetCampaignMilestones";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<MilestonePaginatedResponse1>("/api/public/campaigns/{campaign_id}/milestones", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetCampaignMilestones", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get campaign poll by ID Returns a poll by its ID
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="pollId">Poll ID</param>
        /// <param name="campaignId">Campaign ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>PollResponse1</returns>
        public PollResponse1 GetCampaignPollbyId(string pollId, string campaignId, int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<PollResponse1> localVarResponse = GetCampaignPollbyIdWithHttpInfo(pollId, campaignId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get campaign poll by ID Returns a poll by its ID
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="pollId">Poll ID</param>
        /// <param name="campaignId">Campaign ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of PollResponse1</returns>
        public TiltifyV5.Client.ApiResponse<PollResponse1> GetCampaignPollbyIdWithHttpInfo(string pollId, string campaignId, int operationIndex = 0)
        {
            // verify the required parameter 'pollId' is set
            if (pollId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'pollId' when calling CampaignApi->GetCampaignPollbyId");
            }

            // verify the required parameter 'campaignId' is set
            if (campaignId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'campaignId' when calling CampaignApi->GetCampaignPollbyId");
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

            localVarRequestOptions.PathParameters.Add("poll_id", TiltifyV5.Client.ClientUtils.ParameterToString(pollId)); // path parameter
            localVarRequestOptions.PathParameters.Add("campaign_id", TiltifyV5.Client.ClientUtils.ParameterToString(campaignId)); // path parameter

            localVarRequestOptions.Operation = "CampaignApi.GetCampaignPollbyId";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<PollResponse1>("/api/public/campaigns/{campaign_id}/polls/{poll_id}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetCampaignPollbyId", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get campaign poll by ID Returns a poll by its ID
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="pollId">Poll ID</param>
        /// <param name="campaignId">Campaign ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PollResponse1</returns>
        public async System.Threading.Tasks.Task<PollResponse1> GetCampaignPollbyIdAsync(string pollId, string campaignId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<PollResponse1> localVarResponse = await GetCampaignPollbyIdWithHttpInfoAsync(pollId, campaignId, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get campaign poll by ID Returns a poll by its ID
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="pollId">Poll ID</param>
        /// <param name="campaignId">Campaign ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PollResponse1)</returns>
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<PollResponse1>> GetCampaignPollbyIdWithHttpInfoAsync(string pollId, string campaignId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'pollId' is set
            if (pollId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'pollId' when calling CampaignApi->GetCampaignPollbyId");
            }

            // verify the required parameter 'campaignId' is set
            if (campaignId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'campaignId' when calling CampaignApi->GetCampaignPollbyId");
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

            localVarRequestOptions.PathParameters.Add("poll_id", TiltifyV5.Client.ClientUtils.ParameterToString(pollId)); // path parameter
            localVarRequestOptions.PathParameters.Add("campaign_id", TiltifyV5.Client.ClientUtils.ParameterToString(campaignId)); // path parameter

            localVarRequestOptions.Operation = "CampaignApi.GetCampaignPollbyId";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<PollResponse1>("/api/public/campaigns/{campaign_id}/polls/{poll_id}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetCampaignPollbyId", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List polls 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>PollPaginatedResponse1</returns>
        public PollPaginatedResponse1 GetCampaignPolls(string campaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<PollPaginatedResponse1> localVarResponse = GetCampaignPollsWithHttpInfo(campaignId, after, before, limit);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List polls 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of PollPaginatedResponse1</returns>
        public TiltifyV5.Client.ApiResponse<PollPaginatedResponse1> GetCampaignPollsWithHttpInfo(string campaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            // verify the required parameter 'campaignId' is set
            if (campaignId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'campaignId' when calling CampaignApi->GetCampaignPolls");
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

            localVarRequestOptions.PathParameters.Add("campaign_id", TiltifyV5.Client.ClientUtils.ParameterToString(campaignId)); // path parameter
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

            localVarRequestOptions.Operation = "CampaignApi.GetCampaignPolls";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<PollPaginatedResponse1>("/api/public/campaigns/{campaign_id}/polls", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetCampaignPolls", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List polls 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PollPaginatedResponse1</returns>
        public async System.Threading.Tasks.Task<PollPaginatedResponse1> GetCampaignPollsAsync(string campaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<PollPaginatedResponse1> localVarResponse = await GetCampaignPollsWithHttpInfoAsync(campaignId, after, before, limit, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List polls 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PollPaginatedResponse1)</returns>
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<PollPaginatedResponse1>> GetCampaignPollsWithHttpInfoAsync(string campaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'campaignId' is set
            if (campaignId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'campaignId' when calling CampaignApi->GetCampaignPolls");
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

            localVarRequestOptions.PathParameters.Add("campaign_id", TiltifyV5.Client.ClientUtils.ParameterToString(campaignId)); // path parameter
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

            localVarRequestOptions.Operation = "CampaignApi.GetCampaignPolls";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<PollPaginatedResponse1>("/api/public/campaigns/{campaign_id}/polls", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetCampaignPolls", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List rewards 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>RewardPaginatedResponse1</returns>
        public RewardPaginatedResponse1 GetCampaignRewards(string campaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<RewardPaginatedResponse1> localVarResponse = GetCampaignRewardsWithHttpInfo(campaignId, after, before, limit);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List rewards 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of RewardPaginatedResponse1</returns>
        public TiltifyV5.Client.ApiResponse<RewardPaginatedResponse1> GetCampaignRewardsWithHttpInfo(string campaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            // verify the required parameter 'campaignId' is set
            if (campaignId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'campaignId' when calling CampaignApi->GetCampaignRewards");
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

            localVarRequestOptions.PathParameters.Add("campaign_id", TiltifyV5.Client.ClientUtils.ParameterToString(campaignId)); // path parameter
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

            localVarRequestOptions.Operation = "CampaignApi.GetCampaignRewards";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<RewardPaginatedResponse1>("/api/public/campaigns/{campaign_id}/rewards", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetCampaignRewards", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List rewards 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of RewardPaginatedResponse1</returns>
        public async System.Threading.Tasks.Task<RewardPaginatedResponse1> GetCampaignRewardsAsync(string campaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<RewardPaginatedResponse1> localVarResponse = await GetCampaignRewardsWithHttpInfoAsync(campaignId, after, before, limit, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List rewards 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (RewardPaginatedResponse1)</returns>
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<RewardPaginatedResponse1>> GetCampaignRewardsWithHttpInfoAsync(string campaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'campaignId' is set
            if (campaignId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'campaignId' when calling CampaignApi->GetCampaignRewards");
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

            localVarRequestOptions.PathParameters.Add("campaign_id", TiltifyV5.Client.ClientUtils.ParameterToString(campaignId)); // path parameter
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

            localVarRequestOptions.Operation = "CampaignApi.GetCampaignRewards";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<RewardPaginatedResponse1>("/api/public/campaigns/{campaign_id}/rewards", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetCampaignRewards", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List schedules 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>SchedulePaginatedResponse1</returns>
        public SchedulePaginatedResponse1 GetCampaignSchedules(string campaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<SchedulePaginatedResponse1> localVarResponse = GetCampaignSchedulesWithHttpInfo(campaignId, after, before, limit);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List schedules 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of SchedulePaginatedResponse1</returns>
        public TiltifyV5.Client.ApiResponse<SchedulePaginatedResponse1> GetCampaignSchedulesWithHttpInfo(string campaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            // verify the required parameter 'campaignId' is set
            if (campaignId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'campaignId' when calling CampaignApi->GetCampaignSchedules");
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

            localVarRequestOptions.PathParameters.Add("campaign_id", TiltifyV5.Client.ClientUtils.ParameterToString(campaignId)); // path parameter
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

            localVarRequestOptions.Operation = "CampaignApi.GetCampaignSchedules";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<SchedulePaginatedResponse1>("/api/public/campaigns/{campaign_id}/schedules", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetCampaignSchedules", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List schedules 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of SchedulePaginatedResponse1</returns>
        public async System.Threading.Tasks.Task<SchedulePaginatedResponse1> GetCampaignSchedulesAsync(string campaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<SchedulePaginatedResponse1> localVarResponse = await GetCampaignSchedulesWithHttpInfoAsync(campaignId, after, before, limit, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List schedules 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (SchedulePaginatedResponse1)</returns>
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<SchedulePaginatedResponse1>> GetCampaignSchedulesWithHttpInfoAsync(string campaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'campaignId' is set
            if (campaignId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'campaignId' when calling CampaignApi->GetCampaignSchedules");
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

            localVarRequestOptions.PathParameters.Add("campaign_id", TiltifyV5.Client.ClientUtils.ParameterToString(campaignId)); // path parameter
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

            localVarRequestOptions.Operation = "CampaignApi.GetCampaignSchedules";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<SchedulePaginatedResponse1>("/api/public/campaigns/{campaign_id}/schedules", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetCampaignSchedules", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List targets 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>TargetPaginatedResponse1</returns>
        public TargetPaginatedResponse1 GetCampaignTargets(string campaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<TargetPaginatedResponse1> localVarResponse = GetCampaignTargetsWithHttpInfo(campaignId, after, before, limit);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List targets 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of TargetPaginatedResponse1</returns>
        public TiltifyV5.Client.ApiResponse<TargetPaginatedResponse1> GetCampaignTargetsWithHttpInfo(string campaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            // verify the required parameter 'campaignId' is set
            if (campaignId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'campaignId' when calling CampaignApi->GetCampaignTargets");
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

            localVarRequestOptions.PathParameters.Add("campaign_id", TiltifyV5.Client.ClientUtils.ParameterToString(campaignId)); // path parameter
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

            localVarRequestOptions.Operation = "CampaignApi.GetCampaignTargets";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<TargetPaginatedResponse1>("/api/public/campaigns/{campaign_id}/targets", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetCampaignTargets", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List targets 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TargetPaginatedResponse1</returns>
        public async System.Threading.Tasks.Task<TargetPaginatedResponse1> GetCampaignTargetsAsync(string campaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<TargetPaginatedResponse1> localVarResponse = await GetCampaignTargetsWithHttpInfoAsync(campaignId, after, before, limit, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List targets 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TargetPaginatedResponse1)</returns>
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<TargetPaginatedResponse1>> GetCampaignTargetsWithHttpInfoAsync(string campaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'campaignId' is set
            if (campaignId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'campaignId' when calling CampaignApi->GetCampaignTargets");
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

            localVarRequestOptions.PathParameters.Add("campaign_id", TiltifyV5.Client.ClientUtils.ParameterToString(campaignId)); // path parameter
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

            localVarRequestOptions.Operation = "CampaignApi.GetCampaignTargets";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<TargetPaginatedResponse1>("/api/public/campaigns/{campaign_id}/targets", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetCampaignTargets", localVarResponse);
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
        /// <param name="campaignId">Campaign ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>LeaderboardEntryPaginatedResponse1</returns>
        public LeaderboardEntryPaginatedResponse1 GetCampaignTopDonors(string campaignId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<LeaderboardEntryPaginatedResponse1> localVarResponse = GetCampaignTopDonorsWithHttpInfo(campaignId, timeType, after, before, limit);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List top donors 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of LeaderboardEntryPaginatedResponse1</returns>
        public TiltifyV5.Client.ApiResponse<LeaderboardEntryPaginatedResponse1> GetCampaignTopDonorsWithHttpInfo(string campaignId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            // verify the required parameter 'campaignId' is set
            if (campaignId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'campaignId' when calling CampaignApi->GetCampaignTopDonors");
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

            localVarRequestOptions.PathParameters.Add("campaign_id", TiltifyV5.Client.ClientUtils.ParameterToString(campaignId)); // path parameter
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

            localVarRequestOptions.Operation = "CampaignApi.GetCampaignTopDonors";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<LeaderboardEntryPaginatedResponse1>("/api/public/campaigns/{campaign_id}/donor_leaderboard", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetCampaignTopDonors", localVarResponse);
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
        /// <param name="campaignId">Campaign ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of LeaderboardEntryPaginatedResponse1</returns>
        public async System.Threading.Tasks.Task<LeaderboardEntryPaginatedResponse1> GetCampaignTopDonorsAsync(string campaignId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<LeaderboardEntryPaginatedResponse1> localVarResponse = await GetCampaignTopDonorsWithHttpInfoAsync(campaignId, timeType, after, before, limit, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List top donors 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="campaignId">Campaign ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (LeaderboardEntryPaginatedResponse1)</returns>
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<LeaderboardEntryPaginatedResponse1>> GetCampaignTopDonorsWithHttpInfoAsync(string campaignId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'campaignId' is set
            if (campaignId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'campaignId' when calling CampaignApi->GetCampaignTopDonors");
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

            localVarRequestOptions.PathParameters.Add("campaign_id", TiltifyV5.Client.ClientUtils.ParameterToString(campaignId)); // path parameter
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

            localVarRequestOptions.Operation = "CampaignApi.GetCampaignTopDonors";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<LeaderboardEntryPaginatedResponse1>("/api/public/campaigns/{campaign_id}/donor_leaderboard", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetCampaignTopDonors", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get campaign by user slug and campaign slug Returns a Campaign by its user slug and campaign slug
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userSlug">User Slug</param>
        /// <param name="campaignSlug">Campaign Slug</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>CampaignResponse1</returns>
        public CampaignResponse1 V5ApiWebPublicCampaignControllerShowSlug(string userSlug, string campaignSlug, int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<CampaignResponse1> localVarResponse = V5ApiWebPublicCampaignControllerShowSlugWithHttpInfo(userSlug, campaignSlug);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get campaign by user slug and campaign slug Returns a Campaign by its user slug and campaign slug
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userSlug">User Slug</param>
        /// <param name="campaignSlug">Campaign Slug</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of CampaignResponse1</returns>
        public TiltifyV5.Client.ApiResponse<CampaignResponse1> V5ApiWebPublicCampaignControllerShowSlugWithHttpInfo(string userSlug, string campaignSlug, int operationIndex = 0)
        {
            // verify the required parameter 'userSlug' is set
            if (userSlug == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'userSlug' when calling CampaignApi->V5ApiWebPublicCampaignControllerShowSlug");
            }

            // verify the required parameter 'campaignSlug' is set
            if (campaignSlug == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'campaignSlug' when calling CampaignApi->V5ApiWebPublicCampaignControllerShowSlug");
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

            localVarRequestOptions.PathParameters.Add("user_slug", TiltifyV5.Client.ClientUtils.ParameterToString(userSlug)); // path parameter
            localVarRequestOptions.PathParameters.Add("campaign_slug", TiltifyV5.Client.ClientUtils.ParameterToString(campaignSlug)); // path parameter

            localVarRequestOptions.Operation = "CampaignApi.V5ApiWebPublicCampaignControllerShowSlug";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<CampaignResponse1>("/api/public/campaigns/by/slugs/{user_slug}/{campaign_slug}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V5ApiWebPublicCampaignControllerShowSlug", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get campaign by user slug and campaign slug Returns a Campaign by its user slug and campaign slug
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userSlug">User Slug</param>
        /// <param name="campaignSlug">Campaign Slug</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CampaignResponse1</returns>
        public async System.Threading.Tasks.Task<CampaignResponse1> V5ApiWebPublicCampaignControllerShowSlugAsync(string userSlug, string campaignSlug, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<CampaignResponse1> localVarResponse = await V5ApiWebPublicCampaignControllerShowSlugWithHttpInfoAsync(userSlug, campaignSlug, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get campaign by user slug and campaign slug Returns a Campaign by its user slug and campaign slug
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userSlug">User Slug</param>
        /// <param name="campaignSlug">Campaign Slug</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CampaignResponse1)</returns>
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<CampaignResponse1>> V5ApiWebPublicCampaignControllerShowSlugWithHttpInfoAsync(string userSlug, string campaignSlug, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'userSlug' is set
            if (userSlug == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'userSlug' when calling CampaignApi->V5ApiWebPublicCampaignControllerShowSlug");
            }

            // verify the required parameter 'campaignSlug' is set
            if (campaignSlug == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'campaignSlug' when calling CampaignApi->V5ApiWebPublicCampaignControllerShowSlug");
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

            localVarRequestOptions.PathParameters.Add("user_slug", TiltifyV5.Client.ClientUtils.ParameterToString(userSlug)); // path parameter
            localVarRequestOptions.PathParameters.Add("campaign_slug", TiltifyV5.Client.ClientUtils.ParameterToString(campaignSlug)); // path parameter

            localVarRequestOptions.Operation = "CampaignApi.V5ApiWebPublicCampaignControllerShowSlug";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<CampaignResponse1>("/api/public/campaigns/by/slugs/{user_slug}/{campaign_slug}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V5ApiWebPublicCampaignControllerShowSlug", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}
