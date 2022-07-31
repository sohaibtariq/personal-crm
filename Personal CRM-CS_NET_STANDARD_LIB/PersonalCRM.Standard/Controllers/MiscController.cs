// <copyright file="MiscController.cs" company="APIMatic">
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
    /// MiscController.
    /// </summary>
    public class MiscController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MiscController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        internal MiscController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers)
            : base(config, httpClient, authManagers)
        {
        }

        /// <summary>
        /// GetContacts EndPoint.
        /// </summary>
        /// <returns>Returns the List of Models.Contact response from the API call.</returns>
        public List<Models.Contact> GetContacts()
        {
            Task<List<Models.Contact>> t = this.GetContactsAsync();
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// GetContacts EndPoint.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the List of Models.Contact response from the API call.</returns>
        public async Task<List<Models.Contact>> GetContactsAsync(CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/personal-crm");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", this.Config.Accept },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<List<Models.Contact>>(response.Body);
        }

        /// <summary>
        /// AddContact EndPoint.
        /// </summary>
        /// <param name="contact">Required parameter: Example: .</param>
        public void AddContact(
                Models.Contact contact)
        {
            Task t = this.AddContactAsync(contact);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// AddContact EndPoint.
        /// </summary>
        /// <param name="contact">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task AddContactAsync(
                Models.Contact contact,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/personal-crm/Contacts");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "content-type", "application/json; charset=utf-8" },
                { "accept", this.Config.Accept },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(contact);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);
        }

        /// <summary>
        /// PatchContact EndPoint.
        /// </summary>
        /// <param name="limit">Required parameter: Example: .</param>
        /// <param name="queryType">Required parameter: Example: .</param>
        /// <param name="contact">Required parameter: Example: .</param>
        /// <param name="name">Optional parameter: Example: .</param>
        /// <param name="number">Optional parameter: Example: .</param>
        /// <param name="id">Optional parameter: Example: .</param>
        /// <returns>Returns the List of Models.Contact response from the API call.</returns>
        public List<Models.Contact> PatchContact(
                int limit,
                string queryType,
                Models.Contact contact,
                string name = null,
                int? number = null,
                int? id = null)
        {
            Task<List<Models.Contact>> t = this.PatchContactAsync(limit, queryType, contact, name, number, id);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// PatchContact EndPoint.
        /// </summary>
        /// <param name="limit">Required parameter: Example: .</param>
        /// <param name="queryType">Required parameter: Example: .</param>
        /// <param name="contact">Required parameter: Example: .</param>
        /// <param name="name">Optional parameter: Example: .</param>
        /// <param name="number">Optional parameter: Example: .</param>
        /// <param name="id">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the List of Models.Contact response from the API call.</returns>
        public async Task<List<Models.Contact>> PatchContactAsync(
                int limit,
                string queryType,
                Models.Contact contact,
                string name = null,
                int? number = null,
                int? id = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/personal-crm/Contacts");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "limit", limit },
                { "query_type", queryType },
                { "Name", name },
                { "Number", number },
                { "Id", id },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "content-type", "application/json; charset=utf-8" },
                { "accept", this.Config.Accept },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(contact);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PatchBody(queryBuilder.ToString(), headers, bodyText, queryParameters: queryParams);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<List<Models.Contact>>(response.Body);
        }

        /// <summary>
        /// DeleteContact EndPoint.
        /// </summary>
        /// <param name="limit">Required parameter: Example: .</param>
        /// <param name="queryType">Required parameter: Example: .</param>
        /// <param name="name">Required parameter: Example: .</param>
        /// <param name="number">Required parameter: Example: .</param>
        public void DeleteContact(
                int limit,
                string queryType,
                string name,
                int number)
        {
            Task t = this.DeleteContactAsync(limit, queryType, name, number);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// DeleteContact EndPoint.
        /// </summary>
        /// <param name="limit">Required parameter: Example: .</param>
        /// <param name="queryType">Required parameter: Example: .</param>
        /// <param name="name">Required parameter: Example: .</param>
        /// <param name="number">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task DeleteContactAsync(
                int limit,
                string queryType,
                string name,
                int number,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/personal-crm/Contacts");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "limit", limit },
                { "query_type", queryType },
                { "Name", name },
                { "Number", number },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", this.Config.Accept },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Delete(queryBuilder.ToString(), headers, null, queryParameters: queryParams);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);
        }

        /// <summary>
        /// UpdateContact EndPoint.
        /// </summary>
        /// <param name="limit">Required parameter: Example: .</param>
        /// <param name="queryType">Required parameter: Example: .</param>
        /// <param name="contact">Required parameter: Example: .</param>
        /// <param name="name">Optional parameter: Example: .</param>
        /// <param name="number">Optional parameter: Example: .</param>
        /// <param name="id">Optional parameter: Example: .</param>
        /// <returns>Returns the List of Models.Contact response from the API call.</returns>
        public List<Models.Contact> UpdateContact(
                int limit,
                string queryType,
                Models.Contact contact,
                string name = null,
                int? number = null,
                int? id = null)
        {
            Task<List<Models.Contact>> t = this.UpdateContactAsync(limit, queryType, contact, name, number, id);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// UpdateContact EndPoint.
        /// </summary>
        /// <param name="limit">Required parameter: Example: .</param>
        /// <param name="queryType">Required parameter: Example: .</param>
        /// <param name="contact">Required parameter: Example: .</param>
        /// <param name="name">Optional parameter: Example: .</param>
        /// <param name="number">Optional parameter: Example: .</param>
        /// <param name="id">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the List of Models.Contact response from the API call.</returns>
        public async Task<List<Models.Contact>> UpdateContactAsync(
                int limit,
                string queryType,
                Models.Contact contact,
                string name = null,
                int? number = null,
                int? id = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/personal-crm/Contacts");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "limit", limit },
                { "query_type", queryType },
                { "Name", name },
                { "Number", number },
                { "Id", id },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "content-type", "application/json; charset=utf-8" },
                { "accept", this.Config.Accept },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(contact);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PutBody(queryBuilder.ToString(), headers, bodyText, queryParameters: queryParams);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<List<Models.Contact>>(response.Body);
        }

        /// <summary>
        /// GetScheduledMessages EndPoint.
        /// </summary>
        /// <returns>Returns the List of Models.ScheduledMessage response from the API call.</returns>
        public List<Models.ScheduledMessage> GetScheduledMessages()
        {
            Task<List<Models.ScheduledMessage>> t = this.GetScheduledMessagesAsync();
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// GetScheduledMessages EndPoint.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the List of Models.ScheduledMessage response from the API call.</returns>
        public async Task<List<Models.ScheduledMessage>> GetScheduledMessagesAsync(CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/personal-crm/ScheduledMessages");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", this.Config.Accept },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<List<Models.ScheduledMessage>>(response.Body);
        }

        /// <summary>
        /// DeleteScheduledMessage EndPoint.
        /// </summary>
        /// <param name="limit">Required parameter: Example: .</param>
        /// <param name="queryType">Required parameter: Example: .</param>
        /// <param name="id">Required parameter: Example: .</param>
        public void DeleteScheduledMessage(
                int limit,
                string queryType,
                int id)
        {
            Task t = this.DeleteScheduledMessageAsync(limit, queryType, id);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// DeleteScheduledMessage EndPoint.
        /// </summary>
        /// <param name="limit">Required parameter: Example: .</param>
        /// <param name="queryType">Required parameter: Example: .</param>
        /// <param name="id">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task DeleteScheduledMessageAsync(
                int limit,
                string queryType,
                int id,
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
                { "accept", this.Config.Accept },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Delete(queryBuilder.ToString(), headers, null, queryParameters: queryParams);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);
        }
    }
}