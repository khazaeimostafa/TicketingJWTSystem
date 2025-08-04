using TicketingSystem.Domain.Common;
using TicketingSystem.Domain.Enums;

namespace TicketingSystem.Domain.Entities;

public class User : BaseEntity
{


    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public UserRole Role { get; private set; }

    // Constructor

    public User(string firstName, string lastName, string email, UserRole role, string passwordHash)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordHash = passwordHash;
        Role = role;
    }

    // Behavior
    public bool VerifyPassword(string password)
    {
        return BCrypt.Net.BCrypt.Verify(password, PasswordHash);
    }

    public void ChangePassword(string newPassword)
    {
        PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
    }



}
