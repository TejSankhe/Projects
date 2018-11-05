/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package common;

import entities.Customer;
import entities.Item;
import entities.Order;
import entities.Product;
import entities.SalesPerson;
import java.util.HashMap;
import java.util.Map;

/**
 *
 * @author Admin
 */
public class DataStore {
    private static DataStore dataStore;
    
    private Map<Integer, Product> products;
    private Map<Integer, Order> orders;
    private Map<Integer, Item> items;
    private Map<Integer, Customer> customers;
    private Map<Integer, SalesPerson> salesPerson;

    public void setCustomers(Map<Integer, Customer> customers) {
        this.customers = customers;
    }

    public void setSalesPerson(Map<Integer, SalesPerson> salesPerson) {
        this.salesPerson = salesPerson;
    }
    
    
    public Map<Integer, Customer> getCustomers() {
        return customers;
    }

    public Map<Integer, SalesPerson> getSalesPerson() {
        return salesPerson;
    }

    public Map<Integer, Product> getProducts() {
        return products;
    }

    public Map<Integer, Order> getOrders() {
        return orders;
    }

    public Map<Integer, Item> getItems() {
        return items;
    }

    public void setProducts(Map<Integer, Product> products) {
        this.products = products;
    }

    public void setOrders(Map<Integer, Order> orders) {
        this.orders = orders;
    }

    public void setItems(Map<Integer, Item> items) {
        this.items = items;
    }
    
    
    
    private DataStore()
    {
        products= new HashMap<>();
        orders= new HashMap<>();
        items= new HashMap<>();
        customers= new HashMap<>();
        salesPerson= new HashMap<>();
    }
    
    public static DataStore getInstance()
    {
        if(dataStore == null)
        {
            dataStore= new DataStore();
        }
        return dataStore;
    }
}
