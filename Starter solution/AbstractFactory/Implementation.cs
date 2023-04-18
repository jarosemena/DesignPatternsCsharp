namespace AbstractFactory
{
   public interface IShoppingCartPurcheseFactory
    {
        IDiscountService CreateDiscountService();
        IShippingCostsService CreateShippingCostsService();
    }

    public interface IDiscountService
    {
        int DiscountPersentage { get; }
    }
    
    /// <summary>
    /// Concrete Product Discount Product Belgium 
    /// </summary>
    public class BelgiumDiscountService : IDiscountService
    {
        public int DiscountPersentage => 20;
    }

    /// <summary>
    /// Concrete Product Discount Product France 
    /// </summary>
    public class FranceDiscountService : IDiscountService
    {
        public int DiscountPersentage => 10;
    }

    public interface IShippingCostsService
    {
        decimal ShippingCosts { get; }
    }

    /// <summary>
    /// Concrete Product ShippingCosts Product Belgium 
    /// </summary>
    public class BelgiumShippingCostsService : IShippingCostsService
    {
        public decimal ShippingCosts => 20;
    }

    /// <summary>
    /// Concrete Product ShippingCosts Product France 
    /// </summary>
    public class FranceShippingCostsService : IShippingCostsService
    {
        public decimal ShippingCosts => 25;
    }



    // factories 


    /// <summary>
    /// Concrete Factory  
    /// </summary>
    public class FrancesShoppingCartPurchaseFactory : IShoppingCartPurcheseFactory
    {
        public IDiscountService CreateDiscountService()
        {
            return new FranceDiscountService();
        }

        public IShippingCostsService CreateShippingCostsService()
        {
            return new FranceShippingCostsService();
        }
    }

    /// <summary>
    /// Concrete Factory  
    /// </summary>
    public class BelgiumShoppingCartPurchaseFactory : IShoppingCartPurcheseFactory
    {
        public IDiscountService CreateDiscountService()
        {
            return new BelgiumDiscountService();
        }

        public IShippingCostsService CreateShippingCostsService()
        {
            return new BelgiumShippingCostsService();
        }
    }


    public class ShoppingCart
    {
        private readonly IDiscountService _discountService;
        private readonly IShippingCostsService _shippingCostsService;
        private int _orderCosts;

        public ShoppingCart(IShoppingCartPurcheseFactory factory)
        {
            _discountService = factory.CreateDiscountService();
            _shippingCostsService  = factory.CreateShippingCostsService();
            _orderCosts = 200;
        }

        public void CalculateCosts()
        {
            Console.WriteLine($"Total costs = " +
                $"{_orderCosts - (_orderCosts / 100 * _discountService.DiscountPersentage) + _shippingCostsService.ShippingCosts}");
        }
    }
}
