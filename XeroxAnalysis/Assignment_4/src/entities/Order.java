/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package entities;

import java.util.ArrayList;

/**
 *
 * @author harshalneelkamal
 */
public class Order {
    private int orderId;
    private ArrayList Items;
    private int customerId;

    public Order(int orderId, ArrayList Items, int customerId) {
        this.orderId = orderId;
        this.Items = Items;
        this.customerId = customerId;
    }

    public int getOrderId() {
        return orderId;
    }

    public void setOrderId(int orderId) {
        this.orderId = orderId;
    }

    public ArrayList getItems() {
        return Items;
    }

    public void setItems(ArrayList Items) {
        this.Items = Items;
    }

    public int getCustomerId() {
        return customerId;
    }

    public void setCustomerId(int customerId) {
        this.customerId = customerId;
    }
    
}