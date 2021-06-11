# SnagajobAPIAssignment API Application

This API recieves a JSON file representing a job application, and compares the answers given in the job application to desired answers stored in AzureSQL. If the job application answers all questions satisfactorily, the job application JSON is stored in the AzureSQL database and can be retrieved later.

## Runing the API locally

The API can be run locally using Visual Studio on a Windows machine with IIS enabled and .Net framework 4.7.2

## Accessing the API on the Azure cloud

The API is currently running on an Azure App Service, and can be accessed at https://snagajobapiassignmentapp.azurewebsites.net/api/values

## Supported HTTP requests

The API currently supports only GET and POST.

### GET

#### Request:

    GET /api/values HTTP/1.1
    Host: snagajobapiassignmentapp.azurewebsites.net
    
#### Response:

    ["{\"Name\":\"TestApplicant1\",\"Questions\":[{\"Id\":1,\"Answer\":\"Answer 1\"},{\"Id\":2,\"Answer\":\"Answer 2\"}]}","{\"Name\":\"TestApplicant2\",\"Questions\":[{\"Id\":1,\"Answer\":\"Answer 1\"},{\"Id\":2,\"Answer\":\"Answer 2\"}]}"]
    
### POST

#### Request:

    POST /api/values HTTP/1.1
    Host: snagajobapiassignmentapp.azurewebsites.net
    Accept: */*
    Content-Type: application/json
    Content-Length: 101

    {"Name":"TestApplicant1","Questions":[{"Id":"1","Answer":"Answer 1"},{"Id":"2","Answer":"Answer 2"}]}
