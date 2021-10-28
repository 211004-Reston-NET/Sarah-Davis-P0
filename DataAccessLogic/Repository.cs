using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Models;

namespace DataAccessLogic
{

    public class Repository{

    private const string _filepath = "./../DataAccessLogic/Database/";
    
    private string _jsonString;
    
    public List<Customer> GetAllCustomers()
    {
        _jsonString = File.ReadAllText(_filepath + "Customer.json");
        return JsonSerializer.Deserialize<List<Customer>>(_jsonString);
    }
    public Customer AddCustomer(Customer p_customer)
    {
        List<Customer> ListofCustomers = GetAllCustomers();
        ListofCustomers.Add(p_customer);
        _jsonString = JsonSerializer.Serialize(ListofCustomers,new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filepath + "Customer.json", _jsonString);
        return p_customer;
    }



}
}