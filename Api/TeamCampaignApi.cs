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
    public interface ITeamCampaignApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Get by ID
        /// </summary>
        /// <remarks>
        /// Returns a Team Campaign by its ID
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>TeamCampaignResponse1</returns>
        TeamCampaignResponse1 GetTeamCampaign(string teamCampaignId, int operationIndex = 0);

        /// <summary>
        /// Get by ID
        /// </summary>
        /// <remarks>
        /// Returns a Team Campaign by its ID
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of TeamCampaignResponse1</returns>
        ApiResponse<TeamCampaignResponse1> GetTeamCampaignWithHttpInfo(string teamCampaignId, int operationIndex = 0);
        /// <summary>
        /// List donations
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="completedBefore">Returns only donations that have been completed before the given moment in ISO8601 format (optional)</param>
        /// <param name="completedAfter">Returns only donations that have been completed after the given moment in ISO8601 format (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>DonationPaginatedResponse1</returns>
        DonationPaginatedResponse1 GetTeamCampaignDonations(string teamCampaignId, string? completedBefore = default(string?), string? completedAfter = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);

        /// <summary>
        /// List donations
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="completedBefore">Returns only donations that have been completed before the given moment in ISO8601 format (optional)</param>
        /// <param name="completedAfter">Returns only donations that have been completed after the given moment in ISO8601 format (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of DonationPaginatedResponse1</returns>
        ApiResponse<DonationPaginatedResponse1> GetTeamCampaignDonationsWithHttpInfo(string teamCampaignId, string? completedBefore = default(string?), string? completedAfter = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);
        /// <summary>
        /// List milestones
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
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
        MilestonePaginatedResponse1 GetTeamCampaignMilestones(string teamCampaignId, bool? includeDisabled = default(bool?), string? createdBefore = default(string?), string? createdAfter = default(string?), string? updatedBefore = default(string?), string? updatedAfter = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);

        /// <summary>
        /// List milestones
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
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
        ApiResponse<MilestonePaginatedResponse1> GetTeamCampaignMilestonesWithHttpInfo(string teamCampaignId, bool? includeDisabled = default(bool?), string? createdBefore = default(string?), string? createdAfter = default(string?), string? updatedBefore = default(string?), string? updatedAfter = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);
        /// <summary>
        /// Get team campaign poll by ID
        /// </summary>
        /// <remarks>
        /// Returns a poll by its ID
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="pollId">Poll ID</param>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>PollResponse1</returns>
        PollResponse1 GetTeamCampaignPollbyId(string pollId, string teamCampaignId, int operationIndex = 0);

        /// <summary>
        /// Get team campaign poll by ID
        /// </summary>
        /// <remarks>
        /// Returns a poll by its ID
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="pollId">Poll ID</param>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of PollResponse1</returns>
        ApiResponse<PollResponse1> GetTeamCampaignPollbyIdWithHttpInfo(string pollId, string teamCampaignId, int operationIndex = 0);
        /// <summary>
        /// List polls
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>PollPaginatedResponse1</returns>
        PollPaginatedResponse1 GetTeamCampaignPolls(string teamCampaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);

        /// <summary>
        /// List polls
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of PollPaginatedResponse1</returns>
        ApiResponse<PollPaginatedResponse1> GetTeamCampaignPollsWithHttpInfo(string teamCampaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);
        /// <summary>
        /// List rewards
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>RewardPaginatedResponse1</returns>
        RewardPaginatedResponse1 GetTeamCampaignRewards(string teamCampaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);

        /// <summary>
        /// List rewards
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of RewardPaginatedResponse1</returns>
        ApiResponse<RewardPaginatedResponse1> GetTeamCampaignRewardsWithHttpInfo(string teamCampaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);
        /// <summary>
        /// List schedules
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>SchedulePaginatedResponse1</returns>
        SchedulePaginatedResponse1 GetTeamCampaignSchedules(string teamCampaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);

        /// <summary>
        /// List schedules
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of SchedulePaginatedResponse1</returns>
        ApiResponse<SchedulePaginatedResponse1> GetTeamCampaignSchedulesWithHttpInfo(string teamCampaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);
        /// <summary>
        /// List supporting campaigns
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>CampaignPaginatedResponse1</returns>
        CampaignPaginatedResponse1 GetTeamCampaignSupportingCampaigns(string teamCampaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);

        /// <summary>
        /// List supporting campaigns
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of CampaignPaginatedResponse1</returns>
        ApiResponse<CampaignPaginatedResponse1> GetTeamCampaignSupportingCampaignsWithHttpInfo(string teamCampaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);
        /// <summary>
        /// List targets
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>TargetPaginatedResponse1</returns>
        TargetPaginatedResponse1 GetTeamCampaignTargets(string teamCampaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);

        /// <summary>
        /// List targets
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of TargetPaginatedResponse1</returns>
        ApiResponse<TargetPaginatedResponse1> GetTeamCampaignTargetsWithHttpInfo(string teamCampaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);
        /// <summary>
        /// List top donors
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>LeaderboardEntryPaginatedResponse1</returns>
        LeaderboardEntryPaginatedResponse1 GetTeamCampaignTopDonors(string teamCampaignId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);

        /// <summary>
        /// List top donors
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of LeaderboardEntryPaginatedResponse1</returns>
        ApiResponse<LeaderboardEntryPaginatedResponse1> GetTeamCampaignTopDonorsWithHttpInfo(string teamCampaignId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);
        /// <summary>
        /// Get team campaign by team slug and campaign slug
        /// </summary>
        /// <remarks>
        /// Returns a Team Campaign by its team slug and campaign slug
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamSlug">Team Slug</param>
        /// <param name="teamCampaignSlug">Campaign Slug</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>TeamCampaignResponse1</returns>
        TeamCampaignResponse1 V5ApiWebPublicTeamCampaignControllerShowSlug(string teamSlug, string teamCampaignSlug, int operationIndex = 0);

        /// <summary>
        /// Get team campaign by team slug and campaign slug
        /// </summary>
        /// <remarks>
        /// Returns a Team Campaign by its team slug and campaign slug
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamSlug">Team Slug</param>
        /// <param name="teamCampaignSlug">Campaign Slug</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of TeamCampaignResponse1</returns>
        ApiResponse<TeamCampaignResponse1> V5ApiWebPublicTeamCampaignControllerShowSlugWithHttpInfo(string teamSlug, string teamCampaignSlug, int operationIndex = 0);
        /// <summary>
        /// List top fundraisers
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>LeaderboardEntryPaginatedResponse1</returns>
        LeaderboardEntryPaginatedResponse1 V5ApiWebPublicTeamCampaignLeaderboardControllerUser(string teamCampaignId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);

        /// <summary>
        /// List top fundraisers
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of LeaderboardEntryPaginatedResponse1</returns>
        ApiResponse<LeaderboardEntryPaginatedResponse1> V5ApiWebPublicTeamCampaignLeaderboardControllerUserWithHttpInfo(string teamCampaignId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ITeamCampaignApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Get by ID
        /// </summary>
        /// <remarks>
        /// Returns a Team Campaign by its ID
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TeamCampaignResponse1</returns>
        System.Threading.Tasks.Task<TeamCampaignResponse1> GetTeamCampaignAsync(string teamCampaignId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get by ID
        /// </summary>
        /// <remarks>
        /// Returns a Team Campaign by its ID
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TeamCampaignResponse1)</returns>
        System.Threading.Tasks.Task<ApiResponse<TeamCampaignResponse1>> GetTeamCampaignWithHttpInfoAsync(string teamCampaignId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List donations
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="completedBefore">Returns only donations that have been completed before the given moment in ISO8601 format (optional)</param>
        /// <param name="completedAfter">Returns only donations that have been completed after the given moment in ISO8601 format (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DonationPaginatedResponse1</returns>
        System.Threading.Tasks.Task<DonationPaginatedResponse1> GetTeamCampaignDonationsAsync(string teamCampaignId, string? completedBefore = default(string?), string? completedAfter = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List donations
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="completedBefore">Returns only donations that have been completed before the given moment in ISO8601 format (optional)</param>
        /// <param name="completedAfter">Returns only donations that have been completed after the given moment in ISO8601 format (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DonationPaginatedResponse1)</returns>
        System.Threading.Tasks.Task<ApiResponse<DonationPaginatedResponse1>> GetTeamCampaignDonationsWithHttpInfoAsync(string teamCampaignId, string? completedBefore = default(string?), string? completedAfter = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List milestones
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
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
        System.Threading.Tasks.Task<MilestonePaginatedResponse1> GetTeamCampaignMilestonesAsync(string teamCampaignId, bool? includeDisabled = default(bool?), string? createdBefore = default(string?), string? createdAfter = default(string?), string? updatedBefore = default(string?), string? updatedAfter = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List milestones
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
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
        System.Threading.Tasks.Task<ApiResponse<MilestonePaginatedResponse1>> GetTeamCampaignMilestonesWithHttpInfoAsync(string teamCampaignId, bool? includeDisabled = default(bool?), string? createdBefore = default(string?), string? createdAfter = default(string?), string? updatedBefore = default(string?), string? updatedAfter = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get team campaign poll by ID
        /// </summary>
        /// <remarks>
        /// Returns a poll by its ID
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="pollId">Poll ID</param>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PollResponse1</returns>
        System.Threading.Tasks.Task<PollResponse1> GetTeamCampaignPollbyIdAsync(string pollId, string teamCampaignId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get team campaign poll by ID
        /// </summary>
        /// <remarks>
        /// Returns a poll by its ID
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="pollId">Poll ID</param>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PollResponse1)</returns>
        System.Threading.Tasks.Task<ApiResponse<PollResponse1>> GetTeamCampaignPollbyIdWithHttpInfoAsync(string pollId, string teamCampaignId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List polls
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PollPaginatedResponse1</returns>
        System.Threading.Tasks.Task<PollPaginatedResponse1> GetTeamCampaignPollsAsync(string teamCampaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List polls
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PollPaginatedResponse1)</returns>
        System.Threading.Tasks.Task<ApiResponse<PollPaginatedResponse1>> GetTeamCampaignPollsWithHttpInfoAsync(string teamCampaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List rewards
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of RewardPaginatedResponse1</returns>
        System.Threading.Tasks.Task<RewardPaginatedResponse1> GetTeamCampaignRewardsAsync(string teamCampaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List rewards
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (RewardPaginatedResponse1)</returns>
        System.Threading.Tasks.Task<ApiResponse<RewardPaginatedResponse1>> GetTeamCampaignRewardsWithHttpInfoAsync(string teamCampaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List schedules
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of SchedulePaginatedResponse1</returns>
        System.Threading.Tasks.Task<SchedulePaginatedResponse1> GetTeamCampaignSchedulesAsync(string teamCampaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List schedules
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (SchedulePaginatedResponse1)</returns>
        System.Threading.Tasks.Task<ApiResponse<SchedulePaginatedResponse1>> GetTeamCampaignSchedulesWithHttpInfoAsync(string teamCampaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List supporting campaigns
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CampaignPaginatedResponse1</returns>
        System.Threading.Tasks.Task<CampaignPaginatedResponse1> GetTeamCampaignSupportingCampaignsAsync(string teamCampaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List supporting campaigns
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CampaignPaginatedResponse1)</returns>
        System.Threading.Tasks.Task<ApiResponse<CampaignPaginatedResponse1>> GetTeamCampaignSupportingCampaignsWithHttpInfoAsync(string teamCampaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List targets
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TargetPaginatedResponse1</returns>
        System.Threading.Tasks.Task<TargetPaginatedResponse1> GetTeamCampaignTargetsAsync(string teamCampaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List targets
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TargetPaginatedResponse1)</returns>
        System.Threading.Tasks.Task<ApiResponse<TargetPaginatedResponse1>> GetTeamCampaignTargetsWithHttpInfoAsync(string teamCampaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List top donors
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of LeaderboardEntryPaginatedResponse1</returns>
        System.Threading.Tasks.Task<LeaderboardEntryPaginatedResponse1> GetTeamCampaignTopDonorsAsync(string teamCampaignId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List top donors
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (LeaderboardEntryPaginatedResponse1)</returns>
        System.Threading.Tasks.Task<ApiResponse<LeaderboardEntryPaginatedResponse1>> GetTeamCampaignTopDonorsWithHttpInfoAsync(string teamCampaignId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get team campaign by team slug and campaign slug
        /// </summary>
        /// <remarks>
        /// Returns a Team Campaign by its team slug and campaign slug
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamSlug">Team Slug</param>
        /// <param name="teamCampaignSlug">Campaign Slug</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TeamCampaignResponse1</returns>
        System.Threading.Tasks.Task<TeamCampaignResponse1> V5ApiWebPublicTeamCampaignControllerShowSlugAsync(string teamSlug, string teamCampaignSlug, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get team campaign by team slug and campaign slug
        /// </summary>
        /// <remarks>
        /// Returns a Team Campaign by its team slug and campaign slug
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamSlug">Team Slug</param>
        /// <param name="teamCampaignSlug">Campaign Slug</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TeamCampaignResponse1)</returns>
        System.Threading.Tasks.Task<ApiResponse<TeamCampaignResponse1>> V5ApiWebPublicTeamCampaignControllerShowSlugWithHttpInfoAsync(string teamSlug, string teamCampaignSlug, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List top fundraisers
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of LeaderboardEntryPaginatedResponse1</returns>
        System.Threading.Tasks.Task<LeaderboardEntryPaginatedResponse1> V5ApiWebPublicTeamCampaignLeaderboardControllerUserAsync(string teamCampaignId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List top fundraisers
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (LeaderboardEntryPaginatedResponse1)</returns>
        System.Threading.Tasks.Task<ApiResponse<LeaderboardEntryPaginatedResponse1>> V5ApiWebPublicTeamCampaignLeaderboardControllerUserWithHttpInfoAsync(string teamCampaignId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ITeamCampaignApi : ITeamCampaignApiSync, ITeamCampaignApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class TeamCampaignApi : ITeamCampaignApi
    {
        private TiltifyV5.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamCampaignApi"/> class.
        /// </summary>
        /// <returns></returns>
        public TeamCampaignApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamCampaignApi"/> class.
        /// </summary>
        /// <returns></returns>
        public TeamCampaignApi(string basePath)
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
        /// Initializes a new instance of the <see cref="TeamCampaignApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public TeamCampaignApi(TiltifyV5.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="TeamCampaignApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public TeamCampaignApi(TiltifyV5.Client.ISynchronousClient client, TiltifyV5.Client.IAsynchronousClient asyncClient, TiltifyV5.Client.IReadableConfiguration configuration)
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
        /// Get by ID Returns a Team Campaign by its ID
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>TeamCampaignResponse1</returns>
        public TeamCampaignResponse1 GetTeamCampaign(string teamCampaignId, int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<TeamCampaignResponse1> localVarResponse = GetTeamCampaignWithHttpInfo(teamCampaignId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get by ID Returns a Team Campaign by its ID
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of TeamCampaignResponse1</returns>
        public TiltifyV5.Client.ApiResponse<TeamCampaignResponse1> GetTeamCampaignWithHttpInfo(string teamCampaignId, int operationIndex = 0)
        {
            // verify the required parameter 'teamCampaignId' is set
            if (teamCampaignId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'teamCampaignId' when calling TeamCampaignApi->GetTeamCampaign");
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

            localVarRequestOptions.PathParameters.Add("team_campaign_id", TiltifyV5.Client.ClientUtils.ParameterToString(teamCampaignId)); // path parameter

            localVarRequestOptions.Operation = "TeamCampaignApi.GetTeamCampaign";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<TeamCampaignResponse1>("/api/public/team_campaigns/{team_campaign_id}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTeamCampaign", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get by ID Returns a Team Campaign by its ID
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TeamCampaignResponse1</returns>
        public async System.Threading.Tasks.Task<TeamCampaignResponse1> GetTeamCampaignAsync(string teamCampaignId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<TeamCampaignResponse1> localVarResponse = await GetTeamCampaignWithHttpInfoAsync(teamCampaignId, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get by ID Returns a Team Campaign by its ID
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TeamCampaignResponse1)</returns>
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<TeamCampaignResponse1>> GetTeamCampaignWithHttpInfoAsync(string teamCampaignId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'teamCampaignId' is set
            if (teamCampaignId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'teamCampaignId' when calling TeamCampaignApi->GetTeamCampaign");
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

            localVarRequestOptions.PathParameters.Add("team_campaign_id", TiltifyV5.Client.ClientUtils.ParameterToString(teamCampaignId)); // path parameter

            localVarRequestOptions.Operation = "TeamCampaignApi.GetTeamCampaign";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<TeamCampaignResponse1>("/api/public/team_campaigns/{team_campaign_id}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTeamCampaign", localVarResponse);
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
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="completedBefore">Returns only donations that have been completed before the given moment in ISO8601 format (optional)</param>
        /// <param name="completedAfter">Returns only donations that have been completed after the given moment in ISO8601 format (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>DonationPaginatedResponse1</returns>
        public DonationPaginatedResponse1 GetTeamCampaignDonations(string teamCampaignId, string? completedBefore = default(string?), string? completedAfter = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<DonationPaginatedResponse1> localVarResponse = GetTeamCampaignDonationsWithHttpInfo(teamCampaignId, completedBefore, completedAfter, after, before, limit);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List donations 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="completedBefore">Returns only donations that have been completed before the given moment in ISO8601 format (optional)</param>
        /// <param name="completedAfter">Returns only donations that have been completed after the given moment in ISO8601 format (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of DonationPaginatedResponse1</returns>
        public TiltifyV5.Client.ApiResponse<DonationPaginatedResponse1> GetTeamCampaignDonationsWithHttpInfo(string teamCampaignId, string? completedBefore = default(string?), string? completedAfter = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            // verify the required parameter 'teamCampaignId' is set
            if (teamCampaignId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'teamCampaignId' when calling TeamCampaignApi->GetTeamCampaignDonations");
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

            localVarRequestOptions.PathParameters.Add("team_campaign_id", TiltifyV5.Client.ClientUtils.ParameterToString(teamCampaignId)); // path parameter
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

            localVarRequestOptions.Operation = "TeamCampaignApi.GetTeamCampaignDonations";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<DonationPaginatedResponse1>("/api/public/team_campaigns/{team_campaign_id}/donations", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTeamCampaignDonations", localVarResponse);
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
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="completedBefore">Returns only donations that have been completed before the given moment in ISO8601 format (optional)</param>
        /// <param name="completedAfter">Returns only donations that have been completed after the given moment in ISO8601 format (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DonationPaginatedResponse1</returns>
        public async System.Threading.Tasks.Task<DonationPaginatedResponse1> GetTeamCampaignDonationsAsync(string teamCampaignId, string? completedBefore = default(string?), string? completedAfter = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<DonationPaginatedResponse1> localVarResponse = await GetTeamCampaignDonationsWithHttpInfoAsync(teamCampaignId, completedBefore, completedAfter, after, before, limit, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List donations 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="completedBefore">Returns only donations that have been completed before the given moment in ISO8601 format (optional)</param>
        /// <param name="completedAfter">Returns only donations that have been completed after the given moment in ISO8601 format (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DonationPaginatedResponse1)</returns>
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<DonationPaginatedResponse1>> GetTeamCampaignDonationsWithHttpInfoAsync(string teamCampaignId, string? completedBefore = default(string?), string? completedAfter = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'teamCampaignId' is set
            if (teamCampaignId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'teamCampaignId' when calling TeamCampaignApi->GetTeamCampaignDonations");
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

            localVarRequestOptions.PathParameters.Add("team_campaign_id", TiltifyV5.Client.ClientUtils.ParameterToString(teamCampaignId)); // path parameter
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

            localVarRequestOptions.Operation = "TeamCampaignApi.GetTeamCampaignDonations";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<DonationPaginatedResponse1>("/api/public/team_campaigns/{team_campaign_id}/donations", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTeamCampaignDonations", localVarResponse);
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
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
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
        public MilestonePaginatedResponse1 GetTeamCampaignMilestones(string teamCampaignId, bool? includeDisabled = default(bool?), string? createdBefore = default(string?), string? createdAfter = default(string?), string? updatedBefore = default(string?), string? updatedAfter = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<MilestonePaginatedResponse1> localVarResponse = GetTeamCampaignMilestonesWithHttpInfo(teamCampaignId, includeDisabled, createdBefore, createdAfter, updatedBefore, updatedAfter, after, before, limit);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List milestones 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
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
        public TiltifyV5.Client.ApiResponse<MilestonePaginatedResponse1> GetTeamCampaignMilestonesWithHttpInfo(string teamCampaignId, bool? includeDisabled = default(bool?), string? createdBefore = default(string?), string? createdAfter = default(string?), string? updatedBefore = default(string?), string? updatedAfter = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            // verify the required parameter 'teamCampaignId' is set
            if (teamCampaignId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'teamCampaignId' when calling TeamCampaignApi->GetTeamCampaignMilestones");
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

            localVarRequestOptions.PathParameters.Add("team_campaign_id", TiltifyV5.Client.ClientUtils.ParameterToString(teamCampaignId)); // path parameter
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

            localVarRequestOptions.Operation = "TeamCampaignApi.GetTeamCampaignMilestones";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<MilestonePaginatedResponse1>("/api/public/team_campaigns/{team_campaign_id}/milestones", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTeamCampaignMilestones", localVarResponse);
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
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
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
        public async System.Threading.Tasks.Task<MilestonePaginatedResponse1> GetTeamCampaignMilestonesAsync(string teamCampaignId, bool? includeDisabled = default(bool?), string? createdBefore = default(string?), string? createdAfter = default(string?), string? updatedBefore = default(string?), string? updatedAfter = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<MilestonePaginatedResponse1> localVarResponse = await GetTeamCampaignMilestonesWithHttpInfoAsync(teamCampaignId, includeDisabled, createdBefore, createdAfter, updatedBefore, updatedAfter, after, before, limit, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List milestones 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
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
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<MilestonePaginatedResponse1>> GetTeamCampaignMilestonesWithHttpInfoAsync(string teamCampaignId, bool? includeDisabled = default(bool?), string? createdBefore = default(string?), string? createdAfter = default(string?), string? updatedBefore = default(string?), string? updatedAfter = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'teamCampaignId' is set
            if (teamCampaignId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'teamCampaignId' when calling TeamCampaignApi->GetTeamCampaignMilestones");
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

            localVarRequestOptions.PathParameters.Add("team_campaign_id", TiltifyV5.Client.ClientUtils.ParameterToString(teamCampaignId)); // path parameter
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

            localVarRequestOptions.Operation = "TeamCampaignApi.GetTeamCampaignMilestones";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<MilestonePaginatedResponse1>("/api/public/team_campaigns/{team_campaign_id}/milestones", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTeamCampaignMilestones", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get team campaign poll by ID Returns a poll by its ID
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="pollId">Poll ID</param>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>PollResponse1</returns>
        public PollResponse1 GetTeamCampaignPollbyId(string pollId, string teamCampaignId, int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<PollResponse1> localVarResponse = GetTeamCampaignPollbyIdWithHttpInfo(pollId, teamCampaignId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get team campaign poll by ID Returns a poll by its ID
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="pollId">Poll ID</param>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of PollResponse1</returns>
        public TiltifyV5.Client.ApiResponse<PollResponse1> GetTeamCampaignPollbyIdWithHttpInfo(string pollId, string teamCampaignId, int operationIndex = 0)
        {
            // verify the required parameter 'pollId' is set
            if (pollId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'pollId' when calling TeamCampaignApi->GetTeamCampaignPollbyId");
            }

            // verify the required parameter 'teamCampaignId' is set
            if (teamCampaignId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'teamCampaignId' when calling TeamCampaignApi->GetTeamCampaignPollbyId");
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
            localVarRequestOptions.PathParameters.Add("team_campaign_id", TiltifyV5.Client.ClientUtils.ParameterToString(teamCampaignId)); // path parameter

            localVarRequestOptions.Operation = "TeamCampaignApi.GetTeamCampaignPollbyId";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<PollResponse1>("/api/public/team_campaigns/{team_campaign_id}/polls/{poll_id}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTeamCampaignPollbyId", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get team campaign poll by ID Returns a poll by its ID
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="pollId">Poll ID</param>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PollResponse1</returns>
        public async System.Threading.Tasks.Task<PollResponse1> GetTeamCampaignPollbyIdAsync(string pollId, string teamCampaignId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<PollResponse1> localVarResponse = await GetTeamCampaignPollbyIdWithHttpInfoAsync(pollId, teamCampaignId, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get team campaign poll by ID Returns a poll by its ID
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="pollId">Poll ID</param>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PollResponse1)</returns>
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<PollResponse1>> GetTeamCampaignPollbyIdWithHttpInfoAsync(string pollId, string teamCampaignId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'pollId' is set
            if (pollId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'pollId' when calling TeamCampaignApi->GetTeamCampaignPollbyId");
            }

            // verify the required parameter 'teamCampaignId' is set
            if (teamCampaignId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'teamCampaignId' when calling TeamCampaignApi->GetTeamCampaignPollbyId");
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
            localVarRequestOptions.PathParameters.Add("team_campaign_id", TiltifyV5.Client.ClientUtils.ParameterToString(teamCampaignId)); // path parameter

            localVarRequestOptions.Operation = "TeamCampaignApi.GetTeamCampaignPollbyId";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<PollResponse1>("/api/public/team_campaigns/{team_campaign_id}/polls/{poll_id}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTeamCampaignPollbyId", localVarResponse);
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
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>PollPaginatedResponse1</returns>
        public PollPaginatedResponse1 GetTeamCampaignPolls(string teamCampaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<PollPaginatedResponse1> localVarResponse = GetTeamCampaignPollsWithHttpInfo(teamCampaignId, after, before, limit);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List polls 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of PollPaginatedResponse1</returns>
        public TiltifyV5.Client.ApiResponse<PollPaginatedResponse1> GetTeamCampaignPollsWithHttpInfo(string teamCampaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            // verify the required parameter 'teamCampaignId' is set
            if (teamCampaignId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'teamCampaignId' when calling TeamCampaignApi->GetTeamCampaignPolls");
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

            localVarRequestOptions.PathParameters.Add("team_campaign_id", TiltifyV5.Client.ClientUtils.ParameterToString(teamCampaignId)); // path parameter
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

            localVarRequestOptions.Operation = "TeamCampaignApi.GetTeamCampaignPolls";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<PollPaginatedResponse1>("/api/public/team_campaigns/{team_campaign_id}/polls", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTeamCampaignPolls", localVarResponse);
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
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PollPaginatedResponse1</returns>
        public async System.Threading.Tasks.Task<PollPaginatedResponse1> GetTeamCampaignPollsAsync(string teamCampaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<PollPaginatedResponse1> localVarResponse = await GetTeamCampaignPollsWithHttpInfoAsync(teamCampaignId, after, before, limit, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List polls 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PollPaginatedResponse1)</returns>
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<PollPaginatedResponse1>> GetTeamCampaignPollsWithHttpInfoAsync(string teamCampaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'teamCampaignId' is set
            if (teamCampaignId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'teamCampaignId' when calling TeamCampaignApi->GetTeamCampaignPolls");
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

            localVarRequestOptions.PathParameters.Add("team_campaign_id", TiltifyV5.Client.ClientUtils.ParameterToString(teamCampaignId)); // path parameter
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

            localVarRequestOptions.Operation = "TeamCampaignApi.GetTeamCampaignPolls";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<PollPaginatedResponse1>("/api/public/team_campaigns/{team_campaign_id}/polls", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTeamCampaignPolls", localVarResponse);
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
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>RewardPaginatedResponse1</returns>
        public RewardPaginatedResponse1 GetTeamCampaignRewards(string teamCampaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<RewardPaginatedResponse1> localVarResponse = GetTeamCampaignRewardsWithHttpInfo(teamCampaignId, after, before, limit);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List rewards 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of RewardPaginatedResponse1</returns>
        public TiltifyV5.Client.ApiResponse<RewardPaginatedResponse1> GetTeamCampaignRewardsWithHttpInfo(string teamCampaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            // verify the required parameter 'teamCampaignId' is set
            if (teamCampaignId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'teamCampaignId' when calling TeamCampaignApi->GetTeamCampaignRewards");
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

            localVarRequestOptions.PathParameters.Add("team_campaign_id", TiltifyV5.Client.ClientUtils.ParameterToString(teamCampaignId)); // path parameter
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

            localVarRequestOptions.Operation = "TeamCampaignApi.GetTeamCampaignRewards";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<RewardPaginatedResponse1>("/api/public/team_campaigns/{team_campaign_id}/rewards", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTeamCampaignRewards", localVarResponse);
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
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of RewardPaginatedResponse1</returns>
        public async System.Threading.Tasks.Task<RewardPaginatedResponse1> GetTeamCampaignRewardsAsync(string teamCampaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<RewardPaginatedResponse1> localVarResponse = await GetTeamCampaignRewardsWithHttpInfoAsync(teamCampaignId, after, before, limit, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List rewards 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (RewardPaginatedResponse1)</returns>
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<RewardPaginatedResponse1>> GetTeamCampaignRewardsWithHttpInfoAsync(string teamCampaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'teamCampaignId' is set
            if (teamCampaignId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'teamCampaignId' when calling TeamCampaignApi->GetTeamCampaignRewards");
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

            localVarRequestOptions.PathParameters.Add("team_campaign_id", TiltifyV5.Client.ClientUtils.ParameterToString(teamCampaignId)); // path parameter
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

            localVarRequestOptions.Operation = "TeamCampaignApi.GetTeamCampaignRewards";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<RewardPaginatedResponse1>("/api/public/team_campaigns/{team_campaign_id}/rewards", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTeamCampaignRewards", localVarResponse);
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
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>SchedulePaginatedResponse1</returns>
        public SchedulePaginatedResponse1 GetTeamCampaignSchedules(string teamCampaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<SchedulePaginatedResponse1> localVarResponse = GetTeamCampaignSchedulesWithHttpInfo(teamCampaignId, after, before, limit);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List schedules 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of SchedulePaginatedResponse1</returns>
        public TiltifyV5.Client.ApiResponse<SchedulePaginatedResponse1> GetTeamCampaignSchedulesWithHttpInfo(string teamCampaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            // verify the required parameter 'teamCampaignId' is set
            if (teamCampaignId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'teamCampaignId' when calling TeamCampaignApi->GetTeamCampaignSchedules");
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

            localVarRequestOptions.PathParameters.Add("team_campaign_id", TiltifyV5.Client.ClientUtils.ParameterToString(teamCampaignId)); // path parameter
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

            localVarRequestOptions.Operation = "TeamCampaignApi.GetTeamCampaignSchedules";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<SchedulePaginatedResponse1>("/api/public/team_campaigns/{team_campaign_id}/schedules", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTeamCampaignSchedules", localVarResponse);
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
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of SchedulePaginatedResponse1</returns>
        public async System.Threading.Tasks.Task<SchedulePaginatedResponse1> GetTeamCampaignSchedulesAsync(string teamCampaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<SchedulePaginatedResponse1> localVarResponse = await GetTeamCampaignSchedulesWithHttpInfoAsync(teamCampaignId, after, before, limit, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List schedules 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (SchedulePaginatedResponse1)</returns>
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<SchedulePaginatedResponse1>> GetTeamCampaignSchedulesWithHttpInfoAsync(string teamCampaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'teamCampaignId' is set
            if (teamCampaignId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'teamCampaignId' when calling TeamCampaignApi->GetTeamCampaignSchedules");
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

            localVarRequestOptions.PathParameters.Add("team_campaign_id", TiltifyV5.Client.ClientUtils.ParameterToString(teamCampaignId)); // path parameter
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

            localVarRequestOptions.Operation = "TeamCampaignApi.GetTeamCampaignSchedules";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<SchedulePaginatedResponse1>("/api/public/team_campaigns/{team_campaign_id}/schedules", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTeamCampaignSchedules", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List supporting campaigns 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>CampaignPaginatedResponse1</returns>
        public CampaignPaginatedResponse1 GetTeamCampaignSupportingCampaigns(string teamCampaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<CampaignPaginatedResponse1> localVarResponse = GetTeamCampaignSupportingCampaignsWithHttpInfo(teamCampaignId, after, before, limit);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List supporting campaigns 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of CampaignPaginatedResponse1</returns>
        public TiltifyV5.Client.ApiResponse<CampaignPaginatedResponse1> GetTeamCampaignSupportingCampaignsWithHttpInfo(string teamCampaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            // verify the required parameter 'teamCampaignId' is set
            if (teamCampaignId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'teamCampaignId' when calling TeamCampaignApi->GetTeamCampaignSupportingCampaigns");
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

            localVarRequestOptions.PathParameters.Add("team_campaign_id", TiltifyV5.Client.ClientUtils.ParameterToString(teamCampaignId)); // path parameter
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

            localVarRequestOptions.Operation = "TeamCampaignApi.GetTeamCampaignSupportingCampaigns";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<CampaignPaginatedResponse1>("/api/public/team_campaigns/{team_campaign_id}/supporting_campaigns", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTeamCampaignSupportingCampaigns", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List supporting campaigns 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CampaignPaginatedResponse1</returns>
        public async System.Threading.Tasks.Task<CampaignPaginatedResponse1> GetTeamCampaignSupportingCampaignsAsync(string teamCampaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<CampaignPaginatedResponse1> localVarResponse = await GetTeamCampaignSupportingCampaignsWithHttpInfoAsync(teamCampaignId, after, before, limit, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List supporting campaigns 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CampaignPaginatedResponse1)</returns>
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<CampaignPaginatedResponse1>> GetTeamCampaignSupportingCampaignsWithHttpInfoAsync(string teamCampaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'teamCampaignId' is set
            if (teamCampaignId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'teamCampaignId' when calling TeamCampaignApi->GetTeamCampaignSupportingCampaigns");
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

            localVarRequestOptions.PathParameters.Add("team_campaign_id", TiltifyV5.Client.ClientUtils.ParameterToString(teamCampaignId)); // path parameter
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

            localVarRequestOptions.Operation = "TeamCampaignApi.GetTeamCampaignSupportingCampaigns";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<CampaignPaginatedResponse1>("/api/public/team_campaigns/{team_campaign_id}/supporting_campaigns", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTeamCampaignSupportingCampaigns", localVarResponse);
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
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>TargetPaginatedResponse1</returns>
        public TargetPaginatedResponse1 GetTeamCampaignTargets(string teamCampaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<TargetPaginatedResponse1> localVarResponse = GetTeamCampaignTargetsWithHttpInfo(teamCampaignId, after, before, limit);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List targets 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of TargetPaginatedResponse1</returns>
        public TiltifyV5.Client.ApiResponse<TargetPaginatedResponse1> GetTeamCampaignTargetsWithHttpInfo(string teamCampaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            // verify the required parameter 'teamCampaignId' is set
            if (teamCampaignId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'teamCampaignId' when calling TeamCampaignApi->GetTeamCampaignTargets");
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

            localVarRequestOptions.PathParameters.Add("team_campaign_id", TiltifyV5.Client.ClientUtils.ParameterToString(teamCampaignId)); // path parameter
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

            localVarRequestOptions.Operation = "TeamCampaignApi.GetTeamCampaignTargets";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<TargetPaginatedResponse1>("/api/public/team_campaigns/{team_campaign_id}/targets", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTeamCampaignTargets", localVarResponse);
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
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TargetPaginatedResponse1</returns>
        public async System.Threading.Tasks.Task<TargetPaginatedResponse1> GetTeamCampaignTargetsAsync(string teamCampaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<TargetPaginatedResponse1> localVarResponse = await GetTeamCampaignTargetsWithHttpInfoAsync(teamCampaignId, after, before, limit, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List targets 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Campaign ID or legacy ID</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TargetPaginatedResponse1)</returns>
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<TargetPaginatedResponse1>> GetTeamCampaignTargetsWithHttpInfoAsync(string teamCampaignId, string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'teamCampaignId' is set
            if (teamCampaignId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'teamCampaignId' when calling TeamCampaignApi->GetTeamCampaignTargets");
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

            localVarRequestOptions.PathParameters.Add("team_campaign_id", TiltifyV5.Client.ClientUtils.ParameterToString(teamCampaignId)); // path parameter
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

            localVarRequestOptions.Operation = "TeamCampaignApi.GetTeamCampaignTargets";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<TargetPaginatedResponse1>("/api/public/team_campaigns/{team_campaign_id}/targets", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTeamCampaignTargets", localVarResponse);
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
        /// <param name="teamCampaignId">Team Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>LeaderboardEntryPaginatedResponse1</returns>
        public LeaderboardEntryPaginatedResponse1 GetTeamCampaignTopDonors(string teamCampaignId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<LeaderboardEntryPaginatedResponse1> localVarResponse = GetTeamCampaignTopDonorsWithHttpInfo(teamCampaignId, timeType, after, before, limit);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List top donors 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of LeaderboardEntryPaginatedResponse1</returns>
        public TiltifyV5.Client.ApiResponse<LeaderboardEntryPaginatedResponse1> GetTeamCampaignTopDonorsWithHttpInfo(string teamCampaignId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            // verify the required parameter 'teamCampaignId' is set
            if (teamCampaignId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'teamCampaignId' when calling TeamCampaignApi->GetTeamCampaignTopDonors");
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

            localVarRequestOptions.PathParameters.Add("team_campaign_id", TiltifyV5.Client.ClientUtils.ParameterToString(teamCampaignId)); // path parameter
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

            localVarRequestOptions.Operation = "TeamCampaignApi.GetTeamCampaignTopDonors";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<LeaderboardEntryPaginatedResponse1>("/api/public/team_campaigns/{team_campaign_id}/donor_leaderboards", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTeamCampaignTopDonors", localVarResponse);
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
        /// <param name="teamCampaignId">Team Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of LeaderboardEntryPaginatedResponse1</returns>
        public async System.Threading.Tasks.Task<LeaderboardEntryPaginatedResponse1> GetTeamCampaignTopDonorsAsync(string teamCampaignId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<LeaderboardEntryPaginatedResponse1> localVarResponse = await GetTeamCampaignTopDonorsWithHttpInfoAsync(teamCampaignId, timeType, after, before, limit, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List top donors 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (LeaderboardEntryPaginatedResponse1)</returns>
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<LeaderboardEntryPaginatedResponse1>> GetTeamCampaignTopDonorsWithHttpInfoAsync(string teamCampaignId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'teamCampaignId' is set
            if (teamCampaignId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'teamCampaignId' when calling TeamCampaignApi->GetTeamCampaignTopDonors");
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

            localVarRequestOptions.PathParameters.Add("team_campaign_id", TiltifyV5.Client.ClientUtils.ParameterToString(teamCampaignId)); // path parameter
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

            localVarRequestOptions.Operation = "TeamCampaignApi.GetTeamCampaignTopDonors";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<LeaderboardEntryPaginatedResponse1>("/api/public/team_campaigns/{team_campaign_id}/donor_leaderboards", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTeamCampaignTopDonors", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get team campaign by team slug and campaign slug Returns a Team Campaign by its team slug and campaign slug
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamSlug">Team Slug</param>
        /// <param name="teamCampaignSlug">Campaign Slug</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>TeamCampaignResponse1</returns>
        public TeamCampaignResponse1 V5ApiWebPublicTeamCampaignControllerShowSlug(string teamSlug, string teamCampaignSlug, int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<TeamCampaignResponse1> localVarResponse = V5ApiWebPublicTeamCampaignControllerShowSlugWithHttpInfo(teamSlug, teamCampaignSlug);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get team campaign by team slug and campaign slug Returns a Team Campaign by its team slug and campaign slug
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamSlug">Team Slug</param>
        /// <param name="teamCampaignSlug">Campaign Slug</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of TeamCampaignResponse1</returns>
        public TiltifyV5.Client.ApiResponse<TeamCampaignResponse1> V5ApiWebPublicTeamCampaignControllerShowSlugWithHttpInfo(string teamSlug, string teamCampaignSlug, int operationIndex = 0)
        {
            // verify the required parameter 'teamSlug' is set
            if (teamSlug == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'teamSlug' when calling TeamCampaignApi->V5ApiWebPublicTeamCampaignControllerShowSlug");
            }

            // verify the required parameter 'teamCampaignSlug' is set
            if (teamCampaignSlug == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'teamCampaignSlug' when calling TeamCampaignApi->V5ApiWebPublicTeamCampaignControllerShowSlug");
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

            localVarRequestOptions.PathParameters.Add("team_slug", TiltifyV5.Client.ClientUtils.ParameterToString(teamSlug)); // path parameter
            localVarRequestOptions.PathParameters.Add("team_campaign_slug", TiltifyV5.Client.ClientUtils.ParameterToString(teamCampaignSlug)); // path parameter

            localVarRequestOptions.Operation = "TeamCampaignApi.V5ApiWebPublicTeamCampaignControllerShowSlug";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<TeamCampaignResponse1>("/api/public/team_campaigns/by/slugs/{team_slug}/{team_campaign_slug}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V5ApiWebPublicTeamCampaignControllerShowSlug", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get team campaign by team slug and campaign slug Returns a Team Campaign by its team slug and campaign slug
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamSlug">Team Slug</param>
        /// <param name="teamCampaignSlug">Campaign Slug</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TeamCampaignResponse1</returns>
        public async System.Threading.Tasks.Task<TeamCampaignResponse1> V5ApiWebPublicTeamCampaignControllerShowSlugAsync(string teamSlug, string teamCampaignSlug, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<TeamCampaignResponse1> localVarResponse = await V5ApiWebPublicTeamCampaignControllerShowSlugWithHttpInfoAsync(teamSlug, teamCampaignSlug, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get team campaign by team slug and campaign slug Returns a Team Campaign by its team slug and campaign slug
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamSlug">Team Slug</param>
        /// <param name="teamCampaignSlug">Campaign Slug</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TeamCampaignResponse1)</returns>
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<TeamCampaignResponse1>> V5ApiWebPublicTeamCampaignControllerShowSlugWithHttpInfoAsync(string teamSlug, string teamCampaignSlug, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'teamSlug' is set
            if (teamSlug == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'teamSlug' when calling TeamCampaignApi->V5ApiWebPublicTeamCampaignControllerShowSlug");
            }

            // verify the required parameter 'teamCampaignSlug' is set
            if (teamCampaignSlug == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'teamCampaignSlug' when calling TeamCampaignApi->V5ApiWebPublicTeamCampaignControllerShowSlug");
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

            localVarRequestOptions.PathParameters.Add("team_slug", TiltifyV5.Client.ClientUtils.ParameterToString(teamSlug)); // path parameter
            localVarRequestOptions.PathParameters.Add("team_campaign_slug", TiltifyV5.Client.ClientUtils.ParameterToString(teamCampaignSlug)); // path parameter

            localVarRequestOptions.Operation = "TeamCampaignApi.V5ApiWebPublicTeamCampaignControllerShowSlug";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<TeamCampaignResponse1>("/api/public/team_campaigns/by/slugs/{team_slug}/{team_campaign_slug}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V5ApiWebPublicTeamCampaignControllerShowSlug", localVarResponse);
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
        /// <param name="teamCampaignId">Team Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>LeaderboardEntryPaginatedResponse1</returns>
        public LeaderboardEntryPaginatedResponse1 V5ApiWebPublicTeamCampaignLeaderboardControllerUser(string teamCampaignId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            TiltifyV5.Client.ApiResponse<LeaderboardEntryPaginatedResponse1> localVarResponse = V5ApiWebPublicTeamCampaignLeaderboardControllerUserWithHttpInfo(teamCampaignId, timeType, after, before, limit);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List top fundraisers 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of LeaderboardEntryPaginatedResponse1</returns>
        public TiltifyV5.Client.ApiResponse<LeaderboardEntryPaginatedResponse1> V5ApiWebPublicTeamCampaignLeaderboardControllerUserWithHttpInfo(string teamCampaignId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0)
        {
            // verify the required parameter 'teamCampaignId' is set
            if (teamCampaignId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'teamCampaignId' when calling TeamCampaignApi->V5ApiWebPublicTeamCampaignLeaderboardControllerUser");
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

            localVarRequestOptions.PathParameters.Add("team_campaign_id", TiltifyV5.Client.ClientUtils.ParameterToString(teamCampaignId)); // path parameter
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

            localVarRequestOptions.Operation = "TeamCampaignApi.V5ApiWebPublicTeamCampaignLeaderboardControllerUser";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<LeaderboardEntryPaginatedResponse1>("/api/public/team_campaigns/{team_campaign_id}/user_leaderboards", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V5ApiWebPublicTeamCampaignLeaderboardControllerUser", localVarResponse);
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
        /// <param name="teamCampaignId">Team Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of LeaderboardEntryPaginatedResponse1</returns>
        public async System.Threading.Tasks.Task<LeaderboardEntryPaginatedResponse1> V5ApiWebPublicTeamCampaignLeaderboardControllerUserAsync(string teamCampaignId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            TiltifyV5.Client.ApiResponse<LeaderboardEntryPaginatedResponse1> localVarResponse = await V5ApiWebPublicTeamCampaignLeaderboardControllerUserWithHttpInfoAsync(teamCampaignId, timeType, after, before, limit, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List top fundraisers 
        /// </summary>
        /// <exception cref="TiltifyV5.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="teamCampaignId">Team Event ID</param>
        /// <param name="timeType">The time range to use in leaderboard generation (optional)</param>
        /// <param name="after">Returns records after the given cursor (optional)</param>
        /// <param name="before">Returns records before the given cursor (optional)</param>
        /// <param name="limit"> (optional, default to 10)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (LeaderboardEntryPaginatedResponse1)</returns>
        public async System.Threading.Tasks.Task<TiltifyV5.Client.ApiResponse<LeaderboardEntryPaginatedResponse1>> V5ApiWebPublicTeamCampaignLeaderboardControllerUserWithHttpInfoAsync(string teamCampaignId, string? timeType = default(string?), string? after = default(string?), string? before = default(string?), int? limit = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'teamCampaignId' is set
            if (teamCampaignId == null)
            {
                throw new TiltifyV5.Client.ApiException(400, "Missing required parameter 'teamCampaignId' when calling TeamCampaignApi->V5ApiWebPublicTeamCampaignLeaderboardControllerUser");
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

            localVarRequestOptions.PathParameters.Add("team_campaign_id", TiltifyV5.Client.ClientUtils.ParameterToString(teamCampaignId)); // path parameter
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

            localVarRequestOptions.Operation = "TeamCampaignApi.V5ApiWebPublicTeamCampaignLeaderboardControllerUser";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (authorization) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<LeaderboardEntryPaginatedResponse1>("/api/public/team_campaigns/{team_campaign_id}/user_leaderboards", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V5ApiWebPublicTeamCampaignLeaderboardControllerUser", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}
