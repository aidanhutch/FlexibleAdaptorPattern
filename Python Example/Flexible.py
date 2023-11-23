from abc import ABC, abstractmethod

# Entity and Domain Object Abstract Base Classes
class IEntity(ABC):
    @abstractmethod
    def save(self):
        pass

class IDomainObject(ABC):
    @abstractmethod
    def validate(self):
        pass

# Implement Entity and Domain Object
class UserEntity(IEntity):
    def __init__(self, username, email):
        self.username = username
        self.email = email

    def save(self):
        print("User entity saved.")

class UserDomainObject(IDomainObject):
    def __init__(self, username, email):
        self.username = username
        self.email = email

    def validate(self):
        self._validate_username()
        self._validate_email()
        print("User domain object validated.")

    def _validate_username(self):
        if not self.username:
            raise ValueError("Username cannot be null or empty.")

    def _validate_email(self):
        if not self.email or "@" not in self.email:
            raise ValueError("Email is not in a valid format.")

# Adapter Implementation
class UserAdapter:
    def adapt(self, entity):
        print("Adapting UserEntity to UserDomainObject.")
        return UserDomainObject(entity.username, entity.email)

# Application Logic
class Application:
    def __init__(self, user_adapter):
        self.user_adapter = user_adapter

    def process_user(self, user_entity):
        try:
            user_domain_object = self.user_adapter.adapt(user_entity)
            user_domain_object.validate()
            user_entity.save()
        except Exception as ex:
            print(f"Validation failed: {ex}")

# Simulate the Application Run
if __name__ == "__main__":
    user_entity = UserEntity("SampleUser", "sample@email.com")
    user_adapter = UserAdapter()
    app = Application(user_adapter)
    app.process_user(user_entity)
