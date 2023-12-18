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
    /// DonationMatch
    /// </summary>
    [DataContract(Name = "DonationMatch")]
    public partial class DonationMatch : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DonationMatch" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected DonationMatch() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="DonationMatch" /> class.
        /// </summary>
        /// <param name="active">Whether or not the donation match is active (required).</param>
        /// <param name="amount">amount (required).</param>
        /// <param name="completedAt">Moment when the donation match completed (required).</param>
        /// <param name="donationId">Unique Identifier for the Object. UUID (required).</param>
        /// <param name="endsAt">Moment when the donation match ends (required).</param>
        /// <param name="id">Unique Identifier for the Object. UUID (required).</param>
        /// <param name="insertedAt">Moment when the donation match was created (required).</param>
        /// <param name="matchType">The type of the match, either &#39;all&#39; or &#39;amount&#39;.</param>
        /// <param name="matchedBy">The name of the person who started the donation match (required).</param>
        /// <param name="pledgedAmount">pledgedAmount (required).</param>
        /// <param name="startedAtAmount">startedAtAmount (required).</param>
        /// <param name="startsAt">Moment when the donation match starts (required).</param>
        /// <param name="totalAmountRaised">totalAmountRaised (required).</param>
        /// <param name="updatedAt">Moment when the donation match was last updated (required).</param>
        public DonationMatch(bool active = default(bool), Money amount = default(Money), DateTime? completedAt = default(DateTime?), Guid donationId = default(Guid), DateTime endsAt = default(DateTime), Guid id = default(Guid), DateTime insertedAt = default(DateTime), string matchType = default(string), string matchedBy = default(string), Money pledgedAmount = default(Money), Money startedAtAmount = default(Money), DateTime startsAt = default(DateTime), Money totalAmountRaised = default(Money), DateTime updatedAt = default(DateTime))
        {
            this.Active = active;
            // to ensure "amount" is required (not null)
            if (amount == null)
            {
                throw new ArgumentNullException("amount is a required property for DonationMatch and cannot be null");
            }
            this.Amount = amount;
            // to ensure "completedAt" is required (not null)
            if (completedAt == null)
            {
                throw new ArgumentNullException("completedAt is a required property for DonationMatch and cannot be null");
            }
            this.CompletedAt = completedAt;
            this.DonationId = donationId;
            this.EndsAt = endsAt;
            this.Id = id;
            this.InsertedAt = insertedAt;
            // to ensure "matchedBy" is required (not null)
            if (matchedBy == null)
            {
                throw new ArgumentNullException("matchedBy is a required property for DonationMatch and cannot be null");
            }
            this.MatchedBy = matchedBy;
            // to ensure "pledgedAmount" is required (not null)
            if (pledgedAmount == null)
            {
                throw new ArgumentNullException("pledgedAmount is a required property for DonationMatch and cannot be null");
            }
            this.PledgedAmount = pledgedAmount;
            // to ensure "startedAtAmount" is required (not null)
            if (startedAtAmount == null)
            {
                throw new ArgumentNullException("startedAtAmount is a required property for DonationMatch and cannot be null");
            }
            this.StartedAtAmount = startedAtAmount;
            this.StartsAt = startsAt;
            // to ensure "totalAmountRaised" is required (not null)
            if (totalAmountRaised == null)
            {
                throw new ArgumentNullException("totalAmountRaised is a required property for DonationMatch and cannot be null");
            }
            this.TotalAmountRaised = totalAmountRaised;
            this.UpdatedAt = updatedAt;
            this.MatchType = matchType;
        }

        /// <summary>
        /// Whether or not the donation match is active
        /// </summary>
        /// <value>Whether or not the donation match is active</value>
        [DataMember(Name = "active", IsRequired = true, EmitDefaultValue = true)]
        public bool Active { get; set; }

        /// <summary>
        /// Gets or Sets Amount
        /// </summary>
        [DataMember(Name = "amount", IsRequired = true, EmitDefaultValue = true)]
        public Money Amount { get; set; }

        /// <summary>
        /// Moment when the donation match completed
        /// </summary>
        /// <value>Moment when the donation match completed</value>
        [DataMember(Name = "completed_at", IsRequired = true, EmitDefaultValue = true)]
        public DateTime? CompletedAt { get; set; }

        /// <summary>
        /// Unique Identifier for the Object. UUID
        /// </summary>
        /// <value>Unique Identifier for the Object. UUID</value>
        /// <example>73ab8824-fe2a-4edf-8ae8-6b7bf6358e1b</example>
        [DataMember(Name = "donation_id", IsRequired = true, EmitDefaultValue = true)]
        public Guid DonationId { get; set; }

        /// <summary>
        /// Moment when the donation match ends
        /// </summary>
        /// <value>Moment when the donation match ends</value>
        [DataMember(Name = "ends_at", IsRequired = true, EmitDefaultValue = true)]
        public DateTime EndsAt { get; set; }

        /// <summary>
        /// Unique Identifier for the Object. UUID
        /// </summary>
        /// <value>Unique Identifier for the Object. UUID</value>
        /// <example>73ab8824-fe2a-4edf-8ae8-6b7bf6358e1b</example>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public Guid Id { get; set; }

        /// <summary>
        /// Moment when the donation match was created
        /// </summary>
        /// <value>Moment when the donation match was created</value>
        [DataMember(Name = "inserted_at", IsRequired = true, EmitDefaultValue = true)]
        public DateTime InsertedAt { get; set; }

        /// <summary>
        /// The type of the match, either &#39;all&#39; or &#39;amount&#39;
        /// </summary>
        /// <value>The type of the match, either &#39;all&#39; or &#39;amount&#39;</value>
        [DataMember(Name = "match_type", EmitDefaultValue = false)]
        public string MatchType { get; set; }

        /// <summary>
        /// The name of the person who started the donation match
        /// </summary>
        /// <value>The name of the person who started the donation match</value>
        [DataMember(Name = "matched_by", IsRequired = true, EmitDefaultValue = true)]
        public string MatchedBy { get; set; }

        /// <summary>
        /// Gets or Sets PledgedAmount
        /// </summary>
        [DataMember(Name = "pledged_amount", IsRequired = true, EmitDefaultValue = true)]
        public Money PledgedAmount { get; set; }

        /// <summary>
        /// Gets or Sets StartedAtAmount
        /// </summary>
        [DataMember(Name = "started_at_amount", IsRequired = true, EmitDefaultValue = true)]
        public Money StartedAtAmount { get; set; }

        /// <summary>
        /// Moment when the donation match starts
        /// </summary>
        /// <value>Moment when the donation match starts</value>
        [DataMember(Name = "starts_at", IsRequired = true, EmitDefaultValue = true)]
        public DateTime StartsAt { get; set; }

        /// <summary>
        /// Gets or Sets TotalAmountRaised
        /// </summary>
        [DataMember(Name = "total_amount_raised", IsRequired = true, EmitDefaultValue = true)]
        public Money TotalAmountRaised { get; set; }

        /// <summary>
        /// Moment when the donation match was last updated
        /// </summary>
        /// <value>Moment when the donation match was last updated</value>
        [DataMember(Name = "updated_at", IsRequired = true, EmitDefaultValue = true)]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class DonationMatch {\n");
            sb.Append("  Active: ").Append(Active).Append("\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  CompletedAt: ").Append(CompletedAt).Append("\n");
            sb.Append("  DonationId: ").Append(DonationId).Append("\n");
            sb.Append("  EndsAt: ").Append(EndsAt).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  InsertedAt: ").Append(InsertedAt).Append("\n");
            sb.Append("  MatchType: ").Append(MatchType).Append("\n");
            sb.Append("  MatchedBy: ").Append(MatchedBy).Append("\n");
            sb.Append("  PledgedAmount: ").Append(PledgedAmount).Append("\n");
            sb.Append("  StartedAtAmount: ").Append(StartedAtAmount).Append("\n");
            sb.Append("  StartsAt: ").Append(StartsAt).Append("\n");
            sb.Append("  TotalAmountRaised: ").Append(TotalAmountRaised).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
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
