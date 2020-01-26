﻿using System;

 namespace DotNetSample.Application.DataTypes.Request
{
    public class AddUserRequest
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
    }
}