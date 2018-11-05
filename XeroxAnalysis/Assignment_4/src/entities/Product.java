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
public class Product {
    int id;
    private double min_price;
    private double max_price;
    private double target_price;
    private int popularity;

    public Product(int id, double min_price, double max_price, double target_price) {
        this.id = id;
        this.min_price = min_price;
        this.max_price = max_price;
        this.target_price = target_price;
    }
    
    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public double getMin_price() {
        return min_price;
    }

    public void setMin_price(double min_price) {
        this.min_price = min_price;
    }

    public double getMax_price() {
        return max_price;
    }

    public void setMax_price(double max_price) {
        this.max_price = max_price;
    }

    public double getTarget_price() {
        return target_price;
    }

    public void setTarget_price(double target_price) {
        this.target_price = target_price;
    }

    public int getPopularity() {
        return popularity;
    }

    public void setPopularity(int popularity) {
        this.popularity = popularity;
    }
    
        
}
