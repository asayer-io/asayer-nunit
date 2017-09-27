[<img src="https://dashboard.asayer.io/assets/logo-507f1d735124eb7b629733a52415bd374776bf107c05352184bbb39d8e3f26f5.png" width="235"/>](https://asayer.io)
[<img src="https://s3.eu-central-1.amazonaws.com/asayer-samples-assets/nunit/nunit_logo.png" width="162" />](http://nunit.org/)

# Asayer - NUnit (C#)
[NUnit (C#)](http://nunit.org/) integration with [Asayer](https://asayer.io).

### Table of Contents:
* [Prerequisites](#prerequisites)
* [Set it up](#set-it-up)
* [Run it](#run-it)
* [Dashboard](#dashboard)
   - [Test List](#test-list)
   - [Test Overview](#test-overview)
   - [Session Recording](#session-recording)
   - [Timeline](#timeline)
   - [Screenshots](#screenshots)
   - [Server Logs](#server-logs)
   - [Console Logs](#console-logs)
   - [Assets](#assets)
   - [Tunnels](#tunnels)
* [Application Parameters](#application-parameters)
* [Capabilities](#capabilities)
   - [Supported Mobile Devices](#supported-mobile-devices)
   - [Fun with Flags](#fun-with-flags)
* [Integrating Asayer with your existing project](#integrating-asayer-with-your-existing-project)
   - [Example](#example)
* [Local Testing](#local-testing)
   - [Starting the Tunnel](#starting-the-tunnel)
   - [Setting up the tests for Local Testing](#setting-up-the-tests-for-local-testing)
   - [Limitations](#limitations)
* [Mark a completed Test](#mark-a-completed-test)
* [Dependencies](#dependencies)
* [Important Notes](#important-notes)

## Prerequisites
* Microsoft Visual Studio 2012 or higher (you can download the [Community Edition](https://www.visualstudio.com/en-us/downloads/download-visual-studio-vs.aspx) for free)
    
## Set it up
* Clone the repo `git clone https://github.com/asayer-io/asayer-nunit` or [download it](https://github.com/asayer-io/asayer-nunit/archive/master.zip)
* Open the solution `asayer-nunit/asayer-nunit.sln` in *Visual Studio*
* Build it (*Build > Build Solution*, which will automatically install the required NuGet packages)
* Update the `App.config` file with your Asayer [API key](https://dashboard.asayer.io/settings?f=3)


## Run it
To run the test, proceed as follows:
* Build the project (*Build > Build Solution*)
* Open the Test Explorer window (*Test > Windows > Test Explorer*)
* Right click on the `ProductFeatures` test and choose *Run Selected Tests*
* Go to https://dashboard.asayer.io/automate/sessions and see what happened.

<p align="center">
<img src="https://s3.eu-central-1.amazonaws.com/asayer-samples-assets/specflow/run+first+test.png"/>
</p>

## Dashboard
Details about the test session can be found in the [Dashboard](https://dashboard.asayer.io/automate/sessions) under *Automate > Sessions*.

### Test List
This is where all your executed tests are listed. You can use the filter to navigate through *Passed* or *Failed* tests (see [Mark A Completed Test](#mark-a-completed-test) to learn how to mark a test).

<p align="center">
<img src="https://s3.eu-central-1.amazonaws.com/asayer-samples-assets/nunit/tests-list2.PNG"/>
</p>

### Test Overview
Encloses various details like *State*, *Duration*, *Execution Time*, *Platform*/*Browser* as well as the *User* who initiated the test.

<p align="center">
<img src="https://s3.eu-central-1.amazonaws.com/asayer-samples-assets/nunit/test+overview2.PNG"/>
</p>

### Session Recording
Each session gets fully recorded. The video can be played or downloaded (as part of the [Assets](#assets)).

<p align="center">
<img src="https://s3.eu-central-1.amazonaws.com/asayer-samples-assets/specflow/video.PNG"/>
</p>

### Timeline
All commands gets displayed in the form of a comprehensive timeline, including details such as *Execution Time*, *Duration* and [*Screenshot*](#screenshots).

<p align="center">
<img src="https://s3.eu-central-1.amazonaws.com/asayer-samples-assets/specflow/timeline2.PNG"/>
</p>

### Screenshots
A screenshot is taken automatically upon the execution of each and every command. Simply hover over the cam icon to see it.

<p align="center">
<img src="https://s3.eu-central-1.amazonaws.com/asayer-samples-assets/specflow/screenshot3.png"/>
</p>

### Server Logs
Various actions (i.e. HTTP) taking place throughout the session, are logged.

<p align="center">
<img src="https://s3.eu-central-1.amazonaws.com/asayer-samples-assets/specflow/log-request-response.PNG"/>
</p>

### Console Logs
Chrome and Opera console logs are captured and displayed back.

<p align="center">
<img src="https://s3.eu-central-1.amazonaws.com/asayer-samples-assets/specflow/console+log.PNG"/>
</p>

### Assets
Clicking on the *Download Assets* button will download a zip file enclosing:
* All screenshots
* Session recording (.webm)
* Server logs
* Browser console logs (only Chrome and Opera)

<p align="center">
<kbd>
<img src="https://s3.eu-central-1.amazonaws.com/asayer-samples-assets/nunit/download+assets+2.png"/>
</kbd>
</p>

### Tunnels
The list of your active tunnels is available in *Settings > Tunnels*. For more information, see [Local Testing](#local-testing).

<p align="center">
<img src="https://s3.eu-central-1.amazonaws.com/asayer-samples-assets/specflow/tunnels+list+3.PNG"/>
</p>

## Application Parameters
You can change the app settings from the [`App.config`](https://github.com/asayer-io/asayer-nunit/blob/master/asayer-nunit/App.config) file under `<appSettings>`.
```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  ...
  <appSettings>    
    <add key="apikey" value="YOUR ASAYER API KEY" />
    <add key="server" value="https://hub.asayer.io/wd/hub" />
    <add key="name" value="Testing NUnit with Asayer" />
    ...
  </appSettings>
  ...
</configuration>
```

Belows are the supported settings:

| Name        | Value           | Description  | Required  |
| :-------------: |:-------------| :-----|:-----:|
| `apikey`|  | Your Asayer [API key](https://dashboard.asayer.io/settings?f=3) | yes |
| `server`|`https://hub.asayer.io/wd/hub` |   Asayer's Selenium hub | yes |
| `name` | |    The name of the test to execute (will be visible in the [Dashboard](#test-overview)) | yes |
| `build` | |The build's ID (if any) | no |
| `tunnelId` | | The tunnel's ID for local tests | yes for ([local testing](#local-testing)) | 

## Capabilities
You can change the caps from the [`App.config`](https://github.com/asayer-io/asayer-nunit/blob/master/asayer-nunit/App.config) file under `<capabilities><settings>`.

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  ...
  <capabilities>
    <settings>
        <add key="platform" value="linux" />
        <add key="browserName" value="chrome" />
        ...
    <settings>
  </capabilities>
  ...
</configuration>
```

Below is the list of supported capabilities:

| Name        | Possible Values           | Default Value  |Description  | Required  |
| :-------------: |:-------------| :-----:|:-------------|:-----:|
| `platform`| `linux` `windows` `mac` `android` `ios` `any`| linux | The platform used for the test | yes |
| `browserName`|`chrome` `firefox` `ie` `safari` `opera` `edge`| chrome | The browser used for the test | yes |
| `flags`|| - |A list of flags to be passed to the browser, see [Fun with Flags](#fun-with-flags) | no |
| `deviceName`| see the list of [supported mobile devices](#supported-mobile-devices) | - |The android device name to use for the test | yes if `platform` is set to `android` or `ios` |

The supported browser versions are:

| Name        | Version           |
| :-------------: |:-------------:| 
| edge | 14 |
| opera | 47 |
| firefox | 55 |
| chrome | 61 |
| ie | 11 |
| safari | 10 |

### Supported Mobile Devices

The list of available mobile simulators/emulators is as below:

| platform | deviceName|
| :-------------: |:-------------| 
| `android` | `Galaxy_S8`, `LG_G6`, `Pixel`, `Pixel_XL`, `Pixel_C`, `Nexus_5X`, `Nexus_6P` `Nexus_9` |
| `ios` | `iPhone 5`, `iPhone 5s`, `iPhone 6`, `iPhone 6 Plus`, `iPhone 6s`, `iPhone 6s Plus`, `iPhone 7`, `iPhone 7 Plus`, `iPhone SE`, `iPad Air`, `iPad Air 2`, `iPad Pro` |

Note: Only `Android 7.1.1` and `iOS 10.3` are supported.


### Fun with Flags

In addition to the above mentioned capabilities, you can attach a list of `<flags>` (to run the browser with) by simply adding `<add key="[FLAG NAME]" value="[value|]" />` to the [`App.config`](https://github.com/asayer-io/asayer-specflow/blob/master/asayer-specflow/App.config) file under `<capabilities><flags>`.

In the following example, we used some of the Chrome flags:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  ...
    <capabilities>
        ...
        <flags>
            <add key="--incognito" value="true" />
            <add key="--start-fullscreen" value="true"/>
            ...
        </flags>
    </capabilities>
    	...
</configuration>    
```

These flags will be interpreted as `--incognito --start-fullscreen` (note that `value=""` and `value="true"` are similar).

* Kepp in mind that each browser has its **own and unique** list of flags:
    * [FireFox](https://developer.mozilla.org/fr/docs/Mozilla/Command_Line_Options)
    * [Chrome](https://peter.sh/experiments/chromium-command-line-switches/)
    * [IE](https://msdn.microsoft.com/en-us/library/hh826025(v=vs.85).aspx)
    * Safari (no flags)
    * [Opera](http://www.opera.com/docs/switches/)
    
## Integrating Asayer with your existing project
Follow the below steps to integrate Asayer with your existing project:
* Copy the classe [`AsayerWebDriver.cs`](https://github.com/asayer-io/asayer-nunit/blob/master/asayer-nunit/AsayerWebDriver.cs) to your project
* Have the required [NuGet dependencies](#dependencies) installed
* Copy or merge the [`App.config`](https://github.com/asayer-io/asayer-nunit/blob/master/asayer-nunit/App.config) file to/with your project
* In the test definition class (see [example](#example) below), extend the `AsayerNUnitTest` class, this will provide you with a `driver` attribute
	
### Example
Excerpt from [MyTest.cs](https://github.com/asayer-io/asayer-nunit/blob/master/asayer-nunit/MyTest.cs):
```cs
using ...
namespace asayer_nunit
{
    class MyTest : AsayerWebDriver
    {
        [Test]
        public void CheckProductPage()
        {
            driver.Navigate().GoToUrl("http://www.asayer.io");
            ...
        }
    }
}
```
Note how `WebDriver` was replaced with the `IWebDriver` created by the `AsayerNUnitTest` superclass.

## Local Testing
Local testing allows you to test your internal servers, in addition to public URLs, using Asayer's infrastucture without having to update your firewalls or proxies.

### Starting the Tunnel
1. Download `asayer-tunnel` for *Windows* ([32bits](https://s3.eu-central-1.amazonaws.com/asayer-tunnel/asayer-tunnel_win32.exe)\|[64bits](https://s3.eu-central-1.amazonaws.com/asayer-tunnel/asayer-tunnel_win64.exe)), *Linux* ([32bits](https://s3.eu-central-1.amazonaws.com/asayer-tunnel/asayer-tunnel_linux32)\|[64bits](https://s3.eu-central-1.amazonaws.com/asayer-tunnel/asayer-tunnel_linux64)) or *Mac* ([32bits](https://s3.eu-central-1.amazonaws.com/asayer-tunnel/asayer-tunnel_mac32)\|[64bits](https://s3.eu-central-1.amazonaws.com/asayer-tunnel/asayer-tunnel_mac64))
2. Open a terminal and `cd` to the binary folder 
3. Execute the binary by running `asayer-tunnel_win64.exe -k API_KEY -i TUNNEL_NAME` 

The complete manual for the tunnel is the following:

```
$ asayer-tunnel_win64.exe -h
Usage:
  main [OPTIONS]

Application Options:
  -k, --key=            The user API_KEY
  -i, --id=             The id of the tunnel
  -p, --port=           The local proxy port (default: 9090)
  -w, --whitelist=      List of URLs to exclude from proxy, separated by ';' (eg: url1; url2)
      --proxy-url=      If you are behind a proxy set its URL here, the format is HOST:PORT.
                        If needed, auth info can be set in --proxy-user and --proxy-password
      --proxy-user=     Basic auth HTTP Proxy username
      --proxy-password= Basic auth HTTP Proxy password
  -v, --verbose         Show debug information

Help Options:
  -h, --help            Show this help message
```

Note that only `-k` and `-i` parameters are required.

### Setting up the tests for Local Testing
To set up your tests for local testing, you must add the `tunnelId` capability to the [`App.config`](https://github.com/asayer-io/asayer-nunit/blob/master/asayer-nunit/App.config) file under `<appSettings>` section 

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  ...
  <appSettings>    
    ...
    <add key="tunnelID" value="[TUNNEL_ID]" />
  </appSettings>
  ...
</configuration>
```
Once done, build then run your tests as [usual](#run-it). HTTP traffic will then be redirected to the machine on which the `asayer-tunnel` binary is running through a secure connection.

Details about the local tests can be found in the [Dashboard](#dashboard). Local tests are marked with a *plug* icon.

<p align="center">
<img src="https://s3.eu-central-1.amazonaws.com/asayer-samples-assets/nunit/local1.PNG"/>
</p>

### Limitations
* Local Testing is available on `chrome`, `firefox` and `opera` browsers only
* Only 3 active tunnels are allowed per organization

## Mark a completed Test
Once the session is completed, you can mark the test (either passed or failed) by calling the `markTest(["Passed"|"Failed"])` method of the `AsayerNUnitTest` superclass. 

You can also rely on our REST API to do so by submitting `sessionID` and `sessionStatus` parameters:

```
Endpoint: https://dashboard.asayer.io/sessions/mark_test
Method: POST
Json: {
        sessionID:this.sessionId, // Required
        sessionStatus:"Passed"|"Failed", // Required
        apiKey:"YOUR ASAYER API KEY (this.apikey)", // Required
        reqID: "REQUIREMENT ID", // Optional
	testStatus: { // Optional
    		"TEST ID 1": "Passed"|"Failed",
    		"TEST ID 2": "Passed"|"Failed",
    		...
    	}
    }
```

The state will be visible in the Dashboard as below.

<p align="center">
<img src="https://s3.eu-central-1.amazonaws.com/asayer-samples-assets/nunit/test+state+2.PNG"/>
</p>

## Dependencies
This project relies on the below dependencies:
- Selenium.WebDriver
- NUnit
- NUnit3TestAdapter
- Blun.ConfigurationManager

To install the latest version of these dependencies, go to *Tools > NuGet Package Manager > Manage NuGet Packages For Solution...* then search/install each one of them.

**Or** add the missing line to your `packages.config` file:
```xml
  <package id="Blun.ConfigurationManager" version="1.0.5686.2674" targetFramework="net45" />
  <package id="NUnit" version="3.7.1" targetFramework="net45" />
  <package id="NUnit3TestAdapter" version="3.8.0" targetFramework="net45" />
  <package id="Selenium.WebDriver" version="3.5.0" targetFramework="net45" />
```

## Important Notes
- Do not remove the `[TearDown]` from the `AsayerNUnitTest` class as it closes your session at the end of every test (otherwise it will timeout)
