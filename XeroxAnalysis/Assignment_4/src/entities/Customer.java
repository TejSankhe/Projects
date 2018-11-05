/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package entities;

/**
 *
 * @author harshalneelkamal
 */
public class Customer {
    private int id;
    private long totalItemBought;
    private double totalPriceOfItemBought;

    public Customer(int id) {
        this.id = id;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public long getTotalItemBought() {
        return totalItemBought;
    }

    public void setTotalItemBought(long totalItemBought) {
        this.totalItemBought = totalItemBought;
    }

    public double getTotalPriceOfItemBought() {
        return totalPriceOfItemBought;
    }

    public void setTotalPriceOfItemBought(double totalPriceOfItemBought) {
        this.totalPriceOfItemBought = totalPriceOfItemBought;
    }
    
}
