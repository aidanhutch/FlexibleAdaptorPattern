// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;

/*  App: Flexible Adaptor Pattern Example
    Author: Aidan Hutchinson
    Date: 23/11/2023
*/

Console.WriteLine("Flexible Adaptor Pattern Example...");

// Simulate the Application Run

// Setup DI container
var serviceCollection = new ServiceCollection();
var startup = new Startup();
startup.ConfigureServices(serviceCollection);
var serviceProvider = serviceCollection.BuildServiceProvider();

// Resolve Application with dependencies
var application = serviceProvider.GetService<Application>();
var userEntity = new UserEntity();
application?.ProcessUser(userEntity);


// Step 1: Define Entity and Domain Object Interfaces
public interface IEntity
{
    void Save();
}

public interface IDomainObject
{
    void Validate();
}

// Step 2: Implement Entity and Domain Object
public class UserEntity : IEntity
{
    // User-specific properties
    public void Save()
    {
        Console.WriteLine("User entity saved.");
    }
}

public class UserDomainObject : IDomainObject
{
    // User-specific properties
    public void Validate()
    {
        Console.WriteLine("User domain object validated.");
    }
}

// Step 3: Define the Adapter Interface and Implementation
public interface IEntityAdapter<T> where T : IEntity
{
    IDomainObject Adapt(T entity);
}

public class UserAdapter : IEntityAdapter<UserEntity>
{
    public IDomainObject Adapt(UserEntity entity)
    {
        Console.WriteLine("Adapting UserEntity to UserDomainObject.");
        return new UserDomainObject();
    }
}

// Step 4: Configure Dependency Injection
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IEntityAdapter<UserEntity>, UserAdapter>();
        services.AddScoped<Application>();
    }
}

// Step 5: Implement the Application Logic
public class Application
{
    private readonly IEntityAdapter<UserEntity> _userAdapter;

    public Application(IEntityAdapter<UserEntity> userAdapter)
    {
        _userAdapter = userAdapter;
    }

    public void ProcessUser(UserEntity userEntity)
    {
        IDomainObject userDomainObject = _userAdapter.Adapt(userEntity);
        userDomainObject.Validate();
        userEntity.Save();
    }
}




