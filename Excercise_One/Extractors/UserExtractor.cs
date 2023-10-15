using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Excercise_One
{
    public static class UserExtractor
    {
        public static List<Users> ExtractUsers(List<LogData> list)
        {
            List<Users> usersList = new List<Users>();
            foreach (var item in list)
            {
                if (item.description.LastIndexOf("User") != -1)
                {
                    Users user = new Users();
                    //με αυτά κρατάω το όνομα του user
                    var name = Convert.ToString(item.description.Remove(0, 6));
                    var finalName= name.Remove(name.LastIndexOf("'"));
                    //
                    user.name = finalName;
                    usersList.Add(user);
                }
            }
            return usersList;
        }
    }
}
