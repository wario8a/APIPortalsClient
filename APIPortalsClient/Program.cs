using APIPortalsClient.GraphQL;
using Microsoft.Extensions.DependencyInjection;
using StrawberryShake;

namespace APIPortalsClient;

class Program
{
    static async Task Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection
            .AddPortalsClient()
            .ConfigureHttpClient(client => client.BaseAddress = new Uri("url"));

        IServiceProvider services = serviceCollection.BuildServiceProvider();

        IPortalsClient client = services.GetRequiredService<IPortalsClient>();

        //Query

        var resultQueryCases = await client.QueryCases.ExecuteAsync();
        resultQueryCases.EnsureNoErrors();

        foreach (var caseData in resultQueryCases.Data.Cases)
        {
            Console.WriteLine(caseData.CaseCode);
        }


        //Query with Parameter

        var resultGetCaseById = await client.GetCaseById.ExecuteAsync(1);
        resultGetCaseById.EnsureNoErrors();
            
        Console.WriteLine(resultGetCaseById.Data.CaseById.CaseCode);


        //Mutation 

        var resultUpdatePerson = await client.UpdatePerson.ExecuteAsync(new UpdatePersonInput()
            { PersonKey = 1, BirthDate = DateTimeOffset.Now });
        resultUpdatePerson.EnsureNoErrors();

        var resultUpdateAccounts = await client.UpdateAccounts.ExecuteAsync(new UpdateAccountInput()
            { AccountKey = 1, AccountCode = ""  });
        resultUpdateAccounts.EnsureNoErrors();
    }
}