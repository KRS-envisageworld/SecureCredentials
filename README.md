# SecureCredentials

SecureCredentials is a C# library that provides methods for securely hashing and verifying passwords using a cryptographic algorithm. It utilizes PBKDF2 with a random salt to enhance security against brute-force attacks.

## Features

- Secure password hashing
- Password verification
- Configurable key size and iteration count
- Utilizes cryptographic best practices

## Installation

To use the SecureCredentials library, add it to your project via NuGet:
````
dotnet add package SecureCredentials --version 2.0.1
````
You can find package details over here : [SecureCredentials](https://www.nuget.org/packages/SecureCredentials)
## Usage

### Hashing a Password

To hash a password, create an instance of the `PasswordHasher` class and call the `HashPassword` method:
### Verifying a Password

To verify a password against a stored hash, use the `VerifyHashPassword` method:
## Contributing

Contributions are welcome! Please open an issue or submit a pull request for any improvements or bug fixes.

## License

This project is licensed under the MIT License.
