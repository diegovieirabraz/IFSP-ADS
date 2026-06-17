/*
 * ============================================================
 * TP CBTSWE1_TP_04
 * Dupla:
 *   Integrante 1 - Diego Vieira Braz
 *   Integrante 2 - Bianca Fonseca Dantas Ribeiro
 * ============================================================
 */
package com.dupla.tp.dao;

import com.dupla.tp.util.DatabaseConnection;

import java.math.BigDecimal;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

public class ExchangeRateDAO {

    public BigDecimal getRate(String pairCode) throws SQLException {
        String sql = "SELECT taxa_cambio FROM par_moeda WHERE codigo_par = ?";

        try (Connection con = DatabaseConnection.getConnection();
             PreparedStatement ps = con.prepareStatement(sql)) {

            ps.setString(1, pairCode);

            try (ResultSet rs = ps.executeQuery()) {
                if (rs.next()) {
                    return rs.getBigDecimal("taxa_cambio");
                }
            }
        }
        return null;
    }
}