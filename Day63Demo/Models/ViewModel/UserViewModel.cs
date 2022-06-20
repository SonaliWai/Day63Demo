﻿using Day63Demo.Data.Models;
using System;

namespace Day63Demo.Models.ViewModel
{
    public class UserViewModel
    {
        public int Id { get; set; }
        
        public string? FirstName { get; set; }   
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Pan { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
        public string? MobileNumber { get; set; }
        public string? Email { get; set; }
        public string? Comments { get; set; }
        public int DepartmentRefId { get; set; }
        
       

    }
}
