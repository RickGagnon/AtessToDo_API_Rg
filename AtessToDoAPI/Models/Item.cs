namespace AtessToDoAPI.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemDescription { get; set; }
        public bool  ItemCompleted { get; set; }
        public int CategoryId { get; set; }


    }
}
