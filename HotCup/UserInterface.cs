using InterfaceLayer;
using ProcessLayer;
using System.Threading;

namespace HotCup
{
    class UserInterface : CommonSystemMethod
    {
        string user, password;
        string[] OrderBookArray, PrintBillArray;
        int Total,ExitLoop;
        bool LoginSucess = false;
        
        public void Run()
        {
            do 
            { 
                do
                {
                    GetAutoLoginData();
                    LoginPage();
                    if (LoginSucess)
                    {
                        SaveAutoLoginData(user,password);

                        DefineOrderMenuPage();
                        ShowMenuPage(OrderBookArray);
                        ProcessOrderPage();
                        PrintDetailBillPage();
                        ExitLoop = HomePage();
                    }
                } while (!(ExitLoop == 2 || ExitLoop == 3));

                if (ExitLoop == 2)
                {
                    SaveAutoLoginData("", "");
                }

            } while (ExitLoop != 3);
        }

        private void GetAutoLoginData()
        {
            ILoginData autoLogin = ProcsLayer.LoginDataProc();
            autoLogin.GetUserData(out user, out password);
        }
        private void SaveAutoLoginData(string UserName, string UserPass)
        {
            ILoginData autoLogin = ProcsLayer.LoginDataProc();
            autoLogin.SaveUserData(UserName, UserPass);
        }
        private void LoginPage()
        {
            ShowLogo(user);
            ISucessLogin loginProcs = ProcsLayer.LoginProcs();
            LoginSucess = loginProcs.SucessLogin(user, password, out user, out password);
        }
        private void DefineOrderMenuPage()
        {
            IMenuDefineProcess menuDefineProcess = ProcsLayer.MenuInitialize();
            OrderBookArray = menuDefineProcess.OrderMenuInitialize(user);
        }
        private void ShowMenuPage(string[] MenuArray)
        {
            ShowLogo(user);
            IShowMenu menuDisplayProc = ProcsLayer.MenuDisplayProcs();
            menuDisplayProc.ShowMenu(MenuArray);
        }
        private void ProcessOrderPage()
        {
            IOrderProcess orderProcs = ProcsLayer.OrderProcs();
            orderProcs.PrceedOrderProcs(OrderBookArray,
                                        out Total,
                                        out PrintBillArray);
        }
        private void PrintDetailBillPage()
        {
            ShowLogo2(user);
            IPrintBill printBill = ProcsLayer.CreateBill();
            printBill.DetailedBill(Total, PrintBillArray);
        }
        private void PrintSummrizedBillPage()
        {
            ShowLogo(user);
            IPrintBill printBill = ProcsLayer.CreateBill();
            printBill.SummrizedBill(Total);
        }

        private int HomePage()
        {
            int Input_Value = -1;
            int Get_Value = -1;
            SkipLine(2);
            ShowMsg("SELECT YOUR CHOICE:");
            ShowMsg("1: Home");
            ShowMsg("2: Logout");
            ShowMsg("3: Exit");
            SkipLine();
            do
            {
                WriteMsg("Please Enter your Choice: ");
                Input_Value = Conv_Int(ReadLineMsg());
                
                switch (Input_Value)
                {
                    case 1:
                    case 2:
                    case 3:
                        Get_Value = Input_Value;
                        break;
                    default:
                        ShowMsg("Please enter a valid value.");
                        SkipLine();
                        break;
                }


            } while (!(Get_Value == 1 || Get_Value == 2 || Get_Value == 3));

            return Get_Value;

        }
    }
}
