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
import java.io.PrintWriter;
import java.util.Arrays;
import java.util.Optional;

@WebServlet(name = "removeCookieServlet",
        urlPatterns = {"/remove-currency-pair"},
        loadOnStartup = 1)
public class RemoveExchangeRateCookieServlet extends HttpServlet {

    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse resp)
            throws ServletException, IOException {

        Cookie[] cookies = req.getCookies();

        Optional<Cookie> cookieOptional = (cookies == null)
                ? Optional.empty()
                : Arrays.stream(cookies)
                        .filter(c -> ExchangeRatesServlet.currencyPairKey.equals(c.getName()))
                        .findAny();

        if (cookieOptional.isPresent()) {
            Cookie cookie = cookieOptional.get();
            cookie.setMaxAge(0); // remove o cookie
            cookie.setPath("/");
            resp.addCookie(cookie);
            resp.sendRedirect("/currencySelection.html");
        } else {
            resp.setContentType("text/html;charset=UTF-8");
            PrintWriter writer = resp.getWriter();
            writer.write("O Cookie do par de moedas não existe no navegador.");
            writer.close();
        }
    }
}
