using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using ErrorOr;
using HadiDinner.Domain.Common.Errors;
using HadiDinner.Domain.Common.Models;
using HadiDinner.Domain.User.ValueObjects;

namespace HadiDinner.Domain.User;

public class User : AggregateRoot<UserId>
{
    private const int SaltSize = 16; // 128 bits
    private const int HashSize = 32; // 256 bits
    private const int Iterations = 100000;
    private readonly string _passwordHash;

    public string Password => _passwordHash;

    public string FirstName { get; } = null!;

    public string LastName { get; } = null!;

    public string Email { get; } = null!;

    public DateTime CreatedDateTime { get; private set; }

    public DateTime UpdatedDateTime { get; private set; }

    private User() { }

    private User(
        UserId id,
        string firstName,
        string lastName,
        string email,
        string passwordHash,
        DateTime createdDateTime,
        DateTime updatedDateTime
    )
        : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
        _passwordHash = passwordHash;
    }

    public static ErrorOr<User> Create(
        string firstName,
        string lastName,
        string email,
        string password
    )
    {
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            return Errors.User.InvalidInput;
        }

        var emailValidator = new EmailAddressAttribute();
        if (!emailValidator.IsValid(email))
        {
            return Errors.User.InvalidEmailFormat;
        }

        if (password.Length < 8)
        {
            return Errors.User.WeakPassword;
        }

        var passwordHash = HashPassword(password);

        return new User(
            UserId.CreateUnique(),
            firstName,
            lastName,
            email,
            passwordHash,
            createdDateTime: DateTime.UtcNow,
            updatedDateTime: DateTime.UtcNow
        );
    }

    public bool VerifyPassword(string password)
    {
        return VerifyPasswordHash(password, _passwordHash);
    }

    private static string HashPassword(string password)
    {
        // Generate random salt
        byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);

        // Hash password with salt
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            Iterations,
            HashAlgorithmName.SHA256,
            HashSize
        );

        // Combine salt + hash and encode as Base64
        byte[] hashBytes = new byte[SaltSize + HashSize];
        Array.Copy(salt, 0, hashBytes, 0, SaltSize);
        Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

        return Convert.ToBase64String(hashBytes);
    }

    private static bool VerifyPasswordHash(string password, string storedHash)
    {
        // Decode stored hash
        byte[] hashBytes = Convert.FromBase64String(storedHash);

        // Extract salt
        byte[] salt = new byte[SaltSize];
        Array.Copy(hashBytes, 0, salt, 0, SaltSize);

        // Hash the input password with extracted salt
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            Iterations,
            HashAlgorithmName.SHA256,
            HashSize
        );

        // Compare hashes (constant-time comparison)
        byte[] storedHashPart = new byte[HashSize];
        Array.Copy(hashBytes, SaltSize, storedHashPart, 0, HashSize);

        return CryptographicOperations.FixedTimeEquals(hash, storedHashPart);
    }
}
