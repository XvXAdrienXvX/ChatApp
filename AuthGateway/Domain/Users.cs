﻿using AuthGateway.Domain.Common;

namespace AuthGateway.Domain
{
    public sealed class Users : BaseEntity
    {
        public Users(string username, string email, string passwordHash, string avatarUrl, DateTime createdDate): base(default(int))
        {
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
            AvatarUrl = avatarUrl;
            CreatedDate = createdDate;
        }

        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string AvatarUrl { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
