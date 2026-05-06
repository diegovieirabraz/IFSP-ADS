package servlet;

import dao.BancoProdutos;
import javax.servlet.*;
import javax.servlet.http.*;
import javax.servlet.annotation.*;
import model.Produto;

import java.io.IOException;

@WebServlet("/produto")
public class ProdutoServlet extends HttpServlet {

    private BancoProdutos banco = BancoProdutos.getInstancia();

    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse resp)
            throws ServletException, IOException {

        String acao = req.getParameter("acao");
        if (acao == null) acao = "listar";

        switch (acao) {

            case "listar":
                req.setAttribute("produtos", banco.listarTodos());
                req.getRequestDispatcher("/listaProdutos.jsp").forward(req, resp);
                break;

            case "novo":
                req.getRequestDispatcher("/formProduto.jsp").forward(req, resp);
                break;

            case "editar":
                int idEditar = Integer.parseInt(req.getParameter("id"));
                req.setAttribute("produto", banco.buscarPorId(idEditar));
                req.getRequestDispatcher("/formProduto.jsp").forward(req, resp);
                break;

            case "excluir":
                int idExcluir = Integer.parseInt(req.getParameter("id"));
                banco.excluir(idExcluir);
                resp.sendRedirect("produto?acao=listar");
                break;

            default:
                resp.sendRedirect("index.jsp");
        }
    }

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse resp)
            throws ServletException, IOException {

        req.setCharacterEncoding("UTF-8");

        String acao = req.getParameter("acao");
        String idParam = req.getParameter("id");

        String nome           = req.getParameter("nome");
        int unidadeCompra     = Integer.parseInt(req.getParameter("unidadeCompra"));
        String descricao      = req.getParameter("descricao");
        double qtdPrevistoMes = Double.parseDouble(req.getParameter("qtdPrevistoMes"));
        double precoMax       = Double.parseDouble(req.getParameter("precoMaxComprado"));

        if ("inserir".equals(acao)) {
            Produto p = new Produto(0, nome, unidadeCompra, descricao, qtdPrevistoMes, precoMax);
            banco.inserir(p);

        } else if ("atualizar".equals(acao)) {
            int id = Integer.parseInt(idParam);
            Produto p = new Produto(id, nome, unidadeCompra, descricao, qtdPrevistoMes, precoMax);
            banco.atualizar(p);
        }

        resp.sendRedirect("produto?acao=listar");
    }
}