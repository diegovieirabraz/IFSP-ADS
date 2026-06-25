<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<!DOCTYPE html>
<html lang="pt-BR">
<head>
    <meta charset="UTF-8">
    <title>Formulário de Vendedor</title>
    <link rel="stylesheet" href="${pageContext.request.contextPath}/style.css">
</head>
<body>
    <header>
        <h1>📦 Sistema de Inventário - CBTSWE1</h1>
    </header>
    <nav>
        <a href="${pageContext.request.contextPath}/salesman">Vendedores</a>
        <a href="${pageContext.request.contextPath}/customer">Clientes</a>
        <a href="${pageContext.request.contextPath}/order">Ordens de Venda</a>
    </nav>
    <div class="container">
        <h2>${empty salesman ? 'Novo Vendedor' : 'Editar Vendedor'}</h2>

        <form method="post" action="${pageContext.request.contextPath}/salesman">
            <c:if test="${not empty salesman}">
                <input type="hidden" name="salesmanId" value="${salesman.salesmanId}">
            </c:if>

            <label for="name">Nome</label>
            <input type="text" id="name" name="name" value="${salesman.name}" required maxlength="30">

            <label for="city">Cidade</label>
            <input type="text" id="city" name="city" value="${salesman.city}" maxlength="15">

            <label for="commission">Comissão (ex: 0.12)</label>
            <input type="number" id="commission" name="commission" value="${salesman.commission}" step="0.01" min="0" max="999">

            <div class="actions">
                <button type="submit" class="btn btn-primary">Salvar</button>
                <a class="btn" href="${pageContext.request.contextPath}/salesman">Cancelar</a>
            </div>
        </form>
    </div>
</body>
</html>
