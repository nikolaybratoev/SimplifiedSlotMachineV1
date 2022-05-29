# Simplified Slot Machine v1

This is a simple API with several endpoints which simulates a slot machine. The application uses in-memory database which seeds 3 users to play with. You can get and modify their deposit amount and stake amount. The users can play on the slot machine. You can find additional information how to use the application at section `How to use`.

# Tech stack

* .NET 6.0
* C# 10.0
* Docker

# Install

##### Via Docker image:
* Pull the Docker image using:
    * `docker pull nikbratoe/slotmachinev1`
* Run the image and specify a port to expose the application:
    * `docker run -p 8080:80 -d nikbratoe/slotmachinev1`

##### Local install:
* Clone the repository:
    * `git clone git@github.com:nikolaybratoev/SimplifiedSlotMachineV1.git`
* Build the application:
    * `dotnet build`
* Run the application:
    * `dotnet run`

# How to use
*There are three seeded users in the database when the application is started.*
1. `GET` spin the slot machine
This is the endpoint to spin the slot machine. Generates random symbols and calculates if the requested user by user id has won. Returns `NotFound` if user is not present in the database or `BadRequest` if user doesn't have entered stake amount.
    * `http://localhost:{port}/api/v1/spinslotmachine/{userId}`
```
{
    "userId": 1,
    "firstRow": "ABP",
    "secondRow": "AAA",
    "thirdRow": "ABA",
    "fourthRow": "AAB",
    "won": "12.0",
    "currentBalance": "112.0"
}
```
2. `GET` all users endpoint
The endpoint returns information about all users (user id, name, deposit, stake amount) from the in-memory database. 
    * `http://localhost:{port}/api/v1/users`
```
{
    "userId": 1,
    "name": "Peter",
    "deposit": 100,
    "stakeAmount": 10
},
{
    "userId": 2,
    "name": "Alex",
    "deposit": 300,
    "stakeAmount": 20
},
{
    "userId": 3,
    "name": "Pavel",
    "deposit": 500,
    "stakeAmount": 0
}
```
3. `GET` user
The endpoint returns information about individual user by requested user id if it's present in the database.
    * `http://localhost:{port}/api/v1/users/{userId}`
```
{
    "userId": 2,
    "name": "Alex",
    "deposit": 300,
    "stakeAmount": 20
}
```
4. `GET` user deposit
The endpoint returns the deposit of individual user by requested user id if it's present in the database.
    * `http://localhost:{port}/api/v1/users/{userId}/deposit`
```
500.0
```
5. `POST` user deposit
The endpoint is used to enter deposit amount for requested user by user id. Return success if user is present in the database.
    * `http://localhost:{port}/api/v1/users/{userId}/deposit/{deposit}`
6. `GET` stake amount
The endpoint returns the stake amount for user by user id. Returns `BadRequest` if user is not entered stake amount or `NotFound` if user is not present in the database.
    * `http://localhost:{port}/api/v1/stake/{userId}`
```
{
    "userId": 2,
    "stakeAmount": 20
}
```
7. `POST` stake amount
The endpoint is used to enter a stake amount for user by requested user id.
    * `http://localhost:{port}/api/v1/stake/{userId}/amount/{stakeAmount}`
```
{
    "userId": 2,
    "stakeAmount": 30
}
```