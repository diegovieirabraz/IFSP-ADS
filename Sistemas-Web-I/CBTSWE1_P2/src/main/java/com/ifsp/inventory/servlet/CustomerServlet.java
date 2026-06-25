package com.ifsp.inventory.servlet;

import com.ifsp.inventory.dao.CustomerDAO;
import com.ifsp.inventory.dao.SalesManDAO;
import com.ifsp.inventory.model.Customer;
import com.ifsp.inventory.model.SalesMan;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.sql.SQLException;
import java.util.List;

/**
 * Controla as operações de CRUD para Customer (clientes).
 *
 * Rotas:
 *  GET  /customer                       -> lista todos
 *  GET  /customer?action=new            -> formulário de novo cliente
 *  GET  /customer?action=edit&id=X      -> formulário de edição
 *  POST /customer?action=save           -> salva (insert ou update)
 *  GET  /customer?action=delete&id=X    -> remove
 */
@WebServlet(name = "customerServlet", urlPatterns = {"/customer"})
public class CustomerServlet extends HttpServlet {

    private final CustomerDAO dao = new CustomerDAO();
    private final SalesManDAO salesManDAO = new SalesManDAO();

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
                    resp.sendRedirect("customer");
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

        String idParam = req.getParameter("customerId");
        String custName = req.getParameter("custName");
        String city = req.getParameter("city");
        String gradeParam = req.getParameter("grade");
        String salesmanIdParam = req.getParameter("salesmanId");

        Customer c = new Customer();
        c.setCustName(custName);
        c.setCity(city);
        c.setGrade(gradeParam == null || gradeParam.isEmpty() ? null : Integer.parseInt(gradeParam));
        c.setSalesmanId(salesmanIdParam == null || salesmanIdParam.isEmpty()
                ? null : Integer.parseInt(salesmanIdParam));

        try {
            if (idParam == null || idParam.isEmpty()) {
                dao.insert(c);
            } else {
                c.setCustomerId(Integer.parseInt(idParam));
                dao.update(c);
            }
            resp.sendRedirect("customer");
        } catch (SQLException e) {
            throw new ServletException("Erro ao salvar cliente", e);
        }
    }

    private void listAll(HttpServletRequest req, HttpServletResponse resp)
            throws ServletException, IOException, SQLException {
        List<Customer> list = dao.findAll();
        req.setAttribute("customers", list);
        forward(req, resp, "/WEB-INF/jsp/customer-list.jsp");
    }

    private void showForm(HttpServletRequest req, HttpServletResponse resp, Customer c)
            throws ServletException, IOException, SQLException {
        List<SalesMan> salesmen = salesManDAO.findAll();
        req.setAttribute("salesmen", salesmen);
        req.setAttribute("customer", c);
        forward(req, resp, "/WEB-INF/jsp/customer-form.jsp");
    }

    private void forward(HttpServletRequest req, HttpServletResponse resp, String path)
            throws ServletException, IOException {
        RequestDispatcher rd = req.getRequestDispatcher(path);
        rd.forward(req, resp);
    }
}
