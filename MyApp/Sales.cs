public class Sales(string Item, string Customer, double PricePerItem, int Quantity, string Address, bool ExpeditedShipping) {
    
    public string Item { get; set; } = Item;
    public string Customer { get; set; } = Customer;
    public double PricePerItem { get; set; } = PricePerItem;
    public int Quantity {get; set; } = Quantity;
    public string Address { get; set; } = Address;
    public bool ExpeditedShipping { get; set; } = ExpeditedShipping;

}