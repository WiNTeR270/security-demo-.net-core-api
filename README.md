# React/Redux Malicious IP Search

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

This project is a demonstration of a lightweight React/Redux application is intended to connect to a .NET Core API that searches for malicious IP addresses.

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

# How to Run

<ul>
    <li>Download and run the .NET Core API found here:
    <ul>
        <li>https://github.com/WiNTeR270/security-demo-.net-core-api</li>
    </ul>
    </li>
    <li>Run the .NET Core API application and determine the <strong>localhost:port</strong> in use for the API
        <ul>
            <li>Update src/actions/index.js</li>
        </ul>
    </li>
    <li>Set the IP_SERVICE_URL variable to reflect the .NET Core API <strong>localhost:port</strong> value</li>
    <li>Run the following commands once this git repository is checked out
        <ul>
            <li>npm install</li>
            <li>npm start</li>
        </ul>
    </li>
    <li>Open up a web browser under <strong>localhost:3000</strong></li>
</ul>
