// <copyright file="DeleteScheduledMessageRequest.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace PersonalCRM.Standard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using PersonalCRM.Standard;
    using PersonalCRM.Standard.Utilities;

    /// <summary>
    /// DeleteScheduledMessageRequest.
    /// </summary>
    public class DeleteScheduledMessageRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteScheduledMessageRequest"/> class.
        /// </summary>
        public DeleteScheduledMessageRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteScheduledMessageRequest"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="lastContact">LastContact.</param>
        public DeleteScheduledMessageRequest(
            string name,
            string lastContact)
        {
            this.Name = name;
            this.LastContact = lastContact;
        }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        [JsonProperty("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets LastContact.
        /// </summary>
        [JsonProperty("LastContact")]
        public string LastContact { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"DeleteScheduledMessageRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is DeleteScheduledMessageRequest other &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.LastContact == null && other.LastContact == null) || (this.LastContact?.Equals(other.LastContact) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.LastContact = {(this.LastContact == null ? "null" : this.LastContact == string.Empty ? "" : this.LastContact)}");
        }
    }
}