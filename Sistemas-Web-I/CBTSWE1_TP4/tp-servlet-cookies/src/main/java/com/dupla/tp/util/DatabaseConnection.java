/*
-- ============================================================
-- TP CBTSWE1_TP_04
-- Dupla:
--   Integrante 1 - [Diego Vieira Braz]
--   Integrante 2 - [Bianca Fonseca Dantas Ribeiro]
-- ============================================================
 */
package com.dupla.tp.util;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class DatabaseConnection {


private static final String URL =
        "jdbc:mysql://localhost:3306/tp_cookies?useSSL=false&allowPublicKeyRetrieval=true&serverTimezone=UTC";
    private static final String USER = "root";
    private static final String PASSWORD = "22446688";

    static {
        try {

            Class.forName("com.mysql.cj.jdbc.Driver");
        } catch (ClassNotFoundException e) {
            throw new RuntimeException("Driver JDBC do MySQL nao encontrado.", e);
        }
    }

    private DatabaseConnection() {
    }

    public static Connection getConnection() throws SQLException {
        return DriverManager.getConnection(URL, USER, PASSWORD);
    }
}
