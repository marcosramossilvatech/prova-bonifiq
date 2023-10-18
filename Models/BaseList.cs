namespace ProvaPub.Models
{
    public class BaseList <T>
    {
        public List<T> Lista { get; set; }
        public int TotalCount { get; set; }
        public bool HasNext { get; set; }
    }
}
