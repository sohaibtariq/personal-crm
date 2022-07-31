// <copyright file="ScheduledMessage.cs" company="APIMatic">
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
    /// ScheduledMessage.
    /// </summary>
    public class ScheduledMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduledMessage"/> class.
        /// </summary>
        public ScheduledMessage()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduledMessage"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="timestamp">Timestamp.</param>
        /// <param name="id">Id.</param>
        /// <param name="number">Number.</param>
        public ScheduledMessage(
            string message,
            DateTime timestamp,
            int id,
            string number)
        {
            this.Message = message;
            this.Timestamp = timestamp;
            this.Id = id;
            this.Number = number;
        }

        /// <summary>
        /// Message to send
        /// </summary>
        [JsonProperty("Message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets Timestamp.
        /// </summary>
        [JsonConverter(typeof(IsoDateTimeConverter))]
        [JsonProperty("Timestamp")]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        [JsonProperty("Id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Number.
        /// </summary>
        [JsonProperty("Number")]
        public string Number { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ScheduledMessage : ({string.Join(", ", toStringOutput)})";
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

            return obj is ScheduledMessage other &&
                ((this.Message == null && other.Message == null) || (this.Message?.Equals(other.Message) == true)) &&
                this.Timestamp.Equals(other.Timestamp) &&
                this.Id.Equals(other.Id) &&
                ((this.Number == null && other.Number == null) || (this.Number?.Equals(other.Number) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Message = {(this.Message == null ? "null" : this.Message == string.Empty ? "" : this.Message)}");
            toStringOutput.Add($"this.Timestamp = {this.Timestamp}");
            toStringOutput.Add($"this.Id = {this.Id}");
            toStringOutput.Add($"this.Number = {(this.Number == null ? "null" : this.Number == string.Empty ? "" : this.Number)}");
        }
    }
}