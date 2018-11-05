 /*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package data_generator_reader;

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
        
        //DataGenerator generator = DataGenerator.getInstance();
        
        //Below is the sample for how you can use reader. you might wanna 
        //delete it once you understood.
        DataReader orderReader = new DataReader((Constants.ORDER_FILE_PATH));
        String[] orderRow;
        Map<Integer, Order> orders = DataStore.getInstance().getOrders();
        Map<Integer, Item> items = DataStore.getInstance().getItems();
        while((orderRow = orderReader.getNextRow()) != null){
            if(orders.containsKey(Integer.parseInt(orderRow[0]))){
            Item item = new Item(Integer.parseInt(orderRow[1]),Integer.parseInt(orderRow[2]),Integer.parseInt(orderRow[4]),Double.parseDouble(orderRow[6]),Integer.parseInt(orderRow[3]));
            orders.get(Integer.parseInt(orderRow[0])).getItems().add(item);
            }
            else{
            ArrayList<Item> itemsList = new ArrayList<>();
            Item item = new Item(Integer.parseInt(orderRow[1]),Integer.parseInt(orderRow[2]),Integer.parseInt(orderRow[4]),Double.parseDouble(orderRow[6]),Integer.parseInt(orderRow[3]));
            itemsList.add(item);
            Order order = new Order(Integer.parseInt(orderRow[1]),itemsList,Integer.parseInt(orderRow[5]));
            orders.put(Integer.parseInt(orderRow[0]), order);
            items.put(Integer.parseInt(orderRow[1]), item); 
            }
        }
        System.out.println(orders.toString());
        System.out.println("_____________________________________________________________");
        DataReader productReader = new DataReader(Constants.PROD_CAT_PATH);
        String[] prodRow;
        Map<Integer, Product> products= DataStore.getInstance().getProducts();
        while((prodRow = productReader.getNextRow()) != null){
                Product newProduct= new Product(Integer.parseInt(prodRow[0]),Integer.parseInt(prodRow[1]),Integer.parseInt(prodRow[2]),Integer.parseInt(prodRow[3]));
                 products.put(Integer.parseInt(prodRow[0]), newProduct);
              System.out.println("dg");   
        }
        
    }

    
}
