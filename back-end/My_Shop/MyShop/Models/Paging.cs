namespace MyShop.Models
{
    public class Paging
    {
        public int? NumberOfPage {  get; set; }
        public int? PageIndex { get; set; }
        public List<int> CategoryIds { get; set;}
        public string searchName { get; set; }
    }
}
