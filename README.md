# Sending Emails using SendGrid Email Service and .NET 5

[`Twillio SendGrid service`](https://sendgrid.com/) allows us to programatically send emails freely by registering.

Post registering follow the [`instructions`](https://docs.sendgrid.com/for-developers/sending-email/api-getting-started) to obtain an API key and verify the sender's email address.

To scaffold the app -

```csharp
mkdir src

cd src
dotnet new console -o SendGridEmailTest

cd ..
dotnet new sln

dotnet sln add .\src\SendGridEmailTest\
```

To build the app -
```csharp
dotnet build
```

To run the app -
```
cd .\src\SendGridEmailTest\

# Set the below environment variables
$env:SENDGRID_EMAIL_API_KEY="<SENDGRID_EMAIL_API_KEY>"
$env:FROM_EMAIL="<FROM_EMAIL_ADDRESS>"
$env:FROM_EMAIL_FRIENDLY_NAME="<FROM_EMAIL_FRIENDLY_NAME>"
$env:TO_EMAIL="<TO_EMAIL_ADDRESS>"
$env:TO_EMAIL_FRIENDLY_NAME="<TO_EMAIL_FRIENDLY_NAME>"

dotnet run
```