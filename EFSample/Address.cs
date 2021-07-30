using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFSample
{
    public class Address : ValueObject
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }

        public AddressType AddressType { get; private set; }

        public Address() { }

        public Address(string street, string city, string state, string country, string zipcode, AddressType addressType)
        {
            Street = street;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipcode;
            AddressType = addressType;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return Street;
            yield return City;
            yield return State;
            yield return Country;
            yield return ZipCode;
            yield return AddressType;
        }
    }
}