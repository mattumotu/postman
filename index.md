Postman                        {#mainpage}
=======

Postman is a light weight, object-oriented .Net SDK for sending emails

Usage
-----

This example shows basic C# use of Postman

```cs
using System.Collections.Generic;
using Postman
using Postman.Interfaces

// Create Stamps
ICollection<IStamp> stamps = new List<IStamp>();
stamps.Add(new Stamp.Recipient("test@test.com; test1@test.com"));
stamps.Add(new Stamp.Subject("This is a test email"));
stamps.Add(new Stamp.Sender("test@test.com", "test account"));

// Create Enclosures
ICollection<IEnclosure> enclosures = new List<IEnclosure>();
enclosures.Add(new Enclosure.Plain("plain text"));

// Create Envelope
IEnvelope exampleEnv = new Envelope(stamps, enclosures);

// Create Postman
IPostman postman = new Postman("my.smtp.host");

// Send Envelope
postman.Send(exampleEnv);
```

This example shows basic VB.net use of Postman
```vbnet
Imports System.Collections.Generic
Imports Postman
Imports Postman.Interfaces

' Create Stamps
Dim stamps As ICollection(Of IStamp) = New List(Of IStamp)()
stamps.Add(New Stamp.Recipient("test@test.com; test1@test.com"))
stamps.Add(New Stamp.Subject("This is a test email"))
stamps.Add(New Stamp.Sender("test@test.com", "test account"))

' Create Enclosures
Dim enclosures As ICollection(Of IEnclosure) = New List(Of IEnclosure)()
enclosures.Add(New Enclosure.Plain("plain text"))

Dim embResList As New List(Of IEmbeddedResource)
embResList.Add(New EmbeddedResource.EmbeddedResource(
                HttpContext.Current.Server.MapPath("~/Images/ExmapleImage.jpg"),
                New Net.Mime.ContentType(Net.Mime.MediaTypeNames.Image.Jpeg),
                "APHALogo"))
encs.Add(New Enclosure.Html("My <b>HTML</b> Text <img src=cid:APHALogo>", embResList))

' Create Envelope
Dim exampleEnv As IEnvelope = New Envelope(stamps, enclosures)

' Create Postman
Dim postman As IPostman = New Postman("my.smtp.host")

' Send Envelope
postman.Send(exampleEnv)
```
</example>