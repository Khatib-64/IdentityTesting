namespace IdentitySecurityTesting.DbInitializer;

internal interface IDatabaseInitializer
{
    Task InitializeDatabasesAsync(CancellationToken cancellationToken);
}