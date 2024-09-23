using System.Security.Cryptography;

class PracticeQueries {
    public static void main(String[] args) {
        List<Sales> sales = PracticeQueries.GenerateSalesClasses();
        //finds all the sales that have a price over 10
        IEnumerable<Sales> ExpensiveItems = 
            from s in sales
            where s.PricePerItem > 10.0
            select s;
        //gets all sale objects where quantity is 1 and results in descending order for the price of the item 
        IEnumerable<Sales> OneItemSold = 
            from s1 in sales
            where s1.Quantity == 1
            orderby s1.PricePerItem descending
            select s1;
        //gets the items that are t and dont have expedited shipping 
        IEnumerable<Sales> Tea = 
            from s2 in sales
            where s2.Item.Equals("Tea") && s2.ExpeditedShipping is false
            select s2;
        IEnumerable<Sales> addresses = 
            from s3 in sales
            where (s3.PricePerItem * s3.Quantity) > 100
            select s3;
        IEnumerable<SalesSummary> salesSummaries = 
            from s4 in sales
            where s4.Item.Contains("LLC")
            let totalPrice = s4.Quantity * s4.PricePerItem
            orderby totalPrice
            select new SalesSummary(s4.Item, totalPrice, s4.ExpeditedShipping ? s4.Address + " EXPEDITE" : s4.Address);

    }

    public static List<Sales> GenerateSalesClasses() {
        List<Sales> sales = new List<Sales>();
        int counter = 0;
        bool ex = false;
        for (int i = 0; i < 30; i++) {
            counter++;
            if (i % 2 == 0) {
                ex = true;
            }
            else {
                ex = false;
            }
            sales.Add( new Sales(
                $"Item{i}",
                $"Customer{counter}",
                4.00 * (counter + i) - i * 2,
                counter,
                $"Address{counter}",
                ex
            ));
            if (counter > 3) {
                counter = 0;
            }
        }
        return sales;
    }
}