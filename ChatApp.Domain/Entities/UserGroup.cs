﻿namespace ChatApp.Domain.Entities
{
    public class UserGroup
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public int? GroupId { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
