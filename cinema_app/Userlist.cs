using System;
using System.Collections.Generic;
namespace cinema_app
{
    public class Userlist
    {
        public static List<User> userlist = new List<User>();
        public static JsonAdd saveUser = new JsonAdd("Users.json");
        public static List<User> getUserlist()
        {
            return Userlist.userlist = Userlist.saveUser.LoadFromJson2();
        }
    }
}

