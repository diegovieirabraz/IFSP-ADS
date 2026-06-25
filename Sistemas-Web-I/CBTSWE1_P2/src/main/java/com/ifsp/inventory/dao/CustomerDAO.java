package com.ifsp.inventory.dao;

import com.ifsp.inventory.model.Customer;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Types;
import java.util.ArrayList;
import java.util.List;

/**
 * DAO responsável por todo acesso à tabela customer.
 */
public class CustomerDAO {

    public void insert(Customer c) throws SQLException {
        String sql = "INSERT INTO customer (cust_name, city, grade, salesman_id) VALUES (?, ?, ?, ?)";
        try (Connection con = DB.getConnection();
             PreparedStatement ps = con.prepareStatement(sql)) {
            ps.setString(1, c.getCustName());
            ps.setString(2, c.getCity());
            setNullableInt(ps, 3, c.getGrade());
            setNullableInt(ps, 4, c.getSalesmanId());
            ps.executeUpdate();
        }
    }

    public void update(Customer c) throws SQLException {
        String sql = "UPDATE customer SET cust_name = ?, city = ?, grade = ?, salesman_id = ? WHERE customer_id = ?";
        try (Connection con = DB.getConnection();
             PreparedStatement ps = con.prepareStatement(sql)) {
            ps.setString(1, c.getCustName());
            ps.setString(2, c.getCity());
            setNullableInt(ps, 3, c.getGrade());
            setNullableInt(ps, 4, c.getSalesmanId());
            ps.setInt(5, c.getCustomerId());
            ps.executeUpdate();
        }
    }

    public void delete(int customerId) throws SQLException {
        String sql = "DELETE FROM customer WHERE customer_id = ?";
        try (Connection con = DB.getConnection();
             PreparedStatement ps = con.prepareStatement(sql)) {
            ps.setInt(1, customerId);
            ps.executeUpdate();
        }
    }

    public Customer findById(int customerId) throws SQLException {
        String sql = "SELECT * FROM customer WHERE customer_id = ?";
        try (Connection con = DB.getConnection();
             PreparedStatement ps = con.prepareStatement(sql)) {
            ps.setInt(1, customerId);
            try (ResultSet rs = ps.executeQuery()) {
                if (rs.next()) {
                    return mapRow(rs);
                }
            }
        }
        return null;
    }

    /**
     * Retorna todos os clientes, já trazendo o nome do vendedor associado (via LEFT JOIN).
     */
    public List<Customer> findAll() throws SQLException {
        List<Customer> list = new ArrayList<>();
        String sql = "SELECT c.*, s.name AS salesman_name " +
                "FROM customer c LEFT JOIN salesman s ON c.salesman_id = s.salesman_id " +
                "ORDER BY c.customer_id";
        try (Connection con = DB.getConnection();
             PreparedStatement ps = con.prepareStatement(sql);
             ResultSet rs = ps.executeQuery()) {
            while (rs.next()) {
                Customer c = mapRow(rs);
                c.setSalesmanName(rs.getString("salesman_name"));
                list.add(c);
            }
        }
        return list;
    }

    private Customer mapRow(ResultSet rs) throws SQLException {
        Customer c = new Customer();
        c.setCustomerId(rs.getInt("customer_id"));
        c.setCustName(rs.getString("cust_name"));
        c.setCity(rs.getString("city"));
        int grade = rs.getInt("grade");
        c.setGrade(rs.wasNull() ? null : grade);
        int salesmanId = rs.getInt("salesman_id");
        c.setSalesmanId(rs.wasNull() ? null : salesmanId);
        return c;
    }

    private void setNullableInt(PreparedStatement ps, int index, Integer value) throws SQLException {
        if (value == null) {
            ps.setNull(index, Types.INTEGER);
        } else {
            ps.setInt(index, value);
        }
    }
}
