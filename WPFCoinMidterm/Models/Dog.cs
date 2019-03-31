using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WPFCoinMidterm.Models
{
    public class Dog
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string BarkSound { get; set; }

        public Dog()
        {
            this.Name = "Fido";
            this.BarkSound = "woof!";
            this.Age = 1;
        }

        protected Dog(SerializationInfo info, StreamingContext context)
        {
            Name = info.GetString("Name");
            Age = info.GetInt32("Age");
            BarkSound = info.GetString("BarkSound");
        }

        public override bool Equals(object other)
        {
            var toCompareWith = other as Dog;
            if (toCompareWith == null)
                return false;
            return this.Name == toCompareWith.Name && this.Age == toCompareWith.Age;

        }

        public override int GetHashCode()
        {
            return this.GetHashCode();
        }
    }
}
