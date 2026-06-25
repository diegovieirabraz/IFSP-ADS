package com.ifsp.inventory.model;

/**
 * Representa um cliente (tabela customer).
 * Cada cliente pode estar associado a um vendedor (salesmanId).
 */
public class Customer {

    private int customerId;
    private String custName;
    private String city;
    private Integer grade;
    private Integer salesmanId;   // FK -> salesman.salesman_id (pode ser null)
    private String salesmanName; // usado apenas para exibição (join), não é coluna própria

    public Customer() {
    }

    public Customer(int customerId, String custName, String city, Integer grade, Integer salesmanId) {
        this.customerId = customerId;
        this.custName = custName;
        this.city = city;
        this.grade = grade;
        this.salesmanId = salesmanId;
    }

    public int getCustomerId() {
        return customerId;
    }

    public void setCustomerId(int customerId) {
        this.customerId = customerId;
    }

    public String getCustName() {
        return custName;
    }

    public void setCustName(String custName) {
        this.custName = custName;
    }

    public String getCity() {
        return city;
    }

    public void setCity(String city) {
        this.city = city;
    }

    public Integer getGrade() {
        return grade;
    }

    public void setGrade(Integer grade) {
        this.grade = grade;
    }

    public Integer getSalesmanId() {
        return salesmanId;
    }

    public void setSalesmanId(Integer salesmanId) {
        this.salesmanId = salesmanId;
    }

    public String getSalesmanName() {
        return salesmanName;
    }

    public void setSalesmanName(String salesmanName) {
        this.salesmanName = salesmanName;
    }
}
