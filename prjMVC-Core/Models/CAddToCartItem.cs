namespace prjMVC_Core.Models
{
    public class CAddToCartItem
    {
        public int productId { get; set; }
        public int count { get; set; }
        public decimal price { get; set; }
        public decimal 小計 { get { return price * count; } }
        public TProduct product { get; set; }
    }
}
