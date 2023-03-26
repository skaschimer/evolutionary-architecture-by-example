namespace SuperSimpleArchitecture.Fitnet.Contracts.PrepareContract;

using Data;
using Data.Database;

internal static class PrepareContractEndpoint
{
    internal static void MapPrepareContract(this IEndpointRouteBuilder app)
    {
        app.MapPost(ApiPaths.Contracts, async (ContractsPersistence persistence) =>
        {
            var contract = Contract.Prepare();
            await persistence.Contracts.AddAsync(contract);
            await persistence.SaveChangesAsync();

            return Results.Created($"/{ApiPaths.Contracts}/{contract.Id}", contract.Id);
        });
    }
}