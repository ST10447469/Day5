using System;

namespace Day5.Models
{
    public class EventSearch
    {
        public int Id { get; set; }         
        public string Title { get; set; }    
        public string Description { get; set; } 
        public string Type { get; set; }     

        public EventSearch() { }

        public EventSearch(int id, string title, string description, string type)
        {
            Id = id;
            Title = title;
            Description = description;
            Type = type;
        }
    }
}