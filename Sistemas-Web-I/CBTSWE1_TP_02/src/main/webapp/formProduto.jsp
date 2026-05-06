<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ page import="model.Produto" %>
<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Formulário de Produto</title>
    <style>
        body  { font-family: Arial, sans-serif; background: #f0f2f5;
                display: flex; justify-content: center; padding: 40px; }
        .card { background: white; padding: 36px; border-radius: 12px;
                box-shadow: 0 4px 12px rgba(0,0,0,0.12); width: 480px; }
        h1    { color: #333; margin-bottom: 24px; }
        label { display: block; margin-top: 14px; font-weight: bold; color: #555; }
        input, textarea {
            width: 100%; padding: 9px; margin-top: 4px; border: 1px solid #ccc;
            border-radius: 6px; box-sizing: border-box; font-size: 1em; }
        button { margin-top: 24px; width: 100%; padding: 12px; background: #4A90D9;
                 color: white; border: none; border-radius: 8px; font-size: 1em;
                 font-weight: bold; cursor: pointer; }
        button:hover { background: #357ABD; }
        .back { display: inline-block; margin-top: 12px; color: #4A90D9;
                text-decoration: none; font-size: 0.9em; }
    </style>
</head>
<body>
<div class="card">
    <%
        Produto p = (Produto) request.getAttribute("produto");
        boolean editando = (p != null);
        String acao = editando ? "atualizar" : "inserir";
        String titulo = editando ? "✏️ Editar Produto" : "➕ Novo Produto";
    %>
    <h1><%= titulo %></h1>

    <form action="produto" method="post">
        <input type="hidden" name="acao" value="<%= acao %>">
        <% if (editando) { %>
            <input type="hidden" name="id" value="<%= p.getId() %>">
        <% } %>

        <label>Nome</label>
        <input type="text" name="nome" required
               value="<%= editando ? p.getNome() : "" %>">

        <label>Unidade de Compra</label>
        <input type="number" name="unidadeCompra" required
               value="<%= editando ? p.getUnidadeCompra() : "" %>">

        <label>Descrição</label>
        <textarea name="descricao" rows="3" required><%= editando ? p.getDescricao() : "" %></textarea>

        <label>Quantidade Prevista no Mês</label>
        <input type="number" step="0.01" name="qtdPrevistoMes" required
               value="<%= editando ? p.getQtdPrevistoMes() : "" %>">

        <label>Preço Máximo Comprado (R$)</label>
        <input type="number" step="0.01" name="precoMaxComprado" required
               value="<%= editando ? p.getPrecoMaxComprado() : "" %>">

        <button type="submit">💾 Salvar</button>
    </form>

    <a href="produto?acao=listar" class="back">← Voltar para a lista</a>
</div>
</body>
</html>