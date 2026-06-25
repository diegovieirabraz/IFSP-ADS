package com.ifsp.inventory.filter;

import javax.servlet.Filter;
import javax.servlet.FilterChain;
import javax.servlet.FilterConfig;
import javax.servlet.ServletException;
import javax.servlet.ServletRequest;
import javax.servlet.ServletResponse;
import javax.servlet.annotation.WebFilter;
import java.io.IOException;

/**
 * Garante que toda requisição (inclusive dados de formulário enviados via POST)
 * e toda resposta sejam tratadas como UTF-8.
 *
 * Sem isso, o servidor lê o corpo do POST como ISO-8859-1 por padrão,
 * corrompendo caracteres acentuados (ã, ç, é, etc.) antes mesmo de chegar
 * ao Servlet/DAO/banco de dados.
 */
@WebFilter("/*")
public class EncodingFilter implements Filter {

    @Override
    public void init(FilterConfig filterConfig) {
        // nada a inicializar
    }

    @Override
    public void doFilter(ServletRequest request, ServletResponse response, FilterChain chain)
            throws IOException, ServletException {
        request.setCharacterEncoding("UTF-8");
        response.setCharacterEncoding("UTF-8");
        chain.doFilter(request, response);
    }

    @Override
    public void destroy() {
        // nada a destruir
    }
}
