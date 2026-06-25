package com.ifsp.inventory.servlet;

import com.ifsp.inventory.dao.CustomerDAO;
import com.ifsp.inventory.dao.OrderDAO;
import com.ifsp.inventory.dao.SalesManDAO;
import com.ifsp.inventory.model.Customer;
import com.ifsp.inventory.model.Order;
import com.ifsp.inventory.model.SalesMan;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.math.BigDecimal;
import java.sql.Date;
import java.sql.SQLException;
import java.util.List;

/**
 * Controla as operações de CRUD para Orders (ordens de venda).
 *
 * Rotas:
 *  GET  /order                       -> lista todas
 *  GET  /order?action=new            -> formulário de nova ordem
 *  GET  /order?action=edit&id=X      -> formulário de edição
 *  POST /order?action=save           -> salva (insert ou update)
 *  GET  /order?action=delete&id=X    -> remove
 */
@WebServlet(name = "orderServlet", urlPatterns = {"/order"})
public class OrderServlet extends HttpServlet {

    private final OrderDAO dao = new OrderDAO();
    private final CustomerDAO customerDAO = new CustomerDAO();
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
                    resp.sendRedirect("order");
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

        String idParam = req.getParameter("ordNo");
        String purchAmtParam = req.getParameter("purchAmt");
        String ordDateParam = req.getParameter("ordDate");
        String customerIdParam = req.getParameter("customerId");
        String salesmanIdParam = req.getParameter("salesmanId");

        Order o = new Order();
        o.setPurchAmt(new BigDecimal(purchAmtParam));
        o.setOrdDate(Date.valueOf(ordDateParam)); // formato esperado: yyyy-MM-dd (padrão do <input type="date">)
        o.setCustomerId(Integer.parseInt(customerIdParam));
        o.setSalesmanId(salesmanIdParam == null || salesmanIdParam.isEmpty()
                ? null : Integer.parseInt(salesmanIdParam));

        try {
            if (idParam == null || idParam.isEmpty()) {
                dao.insert(o);
            } else {
                o.setOrdNo(Integer.parseInt(idParam));
                dao.update(o);
            }
            resp.sendRedirect("order");
        } catch (SQLException e) {
            throw new ServletException("Erro ao salvar ordem de venda", e);
        }
    }

    private void listAll(HttpServletRequest req, HttpServletResponse resp)
            throws ServletException, IOException, SQLException {
        List<Order> list = dao.findAll();
        req.setAttribute("orders", list);
        forward(req, resp, "/WEB-INF/jsp/order-list.jsp");
    }

    private void showForm(HttpServletRequest req, HttpServletResponse resp, Order o)
            throws ServletException, IOException, SQLException {
        List<Customer> customers = customerDAO.findAll();
        List<SalesMan> salesmen = salesManDAO.findAll();
        req.setAttribute("customers", customers);
        req.setAttribute("salesmen", salesmen);
        req.setAttribute("order", o);
        forward(req, resp, "/WEB-INF/jsp/order-form.jsp");
    }

    private void forward(HttpServletRequest req, HttpServletResponse resp, String path)
            throws ServletException, IOException {
        RequestDispatcher rd = req.getRequestDispatcher(path);
        rd.forward(req, resp);
    }
}
