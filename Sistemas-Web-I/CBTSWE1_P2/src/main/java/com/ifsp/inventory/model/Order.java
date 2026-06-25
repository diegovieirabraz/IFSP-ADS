package com.ifsp.inventory.model;

import java.math.BigDecimal;
import java.sql.Date;

/**
 * Representa uma ordem de venda (tabela orders).
 */
public class Order {

    private int ordNo;
    private BigDecimal purchAmt;
    private Date ordDate;
    private int customerId;     // FK -> customer.customer_id
    private Integer salesmanId; // FK -> salesman.salesman_id (pode ser null)

    // Campos auxiliares apenas para exibição (preenchidos via JOIN)
    private String customerName;
    private String salesmanName;

    public Order() {
    }

    public Order(int ordNo, BigDecimal purchAmt, Date ordDate, int customerId, Integer salesmanId) {
        this.ordNo = ordNo;
        this.purchAmt = purchAmt;
        this.ordDate = ordDate;
        this.customerId = customerId;
        this.salesmanId = salesmanId;
    }

    public int getOrdNo() {
        return ordNo;
    }

    public void setOrdNo(int ordNo) {
        this.ordNo = ordNo;
    }

    public BigDecimal getPurchAmt() {
        return purchAmt;
    }

    public void setPurchAmt(BigDecimal purchAmt) {
        this.purchAmt = purchAmt;
    }

    public Date getOrdDate() {
        return ordDate;
    }

    public void setOrdDate(Date ordDate) {
        this.ordDate = ordDate;
    }

    public int getCustomerId() {
        return customerId;
    }

    public void setCustomerId(int customerId) {
        this.customerId = customerId;
    }

    public Integer getSalesmanId() {
        return salesmanId;
    }

    public void setSalesmanId(Integer salesmanId) {
        this.salesmanId = salesmanId;
    }

    public String getCustomerName() {
        return customerName;
    }

    public void setCustomerName(String customerName) {
        this.customerName = customerName;
    }

    public String getSalesmanName() {
        return salesmanName;
    }

    public void setSalesmanName(String salesmanName) {
        this.salesmanName = salesmanName;
    }
}
