package com.ifsp.inventory.dao;

import com.ifsp.inventory.model.SalesMan;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

/**
 * DAO (Data Access Object) responsável por todo acesso à tabela salesman.
 */
public class SalesManDAO {

    public void insert(SalesMan s) throws SQLException {
        String sql = "INSERT INTO salesman (name, city, commission) VALUES (?, ?, ?)";
        try (Connection con = DB.getConnection();
             PreparedStatement ps = con.prepareStatement(sql)) {
            ps.setString(1, s.getName());
            ps.setString(2, s.getCity());
            ps.setBigDecimal(3, s.getCommission());
            ps.executeUpdate();
        }
    }

    public void update(SalesMan s) throws SQLException {
        String sql = "UPDATE salesman SET name = ?, city = ?, commission = ? WHERE salesman_id = ?";
        try (Connection con = DB.getConnection();
             PreparedStatement ps = con.prepareStatement(sql)) {
            ps.setString(1, s.getName());
            ps.setString(2, s.getCity());
            ps.setBigDecimal(3, s.getCommission());
            ps.setInt(4, s.getSalesmanId());
            ps.executeUpdate();
        }
    }

    public void delete(int salesmanId) throws SQLException {
        String sql = "DELETE FROM salesman WHERE salesman_id = ?";
        try (Connection con = DB.getConnection();
             PreparedStatement ps = con.prepareStatement(sql)) {
            ps.setInt(1, salesmanId);
            ps.executeUpdate();
        }
    }

    public SalesMan findById(int salesmanId) throws SQLException {
        String sql = "SELECT * FROM salesman WHERE salesman_id = ?";
        try (Connection con = DB.getConnection();
             PreparedStatement ps = con.prepareStatement(sql)) {
            ps.setInt(1, salesmanId);
            try (ResultSet rs = ps.executeQuery()) {
                if (rs.next()) {
                    return mapRow(rs);
                }
            }
        }
        return null;
    }

    public List<SalesMan> findAll() throws SQLException {
        List<SalesMan> list = new ArrayList<>();
        String sql = "SELECT * FROM salesman ORDER BY salesman_id";
        try (Connection con = DB.getConnection();
             PreparedStatement ps = con.prepareStatement(sql);
             ResultSet rs = ps.executeQuery()) {
            while (rs.next()) {
                list.add(mapRow(rs));
            }
        }
        return list;
    }

    private SalesMan mapRow(ResultSet rs) throws SQLException {
        SalesMan s = new SalesMan();
        s.setSalesmanId(rs.getInt("salesman_id"));
        s.setName(rs.getString("name"));
        s.setCity(rs.getString("city"));
        s.setCommission(rs.getBigDecimal("commission"));
        return s;
    }
}
