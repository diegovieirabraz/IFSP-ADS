<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<!DOCTYPE html>
<html lang="pt-BR">
<head>
    <meta charset="UTF-8">
    <title>Formulário de Cliente</title>
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
        <h2>${empty customer ? 'Novo Cliente' : 'Editar Cliente'}</h2>

        <form method="post" action="${pageContext.request.contextPath}/customer">
            <c:if test="${not empty customer}">
                <input type="hidden" name="customerId" value="${customer.customerId}">
            </c:if>

            <label for="custName">Nome</label>
            <input type="text" id="custName" name="custName" value="${customer.custName}" required maxlength="30">

            <label for="city">Cidade</label>
            <input type="text" id="city" name="city" value="${customer.city}" maxlength="15">

            <label for="grade">Grade</label>
            <input type="number" id="grade" name="grade" value="${customer.grade}" min="0" max="999">

            <label for="salesmanId">Vendedor responsável</label>
            <select id="salesmanId" name="salesmanId">
                <option value="">-- Nenhum --</option>
                <c:forEach var="s" items="${salesmen}">
                    <option value="${s.salesmanId}" ${customer.salesmanId == s.salesmanId ? 'selected' : ''}>
                        ${s.name} (ID ${s.salesmanId})
                    </option>
                </c:forEach>
            </select>

            <div class="actions">
                <button type="submit" class="btn btn-primary">Salvar</button>
                <a class="btn" href="${pageContext.request.contextPath}/customer">Cancelar</a>
            </div>
        </form>
    </div>
</body>
</html>
