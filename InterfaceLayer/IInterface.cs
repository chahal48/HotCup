using System;

namespace InterfaceLayer
{
    public interface ISucessLogin
    {
        bool SucessLogin(string AutoUser, string Autopass, out string LoginUser, out string LoginPass);
    }
    public interface ILoginData
    {
        void GetUserData(out string User, out string pass);
        void SaveUserData(string User, string pass);
    }
    public interface IShowMenu
    {
        void ShowMenu(string[] OrderBook);
    }
    public interface IOrderProcess
    {
        void PrceedOrderProcs(string[] OrderBook, out int Total,out string[] PrintBill);
    }
    public interface IMenuDefineProcess
    {
        string[] OrderMenuInitialize(string SecurityLevel);
    }
    public interface IPrintBill
    {
        void DetailedBill(int Total, string[] PrintBill);
        void SummrizedBill(int Total);
    }
    public interface IMainLogo
    {
        void MainLogo();
    }

    public interface ICommon_Write_Method
    {
        string ReadLineMsg();
        string ReturnRepeatMsg(int repeatMsg, string msg);
        void HoldScreen();
        void SkipLine();
        void SkipLine(int repeat);
        void ShowMsg(string msg);
        void WriteMsg(string msg);
        void WriteMsg(int repeatMsg, string msg);
        void WriteMsg(int repeatMsg, string msg, int skipLine);
        void WriteMsg(int repeatMsg1, string msg1, int repeatMsg2, string msg2);
        void WriteMsg(int repeatMsg1, string msg1, int repeatMsg2, string msg2, int repeatMsg3, string msg3);
    }

    public interface ICommon_Convert_Method
    {
        string Conv_String(int iMsg);
        int Conv_Int(string Msg);
    }

    public class CommonSystemMethod : ICommon_Write_Method, ICommon_Convert_Method
    {
        public string ReadLineMsg()
        {
            return Console.ReadLine();
        }
        public void WriteMsg(string msg)
        {
            Console.Write(msg);
        }
        public void ShowMsg(string msg)
        {
            Console.WriteLine(msg);
        }
        public void WriteMsg(int repeatMsg,  string msg)
        {
            for (int i = 0; i < repeatMsg; i++)
            {
                Console.Write(msg);
            }
        }
        public void WriteMsg(int repeatMsg1, string msg1, int skipLine)
        {
            WriteMsg(repeatMsg1, msg1);
            SkipLine(skipLine);
        }
        public void WriteMsg(int repeatMsg1, string msg1, int repeatMsg2, string msg2)
        {
            WriteMsg(repeatMsg1, msg1);
            WriteMsg(repeatMsg2, msg2);
        }
        public void WriteMsg(int repeatMsg1, string msg1, int repeatMsg2, string msg2, int repeatMsg3, string msg3)
        {
            WriteMsg(repeatMsg1, msg1);
            WriteMsg(repeatMsg2, msg2);
            WriteMsg(repeatMsg3, msg3);
        }
        public void SkipLine(int repeat)
        {
            for (int i = 0; i < repeat; i++)
            {
                SkipLine();
            }
        }
        public void SkipLine()
        {
            Console.WriteLine();
        }
        
        public void ShowLogo(string user)
        {
            ClearConsole();
            WriteMsg(12, " ", 1, "HotCup");
            SkipLine();
            WriteMsg(12, " ", 6, "=", 12, " ");
            if (user == null || user == "")
                SkipLine();
            if (user != null && user != "")
                WriteMsg(1, "{" + user + "}",1);
        }
        public void ShowLogo2(string user)
        {
            ClearConsole();
            WriteMsg(30, " ", 1, "HotCup");
            SkipLine();
            WriteMsg(30, " ", 6, "=", 20, " ");
            if (user != null && user != "")
                WriteMsg(1, "{" + user + "}", 1);
        }

        public string Conv_String(int iMsg)
        {
            return Convert.ToString(iMsg);
        }

        public int Conv_Int(string Msg)
        {
            if (int.TryParse(Msg, out int iMsg))
            return iMsg;
            else return -1;
        }

        public void ClearConsole()
        {
            Console.Clear();
        }

        public void HoldScreen()
        {
            Console.ReadKey();
        }

        public string ReturnRepeatMsg(int repeatMsg, string msg)
        {
            string RepeatedMsg = string.Empty;
            for (int i = 0; i < repeatMsg; i++)
            {
                RepeatedMsg += msg;
            }
            return RepeatedMsg;
        }
    }
}
