package com.ifsp.inventory.model;

import java.math.BigDecimal;

/**
 * Representa um vendedor (tabela salesman).
 */
public class SalesMan {

    private int salesmanId;
    private String name;
    private String city;
    private BigDecimal commission;

    public SalesMan() {
    }

    public SalesMan(int salesmanId, String name, String city, BigDecimal commission) {
        this.salesmanId = salesmanId;
        this.name = name;
        this.city = city;
        this.commission = commission;
    }

    public int getSalesmanId() {
        return salesmanId;
    }

    public void setSalesmanId(int salesmanId) {
        this.salesmanId = salesmanId;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getCity() {
        return city;
    }

    public void setCity(String city) {
        this.city = city;
    }

    public BigDecimal getCommission() {
        return commission;
    }

    public void setCommission(BigDecimal commission) {
        this.commission = commission;
    }
}
