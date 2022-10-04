using InterfaceLayer;

namespace MainProcess
{
    public class MenuDisplay : CommonSystemMethod , IShowMenu
    {
        public void ShowMenu(string[] MenuArray)
        {
            for (int i = 0; i < MenuArray.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        PrintHeader(MenuArray[i]);
                        break;
                    default:
                        PrintBody(MenuArray[i]);
                        break;
                }
            }
        }
        private void PrintHeader(string msg)
        {
            ShowMsg(msg);
            WriteMsg(38, "-", 1);
        }
        private void PrintBody(string msg)
        {
            ShowMsg(msg);
        }
    }
}
