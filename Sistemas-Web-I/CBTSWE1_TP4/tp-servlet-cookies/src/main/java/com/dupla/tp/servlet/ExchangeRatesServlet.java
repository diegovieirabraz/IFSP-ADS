/*
 -- ============================================================
-- TP CBTSWE1_TP_04
-- Dupla:
--   Integrante 1 - [Diego Vieira Braz]
--   Integrante 2 - [Bianca Fonseca Dantas Ribeiro]
-- ============================================================
 */
package com.dupla.tp.servlet;

import com.dupla.tp.dao.ExchangeRateDAO;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.Cookie;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;
import java.math.BigDecimal;
import java.sql.SQLException;
import java.util.Arrays;
import java.util.Optional;

@WebServlet(name = "exchangeRatesServlet",
        urlPatterns = {"/exchange-rate"},
        loadOnStartup = 1)
public class ExchangeRatesServlet extends HttpServlet {

    static final String currencyPairKey = "currencyPair";

    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse resp)
            throws ServletException, IOException {

        Cookie[] cookies = req.getCookies();

        // getCookies() pode retornar null quando nao ha cookies no navegador
        Optional<Cookie> op = (cookies == null)
                ? Optional.empty()
                : Arrays.stream(cookies)
                        .filter(c -> currencyPairKey.equals(c.getName()))
                        .findAny();

        if (op.isPresent()) {
            showCurrencyRate(resp, op.get().getValue());
        } else {
            RequestDispatcher rd = req.getRequestDispatcher("/currencySelection.html");
            rd.forward(req, resp);
        }
    }

    private void showCurrencyRate(HttpServletResponse resp, String currencyPair)
            throws IOException {

        resp.setContentType("text/html;charset=UTF-8");
        PrintWriter writer = resp.getWriter();

        writer.write("<html><head><meta charset='UTF-8'>");
        writer.write("<link rel='stylesheet' href='/css/style.css'></head><body>");
        writer.write("<div class='card'>");
        writer.write("<h1>Taxa de Câmbio</h1>");

        try {
            BigDecimal rate = new ExchangeRateDAO().getRate(currencyPair);
            if (rate != null) {
                writer.write(String.format(
                        "<p class='rate'>A taxa de câmbio para <b>%s</b> = <b>%s</b></p>",
                        currencyPair, rate.toPlainString()));
            } else {
                writer.write(String.format(
                        "<p>Par <b>%s</b> não encontrado no banco de dados.</p>",
                        currencyPair));
            }
        } catch (SQLException e) {
            writer.write("<p style='color:#b00'>Erro ao consultar o banco de dados: "
                    + e.getMessage() + "</p>");
        }

        writer.write("<p class='cookie-info'>(Valor lembrado via Cookie no seu navegador)</p>");
        writer.write("<p><a class='btn' href='/remove-currency-pair'>"
                + "Remover seleção de moeda</a></p>");
        writer.write("<p><a href='/creditos.html'>Créditos da dupla</a></p>");
        writer.write("</div></body></html>");
        writer.close();
    }
}
