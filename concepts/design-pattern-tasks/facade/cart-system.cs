using System;
namespace Internship
{
    public class Order
    {
        List<Product> ordered_products;
        private string order_id;
        public Order(string order_id, List<Product> ordered_products)
        {
            this.order_id = order_id;
            this.ordered_products = ordered_products;
        }
        public List<Product> Ordered_products
        {
            get { return ordered_products; }
            set
            {
                ordered_products = value;
            }
        }
        public string Order_Id
        {
            get { return order_id; }
            set
            {
                order_id = value;
            }
        }
    }
    public class Product
    {
        string product_id;
        string product_details;
        public Product(string product_id, string product_details)
        {
            this.product_id = product_id;
            this.product_details = product_details;
        }
        public string ProductID
        {
            get { return product_id; }
            set
            {
                product_id = value;
            }
        }
        public string ProductDetails
        {
            get { return product_details; }
            set
            {
                product_details = value;
            }
        }
    }
    public interface IOrderProcessing
    {
        void placeOrder(Order order);
        void cancelOrder(Order order);
        void HandleOrder();
    }
    public class OrderProcessor : IOrderProcessing
    {
        List<Order> orderList = new List<Order>();

        public void placeOrder(Order order)
        {
            orderList.Add(order);
            Console.WriteLine("Your order has been placed!");
        }
        public void cancelOrder(Order order)
        {
            orderList.Remove(order);
            Console.WriteLine("Order no. {0} has been canceled!", order.Order_Id);
        }
        public void HandleOrder()
        {
            if (orderList.Count() != 0)
            {
                while (true)
                {
                    Console.WriteLine("\nYour Orders:");
                    int i = 1;
                    foreach (var order in orderList)
                    {
                        Console.WriteLine("\nOrder no. {0}:", order.Order_Id);
                        foreach (var product in order.Ordered_products)
                        {
                            Console.WriteLine("\nProduct ID: {0}\t Product Details: {1}", product.ProductID, product.ProductDetails);
                        }
                        i++;
                    }
                    Console.WriteLine("\nMENU\n\n1. Cancel Order\t2. Exit");
                    Console.WriteLine("\nSelect an option:");

                    string selection = Console.ReadLine();
                    switch (selection)
                    {
                        case "1":
                            {
                                Console.WriteLine("\nEnter the Order number to be cancelled:");
                                string cancelOrderNum = Console.ReadLine();

                                foreach (var order in orderList)
                                {
                                    if (order.Order_Id == cancelOrderNum)
                                    {
                                        cancelOrder(order);
                                        return;
                                    }
                                }
                                Console.WriteLine("\nInvalid order number!");
                                break;
                            }
                        case "2":
                            {
                                return;
                            }
                        default:
                            {
                                Console.WriteLine("\nInvalid selection!");
                                break;
                            }
                    }
                }
            }
            else
            {
                Console.WriteLine("\nNo orders placed yet!");
            }

        }
    }
    public interface ICartManagement
    {
        void addProductToCart(Product product);
        void removeProductFromCart(Product product);
        void HandleCart(IOrderProcessing orderProcessor);
    }
    public class CartManager : ICartManagement
    {
        List<Product> cart_content = new List<Product>();

        public void addProductToCart(Product product)
        {
            cart_content.Add(product);
        }
        public void removeProductFromCart(Product product)
        {
            cart_content.Remove(product);
        }
        public void emptyCart()
        {
            cart_content = new List<Product>();
        }
        public void HandleCart(IOrderProcessing orderProcessor)
        {
            if (cart_content.Count() != 0)
            {

                Console.WriteLine("\nCart Content:\n");
                foreach (var product in cart_content)
                {
                    Console.WriteLine("\nProduct ID: {0}\t Product Details: {1}", product.ProductID, product.ProductDetails);
                }

                while (true)
                {
                    Console.WriteLine("\nMENU\n\n1. Place Order\t2. Exit");
                    Console.WriteLine("\nSelect an option:");

                    string selection = Console.ReadLine();
                    switch (selection)
                    {
                        case "1":
                            {
                                string randomId = Convert.ToString(new Random().NextInt64(1, 100));
                                orderProcessor.placeOrder(new Order(randomId, cart_content));
                                emptyCart();
                                return;
                            }
                        case "2":
                            {
                                return;
                            }
                        default:
                            {
                                Console.WriteLine("\nInvalid selection!");
                                break;
                            }
                    }
                }
            }
            else
            {
                Console.WriteLine("\nNo items in the Cart!");
            }
        }
    }
    public class CartSystemFacade
    {
        private readonly IOrderProcessing _orderProcessor;
        private readonly ICartManagement _cartManager;
        private List<Product> _products;
        public CartSystemFacade(IOrderProcessing orderProcessor, ICartManagement cartManager)
        {
            _orderProcessor = orderProcessor;
            _cartManager = cartManager;
            _products = new List<Product>();

            Product firstProduct = new Product("1A", "Laptop, 256GB SSD, 1TB HDD, Stock = 10");
            Product secondProduct = new Product("1B", "Laptop, 256GB SSD, 1TB HDD, Stock = 15");

            _products.Add(firstProduct);
            _products.Add(secondProduct);
        }
        public void ChooseProducts(List<Product> products)
        {
            while (true)
            {
                Console.WriteLine("\nChoose a product via ID to add to your cart:\n");
                foreach (var product in products)
                {
                    Console.WriteLine("\nProduct ID: {0}\t Product Details: {1}", product.ProductID, product.ProductDetails);
                }
                Product selectedProduct = null;
                string selectedProductId = Console.ReadLine();

                foreach (var product in _products)
                {
                    if (product.ProductID == selectedProductId)
                    {
                        selectedProduct = product;
                    }
                }
                if (selectedProduct != null)
                {
                    _cartManager.addProductToCart(selectedProduct);
                    Console.WriteLine("\nProduct added to cart!");
                }
                else
                {
                    Console.WriteLine("\nProduct ID not found!");
                }
                while (true)
                {
                    Console.WriteLine("\nGo to Menu? (Y/N)");
                    string goToSelection = Console.ReadLine();
                    if (goToSelection == "Y")
                    {
                        return;
                    }
                    else if (goToSelection != "N")
                    {
                        Console.WriteLine("\nInvalid selection!");
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        public void StartShopping()
        {
            while (true)
            {
                Console.WriteLine("\nMENU\n\n1. Shop\t2. Go To Cart\t3. View Orders\t4. Exit Shop");
                Console.WriteLine("\nSelect an option:");
                string selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        {
                            ChooseProducts(_products);
                            break;
                        }
                    case "2":
                        {
                            _cartManager.HandleCart(_orderProcessor);
                            break;
                        }
                    case "3":
                        {
                            _orderProcessor.HandleOrder();
                            break;
                        }
                    case "4":
                        {
                            return;
                        }
                    default:
                        {
                            Console.WriteLine("\nInvalid selection!");
                            break;
                        }
                }
            }
        }
    }
    public class ShoppingCartSystem
    {
        public void ManageCartSystem()
        {
            OrderProcessor op = new OrderProcessor();
            CartManager cm = new CartManager();
            CartSystemFacade cartFacade = new CartSystemFacade(op, cm);

            cartFacade.StartShopping();
        }
    }
}