namespace AtessToDoAPI.Models
{
    public class UserItem
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public Item[] Items { get; set; }
    }
}
