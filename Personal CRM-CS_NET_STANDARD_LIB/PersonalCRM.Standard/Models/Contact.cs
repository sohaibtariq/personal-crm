// <copyright file="Contact.cs" company="APIMatic">
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
    /// Contact.
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Contact"/> class.
        /// </summary>
        public Contact()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Contact"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="number">Number.</param>
        /// <param name="lastContact">LastContact.</param>
        /// <param name="birthday">Birthday.</param>
        /// <param name="cadence">Cadence.</param>
        /// <param name="id">Id.</param>
        public Contact(
            string name,
            string number,
            DateTime lastContact,
            DateTime birthday,
            int cadence,
            int id)
        {
            this.Name = name;
            this.Number = number;
            this.LastContact = lastContact;
            this.Birthday = birthday;
            this.Cadence = cadence;
            this.Id = id;
        }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        [JsonProperty("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Number.
        /// </summary>
        [JsonProperty("Number")]
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets LastContact.
        /// </summary>
        [JsonConverter(typeof(IsoDateTimeConverter))]
        [JsonProperty("LastContact")]
        public DateTime LastContact { get; set; }

        /// <summary>
        /// Gets or sets Birthday.
        /// </summary>
        [JsonConverter(typeof(IsoDateTimeConverter))]
        [JsonProperty("Birthday")]
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Gets or sets Cadence.
        /// </summary>
        [JsonProperty("Cadence")]
        public int Cadence { get; set; }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        [JsonProperty("Id")]
        public int Id { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Contact : ({string.Join(", ", toStringOutput)})";
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

            return obj is Contact other &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Number == null && other.Number == null) || (this.Number?.Equals(other.Number) == true)) &&
                this.LastContact.Equals(other.LastContact) &&
                this.Birthday.Equals(other.Birthday) &&
                this.Cadence.Equals(other.Cadence) &&
                this.Id.Equals(other.Id);
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.Number = {(this.Number == null ? "null" : this.Number == string.Empty ? "" : this.Number)}");
            toStringOutput.Add($"this.LastContact = {this.LastContact}");
            toStringOutput.Add($"this.Birthday = {this.Birthday}");
            toStringOutput.Add($"this.Cadence = {this.Cadence}");
            toStringOutput.Add($"this.Id = {this.Id}");
        }
    }
}