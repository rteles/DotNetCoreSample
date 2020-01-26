﻿using System;

 namespace DotNetSample.Application.DataTypes.Result
{
    public class UserResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
    }
}
