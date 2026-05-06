<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Sistema de Produtos</title>
    <style>
        body { font-family: Arial, sans-serif; background: #f0f2f5; 
               display: flex; justify-content: center; align-items: center;
               min-height: 100vh; margin: 0; }
        .card { background: white; padding: 40px; border-radius: 12px;
                box-shadow: 0 4px 12px rgba(0,0,0,0.15); text-align: center; width: 320px; }
        h1 { color: #333; margin-bottom: 8px; }
        p  { color: #666; margin-bottom: 30px; }
        a  { display: block; padding: 12px; margin: 10px 0; border-radius: 8px;
             text-decoration: none; font-weight: bold; color: white; }
        .btn-primary  { background: #4A90D9; }
        .btn-secondary{ background: #6c757d; }
        a:hover { opacity: 0.85; }
    </style>
</head>
<body>
    <div class="card">
        <h1>📦 Produtos</h1>
        <p>Gerenciamento de Produtos</p>
        <a href="produto?acao=listar" class="btn-primary">🗂️ Gerenciar Produtos</a>
        <a href="creditos.jsp"        class="btn-secondary">👥 Créditos</a>
    </div>
</body>
</html>