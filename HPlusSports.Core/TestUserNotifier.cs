using System;

namespace HPlusSports.Core {
public class TestUserNotifier : IUserNotifier
    {
        public void NotifyUser(int id)
        {
            Console.WriteLine($"Pretending to Notify User {id}");
        }
    }
}