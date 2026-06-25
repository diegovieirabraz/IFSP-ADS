package com.ifsp.inventory.servlet;

import com.ifsp.inventory.dao.SalesManDAO;
import com.ifsp.inventory.model.SalesMan;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.math.BigDecimal;
import java.sql.SQLException;
import java.util.List;

/**
 * Controla as operações de CRUD para SalesMan (vendedores).
 *
 * Rotas:
 *  GET  /salesman          -> lista todos
 *  GET  /salesman?action=new            -> formulário de novo vendedor
 *  GET  /salesman?action=edit&id=X      -> formulário de edição
 *  POST /salesman?action=save           -> salva (insert ou update)
 *  GET  /salesman?action=delete&id=X    -> remove
 */
@WebServlet(name = "salesManServlet", urlPatterns = {"/salesman"})
public class SalesManServlet extends HttpServlet {

    private final SalesManDAO dao = new SalesManDAO();

    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse resp)
            throws ServletException, IOException {

        String action = req.getParameter("action");
        if (action == null) {
            action = "list";
        }

        try {
            switch (action) {
                case "new":
                    showForm(req, resp, null);
                    break;
                case "edit":
                    int editId = Integer.parseInt(req.getParameter("id"));
                    showForm(req, resp, dao.findById(editId));
                    break;
                case "delete":
                    int delId = Integer.parseInt(req.getParameter("id"));
                    dao.delete(delId);
                    resp.sendRedirect("salesman");
                    break;
                default:
                    listAll(req, resp);
            }
        } catch (SQLException e) {
            throw new ServletException("Erro ao acessar o banco de dados", e);
        }
    }

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse resp)
            throws ServletException, IOException {

        String idParam = req.getParameter("salesmanId");
        String name = req.getParameter("name");
        String city = req.getParameter("city");
        String commissionParam = req.getParameter("commission");

        SalesMan s = new SalesMan();
        s.setName(name);
        s.setCity(city);
        s.setCommission(commissionParam == null || commissionParam.isEmpty()
                ? null : new BigDecimal(commissionParam));

        try {
            if (idParam == null || idParam.isEmpty()) {
                // novo registro
                dao.insert(s);
            } else {
                // atualização
                s.setSalesmanId(Integer.parseInt(idParam));
                dao.update(s);
            }
            resp.sendRedirect("salesman");
        } catch (SQLException e) {
            throw new ServletException("Erro ao salvar vendedor", e);
        }
    }

    private void listAll(HttpServletRequest req, HttpServletResponse resp)
            throws ServletException, IOException, SQLException {
        List<SalesMan> list = dao.findAll();
        req.setAttribute("salesmen", list);
        forward(req, resp, "/WEB-INF/jsp/salesman-list.jsp");
    }

    private void showForm(HttpServletRequest req, HttpServletResponse resp, SalesMan s)
            throws ServletException, IOException {
        req.setAttribute("salesman", s);
        forward(req, resp, "/WEB-INF/jsp/salesman-form.jsp");
    }

    private void forward(HttpServletRequest req, HttpServletResponse resp, String path)
            throws ServletException, IOException {
        RequestDispatcher rd = req.getRequestDispatcher(path);
        rd.forward(req, resp);
    }
}
