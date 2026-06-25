package com.ifsp.inventory.dao;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

/**
 * Classe utilitária responsável por abrir conexões com o banco MySQL.
 *
 * IMPORTANTE: ajuste USER e PASSWORD conforme a configuração do seu MySQL local.
 * Se sua porta ou nome do banco forem diferentes, ajuste também a URL.
 */
public class DB {

    private static final String URL =
            "jdbc:mysql://localhost:3306/inventory_db?useSSL=false&serverTimezone=UTC&allowPublicKeyRetrieval=true"
            + "&characterEncoding=UTF-8&useUnicode=true";
    private static final String USER = "root";
    private static final String PASSWORD = "22446688";

    static {
        try {
            // Garante que o driver do MySQL seja carregado
            Class.forName("com.mysql.cj.jdbc.Driver");
        } catch (ClassNotFoundException e) {
            throw new RuntimeException("Driver do MySQL não encontrado no classpath.", e);
        }
    }

    /**
     * Abre e retorna uma nova conexão com o banco de dados.
     * Quem chamar este método é responsável por fechar a conexão (use try-with-resources).
     */
    public static Connection getConnection() throws SQLException {
        return DriverManager.getConnection(URL, USER, PASSWORD);
    }
}
