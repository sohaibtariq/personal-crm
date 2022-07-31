
# Scheduled Message

A message to send at a particular time

## Structure

`ScheduledMessage`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Message` | `string` | Required | Message to send |
| `Timestamp` | `DateTime` | Required | - |
| `Id` | `int` | Required | - |
| `Number` | `string` | Required | - |

## Example (as JSON)

```json
{
  "Message": "Hello",
  "Timestamp": "12/10/2018 13:45:00",
  "Id": null,
  "Number": null
}
```

