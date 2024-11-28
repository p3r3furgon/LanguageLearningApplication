﻿namespace Auth.Application.Dtos
{
    public class UserResponseDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }
        public string Role { get; set; } = string.Empty;
    }
}
