
using System.Text.Json.Serialization;

namespace WhatsappChatbot.Api.Models;

public class ScheduledTaskConfig
{
[JsonPropertyName("Touchpoint")] public int Touchpoint { get; set; } = default!;

[JsonPropertyName("BirthdayMessage")] public int BirthdayMessage { get; set; } = default!;

[JsonPropertyName("ScheduledMessage")] public int ScheduledMessage { get; set; } = default;

}


