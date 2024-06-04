using System;
using System.Collections.Generic;
using System.Text;

namespace EventPlanning
{
    // Address class
    public class Address
    {
        public string StreetAddress { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }

        public Address(string streetAddress, string city, string state, string country)
        {
            StreetAddress = streetAddress;
            City = city;
            State = state;
            Country = country;
        }

        public string GetFullAddress()
        {
            return $"{StreetAddress}\n{City}, {State}\n{Country}";
        }
    }

    // Base Event class
    public abstract class Event
    {
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public string Date { get; protected set; }
        public string Time { get; protected set; }
        public Address Address { get; protected set; }

        public Event(string title, string description, string date, string time, Address address)
        {
            Title = title;
            Description = description;
            Date = date;
            Time = time;
            Address = address;
        }

        public string GetStandardDetails()
        {
            return $"Title: {Title}\nDescription: {Description}\nDate: {Date}\nTime: {Time}\nAddress:\n{Address.GetFullAddress()}";
        }

        public abstract string GetFullDetails();

        public string GetShortDescription()
        {
            return $"{GetType().Name}: {Title} on {Date}";
        }
    }

    // Lecture class
    public class Lecture : Event
    {
        private string _speaker;
        private int _capacity;

        public Lecture(string title, string description, string date, string time, Address address, string speaker, int capacity)
            : base(title, description, date, time, address)
        {
            _speaker = speaker;
            _capacity = capacity;
        }

        public override string GetFullDetails()
        {
            return $"{GetStandardDetails()}\nType: Lecture\nSpeaker: {_speaker}\nCapacity: {_capacity}";
        }
    }

    // Reception class
    public class Reception : Event
    {
        private string _rsvpEmail;

        public Reception(string title, string description, string date, string time, Address address, string rsvpEmail)
            : base(title, description, date, time, address)
        {
            _rsvpEmail = rsvpEmail;
        }

        public override string GetFullDetails()
        {
            return $"{GetStandardDetails()}\nType: Reception\nRSVP Email: {_rsvpEmail}";
        }
    }

    // OutdoorGathering class
    public class OutdoorGathering : Event
    {
        private string _weather;

        public OutdoorGathering(string title, string description, string date, string time, Address address, string weather)
            : base(title, description, date, time, address)
        {
            _weather = weather;
        }

        public override string GetFullDetails()
        {
            return $"{GetStandardDetails()}\nType: Outdoor Gathering\nWeather: {_weather}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create address objects
            Address address1 = new Address("123 Elm St", "Springfield", "IL", "USA");
            Address address2 = new Address("456 Oak Ave", "Metropolis", "NY", "USA");
            Address address3 = new Address("789 Pine Rd", "Toronto", "ON", "Canada");

            // Create event objects
            Lecture lecture = new Lecture("C# Programming Basics", "An introductory lecture on C# programming.", "2024-06-15", "10:00 AM", address1, "John Doe", 100);
            Reception reception = new Reception("Networking Event", "A networking event for professionals.", "2024-06-20", "06:00 PM", address2, "rsvp@example.com");
            OutdoorGathering outdoorGathering = new OutdoorGathering("Summer Festival", "A fun outdoor festival.", "2024-06-25", "12:00 PM", address3, "Sunny");

            // Create a list to store events
            List<Event> events = new List<Event> { lecture, reception, outdoorGathering };

            // Display event details
            foreach (var eventItem in events)
            {
                Console.WriteLine(eventItem.GetStandardDetails());
                Console.WriteLine(eventItem.GetFullDetails());
                Console.WriteLine(eventItem.GetShortDescription());
                Console.WriteLine();
            }
        }
    }
}
