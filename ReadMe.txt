
# 📦 Customer API
A RESTful API for managing customer registration, verification, and biometric login functionality.

## 📌 Features
- Customer registration with PIN and biometric login support
- Biometric login enable/disable
- Email/phone verification code sending
- Verification code validation
- Retrieve privacy policy

## 🚀 API Endpoints
1. Register Customer

**POST** `/api/Customers/register`

Registers a new customer.
#### Request Body (JSON)
{
  "name": "John Doe",
  "icNumber": "123456789012",
  "email": "john@example.com",
  "mobileNo": "0123456789",
  "acceptPrivacyPolicy": true,
  "pin": "123456",
  "isBiometricLoginEnable": true
}
Response
200 OK – Customer registered successfully

2. Enable/Disable Biometric Login
POST /api/Customers/biometric-login

Query Parameters
Name	Type	Required	Description
id	UUID	Yes	Customer's unique identifier
isEnable	boolean	Yes	Enable (true) or disable

Response
200 OK – Biometric login status updated

3. Send Verification Code
POST /api/Customers/send-verification

Request Body json
{
  "customerId": "uuid",
  "emailOrPhone": "john@example.com",
  "isEmail": true
}
Response
200 OK – Verification code sent

4. Verify Code
POST /api/Customers/verify

Request Body json
{
  "customerId": "uuid",
  "emailOrPhone": "john@example.com",
  "code": "654321",
  "isEmail": true
}
Response
200 OK – Verification successful

5. Get Privacy Policy
GET /api/Customers/privacy-policy

Response
200 OK – Returns the current privacy policy

🛠️ Technologies
ASP.NET Core 8.0 / Web API 
OpenAPI (Swagger) v3.0.1


###Additional Resources
Creating a web api project using dot net cli
Commands:
dotnet new sln
dotnet new webapi -n API
dotnet new classlib -n Application
dotnet new classlib -n Domain
dotnet new classlib -n Persistence
dotnet sln add API/API.csproj
dotnet sln add Application
dotnet sln add Domain
dotnet sln add Persistence

cd API
dotnet add reference ../Application

cd ..
cd Application
dotnet add reference ../Persistence
dotnet add reference ../Domain

cd ..
cd Persistence
dotnet add reference ../Domain

### Migration Command
dotnet ef migrations add InitialCreate -p Persistence -s API
dotnet ef database update -p API

👩‍💻 Author
Khandokar Mahidy Hasan
