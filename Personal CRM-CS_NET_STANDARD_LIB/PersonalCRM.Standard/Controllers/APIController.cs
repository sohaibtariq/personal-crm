// <copyright file="APIController.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace PersonalCRM.Standard.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Converters;
    using PersonalCRM.Standard;
    using PersonalCRM.Standard.Authentication;
    using PersonalCRM.Standard.Http.Client;
    using PersonalCRM.Standard.Http.Request;
    using PersonalCRM.Standard.Http.Request.Configuration;
    using PersonalCRM.Standard.Http.Response;
    using PersonalCRM.Standard.Utilities;

    /// <summary>
    /// APIController.
    /// </summary>
    public class APIController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="APIController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        internal APIController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers)
            : base(config, httpClient, authManagers)
        {
        }

        /// <summary>
        /// DeleteScheduledMessage EndPoint.
        /// </summary>
        /// <param name="limit">Required parameter: Example: .</param>
        /// <param name="queryType">Required parameter: Example: .</param>
        /// <param name="id">Required parameter: Example: .</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="contentType">Required parameter: Example: .</param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public dynamic DeleteScheduledMessage(
                int limit,
                string queryType,
                int id,
                Models.DeleteScheduledMessageRequest body,
                string accept,
                string contentType)
        {
            Task<dynamic> t = this.DeleteScheduledMessageAsync(limit, queryType, id, body, accept, contentType);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// DeleteScheduledMessage EndPoint.
        /// </summary>
        /// <param name="limit">Required parameter: Example: .</param>
        /// <param name="queryType">Required parameter: Example: .</param>
        /// <param name="id">Required parameter: Example: .</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="contentType">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public async Task<dynamic> DeleteScheduledMessageAsync(
                int limit,
                string queryType,
                int id,
                Models.DeleteScheduledMessageRequest body,
                string accept,
                string contentType,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/personal-crm/ScheduledMessages");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "limit", limit },
                { "query_type", queryType },
                { "Id", id },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", accept },
                { "content-type", contentType },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().DeleteBody(queryBuilder.ToString(), headers, bodyText, queryParameters: queryParams);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<dynamic>(response.Body);
        }
    }
}