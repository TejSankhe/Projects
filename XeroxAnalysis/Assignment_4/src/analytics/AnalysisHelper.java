/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package analytics;

import common.DataStore;
import entities.Customer;
import entities.Product;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;
import java.util.Map;

/**
 *
 * @author Admin
 */
public class AnalysisHelper  {
    
    public void getThreeMostPopularProducts()
    {
        Map<Integer, Product> products= DataStore.getInstance().getProducts(); 
        List<Product> productList= (ArrayList<Product>)products.values();
        productList.sort(new Comparator<Product>(){

            @Override
            public int compare(Product o1, Product o2) {
                return o1.getPopularity()- o2.getPopularity();
            }
            
        });
        
        for(int i=0; i <3 ;i++)
        {
            System.out.println("Top 3 most popular Products");
            System.out.println(productList.get(0).getId());
        }
        Map<Integer, Customer> customers= DataStore.getInstance().getCustomers(); 
        List<Customer> customerList= (ArrayList<Customer>)customers.values();
        //customerList.sort((Customer o1, Customer o2)->o2.getTotalItemBought()-o1.getTotalItemBought());
    }
    
}
