/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: User provides an invalid queue size (0 or negative)
        // Expected Result: The max queue size should default to 10 
        Console.WriteLine("Test 1");
        var service1 = new CustomerService(0); // invalid size
        Console.WriteLine($"Max queue size should default to 10: {service1}");
        var serviceNegative = new CustomerService(-5); // invalid size ( negative number)
        Console.WriteLine($"Max queue size should default to 10: {serviceNegative}");

        // Defect(s) Found: None

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Add a single customer to the queue 
        // Expected Result: The queue should contain that customer
        Console.WriteLine("Test 2");
        var service2 = new CustomerService(5);
        service2.AddNewCustomer();
        // Display the queue to verify the customer was added
        Console.WriteLine($"Queue after adding one customer: {service2}");

        // Defect(s) Found: None

        Console.WriteLine("=================");

        // Test 3
        // Scenario: Does the max queue size get enforced?
        // Expected Result: This should display an error message when trying to add a customer beyond the max size
        Console.WriteLine("Test 3");
        var service3 = new CustomerService(3);

        // Add three customers 
        service3.AddNewCustomer();
        service3.AddNewCustomer();
        service3.AddNewCustomer();
        // Attempt to add a fourth customer — this should trigger the error message
        service3.AddNewCustomer();
        // Display the queue to see the three customers only
        Console.WriteLine($"Current queue: {service3}");

        // Defect(s) Found: I needed to do >= instead of > in AddNewCustomer

        Console.WriteLine("=================");

        // Test 4
        // Scenario: Serve a customer after adding them to the queue
        // Expected Result: The first customer added should be dequeued and displayed
        Console.WriteLine("Test 4");

        // Create a queue with max size of 3
        var service4 = new CustomerService(3);
        // Add two customers
        service4.AddNewCustomer();
        service4.AddNewCustomer();

        // Serve the first customer — should display the first customer entered
        service4.ServeCustomer();
        // Serve the second customer — should display the second customer entered
        service4.ServeCustomer();
        // Display the queue to verify it is now empty
        Console.WriteLine($"Queue after serving all customers: {service4}");

        // Defect(s) Found: I needed to get the customer before removing from the list in ServeCustomer

        Console.WriteLine("=================");

        // Test 5
        // Scenario: Attempt to serve a customer when the queue is empty
        // Expected Result: An error message should be displayed
        Console.WriteLine("Test 5");

        // Create a queue with some max size
        var emptyQueue = new CustomerService(3);

        // Attempt to serve a customer from the empty queue
        emptyQueue.ServeCustomer();

        // Defect(s) Found: I needed to check the length in serve_customer and display an error message


    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
    if (_queue.Count == 0) {
        Console.WriteLine("No customers in the queue.");
        return;
    }

    var customer = _queue[0]; // get the customer first
    _queue.RemoveAt(0);       // then remove it
    Console.WriteLine(customer); // now print the details
}


    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}