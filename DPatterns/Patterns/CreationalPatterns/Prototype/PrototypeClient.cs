using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

namespace DPatterns.Patterns.CreationalPatterns.Prototype
{

    //To implement a prototype< partially construct an object and store it somewhere
    //For make a clone, you can use:
    // - Implement your own deep copy functionality
    // - Implement ICloneable
    // - Serialize and deserialize
    // - Create an abstraction like IPrototype<T> with method DeepCopy
    // and more different approaches, but idea still one;
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

        public static class ExtensionMethods
        {
            //Also for cloning of objects, you can use smth like this methods
            public static T DeepCopy<T>(T self)
            {
                using (var ms = new MemoryStream())
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(ms, self);
                    ms.Position = 0;

                    return (T)formatter.Deserialize(ms); //For using it, please, be ensure that your's classes are [Serializable]
                }
            }

            public static T DeepCopyXml<T>(T self)
            {
                using (var ms = new MemoryStream())
                {
                    var s = new XmlSerializer(typeof(T));
                    s.Serialize(ms, self);
                    ms.Position = 0;
                    return (T)s.Deserialize(ms);
                }
            }
        }

        //[Serializable]
        class Person //: ICloneable Yep, you can to implement Clone method for each Class for this class, but it isn't convenient, because then you will have object, not yours type and some else misunderstood api =(
                     // I just want to show u how u can use copy constructor, for convenient api of creation deep copy of objects
        {
            public string[] Names;
            public Address Address;

            public Person(string[] names, Address address)
            {
                Names = names;
                Address = address;
            }

            public Person(Person otherPerson) //Copy constructor
            {
                Names = otherPerson.Names;
                Address = new Address(otherPerson.Address);
            }

            public Person()
            {
                
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

            public Address()
            {
                
            }

            public override string ToString()
            {
                return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
            }
        }
    }


}
