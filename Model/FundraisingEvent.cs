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
    /// FundraisingEvent
    /// </summary>
    [DataContract(Name = "FundraisingEvent")]
    public partial class FundraisingEvent : IValidatableObject
    {
        /// <summary>
        /// The status of this fundraising event
        /// </summary>
        /// <value>The status of this fundraising event</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            /// <summary>
            /// Enum Unpublished for value: unpublished
            /// </summary>
            [EnumMember(Value = "unpublished")]
            Unpublished = 1,

            /// <summary>
            /// Enum Published for value: published
            /// </summary>
            [EnumMember(Value = "published")]
            Published = 2,

            /// <summary>
            /// Enum Retired for value: retired
            /// </summary>
            [EnumMember(Value = "retired")]
            Retired = 3
        }


        /// <summary>
        /// The status of this fundraising event
        /// </summary>
        /// <value>The status of this fundraising event</value>
        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = true)]
        public StatusEnum Status { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="FundraisingEvent" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected FundraisingEvent() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="FundraisingEvent" /> class.
        /// </summary>
        /// <param name="avatar">avatar (required).</param>
        /// <param name="canPublishSupportingAt">The datetime the campaign will allow supporting campaigns to be published in ISO 8601 format (required).</param>
        /// <param name="causeId">Unique Identifier for the Object. UUID (required).</param>
        /// <param name="currencyCode">ISO 4217 alphabetic currency code (required).</param>
        /// <param name="description">A short description about this fundraising event (required).</param>
        /// <param name="donateUrl">This is the full url used for the given resource. (required).</param>
        /// <param name="endSupportingAt">The datetime the campaign will stop accepting registrations in ISO 8601 format (required).</param>
        /// <param name="endsAt">A date when this fundraising event ends. (required).</param>
        /// <param name="goal">goal (required).</param>
        /// <param name="id">Unique Identifier for the Object. UUID (required).</param>
        /// <param name="insertedAt">When the fundraising event was created (required).</param>
        /// <param name="legacyId">Legacy numeric ID of the object. If your app is dependent on this field, please migrate to id. This will be deprecated in the next version of the API. (required).</param>
        /// <param name="name">The name of this fundraising event (required).</param>
        /// <param name="publishedAt">When the fundraising event was last published (required).</param>
        /// <param name="retiredAt">When the fundraising event was retired (required).</param>
        /// <param name="slug">This is a url slug used for the given resource. (required).</param>
        /// <param name="startSupportingAt">The datetime the campaign will start accepting registrations in ISO 8601 format (required).</param>
        /// <param name="startsAt">An optional date when this fundraising event starts. (required).</param>
        /// <param name="status">The status of this fundraising event (required).</param>
        /// <param name="totalAmountRaised">totalAmountRaised (required).</param>
        /// <param name="updatedAt">When the fundraising event details were last updated (required).</param>
        /// <param name="url">This is the full url used for the given resource. (required).</param>
        public FundraisingEvent(Image avatar = default(Image), string canPublishSupportingAt = default(string), Guid causeId = default(Guid), string currencyCode = default(string), string description = default(string), string donateUrl = default(string), string endSupportingAt = default(string), DateTime endsAt = default(DateTime), FundraisingEventGoal goal = default(FundraisingEventGoal), Guid id = default(Guid), DateTime insertedAt = default(DateTime), decimal legacyId = default(decimal), string name = default(string), DateTime publishedAt = default(DateTime), DateTime? retiredAt = default(DateTime?), string slug = default(string), string startSupportingAt = default(string), DateTime? startsAt = default(DateTime?), StatusEnum status = default(StatusEnum), Money totalAmountRaised = default(Money), DateTime updatedAt = default(DateTime), string url = default(string))
        {
            // to ensure "avatar" is required (not null)
            if (avatar == null)
            {
                throw new ArgumentNullException("avatar is a required property for FundraisingEvent and cannot be null");
            }
            this.Avatar = avatar;
            // to ensure "canPublishSupportingAt" is required (not null)
            if (canPublishSupportingAt == null)
            {
                throw new ArgumentNullException("canPublishSupportingAt is a required property for FundraisingEvent and cannot be null");
            }
            this.CanPublishSupportingAt = canPublishSupportingAt;
            this.CauseId = causeId;
            // to ensure "currencyCode" is required (not null)
            if (currencyCode == null)
            {
                throw new ArgumentNullException("currencyCode is a required property for FundraisingEvent and cannot be null");
            }
            this.CurrencyCode = currencyCode;
            // to ensure "description" is required (not null)
            if (description == null)
            {
                throw new ArgumentNullException("description is a required property for FundraisingEvent and cannot be null");
            }
            this.Description = description;
            // to ensure "donateUrl" is required (not null)
            if (donateUrl == null)
            {
                throw new ArgumentNullException("donateUrl is a required property for FundraisingEvent and cannot be null");
            }
            this.DonateUrl = donateUrl;
            // to ensure "endSupportingAt" is required (not null)
            if (endSupportingAt == null)
            {
                throw new ArgumentNullException("endSupportingAt is a required property for FundraisingEvent and cannot be null");
            }
            this.EndSupportingAt = endSupportingAt;
            this.EndsAt = endsAt;
            // to ensure "goal" is required (not null)
            if (goal == null)
            {
                throw new ArgumentNullException("goal is a required property for FundraisingEvent and cannot be null");
            }
            this.Goal = goal;
            this.Id = id;
            this.InsertedAt = insertedAt;
            this.LegacyId = legacyId;
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for FundraisingEvent and cannot be null");
            }
            this.Name = name;
            this.PublishedAt = publishedAt;
            // to ensure "retiredAt" is required (not null)
            if (retiredAt == null)
            {
                throw new ArgumentNullException("retiredAt is a required property for FundraisingEvent and cannot be null");
            }
            this.RetiredAt = retiredAt;
            // to ensure "slug" is required (not null)
            if (slug == null)
            {
                throw new ArgumentNullException("slug is a required property for FundraisingEvent and cannot be null");
            }
            this.Slug = slug;
            // to ensure "startSupportingAt" is required (not null)
            if (startSupportingAt == null)
            {
                throw new ArgumentNullException("startSupportingAt is a required property for FundraisingEvent and cannot be null");
            }
            this.StartSupportingAt = startSupportingAt;
            // to ensure "startsAt" is required (not null)
            if (startsAt == null)
            {
                throw new ArgumentNullException("startsAt is a required property for FundraisingEvent and cannot be null");
            }
            this.StartsAt = startsAt;
            this.Status = status;
            // to ensure "totalAmountRaised" is required (not null)
            if (totalAmountRaised == null)
            {
                throw new ArgumentNullException("totalAmountRaised is a required property for FundraisingEvent and cannot be null");
            }
            this.TotalAmountRaised = totalAmountRaised;
            this.UpdatedAt = updatedAt;
            // to ensure "url" is required (not null)
            if (url == null)
            {
                throw new ArgumentNullException("url is a required property for FundraisingEvent and cannot be null");
            }
            this.Url = url;
        }

        /// <summary>
        /// Gets or Sets Avatar
        /// </summary>
        [DataMember(Name = "avatar", IsRequired = true, EmitDefaultValue = true)]
        public Image Avatar { get; set; }

        /// <summary>
        /// The datetime the campaign will allow supporting campaigns to be published in ISO 8601 format
        /// </summary>
        /// <value>The datetime the campaign will allow supporting campaigns to be published in ISO 8601 format</value>
        [DataMember(Name = "can_publish_supporting_at", IsRequired = true, EmitDefaultValue = true)]
        public string CanPublishSupportingAt { get; set; }

        /// <summary>
        /// Unique Identifier for the Object. UUID
        /// </summary>
        /// <value>Unique Identifier for the Object. UUID</value>
        /// <example>73ab8824-fe2a-4edf-8ae8-6b7bf6358e1b</example>
        [DataMember(Name = "cause_id", IsRequired = true, EmitDefaultValue = true)]
        public Guid CauseId { get; set; }

        /// <summary>
        /// ISO 4217 alphabetic currency code
        /// </summary>
        /// <value>ISO 4217 alphabetic currency code</value>
        /// <example>USD</example>
        [DataMember(Name = "currency_code", IsRequired = true, EmitDefaultValue = true)]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// A short description about this fundraising event
        /// </summary>
        /// <value>A short description about this fundraising event</value>
        [DataMember(Name = "description", IsRequired = true, EmitDefaultValue = true)]
        public string Description { get; set; }

        /// <summary>
        /// This is the full url used for the given resource.
        /// </summary>
        /// <value>This is the full url used for the given resource.</value>
        /// <example>https://tiltify.com/@username/campaign-slug</example>
        [DataMember(Name = "donate_url", IsRequired = true, EmitDefaultValue = true)]
        public string DonateUrl { get; set; }

        /// <summary>
        /// The datetime the campaign will stop accepting registrations in ISO 8601 format
        /// </summary>
        /// <value>The datetime the campaign will stop accepting registrations in ISO 8601 format</value>
        [DataMember(Name = "end_supporting_at", IsRequired = true, EmitDefaultValue = true)]
        public string EndSupportingAt { get; set; }

        /// <summary>
        /// A date when this fundraising event ends.
        /// </summary>
        /// <value>A date when this fundraising event ends.</value>
        [DataMember(Name = "ends_at", IsRequired = true, EmitDefaultValue = true)]
        [JsonConverter(typeof(OpenAPIDateConverter))]
        [Obsolete]
        public DateTime EndsAt { get; set; }

        /// <summary>
        /// Gets or Sets Goal
        /// </summary>
        [DataMember(Name = "goal", IsRequired = true, EmitDefaultValue = true)]
        public FundraisingEventGoal Goal { get; set; }

        /// <summary>
        /// Unique Identifier for the Object. UUID
        /// </summary>
        /// <value>Unique Identifier for the Object. UUID</value>
        /// <example>73ab8824-fe2a-4edf-8ae8-6b7bf6358e1b</example>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public Guid Id { get; set; }

        /// <summary>
        /// When the fundraising event was created
        /// </summary>
        /// <value>When the fundraising event was created</value>
        [DataMember(Name = "inserted_at", IsRequired = true, EmitDefaultValue = true)]
        public DateTime InsertedAt { get; set; }

        /// <summary>
        /// Legacy numeric ID of the object. If your app is dependent on this field, please migrate to id. This will be deprecated in the next version of the API.
        /// </summary>
        /// <value>Legacy numeric ID of the object. If your app is dependent on this field, please migrate to id. This will be deprecated in the next version of the API.</value>
        /// <example>211995566</example>
        [DataMember(Name = "legacy_id", IsRequired = true, EmitDefaultValue = true)]
        [Obsolete]
        public decimal LegacyId { get; set; }

        /// <summary>
        /// The name of this fundraising event
        /// </summary>
        /// <value>The name of this fundraising event</value>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// When the fundraising event was last published
        /// </summary>
        /// <value>When the fundraising event was last published</value>
        [DataMember(Name = "published_at", IsRequired = true, EmitDefaultValue = true)]
        public DateTime PublishedAt { get; set; }

        /// <summary>
        /// When the fundraising event was retired
        /// </summary>
        /// <value>When the fundraising event was retired</value>
        [DataMember(Name = "retired_at", IsRequired = true, EmitDefaultValue = true)]
        public DateTime? RetiredAt { get; set; }

        /// <summary>
        /// This is a url slug used for the given resource.
        /// </summary>
        /// <value>This is a url slug used for the given resource.</value>
        /// <example>example-slug</example>
        [DataMember(Name = "slug", IsRequired = true, EmitDefaultValue = true)]
        public string Slug { get; set; }

        /// <summary>
        /// The datetime the campaign will start accepting registrations in ISO 8601 format
        /// </summary>
        /// <value>The datetime the campaign will start accepting registrations in ISO 8601 format</value>
        [DataMember(Name = "start_supporting_at", IsRequired = true, EmitDefaultValue = true)]
        public string StartSupportingAt { get; set; }

        /// <summary>
        /// An optional date when this fundraising event starts.
        /// </summary>
        /// <value>An optional date when this fundraising event starts.</value>
        [DataMember(Name = "starts_at", IsRequired = true, EmitDefaultValue = true)]
        [JsonConverter(typeof(OpenAPIDateConverter))]
        [Obsolete]
        public DateTime? StartsAt { get; set; }

        /// <summary>
        /// Gets or Sets TotalAmountRaised
        /// </summary>
        [DataMember(Name = "total_amount_raised", IsRequired = true, EmitDefaultValue = true)]
        public Money TotalAmountRaised { get; set; }

        /// <summary>
        /// When the fundraising event details were last updated
        /// </summary>
        /// <value>When the fundraising event details were last updated</value>
        [DataMember(Name = "updated_at", IsRequired = true, EmitDefaultValue = true)]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// This is the full url used for the given resource.
        /// </summary>
        /// <value>This is the full url used for the given resource.</value>
        /// <example>https://tiltify.com/@username/campaign-slug</example>
        [DataMember(Name = "url", IsRequired = true, EmitDefaultValue = true)]
        public string Url { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class FundraisingEvent {\n");
            sb.Append("  Avatar: ").Append(Avatar).Append("\n");
            sb.Append("  CanPublishSupportingAt: ").Append(CanPublishSupportingAt).Append("\n");
            sb.Append("  CauseId: ").Append(CauseId).Append("\n");
            sb.Append("  CurrencyCode: ").Append(CurrencyCode).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  DonateUrl: ").Append(DonateUrl).Append("\n");
            sb.Append("  EndSupportingAt: ").Append(EndSupportingAt).Append("\n");
            sb.Append("  EndsAt: ").Append(EndsAt).Append("\n");
            sb.Append("  Goal: ").Append(Goal).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  InsertedAt: ").Append(InsertedAt).Append("\n");
            sb.Append("  LegacyId: ").Append(LegacyId).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  PublishedAt: ").Append(PublishedAt).Append("\n");
            sb.Append("  RetiredAt: ").Append(RetiredAt).Append("\n");
            sb.Append("  Slug: ").Append(Slug).Append("\n");
            sb.Append("  StartSupportingAt: ").Append(StartSupportingAt).Append("\n");
            sb.Append("  StartsAt: ").Append(StartsAt).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  TotalAmountRaised: ").Append(TotalAmountRaised).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
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
            if (this.CurrencyCode != null) {
                // CurrencyCode (string) pattern
                Regex regexCurrencyCode = new Regex(@"[A-Z]{3}", RegexOptions.CultureInvariant);
                if (!regexCurrencyCode.Match(this.CurrencyCode).Success)
                {
                    yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for CurrencyCode, must match a pattern of " + regexCurrencyCode, new [] { "CurrencyCode" });
                }
            }

            yield break;
        }
    }

}
