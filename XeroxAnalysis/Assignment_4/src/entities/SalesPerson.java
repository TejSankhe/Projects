/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package entities;

/**
 *
 * @author samartha
 */
public class SalesPerson {
    private int id;
    private int totalItemSold;
    private int totalpriceWRTTarget;

    public SalesPerson(int id) {
        this.id = id;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public int getTotalItemSold() {
        return totalItemSold;
    }

    public void setTotalItemSold(int totalItemSold) {
        this.totalItemSold = totalItemSold;
    }

    public int getTotalpriceWRTTarget() {
        return totalpriceWRTTarget;
    }

    public void setTotalpriceWRTTarget(int totalpriceWRTTarget) {
        this.totalpriceWRTTarget = totalpriceWRTTarget;
    }
    
}
