// Define Entity and Domain Object Traits
trait IEntity {
    fn save(&self);
}

trait IDomainObject {
    fn validate(&self);
}

// Implement Entity and Domain Object
struct UserEntity {
    username: String,
    email: String,
}

impl IEntity for UserEntity {
    fn save(&self) {
        println!("User entity saved.");
    }
}

struct UserDomainObject {
    username: String,
    email: String,
}

impl IDomainObject for UserDomainObject {
    fn validate(&self) {
        self.validate_username();
        self.validate_email();
        println!("User domain object validated.");
    }
}

impl UserDomainObject {
    fn validate_username(&self) {
        if self.username.is_empty() {
            panic!("Username cannot be null or empty.");
        }
        // Additional username specific validations
    }

    fn validate_email(&self) {
        if self.email.is_empty() || !self.email.contains("@") {
            panic!("Email is not in a valid format.");
        }
        // Additional email specific validations
    }
}

// Adapter Implementation
struct UserAdapter;

impl UserAdapter {
    fn adapt(&self, entity: &UserEntity) -> UserDomainObject {
        println!("Adapting UserEntity to UserDomainObject.");
        UserDomainObject {
            username: entity.username.clone(),
            email: entity.email.clone(),
        }
    }
}

// Application Logic
struct Application {
    user_adapter: UserAdapter,
}

impl Application {
    fn process_user(&self, user_entity: &UserEntity) {
        let user_domain_object = self.user_adapter.adapt(user_entity);
        user_domain_object.validate();
        user_entity.save();
    }
}

// Main Function to Simulate the Application Run
fn main() {
    let user_entity = UserEntity {
        username: "SampleUser".to_string(),
        email: "sample@email.com".to_string(),
    };
    let user_adapter = UserAdapter;
    let app = Application { user_adapter };

    app.process_user(&user_entity);
}
