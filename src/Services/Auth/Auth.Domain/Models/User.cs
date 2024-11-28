﻿namespace Auth.Domain.Models
{
    public class User
    {
        private User() { }
        private User(Guid id, string firstName, string surname, string userName,
            DateOnly birthDate, string email, string passwordHash, string role)
        {
            Id = id;
            FirstName = firstName;
            Surname = surname;
            UserName = userName;
            BirthDate = birthDate;
            Email = email;
            PasswordHash = passwordHash;
            Role = role;
        }
        public const int NAMES_MAX_LENGTH = 40;
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;

        public static User Create(Guid id, string firstName, string surname, string userName,
            DateOnly birthDate, string email, string passwordHash, string role)
        {

            return new User(id, firstName, surname, userName, birthDate, email, passwordHash, role);
        }


    }
}
