namespace UsluzniObrt.Model
{
    /// <summary>
    /// tablica za "Shopping cart"
    /// </summary>
    public class OrderItem
    {
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public int MenuItemId { get; set; }
        public virtual MenuItem MenuItem { get; set; }

        public int Quantity { get; set; }
    }
}
