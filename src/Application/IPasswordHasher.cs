namespace Application;


/// <summary>
/// Defines methods for hashing and verifying passwords.
/// </summary>
public interface IPasswordHasher
{
    /// <summary>
    /// Hashes a plain text password and returns a hashed representation.
    /// </summary>
    /// <param name="passwordPlain">The plain text password to hash.</param>
    /// <returns>A hashed representation of the password.</returns>
    string Hash(string passwordPlain);

    /// <summary>
    /// Verifies whether a plain-text password matches a stored password hash.
    /// </summary>
    /// <param name="passwordPlain">The plain-text password to verify.</param>
    /// <param name="passwordHash">The stored password hash to compare against.</param>
    /// <returns><c>true</c> if the password matches the hash; otherwise, <c>false</c>.</returns>
    bool Verify(string passwordPlain, string passwordHash);

}
