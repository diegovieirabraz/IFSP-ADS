package com.ifsp.inventory.dao;

import com.ifsp.inventory.model.Order;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Types;
import java.util.ArrayList;
import java.util.List;

/**
 * DAO responsável por todo acesso à tabela orders.
 */
public class OrderDAO {

    public void insert(Order o) throws SQLException {
        String sql = "INSERT INTO orders (purch_amt, ord_date, customer_id, salesman_id) VALUES (?, ?, ?, ?)";
        try (Connection con = DB.getConnection();
             PreparedStatement ps = con.prepareStatement(sql)) {
            ps.setBigDecimal(1, o.getPurchAmt());
            ps.setDate(2, o.getOrdDate());
            ps.setInt(3, o.getCustomerId());
            setNullableInt(ps, 4, o.getSalesmanId());
            ps.executeUpdate();
        }
    }

    public void update(Order o) throws SQLException {
        String sql = "UPDATE orders SET purch_amt = ?, ord_date = ?, customer_id = ?, salesman_id = ? WHERE ord_no = ?";
        try (Connection con = DB.getConnection();
             PreparedStatement ps = con.prepareStatement(sql)) {
            ps.setBigDecimal(1, o.getPurchAmt());
            ps.setDate(2, o.getOrdDate());
            ps.setInt(3, o.getCustomerId());
            setNullableInt(ps, 4, o.getSalesmanId());
            ps.setInt(5, o.getOrdNo());
            ps.executeUpdate();
        }
    }

    public void delete(int ordNo) throws SQLException {
        String sql = "DELETE FROM orders WHERE ord_no = ?";
        try (Connection con = DB.getConnection();
             PreparedStatement ps = con.prepareStatement(sql)) {
            ps.setInt(1, ordNo);
            ps.executeUpdate();
        }
    }

    public Order findById(int ordNo) throws SQLException {
        String sql = "SELECT * FROM orders WHERE ord_no = ?";
        try (Connection con = DB.getConnection();
             PreparedStatement ps = con.prepareStatement(sql)) {
            ps.setInt(1, ordNo);
            try (ResultSet rs = ps.executeQuery()) {
                if (rs.next()) {
                    return mapRow(rs);
                }
            }
        }
        return null;
    }

    /**
     * Retorna todas as ordens, já trazendo nome do cliente e do vendedor (via JOIN).
     */
    public List<Order> findAll() throws SQLException {
        List<Order> list = new ArrayList<>();
        String sql = "SELECT o.*, c.cust_name, s.name AS salesman_name " +
                "FROM orders o " +
                "JOIN customer c ON o.customer_id = c.customer_id " +
                "LEFT JOIN salesman s ON o.salesman_id = s.salesman_id " +
                "ORDER BY o.ord_no";
        try (Connection con = DB.getConnection();
             PreparedStatement ps = con.prepareStatement(sql);
             ResultSet rs = ps.executeQuery()) {
            while (rs.next()) {
                Order o = mapRow(rs);
                o.setCustomerName(rs.getString("cust_name"));
                o.setSalesmanName(rs.getString("salesman_name"));
                list.add(o);
            }
        }
        return list;
    }

    private Order mapRow(ResultSet rs) throws SQLException {
        Order o = new Order();
        o.setOrdNo(rs.getInt("ord_no"));
        o.setPurchAmt(rs.getBigDecimal("purch_amt"));
        o.setOrdDate(rs.getDate("ord_date"));
        o.setCustomerId(rs.getInt("customer_id"));
        int salesmanId = rs.getInt("salesman_id");
        o.setSalesmanId(rs.wasNull() ? null : salesmanId);
        return o;
    }

    private void setNullableInt(PreparedStatement ps, int index, Integer value) throws SQLException {
        if (value == null) {
            ps.setNull(index, Types.INTEGER);
        } else {
            ps.setInt(index, value);
        }
    }
}
