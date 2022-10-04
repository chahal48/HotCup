//using System.Linq;

using InterfaceLayer;

namespace MainProcess
{
    public class UserDefination : InitializeMenu, IMenuDefineProcess
    {
        public string[] AllowedUser = 
        { /* userName, Password, SecurityLevel */
            "admin,admin,admin",
            "user,1234,user",
            "sachin,asdf1234,admin" 
        };
        
        public string[] LoginProperty;

        public bool allowedUsers(string user)
        {
            //return AllowedUser.Contains(user);
            //Require using directive of System.Linq 

            bool result = false;
            for (int i = 0; i < AllowedUser.Length; i++)
            {
                result = (AllowedUser[i].Substring(0,AllowedUser[i].IndexOf(',')) == user);
                if (result)
                    break;
            }
            
            return result;
        }
        public bool allowedUserPass(string UserPass)
        {
            bool result = false;
            for (int i = 0; i < AllowedUser.Length; i++)
            {
                result = (AllowedUser[i].Substring(0, AllowedUser[i].LastIndexOf(',')) == UserPass);
                if (result)
                    break;
            }
            return result;
        }

        public string[] OrderMenuInitialize(string LoginUser)
        {
            switch (LoginUser)
            {
                case "admin":
                    return MilkShake;
                case "user":
                    return MasalaLemon;
                default:
                    return ColdCoffee;
            }
        }
    }
}
