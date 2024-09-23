// See https://aka.ms/new-console-template for more information

using APIPortals.Net.Models;
using APIPortalsClient.Net.Models;
using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;


// To use NewtonsoftJsonSerializer, add a reference to 
// NuGet package GraphQL.Client.Serializer.Newtonsoft
var graphQlClient = new GraphQLHttpClient(
    "url",
    new NewtonsoftJsonSerializer());

var caseRequest = new GraphQLRequest
{
    Query = """
            query QueryCases {
            	cases{
            		caseKey
            		caseCode
            		sourceCaseCode
            	}
            }
            """
};


var graphQlResponse = await graphQlClient.SendQueryAsync<ResponseCases>(caseRequest);


foreach (var caseResult in graphQlResponse.Data.Cases)
{
    Console.WriteLine(caseResult.caseCode);
}


GraphQLQuery getCaseById = new("""
                               query GetCaseById($caseKey: Int!){
                               	caseById(caseKey: $caseKey) {
                               		caseCode
                               		officeKey
                               		sourceCaseCode
                               	}
                               }
                               """);

var caseResponse = await graphQlClient.SendQueryAsync<ResponseCaseById>(
    getCaseById,
    new { caseKey = 1 },
    "GetCaseById"
    );

Console.WriteLine(caseResponse.Data.CaseById);

