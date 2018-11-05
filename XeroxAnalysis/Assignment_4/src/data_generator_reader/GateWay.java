 /*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package data_generator_reader;

import common.Constants;
import common.DataStore;
import entities.Product;
import java.io.IOException;
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
        while((orderRow = orderReader.getNextRow()) != null){
            for (String row1 : orderRow) {
                
        }
        }
        System.out.println("_____________________________________________________________");
        DataReader productReader = new DataReader(Constants.PROD_CAT_PATH);
        String[] prodRow;
        Map<Integer, Product> products= DataStore.getInstance().getProducts();
        while((prodRow = productReader.getNextRow()) != null){
                Product newProduct= new Product(Integer.parseInt(prodRow[0]),Integer.parseInt(prodRow[1]),Integer.parseInt(prodRow[2]),Integer.parseInt(prodRow[3]));
                 products.put(Integer.parseInt(prodRow[0]), newProduct);
        }
        
    }

    
}
