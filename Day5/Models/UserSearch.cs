using System;

namespace Day5.Models
{
    public class UserSearch
    {
        public int Id { get; set; }          
        public string Username { get; set; }
        public string Email { get; set; }    

        public UserSearch() { }

        public UserSearch(int id, string username, string email)
        {
            Id = id;
            Username = username;
            Email = email;
        }
    }
}