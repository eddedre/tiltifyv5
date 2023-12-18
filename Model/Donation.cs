/*
 * V5ApiPublic
 *
 * Welcome to the Tiltify V5 API docmentation site.  This is the public API for Tiltify. It is intended to be used by third party developers to build integrations with Tiltify. Additional documentation may be found at the [Tiltify Developers](https://developers.tiltify.com) documentation site.  # OpenAPI Specification The API uses the OpenAPI Specification (OAS) to define the API. More information about the OpenAPI Specification can be found at [https://swagger.io/specification/](https://swagger.io/specification/).  # Authentication Tiltify uses OAuth 2.0 access tokens to authenticate API requests. You may get an Application `access_token` or a User `access_token`. To authenticate, you will need to create an application in the Tiltify User Dashboard, and use the generated credentials.  ## Getting an Application Access Token  The method to get an application access token follows the Client Credentials Oauth2 grant flow.  You may give the required parameters to the [Oauth Token Endpoint](#tag/oauth) to get an access token for use with the api directly.  ## Getting a User Access Token  The method to get a user access token follows the OAuth2 Authorization Grant flow. The following is a specific example of how to retrieve A User Access token using OAuth2  ### Getting the code  This example will be using the following values as needed. - Application ID: 1234 - Redirect https://www.example.com/redirect - Secret Key: asdf  To begin with, send a user in a browser to the Tiltify OAuth Authorization url. Include your Client ID, and the response type of `code` as query parameters. You may include your redirect URI if you have more than one. A space separated list of scopes may also be added, however, if not included, the `public` scope will be automatically selected.  ``` https://v5api.tiltify.com/oauth/authorize?&client_id=1234&response_type=code&redirect_uri=https%3A%2F%2Fwww.example.com%2Fredirect&scope=public ```  After signing in and authorizing, the user will be redirected back to your chosen redirect URI with a query parameter of `code`, containing the code used to fetch the access token.  ``` https://www.example.com/redirect?code=1234abcdef ```  The code should be passed to your server backend as the following steps require your secret key, which should not be exposed to the public.  ### Converting The Code To A User Access Token  To retrieve the User Access Token, a post request must be made to the Token URL. In the body of the url are the following fields in Form Data format. Note specifically that code is the code retrieved from the first step.  ``` client_id=1234 redirect_uri=https://www.example.com/redirect code=1234abcdef grant_type=authorization_code ```  Tiltify will return a response like the following:  ``` {      \"access_token\": \"ab6a592346444dea97170837e104d8a5ab6a592346444dea97170837e104d8a5\",     \"created_at\": \"2023-01-27T19:32:03Z\",     \"expires_in\": 7200,     \"refresh_token\": \"njjjytm3otetmgrjmi00yjawlwe4zgytzjixy2mzm2y3njawcg121231999393a3\",     \"scope\": \"public\",     \"token_type\": \"bearer\"  } ```  This access token may now be used as shown below to make requests. When used with the [/current-user](#tag/user/operation/V5ApiWeb.Public.UserController.current_user) endpoint, the full `user` object is returned.  ## Using Access Tokens  Add the Authorization header to your HTTP request.  ``` Authorization: Bearer <access_token> ```  Example:  ``` Authorization: Bearer ab6a592346444dea97170837e104d8a5ab6a592346444dea97170837e104d8a5 ```  ## Using Refresh Tokens  When an initial access token is created, a refresh token will be provided. The refresh token can be used to get a new access token when the current one expires. To do this, make a post request to the token url with grant_type set to `refresh_token`.  Example:  To refresh the User Access Token, a post request must be made to the Token URL. In the body of the url are the following fields in Form Data or json format.  ``` client_id=1234 client_secret=asdf grant_type=refresh_token refresh_token=njjjytm3otetmgrjmi00yjawlwe4zgytzjixy2mzm2y3njawcg121231999393a3 ```  <SecurityDefinitions />  # Webhooks  Tiltify provides a dashboard to subscribe and test campaign and campaign donation webhooks.  To register a webhook, visit the [Developer Dashboard](https://app.tiltify.com/developers)  ## Registering a webhook  In order to begin registering webhooks, you must first create an application.  In the application dashboard, there will be a side navigation option for `Webhooks`.  - Click the `Add Webhook` button - Create the webhook with an endpoint URL and an optional description. - Click edit on the newly created webhook - Click the `Events` submenu and add and event to subscribe to using the `Add event` button. - Enter your Campaign ID, this can be found in your campaign's dashboard under `Setup > Information` - Once created, click the `...` button and select Edit - Select the donation and/or Campaign events you would like to receive to your webhook endpoint and click `Update Event`. Including private data may include sensitive information, so please ensure that you secure your application.  You should now receive updates for those events on your webhook url.  <style>blockquote{border-left: 4px solid #F4CB14 !important; color: inherit !important;}</style> > Caution: > When we send a webhook we expect the endpoint to respond with a 200-299 status code. If we do not receive that, we deactivate the webhook after about an hour.   ## Testing  Once a webhook is created, you may send test messages through the `Testing` Submenu.  An example payload will be shown for each event type.  Click `Send Test` to initiate the test. 
 *
 * The version of the OpenAPI document: 1.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = TiltifyV5.Client.OpenAPIDateConverter;

namespace TiltifyV5.Model
{
    /// <summary>
    /// Donation
    /// </summary>
    [DataContract(Name = "Donation")]
    public partial class Donation : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Donation" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Donation() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Donation" /> class.
        /// </summary>
        /// <param name="amount">amount (required).</param>
        /// <param name="campaignId">Unique Identifier for the Object. UUID (required).</param>
        /// <param name="causeId">Unique Identifier for the Object. UUID (required).</param>
        /// <param name="completedAt">Timestamp of when the donation was completed. (required).</param>
        /// <param name="donorComment">Note left by donor (required).</param>
        /// <param name="donorName">Publically visible donor name. This may be set to &#39;Anonymous&#39; if the donation was anonymous or moderated. (required).</param>
        /// <param name="fundraisingEventId">Unique Identifier for the Object. UUID (required).</param>
        /// <param name="id">Unique Identifier for the Object. UUID (required).</param>
        /// <param name="legacyId">Legacy numeric ID of the object. If your app is dependent on this field, please migrate to id. This will be deprecated in the next version of the API. (required).</param>
        /// <param name="pollId">Unique Identifier for the Object. UUID (required).</param>
        /// <param name="pollOptionId">Unique Identifier for the Object. UUID (required).</param>
        /// <param name="rewardClaims">rewardClaims (required).</param>
        /// <param name="rewardId">Unique Identifier for the Object. UUID (required).</param>
        /// <param name="sustained">Whether or not the donation is a part of a monthly donation. (required).</param>
        /// <param name="targetId">Unique Identifier for the Object. UUID (required).</param>
        /// <param name="teamEventId">Unique Identifier for the Object. UUID (required).</param>
        public Donation(Money amount = default(Money), Guid campaignId = default(Guid), Guid causeId = default(Guid), DateTime? completedAt = default(DateTime?), string donorComment = default(string), string donorName = default(string), Guid fundraisingEventId = default(Guid), Guid id = default(Guid), decimal legacyId = default(decimal), Guid pollId = default(Guid), Guid pollOptionId = default(Guid), List<RewardClaim> rewardClaims = default(List<RewardClaim>), Guid rewardId = default(Guid), bool? sustained = default(bool?), Guid targetId = default(Guid), Guid teamEventId = default(Guid))
        {
            // to ensure "amount" is required (not null)
            if (amount == null)
            {
                throw new ArgumentNullException("amount is a required property for Donation and cannot be null");
            }
            this.Amount = amount;
            this.CampaignId = campaignId;
            this.CauseId = causeId;
            // to ensure "completedAt" is required (not null)
            if (completedAt == null)
            {
                throw new ArgumentNullException("completedAt is a required property for Donation and cannot be null");
            }
            this.CompletedAt = completedAt;
            // to ensure "donorComment" is required (not null)
            if (donorComment == null)
            {
                throw new ArgumentNullException("donorComment is a required property for Donation and cannot be null");
            }
            this.DonorComment = donorComment;
            // to ensure "donorName" is required (not null)
            if (donorName == null)
            {
                throw new ArgumentNullException("donorName is a required property for Donation and cannot be null");
            }
            this.DonorName = donorName;
            this.FundraisingEventId = fundraisingEventId;
            this.Id = id;
            this.LegacyId = legacyId;
            this.PollId = pollId;
            this.PollOptionId = pollOptionId;
            // to ensure "rewardClaims" is required (not null)
            if (rewardClaims == null)
            {
                throw new ArgumentNullException("rewardClaims is a required property for Donation and cannot be null");
            }
            this.RewardClaims = rewardClaims;
            this.RewardId = rewardId;
            // to ensure "sustained" is required (not null)
            if (sustained == null)
            {
                throw new ArgumentNullException("sustained is a required property for Donation and cannot be null");
            }
            this.Sustained = sustained;
            this.TargetId = targetId;
            this.TeamEventId = teamEventId;
        }

        /// <summary>
        /// Gets or Sets Amount
        /// </summary>
        [DataMember(Name = "amount", IsRequired = true, EmitDefaultValue = true)]
        public Money Amount { get; set; }

        /// <summary>
        /// Unique Identifier for the Object. UUID
        /// </summary>
        /// <value>Unique Identifier for the Object. UUID</value>
        /// <example>73ab8824-fe2a-4edf-8ae8-6b7bf6358e1b</example>
        [DataMember(Name = "campaign_id", IsRequired = true, EmitDefaultValue = true)]
        public Guid CampaignId { get; set; }

        /// <summary>
        /// Unique Identifier for the Object. UUID
        /// </summary>
        /// <value>Unique Identifier for the Object. UUID</value>
        /// <example>73ab8824-fe2a-4edf-8ae8-6b7bf6358e1b</example>
        [DataMember(Name = "cause_id", IsRequired = true, EmitDefaultValue = true)]
        public Guid CauseId { get; set; }

        /// <summary>
        /// Timestamp of when the donation was completed.
        /// </summary>
        /// <value>Timestamp of when the donation was completed.</value>
        [DataMember(Name = "completed_at", IsRequired = true, EmitDefaultValue = true)]
        public DateTime? CompletedAt { get; set; }

        /// <summary>
        /// Note left by donor
        /// </summary>
        /// <value>Note left by donor</value>
        [DataMember(Name = "donor_comment", IsRequired = true, EmitDefaultValue = true)]
        public string DonorComment { get; set; }

        /// <summary>
        /// Publically visible donor name. This may be set to &#39;Anonymous&#39; if the donation was anonymous or moderated.
        /// </summary>
        /// <value>Publically visible donor name. This may be set to &#39;Anonymous&#39; if the donation was anonymous or moderated.</value>
        [DataMember(Name = "donor_name", IsRequired = true, EmitDefaultValue = true)]
        public string DonorName { get; set; }

        /// <summary>
        /// Unique Identifier for the Object. UUID
        /// </summary>
        /// <value>Unique Identifier for the Object. UUID</value>
        /// <example>73ab8824-fe2a-4edf-8ae8-6b7bf6358e1b</example>
        [DataMember(Name = "fundraising_event_id", IsRequired = true, EmitDefaultValue = true)]
        public Guid FundraisingEventId { get; set; }

        /// <summary>
        /// Unique Identifier for the Object. UUID
        /// </summary>
        /// <value>Unique Identifier for the Object. UUID</value>
        /// <example>73ab8824-fe2a-4edf-8ae8-6b7bf6358e1b</example>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public Guid Id { get; set; }

        /// <summary>
        /// Legacy numeric ID of the object. If your app is dependent on this field, please migrate to id. This will be deprecated in the next version of the API.
        /// </summary>
        /// <value>Legacy numeric ID of the object. If your app is dependent on this field, please migrate to id. This will be deprecated in the next version of the API.</value>
        /// <example>211995566</example>
        [DataMember(Name = "legacy_id", IsRequired = true, EmitDefaultValue = true)]
        [Obsolete]
        public decimal LegacyId { get; set; }

        /// <summary>
        /// Unique Identifier for the Object. UUID
        /// </summary>
        /// <value>Unique Identifier for the Object. UUID</value>
        /// <example>73ab8824-fe2a-4edf-8ae8-6b7bf6358e1b</example>
        [DataMember(Name = "poll_id", IsRequired = true, EmitDefaultValue = true)]
        public Guid PollId { get; set; }

        /// <summary>
        /// Unique Identifier for the Object. UUID
        /// </summary>
        /// <value>Unique Identifier for the Object. UUID</value>
        /// <example>73ab8824-fe2a-4edf-8ae8-6b7bf6358e1b</example>
        [DataMember(Name = "poll_option_id", IsRequired = true, EmitDefaultValue = true)]
        public Guid PollOptionId { get; set; }

        /// <summary>
        /// Gets or Sets RewardClaims
        /// </summary>
        [DataMember(Name = "reward_claims", IsRequired = true, EmitDefaultValue = true)]
        public List<RewardClaim> RewardClaims { get; set; }

        /// <summary>
        /// Unique Identifier for the Object. UUID
        /// </summary>
        /// <value>Unique Identifier for the Object. UUID</value>
        /// <example>73ab8824-fe2a-4edf-8ae8-6b7bf6358e1b</example>
        [DataMember(Name = "reward_id", IsRequired = true, EmitDefaultValue = true)]
        [Obsolete]
        public Guid RewardId { get; set; }

        /// <summary>
        /// Whether or not the donation is a part of a monthly donation.
        /// </summary>
        /// <value>Whether or not the donation is a part of a monthly donation.</value>
        [DataMember(Name = "sustained", IsRequired = true, EmitDefaultValue = true)]
        public bool? Sustained { get; set; }

        /// <summary>
        /// Unique Identifier for the Object. UUID
        /// </summary>
        /// <value>Unique Identifier for the Object. UUID</value>
        /// <example>73ab8824-fe2a-4edf-8ae8-6b7bf6358e1b</example>
        [DataMember(Name = "target_id", IsRequired = true, EmitDefaultValue = true)]
        public Guid TargetId { get; set; }

        /// <summary>
        /// Unique Identifier for the Object. UUID
        /// </summary>
        /// <value>Unique Identifier for the Object. UUID</value>
        /// <example>73ab8824-fe2a-4edf-8ae8-6b7bf6358e1b</example>
        [DataMember(Name = "team_event_id", IsRequired = true, EmitDefaultValue = true)]
        public Guid TeamEventId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Donation {\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  CampaignId: ").Append(CampaignId).Append("\n");
            sb.Append("  CauseId: ").Append(CauseId).Append("\n");
            sb.Append("  CompletedAt: ").Append(CompletedAt).Append("\n");
            sb.Append("  DonorComment: ").Append(DonorComment).Append("\n");
            sb.Append("  DonorName: ").Append(DonorName).Append("\n");
            sb.Append("  FundraisingEventId: ").Append(FundraisingEventId).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  LegacyId: ").Append(LegacyId).Append("\n");
            sb.Append("  PollId: ").Append(PollId).Append("\n");
            sb.Append("  PollOptionId: ").Append(PollOptionId).Append("\n");
            sb.Append("  RewardClaims: ").Append(RewardClaims).Append("\n");
            sb.Append("  RewardId: ").Append(RewardId).Append("\n");
            sb.Append("  Sustained: ").Append(Sustained).Append("\n");
            sb.Append("  TargetId: ").Append(TargetId).Append("\n");
            sb.Append("  TeamEventId: ").Append(TeamEventId).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
