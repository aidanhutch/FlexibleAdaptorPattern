// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;

/*  App: Flexible Adaptor Pattern Example
    Author: Aidan Hutchinson
    Date: 23/11/2023
*/

// Setup DI container
var serviceCollection = new ServiceCollection();
var startup = new Startup();
startup.ConfigureServices(serviceCollection);
var serviceProvider = serviceCollection.BuildServiceProvider();

// Resolve Application with dependencies
var application = serviceProvider.GetService<Application>();
var userEntity = new UserEntity
{
    Username = "SampleUser",
    Email = "sample@email.com"
};

application?.ProcessUser(userEntity);

// Entity and Domain Object Interfaces
public interface IEntity
{
    void Save();
}

public interface IDomainObject
{
    void Validate();
}

// Implement Entity and Domain Object
public class UserEntity : IEntity
{
    public string Username { get; set; }
    public string Email { get; set; }

    public void Save()
    {
        Console.WriteLine("User entity saved.");
    }
}

public class UserDomainObject : IDomainObject
{
    public string Username { get; set; }
    public string Email { get; set; }

    public void Validate()
    {
        ValidateUsername();
        ValidateEmail();
        Console.WriteLine("User domain object validated.");
    }

    private void ValidateUsername()
    {
        if (string.IsNullOrWhiteSpace(Username))
        {
            throw new ArgumentException("Username cannot be null or empty.");
        }
        // Additional username specific validations
    }

    private void ValidateEmail()
    {
        if (string.IsNullOrWhiteSpace(Email))
        {
            throw new ArgumentException("Email cannot be null or empty.");
        }
        if (!Email.Contains("@"))
        {
            throw new ArgumentException("Email is not in a valid format.");
        }
        // Additional email specific validations
    }
}

// Adapter Interface and Implementation
public interface IEntityAdapter<T> where T : IEntity
{
    IDomainObject Adapt(T entity);
}

public class UserAdapter : IEntityAdapter<UserEntity>
{
    public IDomainObject Adapt(UserEntity entity)
    {
        Console.WriteLine("Adapting UserEntity to UserDomainObject.");
        return new UserDomainObject
        {
            Username = entity.Username,
            Email = entity.Email
        };
    }
}

// Configure Dependency Injection
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IEntityAdapter<UserEntity>, UserAdapter>();
        services.AddScoped<Application>();
    }
}

// Implement the Application Logic
public class Application
{
    private readonly IEntityAdapter<UserEntity> _userAdapter;

    public Application(IEntityAdapter<UserEntity> userAdapter)
    {
        _userAdapter = userAdapter;
    }

    public void ProcessUser(UserEntity userEntity)
    {
        try
        {
            IDomainObject userDomainObject = _userAdapter.Adapt(userEntity);
            userDomainObject.Validate();
            userEntity.Save();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Validation failed: {ex.Message}");
        }
    }
}
