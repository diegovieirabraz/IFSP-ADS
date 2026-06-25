<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<!DOCTYPE html>
<html lang="pt-BR">
<head>
    <meta charset="UTF-8">
    <title>Ordens de Venda</title>
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
        <h2>Ordens de Venda (Orders)</h2>

        <div class="actions">
            <a class="btn btn-primary" href="${pageContext.request.contextPath}/order?action=new">+ Nova Ordem</a>
        </div>

        <c:if test="${empty orders}">
            <p class="empty-msg">Nenhuma ordem de venda cadastrada.</p>
        </c:if>

        <c:if test="${not empty orders}">
            <table>
                <tr>
                    <th>Nº Ordem</th>
                    <th>Valor</th>
                    <th>Data</th>
                    <th>Cliente</th>
                    <th>Vendedor</th>
                    <th>Ações</th>
                </tr>
                <c:forEach var="o" items="${orders}">
                    <tr>
                        <td>${o.ordNo}</td>
                        <td>R$ ${o.purchAmt}</td>
                        <td>${o.ordDate}</td>
                        <td>${o.customerName}</td>
                        <td>${empty o.salesmanName ? '-' : o.salesmanName}</td>
                        <td>
                            <a class="btn btn-edit" href="${pageContext.request.contextPath}/order?action=edit&id=${o.ordNo}">Editar</a>
                            <a class="btn btn-delete" href="${pageContext.request.contextPath}/order?action=delete&id=${o.ordNo}"
                               onclick="return confirm('Tem certeza que deseja excluir esta ordem?');">Excluir</a>
                        </td>
                    </tr>
                </c:forEach>
            </table>
        </c:if>
    </div>
</body>
</html>
