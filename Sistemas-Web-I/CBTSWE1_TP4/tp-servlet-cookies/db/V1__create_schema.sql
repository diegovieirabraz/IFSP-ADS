-- ============================================================
-- TP CBTSWE1_TP_04
-- Dupla:
--   Integrante 1 - [Diego Vieira Braz]
--   Integrante 2 - [Bianca Fonseca Dantas Ribeiro]
-- ============================================================

CREATE DATABASE IF NOT EXISTS tp_cookies
    DEFAULT CHARACTER SET utf8mb4
    DEFAULT COLLATE utf8mb4_general_ci;

USE  tp_cookies;

CREATE TABLE IF NOT EXISTS par_moeda (
    id               INT AUTO_INCREMENT PRIMARY KEY,
    codigo_par       VARCHAR(10)   NOT NULL UNIQUE,
    taxa_cambio      DECIMAL(10,4) NOT NULL,
    atualizado_em    TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- Carga inicial de dados (pares de moedas e suas taxas)
INSERT INTO par_moeda (codigo_par, taxa_cambio) VALUES
    ('USD/EUR', 0.9234),
    ('USD/CAD', 1.3650),
    ('USD/AUD', 1.5120)
ON DUPLICATE KEY UPDATE taxa_cambio = VALUES(taxa_cambio);
