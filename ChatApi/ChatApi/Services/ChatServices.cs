using System.Collections.Generic;
using System.Linq;

namespace ChatApi.Services
{
    public class ChatServices
    {
        // key, Value eg:{ {"jhon","asdf!j211"}, {"David","asdf!j211"} }
        private static readonly Dictionary<string, string> Users = new Dictionary<string, string>();

        public bool AddUserToList(string UserToAdd)
        {
            lock(Users)
            {
                foreach(var user in Users)
                {
                    if(user.Key.ToLower() == UserToAdd.ToLower())
                    {
                        return false;
                    }
                }

                Users.Add(UserToAdd.ToLower(), null);
                return true;
            }
        }

        public void AddUserConnectionId(string user, string connectionId)
        {
            lock (Users)
            {
                if(Users.ContainsKey(user))
                {
                    Users[user] = connectionId;
                }
            }
        }

        public string GetUserConnectionId(string ConnectionId)
        {
            lock(Users)
            {
                return Users.Where(x => x.Value == ConnectionId).Select(x => x.Key).FirstOrDefault();
            }
        }

        public string GetConnectionIdByUser(string user)
        {
            lock (Users)
            {
                return Users.Where(x => x.Key == user).Select(x => x.Value).FirstOrDefault();
            }
        }

        public void RemoveUser(string UserToRemove)
        {
            lock(Users)
            {
                if(Users.ContainsKey(UserToRemove))
                {
                    Users.Remove(UserToRemove);
                }
            }
        }

        public string[] GetOnlineUsers()
        {
            lock (Users)
            {
                return Users.OrderBy(x=>x.Key).Select(x=>x.Key).ToArray();
            }
        }
    }
}
