using InterfaceLayer;

namespace MainProcess
{
    public class PrintBill : CommonSystemMethod, IPrintBill
    {
        public void SummrizedBill(int TotalBillAmount)
        {
            WriteMsg(30, "-");
            SkipLine(1);
            ShowMsg("Thank you for shopping with us");
            ShowMsg("Total Bill Amount : " + Conv_String(TotalBillAmount));
        }
        public void DetailedBill(int Total, string[] PrintBill)
        {
            ShowMsg("OrderedItem             Price\t\t Qty  \t  AmountPerItem");
            WriteMsg(63, "-", 1);
            BilledItem(PrintBill);

            WriteMsg(63, "-", 1);
            ShowMsg(PrintTotalAmount(Total));

            WriteMsg(63, "-", 1);
            WriteMsg(17, " ", 1, "Thank you for shopping with us");
        }
        private void BilledItem(string[] PrintBill)
        {
            for (int i = 0; i < PrintBill.Length; i++)
            {
                if (PrintBill[i] != null)
                    ShowMsg(PrintBill[i]);
            }
        }

        private string PrintTotalAmount(int Total)
        {
            string TotalAmountMsg = "Total Bill Amount :/" + Total;
            int GetSapce = 64 - TotalAmountMsg.Length;
            TotalAmountMsg = TotalAmountMsg.Replace("/", ReturnRepeatMsg(GetSapce, " "));
            return TotalAmountMsg;
        }
    }
}
