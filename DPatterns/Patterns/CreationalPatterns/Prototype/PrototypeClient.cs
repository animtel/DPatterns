using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace DPatterns.Patterns.CreationalPatterns.Prototype
{
    public class PrototypeClient : IClient
    {
        public PrototypeClient()
        {
            Execute();
        }
        public void Execute()
        {
            var jonh = new Person(new[] { "Jonh", "Smith" }, new Address("Some Road", 42));

            var jane = new Person(jonh);
            jane.Address.HouseNumber = 43;

            Console.WriteLine(jonh);
            Console.WriteLine(jane);
        }

        class Person //: ICloneable Yep, you can to implement Clone method for each Class for this class, but it isn't convenient =(
            // I just want to show u how u can use copy constructor and factory, for convenient api of creation deep copy of objects
        {
            public string[] Names;
            public Address Address;

            public Person(string[] names, Address address)
            {
                Names = names;
                Address = address;
            }

            public Person(Person otherPerson)
            {
                Names = otherPerson.Names;
                Address = new Address(otherPerson.Address);
            }

            public override string ToString()
            {
                return $"{nameof(Names)}: {String.Join(" ", Names)}, {nameof(Address)}: {Address}";
            }

        }

        class Address
        {
            public string StreetName;
            public int HouseNumber;

            public Address(string streetName, int houseNumber)
            {
                StreetName = streetName;
                HouseNumber = houseNumber;
            }

            public Address(Address otherAddress)
            {
                StreetName = otherAddress.StreetName;
                HouseNumber = otherAddress.HouseNumber;
            }

            public override string ToString()
            {
                return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
            }
        }
    }


}
