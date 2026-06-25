<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<!DOCTYPE html>
<html lang="pt-BR">
<head>
    <meta charset="UTF-8">
    <title>Clientes</title>
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
        <h2>Clientes (Customer)</h2>

        <div class="actions">
            <a class="btn btn-primary" href="${pageContext.request.contextPath}/customer?action=new">+ Novo Cliente</a>
        </div>

        <c:if test="${empty customers}">
            <p class="empty-msg">Nenhum cliente cadastrado.</p>
        </c:if>

        <c:if test="${not empty customers}">
            <table>
                <tr>
                    <th>ID</th>
                    <th>Nome</th>
                    <th>Cidade</th>
                    <th>Grade</th>
                    <th>Vendedor</th>
                    <th>Ações</th>
                </tr>
                <c:forEach var="c" items="${customers}">
                    <tr>
                        <td>${c.customerId}</td>
                        <td>${c.custName}</td>
                        <td>${c.city}</td>
                        <td>${c.grade}</td>
                        <td>${empty c.salesmanName ? '-' : c.salesmanName}</td>
                        <td>
                            <a class="btn btn-edit" href="${pageContext.request.contextPath}/customer?action=edit&id=${c.customerId}">Editar</a>
                            <a class="btn btn-delete" href="${pageContext.request.contextPath}/customer?action=delete&id=${c.customerId}"
                               onclick="return confirm('Tem certeza que deseja excluir este cliente?');">Excluir</a>
                        </td>
                    </tr>
                </c:forEach>
            </table>
        </c:if>
    </div>
</body>
</html>
