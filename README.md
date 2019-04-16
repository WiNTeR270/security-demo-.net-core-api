# React/Redux Malicious IP Search

[![Build Status](https://travis-ci.com/WiNTeR270/security-demo-.net-core-api.svg?branch=master)](https://travis-ci.com/WiNTeR270/security-demo-.net-core-api)

This project is a demonstration of a lightweight .NET Core API that allows for the search of IP data based on two data feeds:
<ul>
    <li>https://www.binarydefense.com/banlist.txt</li>
    <li>ipinfo.io for Geo spacial information based off an IP address</li>
</ul>

# Associated Projects
<ul>
    <li>
        Available API Services:
        <ul>
            <li>Java Spring: https://github.com/WiNTeR270/security-demo-java-api</li>
            <li>C# .NET Core: https://github.com/WiNTeR270/security-demo-.net-core-api</li>
        </ul>
    </li>
    <li>Web Application: https://github.com/WiNTeR270/security-demo-react-redux </li>
</ul>

# Goals of Projects
<ol>
    <li><strong>Create a Simple React/Redux Application</strong>
    <ul>
        <li>Start an empty create-react-app</li>
        <li>Integrate Redux to manage application state</li>
        <li>Integrate Redux middleware (thunk) for allowing async / await dispatch action creators</li>
        <li>Embed OpenLayers map library into a React component</li>
        <li>Integrate UI application with a lightweight .NET Core API</li>
        <li>Demonstrate Redux Reducers</li>
        <li>Demonstrate Redux Actions</li>
        <li>Demonstrate various React components</li>
    </ul>
    </li>
    <li><strong>Create a Simple Java Spring API Service Layer</strong>
    <ul>
        <li>Start with an empty Java Springboot project</li>
        <li>Provide an API for determing if an IP is in a known list (malicious) and retrieve Geo data for IP address</li>
        <li>Integrate Service layer with another external API (ipinfo.io) and converting JSON results</li>
        <li>Integrate Service layer with parsing data from an external URL (binarydefense) and converting raw text results</li>
        <li>Simple unit test exercising API Controller that avoids having to run the full application to test against</li>
        </ul>
    </li>
    <li><strong>Create a Simple .NET Core API Service Layer</strong>
    <ul>
        <li>Start with an empty .NET Core project</li>
        <li>Provide an API for determing if an IP is in a known list (malicious) and retrieve Geo data for IP address</li>
        <li>Integrate Service layer with another external API (ipinfo.io) and converting JSON results</li>
        <li>Integrate Service layer with parsing data from an external URL (binarydefense) and converting raw text results</li>
        <li>Simple unit test exercising API Controller that avoids having to run the full application to test against</li>
        </ul>
    </li>
    <li><strong>Demonstrate CI Pipeline of projects using Travis</strong></li>
</ol>

# Prerequisites
<ul>
    <li>Visual Studio must be installed (application was developed in Visual Studio 2019)</li>
</ul>

# How to Run

<ul>
    <li>Download and run the .NET Core API found here:
    <ul>
        <li>https://github.com/WiNTeR270/security-demo-.net-core-api</li>
    </ul>
    </li>
    <li>Sign up and configure the ipinfo.io API key
        <ul>
            <li>https://ipinfo.io/signup</li>
            <li>Update the <b>IP_GEO_LOOKUP_API_KEY</b> variable in (https://github.com/WiNTeR270/security-demo-.net-core-api/blob/master/API/Controllers/IpAddressController.cs#L22) to reflect the API key</li>
        </ul>
    </li>
    <li>Open up a command line and run the following commands
        <ul>
            <li>cd into the root API project folder</li>
            <li>run <b>dotnet build</b></li>
            <li>run <b>dotnet API/bin/Release/netcoreapp2.0/API.dll</b></li>
            <li>find the port in use line <b>"Now listening on: http://localhost:PORT_NUM'</b>.</li>
            <li>Verify the API is running by opening a browser and entering <b>http://localhost:PORT_NUMBER/api/maliciousIp/22.22.22.22</b> This should give you JSON result data
            </li>
        </ul>
    </li>
    <li>The API port number will need to reflected in the react-redux UI application in order for the UI to connect to the API layer</li>
    <li>Download, setup, and follow instructions for the UI Application here: 
        <ul>
            <li>https://github.com/WiNTeR270/security-demo-react-redux</li>
        </ul>
    </li>
</ul>
