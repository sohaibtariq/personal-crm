# API

```csharp
APIController aPIController = client.APIController;
```

## Class Name

`APIController`


# Delete Scheduled Message

```csharp
DeleteScheduledMessageAsync(
    int limit,
    string queryType,
    int id,
    Models.DeleteScheduledMessageRequest body,
    string accept,
    string contentType)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `limit` | `int` | Query, Required | - |
| `queryType` | `string` | Query, Required | - |
| `id` | `int` | Query, Required | - |
| `body` | [`Models.DeleteScheduledMessageRequest`](../../doc/models/delete-scheduled-message-request.md) | Body, Required | - |
| `accept` | `string` | Header, Required | - |
| `contentType` | `string` | Header, Required | - |

## Response Type

`Task<dynamic>`

## Example Usage

```csharp
int limit = 172;
string queryType = "query_type2";
int id = 146;
var body = new DeleteScheduledMessageRequest();
body.Name = "example value";
body.LastContact = "12/10/2019 13:45:00";
string accept = "accept4";
string contentType = "content-type8";

try
{
    dynamic result = await aPIController.DeleteScheduledMessageAsync(limit, queryType, id, body, accept, contentType);
}
catch (ApiException e){};
```

