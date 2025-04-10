# Subscription Management System 

Here is what we did in this branch:

- Added a new `Class Library` project which I called `SubscriptionManagementSystem.shared` to the solution.
- I deleted the `Class1.cs` file that was created by default.
- It is to house resources that will be shared between the `SubscriptionManagementSystemAPI` and `SubscriptionManagementSystemMVC` projects.
- In the Models > Domain folder, I added the model classes - Users, Plans, Subscriptions, Payments, Notifications, alongside their properties and relationships (Primary Key, Foriegn Key, Navigation Properties).
> Navigation properties represent relationships between entities, such as one-to-one, one-to-many, or many-to-many.

Below is the summary of relationships between all tables (models):
- **Users**: 
    - One-to-Many relationship with External Logins (one user can have multiple external logins).
    - One-to-Many relationship with Subscriptions (one user can have multiple subscriptions).
    - One-to-Many relationship with Payments (one user can make multiple payments).
    - One-to-Many relationship with Notifications (one user can receive multiple notifications).

- **External Logins**:
    - Many-to-One relationship with User (each external login is associated with one user).

- **Plans**:
    - One-to-Many relationship with Subscription (one plan can have multiple subscriptions). 

- **Subscriptions**:
    - Many-to-One relationship with User (each subscription is associated with one user).
    - Many-to-One relationship with Plan (each subscription is associated with one plan).
    - One-to-Many relationship with Payment (one subscription can have multiple payments).

- **Payments**
    - Many-to-One relationship with User (each payment is associated with one user).
    - Many-to-One relationship with Subscription (each payment is associated with one subscription).

- **Notifications**
    - Many-to-One relationship with User (each notification is associated with one user).