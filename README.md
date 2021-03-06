# Postman

![Postman Logo](https://raw.githubusercontent.com/mattumotu/postman/master/postman.png "Postman Logo")

Postman is a C#.Net implementation of the wonderful [jcabi-email](https://github.com/jcabi/jcabi-email) created by [Yegor Bugayenko](https://github.com/yegor256)
More details are here: [email.jcabi.com](http://email.jcabi.com/).

[![AppVeyor](https://img.shields.io/appveyor/ci/mattumotu/postman.svg?maxAge=3600)](https://ci.appveyor.com/project/mattumotu/postman)
[![Coverage Status](https://img.shields.io/coveralls/mattumotu/postman/master.svg?maxAge=3600)](https://coveralls.io/github/mattumotu/postman?branch=master)
[![Quality Gate](https://sonarcloud.io/api/project_badges/measure?project=postman&metric=alert_status)](https://sonarcloud.io/dashboard?id=postman)
[![NuGet](https://img.shields.io/nuget/v/postman.svg)](https://www.nuget.org/packages/Postman/)

Installation
---
Via NuGet

    PM> Install-Package Postman
    
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
