 /*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package data_generator_reader;


import analytics.AnalysisHelper;
import common.Constants;
import common.DataStore;
import entities.*;
import java.io.IOException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

/**
 *
 * @author harshalneelkamal
 */
public class GateWay {
    
    public static void main(String args[]) throws IOException, NoSuchFieldException, IllegalArgumentException, IllegalAccessException{
        
        DataReader orderReader = new DataReader((Constants.ORDER_FILE_PATH));
        String[] orderRow;
        DataReader productReader = new DataReader(Constants.PROD_CAT_PATH);
        String[] prodRow;
        Map<Integer, Order> orders = DataStore.getInstance().getOrders();
        Map<Integer, Item> items = DataStore.getInstance().getItems();
        Map<Integer, Product> products = DataStore.getInstance().getProducts();
        while((prodRow = productReader.getNextRow()) != null){
                Product newProduct= new Product(Integer.parseInt(prodRow[0]),Integer.parseInt(prodRow[1]),Integer.parseInt(prodRow[2]),Integer.parseInt(prodRow[3]));
                 products.put(Integer.parseInt(prodRow[0]), newProduct);  
        }
        Map<Integer, SalesPerson> salespersonList = DataStore.getInstance().getSalesPerson();
        Map<Integer, Customer> customers = DataStore.getInstance().getCustomers();
        Item item;
        while((orderRow = orderReader.getNextRow()) != null){
            
            //Calculating Popularity
            int producId=Integer.parseInt(orderRow[2]);
            Product pro= products.get(producId);
            int tempPopularity= pro.getPopularity()+ Integer.parseInt(orderRow[3]);
            pro.setPopularity(tempPopularity);
            
            if(orders.containsKey(Integer.parseInt(orderRow[0]))){
            item = new Item(Integer.parseInt(orderRow[1]),Integer.parseInt(orderRow[2]),Integer.parseInt(orderRow[4]),Double.parseDouble(orderRow[6]),Integer.parseInt(orderRow[3]));
            orders.get(Integer.parseInt(orderRow[0])).getItems().add(item);
            }
            else{
            ArrayList<Item> itemsList = new ArrayList<>();
            item = new Item(Integer.parseInt(orderRow[1]),Integer.parseInt(orderRow[2]),Integer.parseInt(orderRow[4]),Double.parseDouble(orderRow[6]),Integer.parseInt(orderRow[3]));
            itemsList.add(item);
            Order order = new Order(Integer.parseInt(orderRow[1]),itemsList,Integer.parseInt(orderRow[5]));
            orders.put(Integer.parseInt(orderRow[0]), order);
            }
            items.put(Integer.parseInt(orderRow[1]), item);
            // calculating sales person customer parameters
            SalesPerson salesPerson= new SalesPerson((Integer.parseInt(orderRow[4])));
            double targetprice = products.get(Integer.parseInt(orderRow[2])).getTarget_price();
            double salesPrice = Double.parseDouble(orderRow[6]);
            double priceWRTTarget = salesPrice-targetprice;
            double totalpriceWRTTarget = priceWRTTarget+salesPerson.getTotalpriceWRTTarget();
            salesPerson.setTotalpriceWRTTarget(totalpriceWRTTarget);
            int totalItemSold = salesPerson.getTotalItemSold()+Integer.parseInt(orderRow[3]);
            salesPerson.setTotalItemSold(totalItemSold);
            salespersonList.put(Integer.parseInt(orderRow[4]), salesPerson);
            
            // calculating customer parameters
            Customer customer = new Customer(Integer.parseInt(orderRow[5]));
            long totalItemBought = customer.getTotalItemBought()+Integer.parseInt(orderRow[3]);
            double totalPriceOfItemBought = customer.getTotalPriceOfItemBought()+Integer.parseInt(orderRow[3])*Integer.parseInt(orderRow[6]);
            customer.setTotalItemBought(totalItemBought);
            customer.setTotalPriceOfItemBought(totalPriceOfItemBought);
            customers.put(Integer.parseInt(orderRow[5]), customer);
        }
        AnalysisHelper analysisHelper= new AnalysisHelper();
        analysisHelper.getThreeMostPopularCustomers();
        analysisHelper.getTopThreeSalesPerson();
        analysisHelper.getTotalRevenueForTheYear();
    }
    
    
}
