using InterfaceLayer;
using System;

namespace MainProcess
{
    public class LoginProcs : UserDetail , ISucessLogin
    {
        UserDefination userdef = new UserDefination();
        public bool SucessLogin(string User, string Pass,out string LoginUser,out string LoginPass)
        {
            bool Auto = AutoLogin(User, Pass);
            if (Auto)
            {
                LoginUser = User;
                LoginPass = Pass;
                return true;
            }
            else
            {
                return InputUser(out LoginUser, out LoginPass);
            }
        }

        private bool AutoLogin(string User, string Pass)
        {
            if (userdef.allowedUserPass(User + "," + Pass))
                return true;
            else
                return false;
        }

        private bool ValidPass()
        {
            if (pass == null || pass == "")
                return BlankMessage();
            else if (userdef.allowedUserPass(name + "," + pass))
                return true;
            else
                return InvalidMessage();
        }
        private bool ValidUser()
        {
            if (name == null || name == "")
                return BlankMessage();
            else if (userdef.allowedUsers(name))
                return true;
            else
                return InvalidMessage();
        }
        private bool InputUser(out string LoginUser, out string LoginPass)
        {
            for (int i = 0; i <= 5; i++)
            {
                if (i == 5)
                {
                    blocked = BlockLogin();
                    break;
                }

                WriteMsg("ENTER THE USERNAME : ");
                name = ReadLineMsg();

                if (!ValidUser())
                {
                    EnterLine();
                    continue;
                }
                else if (ValidUser())
                {
                    EnterLine();
                    break;
                }

            }
            if (!blocked)
            {
                LoginUser = name;
                return InputPass(out LoginPass);
            }
            else
            {
                LoginUser = null;
                LoginPass = null;
                return false; 
            }
        }

        private bool InputPass(out string LoginPass)
        {
            for (int i = 0; i <= 5; i++)
            {
                if (i == 5)
                {
                    blocked = BlockLogin();
                    break;
                }

                WriteMsg("ENTER THE PASSWORD : ");
                pass = ReadLineMsg();

                if (!ValidPass())
                {
                    EnterLine();
                    continue;
                }
                else if (ValidPass())
                {
                    EnterLine();
                    break;
                }
            }

            if (!blocked)
            {
                LoginPass = pass;
                return PrintLogin();
            }
            else 
            {
                LoginPass = null;
                return false; 
            }
        }

        private bool PrintLogin()
        {
            if (ValidUser() && ValidPass())
                return true;
            else
            {
                SkipLine();
                return InvalidCred();
            }
        }
    }

    public class UserDetail : CommonSystemMethod
    {
        public string name { get; set; }
        public string pass { get; set; }
        public bool blocked { get; set; }

        public bool BlankMessage()
        {
            ShowMsg("Can`t leave blank.");
            return false;
        }

        public bool InvalidCred()
        {
            ShowMsg("Invalid Cred...");
            return false;
        }

        public bool InvalidMessage()
        {
            ShowMsg("Please Enter a valid value.");
            return false;
        }
        public void EnterLine()
        {
            WriteMsg(30, "-",1);
        }
        public bool BlockLogin()
        {
            SkipLine();
            WriteMsg(10,"-",10,"*",10,"-");
            SkipLine();
            ShowMsg("Too many attempts");
            ShowMsg("You are Blocked");
            return true;
        }
    }
}
