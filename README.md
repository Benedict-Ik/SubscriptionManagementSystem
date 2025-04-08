# Subscription Management System 

Here is what we did in this branch:

- Added a new `Class Library` project which I called `SubscriptionManagementSystem.shared` to the solution.
- I deleted the `Class1.cs` file that was created by default.
- It is to house resources that will be shared between the `SubscriptionManagementSystemAPI` and `SubscriptionManagementSystemMVC` projects.
- In the Models > Domain folder, I added the model classes - Users, Plans, Subscriptions, Payments, Notifications, alongside their properties and relationships (Primary Key, Foriegn Key, Navigation Properties).
> Navigation properties represent relationships between entities, such as one-to-one, one-to-many, or many-to-many.


