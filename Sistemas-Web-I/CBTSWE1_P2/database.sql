-- ============================================
-- Script de criação do banco de dados
-- Estrutura conforme diagrama da Prova II - CBTSWE1
-- ============================================

CREATE DATABASE IF NOT EXISTS inventory_db
    CHARACTER SET utf8mb4
    COLLATE utf8mb4_unicode_ci;

USE inventory_db;

-- Tabela SalesMan (vendedores)
CREATE TABLE IF NOT EXISTS salesman (
    salesman_id   INT(5)         PRIMARY KEY AUTO_INCREMENT,
    name          VARCHAR(30)    NOT NULL,
    city          VARCHAR(15),
    commission    DECIMAL(5,2)
);

-- Tabela Customer (clientes)
-- salesman_id é FK para o vendedor responsável pelo cliente (1 salesman -> N customers)
CREATE TABLE IF NOT EXISTS customer (
    customer_id   INT(5)         PRIMARY KEY AUTO_INCREMENT,
    cust_name     VARCHAR(30)    NOT NULL,
    city          VARCHAR(15),
    grade         INT(3),
    salesman_id   INT(5),
    CONSTRAINT fk_customer_salesman
        FOREIGN KEY (salesman_id) REFERENCES salesman(salesman_id)
        ON DELETE SET NULL
);

-- Tabela Orders (ordens de venda)
-- customer_id e salesman_id são FKs (N orders -> 1 customer, N orders -> 1 salesman)
CREATE TABLE IF NOT EXISTS orders (
    ord_no        INT(5)         PRIMARY KEY AUTO_INCREMENT,
    purch_amt     DECIMAL(8,2)   NOT NULL,
    ord_date      DATE           NOT NULL,
    customer_id   INT(5)         NOT NULL,
    salesman_id   INT(5),
    CONSTRAINT fk_orders_customer
        FOREIGN KEY (customer_id) REFERENCES customer(customer_id)
        ON DELETE CASCADE,
    CONSTRAINT fk_orders_salesman
        FOREIGN KEY (salesman_id) REFERENCES salesman(salesman_id)
        ON DELETE SET NULL
);

-- ============================================
-- Dados de exemplo (opcional, ajuda a testar)
-- ============================================

INSERT INTO salesman (name, city, commission) VALUES
('João Silva', 'São Paulo', 0.15),
('Maria Souza', 'Santos', 0.12),
('Carlos Lima', 'Cubatão', 0.10);

INSERT INTO customer (cust_name, city, grade, salesman_id) VALUES
('Empresa Alfa', 'São Paulo', 100, 1),
('Empresa Beta', 'Santos', 200, 2),
('Empresa Gama', 'Cubatão', 300, 3);

INSERT INTO orders (purch_amt, ord_date, customer_id, salesman_id) VALUES
(1500.50, '2026-06-01', 1, 1),
(2300.00, '2026-06-10', 2, 2),
(980.75,  '2026-06-15', 3, 3);
