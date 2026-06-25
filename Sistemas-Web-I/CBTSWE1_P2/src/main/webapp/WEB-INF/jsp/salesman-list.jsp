<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<!DOCTYPE html>
<html lang="pt-BR">
<head>
    <meta charset="UTF-8">
    <title>Vendedores</title>
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
        <h2>Vendedores (SalesMan)</h2>

        <div class="actions">
            <a class="btn btn-primary" href="${pageContext.request.contextPath}/salesman?action=new">+ Novo Vendedor</a>
        </div>

        <c:if test="${empty salesmen}">
            <p class="empty-msg">Nenhum vendedor cadastrado.</p>
        </c:if>

        <c:if test="${not empty salesmen}">
            <table>
                <tr>
                    <th>ID</th>
                    <th>Nome</th>
                    <th>Cidade</th>
                    <th>Comissão</th>
                    <th>Ações</th>
                </tr>
                <c:forEach var="s" items="${salesmen}">
                    <tr>
                        <td>${s.salesmanId}</td>
                        <td>${s.name}</td>
                        <td>${s.city}</td>
                        <td>${s.commission}</td>
                        <td>
                            <a class="btn btn-edit" href="${pageContext.request.contextPath}/salesman?action=edit&id=${s.salesmanId}">Editar</a>
                            <a class="btn btn-delete" href="${pageContext.request.contextPath}/salesman?action=delete&id=${s.salesmanId}"
                               onclick="return confirm('Tem certeza que deseja excluir este vendedor?');">Excluir</a>
                        </td>
                    </tr>
                </c:forEach>
            </table>
        </c:if>
    </div>
</body>
</html>
