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
    /// Reward
    /// </summary>
    [DataContract(Name = "Reward")]
    public partial class Reward : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Reward" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Reward() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Reward" /> class.
        /// </summary>
        /// <param name="active">Whether or not the reward is active (required).</param>
        /// <param name="amount">amount (required).</param>
        /// <param name="description">Short description of the reward (required).</param>
        /// <param name="endsAt">Moment when the reward ends (required).</param>
        /// <param name="fairMarketValue">fairMarketValue (required).</param>
        /// <param name="highlighted">If the reward is highlighted ro not (required).</param>
        /// <param name="id">Unique Identifier for the Object. UUID (required).</param>
        /// <param name="image">image (required).</param>
        /// <param name="insertedAt">Moment when the reward was created (required).</param>
        /// <param name="legacyId">Legacy numeric ID of the object. If your app is dependent on this field, please migrate to id. This will be deprecated in the next version of the API. (required).</param>
        /// <param name="name">Reward name (required).</param>
        /// <param name="quantity">total amount of this reward if it has a limited quantity (required).</param>
        /// <param name="quantityRemaining">remaining amount of this reward if it has a limited quantity (required).</param>
        /// <param name="startsAt">Moment when the reward starts (required).</param>
        /// <param name="updatedAt">Moment when the milestone was last updated (required).</param>
        public Reward(bool active = default(bool), Money amount = default(Money), string description = default(string), DateTime? endsAt = default(DateTime?), RewardFairMarketValue fairMarketValue = default(RewardFairMarketValue), bool highlighted = default(bool), Guid id = default(Guid), Image image = default(Image), DateTime insertedAt = default(DateTime), decimal legacyId = default(decimal), string name = default(string), int? quantity = default(int?), int? quantityRemaining = default(int?), DateTime? startsAt = default(DateTime?), DateTime updatedAt = default(DateTime))
        {
            this.Active = active;
            // to ensure "amount" is required (not null)
            if (amount == null)
            {
                throw new ArgumentNullException("amount is a required property for Reward and cannot be null");
            }
            this.Amount = amount;
            // to ensure "description" is required (not null)
            if (description == null)
            {
                throw new ArgumentNullException("description is a required property for Reward and cannot be null");
            }
            this.Description = description;
            // to ensure "endsAt" is required (not null)
            if (endsAt == null)
            {
                throw new ArgumentNullException("endsAt is a required property for Reward and cannot be null");
            }
            this.EndsAt = endsAt;
            // to ensure "fairMarketValue" is required (not null)
            if (fairMarketValue == null)
            {
                throw new ArgumentNullException("fairMarketValue is a required property for Reward and cannot be null");
            }
            this.FairMarketValue = fairMarketValue;
            this.Highlighted = highlighted;
            this.Id = id;
            // to ensure "image" is required (not null)
            if (image == null)
            {
                throw new ArgumentNullException("image is a required property for Reward and cannot be null");
            }
            this.Image = image;
            this.InsertedAt = insertedAt;
            this.LegacyId = legacyId;
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for Reward and cannot be null");
            }
            this.Name = name;
            // to ensure "quantity" is required (not null)
            if (quantity == null)
            {
                throw new ArgumentNullException("quantity is a required property for Reward and cannot be null");
            }
            this.Quantity = quantity;
            // to ensure "quantityRemaining" is required (not null)
            if (quantityRemaining == null)
            {
                throw new ArgumentNullException("quantityRemaining is a required property for Reward and cannot be null");
            }
            this.QuantityRemaining = quantityRemaining;
            // to ensure "startsAt" is required (not null)
            if (startsAt == null)
            {
                throw new ArgumentNullException("startsAt is a required property for Reward and cannot be null");
            }
            this.StartsAt = startsAt;
            this.UpdatedAt = updatedAt;
        }

        /// <summary>
        /// Whether or not the reward is active
        /// </summary>
        /// <value>Whether or not the reward is active</value>
        [DataMember(Name = "active", IsRequired = true, EmitDefaultValue = true)]
        public bool Active { get; set; }

        /// <summary>
        /// Gets or Sets Amount
        /// </summary>
        [DataMember(Name = "amount", IsRequired = true, EmitDefaultValue = true)]
        public Money Amount { get; set; }

        /// <summary>
        /// Short description of the reward
        /// </summary>
        /// <value>Short description of the reward</value>
        [DataMember(Name = "description", IsRequired = true, EmitDefaultValue = true)]
        public string Description { get; set; }

        /// <summary>
        /// Moment when the reward ends
        /// </summary>
        /// <value>Moment when the reward ends</value>
        [DataMember(Name = "ends_at", IsRequired = true, EmitDefaultValue = true)]
        public DateTime? EndsAt { get; set; }

        /// <summary>
        /// Gets or Sets FairMarketValue
        /// </summary>
        [DataMember(Name = "fair_market_value", IsRequired = true, EmitDefaultValue = true)]
        public RewardFairMarketValue FairMarketValue { get; set; }

        /// <summary>
        /// If the reward is highlighted ro not
        /// </summary>
        /// <value>If the reward is highlighted ro not</value>
        [DataMember(Name = "highlighted", IsRequired = true, EmitDefaultValue = true)]
        public bool Highlighted { get; set; }

        /// <summary>
        /// Unique Identifier for the Object. UUID
        /// </summary>
        /// <value>Unique Identifier for the Object. UUID</value>
        /// <example>73ab8824-fe2a-4edf-8ae8-6b7bf6358e1b</example>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or Sets Image
        /// </summary>
        [DataMember(Name = "image", IsRequired = true, EmitDefaultValue = true)]
        public Image Image { get; set; }

        /// <summary>
        /// Moment when the reward was created
        /// </summary>
        /// <value>Moment when the reward was created</value>
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
        /// Reward name
        /// </summary>
        /// <value>Reward name</value>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// total amount of this reward if it has a limited quantity
        /// </summary>
        /// <value>total amount of this reward if it has a limited quantity</value>
        [DataMember(Name = "quantity", IsRequired = true, EmitDefaultValue = true)]
        public int? Quantity { get; set; }

        /// <summary>
        /// remaining amount of this reward if it has a limited quantity
        /// </summary>
        /// <value>remaining amount of this reward if it has a limited quantity</value>
        [DataMember(Name = "quantity_remaining", IsRequired = true, EmitDefaultValue = true)]
        public int? QuantityRemaining { get; set; }

        /// <summary>
        /// Moment when the reward starts
        /// </summary>
        /// <value>Moment when the reward starts</value>
        [DataMember(Name = "starts_at", IsRequired = true, EmitDefaultValue = true)]
        public DateTime? StartsAt { get; set; }

        /// <summary>
        /// Moment when the milestone was last updated
        /// </summary>
        /// <value>Moment when the milestone was last updated</value>
        [DataMember(Name = "updated_at", IsRequired = true, EmitDefaultValue = true)]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Reward {\n");
            sb.Append("  Active: ").Append(Active).Append("\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  EndsAt: ").Append(EndsAt).Append("\n");
            sb.Append("  FairMarketValue: ").Append(FairMarketValue).Append("\n");
            sb.Append("  Highlighted: ").Append(Highlighted).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Image: ").Append(Image).Append("\n");
            sb.Append("  InsertedAt: ").Append(InsertedAt).Append("\n");
            sb.Append("  LegacyId: ").Append(LegacyId).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Quantity: ").Append(Quantity).Append("\n");
            sb.Append("  QuantityRemaining: ").Append(QuantityRemaining).Append("\n");
            sb.Append("  StartsAt: ").Append(StartsAt).Append("\n");
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
