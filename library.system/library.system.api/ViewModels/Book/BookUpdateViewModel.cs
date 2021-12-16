namespace library.system.api.ViewModels.Book
{
    public class BookUpdateViewModel
    {
        public int Id { get; set; }

        public string ISBN { get; set; }

        public string BarCode { get; set; }
        public int Year { get; set; }

        public string Type { get; set; }

        public string Title { get; set; }

        public string InitialCondition { get; set; }

        public decimal OrderCost { get; set; }

        public string Publisher { get; set; }

        public string ModifyUserId { get; set; }

        public int StatusId { get; set; }
    }
}
