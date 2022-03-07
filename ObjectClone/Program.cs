using ObjectClone.Extension;
using System;
using System.Collections.Generic;

namespace ObjectClone
{
    class Program
    {
        static void Main(string[] args)
        {
            var realKyle = new Person() { Name = "Kyle", Age = 29, Height = 172 };
            realKyle.Friends.Add(new Person() { Name = "Pi", Age = 33, Height = 168 });

            //var cloneKyle = realKyle.DeepClone();
            var cloneKyle = realKyle.DeepCloneByJson();

            cloneKyle.Name = "Clone Kyle";
            cloneKyle.Friends[0].Name = "Clone Pi";

            realKyle.DisplayData();
            cloneKyle.DisplayData();

            Console.WriteLine("-----------------------");

            realKyle.DisplayFriendData();
            cloneKyle.DisplayFriendData();
        }
    }

    [Serializable]
    class Person
    {


        public string Name { get; set; }

        public int Age { get; set; }

        public decimal Height { get; set; }

        private string _secret;

        public List<Person> Friends { get; set; } = new List<Person>();

        public void DisplayData() => Console.WriteLine($"Name: {Name}/Age: {Age}/Height: {Height}");

        public void DisplayFriendData()
        {
            foreach(var f in Friends)
            {
                Console.WriteLine($"Name: {f.Name}/Age: {f.Age}/Height: {f.Height}");
            }
        }

        public void SetSecret(string s) => this._secret = s;

        public void DisplaySecret() => Console.WriteLine(this._secret);
    }
}
