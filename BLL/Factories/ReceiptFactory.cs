namespace BLL.Factories
{
    public static class ReceiptFactory
    {
        public static BllProvider GetReceipt()
        {
            return new BLL.Receipt();
        }
    }
}
