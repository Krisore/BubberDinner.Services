using BubberDinner.Domain.Models;

namespace BubberDinner.Domain.Dinner.ValueObjects;

public class Location : ValueObject
{
    public string Name { get; }
    public string Address { get; }

    public string Latitude { get; }

    public string Longitude { get; set; }

    public Location(string name, string address, string latitude, string longitude)
    {
        Name = name;
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
    }

    public Location Create(string name, string address, string latitude, string longitude)
    {
        return new Location(name, address, latitude, longitude);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Address;
        yield return Latitude;
        yield return Longitude;
    }
}