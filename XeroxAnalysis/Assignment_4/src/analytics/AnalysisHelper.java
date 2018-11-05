/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package analytics;

import common.DataStore;
import entities.Customer;
import entities.Product;
import entities.SalesPerson;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;
import java.util.Map;

/**
 *
 * @author Admin
 */
public class AnalysisHelper {

    public void getThreeMostPopularProducts() {
        Map<Integer, Product> products = DataStore.getInstance().getProducts();
        List<Product> productList = new ArrayList(products.values());
        productList.sort(new Comparator<Product>() {

            @Override
            public int compare(Product o1, Product o2) {
                return o2.getPopularity() - o1.getPopularity();
            }

        });
        System.out.println("Top 3 most popular Products");
        for (int i = 0; i < 3; i++) {
            System.out.println(productList.get(i).getId());
        }
    }

    public void getThreeMostPopularCustomers() {

        Map<Integer, Customer> customers = DataStore.getInstance().getCustomers();
        List<Customer> customerList = new ArrayList(customers.values());
        customerList.sort((Customer o1, Customer o2) -> (int) (o2.getTotalItemBought() - o1.getTotalItemBought()));
        System.out.println("Top 3 most popular Customers as per Total items bought");
        for (int i = 0; i < 3; i++) {
            System.out.println(customerList.get(i).getId());
        }
        customerList.sort((Customer o1, Customer o2) -> (int) (o2.getTotalPriceOfItemBought() - o1.getTotalPriceOfItemBought()));
        
        System.out.println("Top 3 most popular Customers as per total price of items bought");
        for (int i = 0; i < 3; i++) {
            System.out.println(customerList.get(i).getId());
        }
    }
    public void getTopThreeSalesPerson() {

        Map<Integer, SalesPerson> salesPerson = DataStore.getInstance().getSalesPerson();
        List<SalesPerson> salesList = new ArrayList(salesPerson.values());
        salesList.sort((SalesPerson o1, SalesPerson o2) ->  (int) (o2.getTotalpriceWRTTarget()- o1.getTotalpriceWRTTarget()));
        System.out.println("Top 3 most popular Salesperson as per crossing target price");
        for (int i = 0; i < 3; i++) {
            System.out.println(salesList.get(i).getId());
        }
        salesList.sort((SalesPerson o1, SalesPerson o2) ->  (int) (o2.getTotalItemSold()- o1.getTotalItemSold()));
        
        System.out.println("Top 3 most popular SalesPerson as per items sold");
        for (int i = 0; i < 3; i++) {
            System.out.println(salesList.get(i).getId());
        }
    }
    
    public void getTotalRevenueForTheYear(){
        System.out.println("Total revenue = "+DataStore.getInstance().getTotalRevenue());
        
    }
}
