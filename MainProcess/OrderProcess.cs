using InterfaceLayer;

namespace MainProcess
{
    public class OrderProcess : CommonSystemMethod, IOrderProcess
    {
        public int TotalBillAmount { get; set; }
        public string UserChoice { get; set; }

        public string[] BilledItem = new string[101];

        public int Itemcount = 1;

        private bool FirstTime = true;
        public void PrceedOrderProcs(string[] OrderBook, out int PrintBillAmount, out string[] PrintBill)
        {
            LoopOrder(OrderBook);
            PrintBillAmount = TotalBillAmount;
            PrintBill = BilledItem;
        }

        private int GetItemPrice(int ItemIndex, string[] OrderBook)
        {
            return Conv_Int(OrderBook[ItemIndex].Substring(30));
        }

        private void LoopOrder(string[] OrderBook)
        {
            int MaxIndexValue = OrderBook.Length - 1;
            int MaxPrintLimit = 0;
            do
            {
                int ItemIndex;
                do
                {
                    if (FirstTime)
                    {
                        WriteMsg("Choose your Drink Like 1, 2 or 3 etc. : ");
                        FirstTime = false;
                    }
                    else
                    {
                        WriteMsg("Choose your Drink : ");
                    }
                    ItemIndex = Conv_Int(ReadLineMsg());

                    if ((ItemIndex <= MaxIndexValue) && !(ItemIndex < 1))
                    {
                        MaxPrintLimit = MultiplyItem(ItemIndex, OrderBook);
                        if (MaxPrintLimit == -1)
                            break;
                        TotalBillAmount += MaxPrintLimit;
                    }
                    else
                        ShowMsg("Your choice is invalid. Please try again...");

                } while (!((ItemIndex <= MaxIndexValue) && !(ItemIndex < 1)));
                do
                {
                    if (MaxPrintLimit == -1)
                        break;
                    ShowMsg("Do you want to buy another drink - y or n?");
                    UserChoice = ReadLineMsg();

                    if (UserChoice.ToUpper() != "Y" && UserChoice.ToUpper() != "N")
                        ShowMsg("Your choice is invalid. Please try again...");

                } while (UserChoice.ToUpper() != "Y" && UserChoice.ToUpper() != "N") ;

                if (MaxPrintLimit == -1)
                    break;

            } while (UserChoice.ToUpper() != "N");

        }

        private int MultiplyItem(int ItemIndex, string[] OrderBook)
        {
            int PricePerItem = GetItemPrice(ItemIndex, OrderBook);
            int Quantity;
            int AmountPerItem = 0;
            
            do
            {
                WriteMsg("Enter Multiple Quantity : ");
                Quantity = Conv_Int(ReadLineMsg());

                if (Quantity > 0 && Quantity < 10001)
                {
                    if (Itemcount < 101)
                    {
                        AmountPerItem = PricePerItem * Quantity;
                        BilledItem[Itemcount] = OrderedItem(ItemIndex, Quantity, AmountPerItem, OrderBook);
                        Itemcount++;
                    }
                    else AmountPerItem = -1;
                }
                else
                    ShowMsg("Please enter a number between 1 and 10000");

            } while (!((Quantity > 0) && (Quantity < 10001)));

            return AmountPerItem;

        }

        public string OrderedItem(int ItemIndex, int Quantity,int AmountPerItem, string[] OrderBook)
        {
            string Item = OrderBook[ItemIndex].Substring(4) + "\t" + AlignQty_Amount(Quantity, AmountPerItem);
            
            return Item;
        }

        private string AlignQty_Amount(int Qty, int Amount)
        {
            string AlignedQty_Amount = "X/" + Qty;
            int GetSapce = 13 - AlignedQty_Amount.Length;
            AlignedQty_Amount = AlignedQty_Amount.Replace("/", ReturnRepeatMsg(GetSapce, " ")) + "    =/" + Amount;

            GetSapce = 32 - AlignedQty_Amount.Length;

            AlignedQty_Amount = AlignedQty_Amount.Replace("/", ReturnRepeatMsg(GetSapce, " "));

            return AlignedQty_Amount;
        }
    }
}
