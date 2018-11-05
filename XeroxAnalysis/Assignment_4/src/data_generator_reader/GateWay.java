 /*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package data_generator_reader;

import common.Constants;
import java.io.IOException;

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
        printRow(orderReader.getFileHeader());
        while((orderRow = orderReader.getNextRow()) != null){
            printRow(orderRow);
        }
        System.out.println("_____________________________________________________________");
        DataReader productReader = new DataReader(Constants.PROD_CAT_PATH);
        String[] prodRow;
        printRow(productReader.getFileHeader());
        while((prodRow = productReader.getNextRow()) != null){
            printRow(prodRow);
        }
    }
    
    public static void printRow(String[] row){
        for (String row1 : row) {
            System.out.print(row1 + ", ");
        }
        System.out.println("");
    }
    
}
