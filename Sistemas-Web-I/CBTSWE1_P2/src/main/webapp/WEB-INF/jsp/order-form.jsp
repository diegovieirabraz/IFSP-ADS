<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<!DOCTYPE html>
<html lang="pt-BR">
<head>
    <meta charset="UTF-8">
    <title>Formulário de Ordem de Venda</title>
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
        <h2>${empty order ? 'Nova Ordem de Venda' : 'Editar Ordem de Venda'}</h2>

        <c:if test="${empty customers}">
            <p class="empty-msg">
                ⚠️ Você precisa cadastrar pelo menos um cliente antes de criar uma ordem de venda.
                <a href="${pageContext.request.contextPath}/customer?action=new">Cadastrar cliente</a>
            </p>
        </c:if>

        <c:if test="${not empty customers}">
            <form method="post" action="${pageContext.request.contextPath}/order">
                <c:if test="${not empty order}">
                    <input type="hidden" name="ordNo" value="${order.ordNo}">
                </c:if>

                <label for="purchAmt">Valor da compra (R$)</label>
                <input type="number" id="purchAmt" name="purchAmt" value="${order.purchAmt}" step="0.01" min="0" required>

                <label for="ordDate">Data da ordem</label>
                <input type="date" id="ordDate" name="ordDate" value="${order.ordDate}" required>

                <label for="customerId">Cliente</label>
                <select id="customerId" name="customerId" required>
                    <option value="">-- Selecione --</option>
                    <c:forEach var="c" items="${customers}">
                        <option value="${c.customerId}" ${order.customerId == c.customerId ? 'selected' : ''}>
                            ${c.custName} (ID ${c.customerId})
                        </option>
                    </c:forEach>
                </select>

                <label for="salesmanId">Vendedor</label>
                <select id="salesmanId" name="salesmanId">
                    <option value="">-- Nenhum --</option>
                    <c:forEach var="s" items="${salesmen}">
                        <option value="${s.salesmanId}" ${order.salesmanId == s.salesmanId ? 'selected' : ''}>
                            ${s.name} (ID ${s.salesmanId})
                        </option>
                    </c:forEach>
                </select>

                <div class="actions">
                    <button type="submit" class="btn btn-primary">Salvar</button>
                    <a class="btn" href="${pageContext.request.contextPath}/order">Cancelar</a>
                </div>
            </form>
        </c:if>
    </div>
</body>
</html>
