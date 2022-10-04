using MainProcess;
using InterfaceLayer;


namespace ProcessLayer
{
    public static class ProcsLayer
    {
        public static ISucessLogin LoginProcs()
        {
            return new LoginProcs();
        }

        public static IShowMenu MenuDisplayProcs()
        {
            return new MenuDisplay();
        }
        public static IOrderProcess OrderProcs()
        {
            return new OrderProcess();
        }
        public static IMenuDefineProcess MenuInitialize()
        {
            return new UserDefination();
        }
        public static IPrintBill CreateBill()
        {
            return new PrintBill();
        }
        public static ILoginData LoginDataProc()
        {
            return new FileReadWrite();
        }
    }
}
