<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ page import="java.util.List, model.Produto" %>
<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Lista de Produtos</title>
    <style>
        body  { font-family: Arial, sans-serif; background: #f0f2f5; padding: 30px; }
        h1    { color: #333; }
        table { width: 100%; border-collapse: collapse; background: white;
                border-radius: 8px; overflow: hidden;
                box-shadow: 0 2px 8px rgba(0,0,0,0.1); }
        th    { background: #4A90D9; color: white; padding: 12px; text-align: left; }
        td    { padding: 10px 12px; border-bottom: 1px solid #eee; }
        tr:last-child td { border-bottom: none; }
        tr:hover td { background: #f7f9fc; }
        .btn  { padding: 6px 12px; border-radius: 6px; text-decoration: none;
                font-size: 0.85em; font-weight: bold; color: white; margin: 2px; }
        .edit { background: #f0a500; }
        .del  { background: #e74c3c; }
        .new  { display: inline-block; margin-bottom: 16px; padding: 10px 20px;
                background: #27ae60; border-radius: 8px; color: white;
                text-decoration: none; font-weight: bold; }
        .home { display: inline-block; margin-bottom: 16px; margin-right: 10px;
                padding: 10px 20px; background: #6c757d; border-radius: 8px;
                color: white; text-decoration: none; font-weight: bold; }
    </style>
</head>
<body>
    <h1>📦 Lista de Produtos</h1>
    <a href="index.jsp"           class="home">🏠 Menu</a>
    <a href="produto?acao=novo"   class="new">➕ Novo Produto</a>

    <table>
        <tr>
            <th>ID</th>
            <th>Nome</th>
            <th>Unid. Compra</th>
            <th>Descrição</th>
            <th>Qtd Prevista/Mês</th>
            <th>Preço Máx.</th>
            <th>Ações</th>
        </tr>
        <%
            List<Produto> produtos = (List<Produto>) request.getAttribute("produtos");
            if (produtos != null) {
                for (Produto p : produtos) {
        %>
        <tr>
            <td><%= p.getId() %></td>
            <td><%= p.getNome() %></td>
            <td><%= p.getUnidadeCompra() %></td>
            <td><%= p.getDescricao() %></td>
            <td><%= p.getQtdPrevistoMes() %></td>
            <td>R$ <%= String.format("%.2f", p.getPrecoMaxComprado()) %></td>
            <td>
                <a href="produto?acao=editar&id=<%= p.getId() %>" class="btn edit">✏️ Editar</a>
                <a href="produto?acao=excluir&id=<%= p.getId() %>" class="btn del"
                   onclick="return confirm('Excluir este produto?')">🗑️ Excluir</a>
            </td>
        </tr>
        <%  } } %>
    </table>
</body>
</html>