using System;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using ServiceStack.Text;

namespace testRedisConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using(RedisClient redisClient = new RedisClient("redis://clientid:Chenz2584@localhost:6379"))
            {
                IRedisTypedClient<Person> redisUser = redisClient.As<Person>();
                
                var rick = new Person { Id = "Rick", Name = "Rick @ code with intent" };
                var backy = new Person { Id = "Backy", Name = "Backy @ becy,com" };
                //var chen = new Person { Id = redisUser.GetNextSequence(), Name = "Chen @ becy,com" };

                redisUser.Store(rick);
                redisUser.Store(backy);
                
                var allThePeople = redisUser.GetAll();
                Console.WriteLine("--- Get All People ---");
                foreach(var people in allThePeople)
                {
                    Console.WriteLine($"Id: {people.Id} - Name: {people.Name} ");
                }
                //Console.WriteLine(allThePeople.Dump()); //return json format

                Console.WriteLine("--- GetByUser ---");
                redisClient.SetValue("ChenName", "Worameth Semapat");
                Console.WriteLine("Get Result: " + redisClient.GetValue("ChenName"));
            }
        }
    }
}
