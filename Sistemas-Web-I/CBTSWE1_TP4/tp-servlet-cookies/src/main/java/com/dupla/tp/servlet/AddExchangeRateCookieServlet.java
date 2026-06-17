/*
-- ============================================================
-- TP CBTSWE1_TP_04
-- Dupla:
--   Integrante 1 - [Diego Vieira Braz]
--   Integrante 2 - [Bianca Fonseca Dantas Ribeiro]
-- ============================================================
 */
package com.dupla.tp.servlet;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.Cookie;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

@WebServlet(name = "saveExchangeRatesServlet",
        urlPatterns = {"/save-exchange-rates-pair"},
        loadOnStartup = 1)
public class AddExchangeRateCookieServlet extends HttpServlet {

    static final String currencyPairKey = "currencyPair";

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse resp)
            throws ServletException, IOException {

        String thePair = req.getParameter(currencyPairKey);
        if (thePair != null) {
            Cookie cookie = new Cookie(currencyPairKey, thePair);
            cookie.setMaxAge(30 * 24 * 60 * 60); 
            resp.addCookie(cookie);

            resp.sendRedirect("/exchange-rate");
        } else {
            resp.sendRedirect("/currencySelection.html");
        }
    }
}
