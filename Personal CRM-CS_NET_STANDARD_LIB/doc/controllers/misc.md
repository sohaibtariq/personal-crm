# Misc

```csharp
MiscController miscController = client.MiscController;
```

## Class Name

`MiscController`

## Methods

* [Get Contacts](../../doc/controllers/misc.md#get-contacts)
* [Add Contact](../../doc/controllers/misc.md#add-contact)
* [Patch Contact](../../doc/controllers/misc.md#patch-contact)
* [Delete Contact](../../doc/controllers/misc.md#delete-contact)
* [Update Contact](../../doc/controllers/misc.md#update-contact)
* [Get Scheduled Messages](../../doc/controllers/misc.md#get-scheduled-messages)
* [Delete Scheduled Message](../../doc/controllers/misc.md#delete-scheduled-message)


# Get Contacts

```csharp
GetContactsAsync()
```

## Response Type

[`Task<List<Models.Contact>>`](../../doc/models/contact.md)

## Example Usage

```csharp
try
{
    List<Contact> result = await miscController.GetContactsAsync();
}
catch (ApiException e){};
```


# Add Contact

```csharp
AddContactAsync(
    Models.Contact contact)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `contact` | [`Models.Contact`](../../doc/models/contact.md) | Body, Required | - |

## Response Type

`Task`

## Example Usage

```csharp
var contact = new Contact();
contact.Name = "Name8";
contact.Number = "Number8";
contact.LastContact = DateTime.Parse("2016-03-13T12:52:32.123Z");
contact.Birthday = DateTime.Parse("2016-03-13T12:52:32.123Z");
contact.Cadence = 2;
contact.Id = 28;

try
{
    await miscController.AddContactAsync(contact);
}
catch (ApiException e){};
```


# Patch Contact

```csharp
PatchContactAsync(
    int limit,
    string queryType,
    Models.Contact contact,
    string name = null,
    int? number = null,
    int? id = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `limit` | `int` | Query, Required | - |
| `queryType` | `string` | Query, Required | - |
| `contact` | [`Models.Contact`](../../doc/models/contact.md) | Body, Required | - |
| `name` | `string` | Query, Optional | - |
| `number` | `int?` | Query, Optional | - |
| `id` | `int?` | Query, Optional | - |

## Response Type

[`Task<List<Models.Contact>>`](../../doc/models/contact.md)

## Example Usage

```csharp
int limit = 10;
string queryType = "and";
var contact = new Contact();
contact.Name = "Name8";
contact.Number = "Number8";
contact.LastContact = DateTime.Parse("2016-03-13T12:52:32.123Z");
contact.Birthday = DateTime.Parse("2016-03-13T12:52:32.123Z");
contact.Cadence = 2;
contact.Id = 28;
string name = "sohaib";
int? number = 1000050;
int? id = 10;

try
{
    List<Contact> result = await miscController.PatchContactAsync(limit, queryType, contact, name, number, id);
}
catch (ApiException e){};
```


# Delete Contact

```csharp
DeleteContactAsync(
    int limit,
    string queryType,
    string name,
    int number)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `limit` | `int` | Query, Required | - |
| `queryType` | `string` | Query, Required | - |
| `name` | `string` | Query, Required | - |
| `number` | `int` | Query, Required | - |

## Response Type

`Task`

## Example Usage

```csharp
int limit = 10;
string queryType = "and";
string name = "example value";
int number = 1000050;

try
{
    await miscController.DeleteContactAsync(limit, queryType, name, number);
}
catch (ApiException e){};
```


# Update Contact

```csharp
UpdateContactAsync(
    int limit,
    string queryType,
    Models.Contact contact,
    string name = null,
    int? number = null,
    int? id = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `limit` | `int` | Query, Required | - |
| `queryType` | `string` | Query, Required | - |
| `contact` | [`Models.Contact`](../../doc/models/contact.md) | Body, Required | - |
| `name` | `string` | Query, Optional | - |
| `number` | `int?` | Query, Optional | - |
| `id` | `int?` | Query, Optional | - |

## Response Type

[`Task<List<Models.Contact>>`](../../doc/models/contact.md)

## Example Usage

```csharp
int limit = 10;
string queryType = "and";
var contact = new Contact();
contact.Name = "Name8";
contact.Number = "Number8";
contact.LastContact = DateTime.Parse("2016-03-13T12:52:32.123Z");
contact.Birthday = DateTime.Parse("2016-03-13T12:52:32.123Z");
contact.Cadence = 2;
contact.Id = 28;
string name = "sohaib";
int? number = 1000030;
int? id = 10;

try
{
    List<Contact> result = await miscController.UpdateContactAsync(limit, queryType, contact, name, number, id);
}
catch (ApiException e){};
```


# Get Scheduled Messages

```csharp
GetScheduledMessagesAsync()
```

## Response Type

[`Task<List<Models.ScheduledMessage>>`](../../doc/models/scheduled-message.md)

## Example Usage

```csharp
try
{
    List<ScheduledMessage> result = await miscController.GetScheduledMessagesAsync();
}
catch (ApiException e){};
```


# Delete Scheduled Message

```csharp
DeleteScheduledMessageAsync(
    int limit,
    string queryType,
    int id)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `limit` | `int` | Query, Required | - |
| `queryType` | `string` | Query, Required | - |
| `id` | `int` | Query, Required | - |

## Response Type

`Task`

## Example Usage

```csharp
int limit = 172;
string queryType = "query_type2";
int id = 146;

try
{
    await miscController.DeleteScheduledMessageAsync(limit, queryType, id);
}
catch (ApiException e){};
```

