# Trabalho Prático 04 – Java + SQL Server (Swing)

Frame igual ao do enunciado, busca com `LIKE`, `PreparedStatement` e navegação Próximo/Anterior.

## Estrutura
- `src/Main.java` – UI Swing, conexão JDBC e lógica de navegação.
- `sql/setup.sql` – cria o banco `aulajava`, tabelas `tbcargos` e `tbfuncs` e insere registros.

## Banco de dados
1) Execute o script:  
   - Via SSMS: novo query em `master`, rode `sql/setup.sql`.  
   - Via `sqlcmd` (ex.): `sqlcmd -S localhost -U sa -P SuaSenhaAqui -i sql\\setup.sql`
2) O banco `aulajava` ficará criado com dados de exemplo (incluindo “Marcelo”).

## Configurar JDBC
1) Baixe o driver Microsoft JDBC para SQL Server (ex.: `mssql-jdbc-12.4.1.jre11.jar`).  
2) Coloque o `.jar` na pasta do projeto.  
3) Edite em `src/Main.java`:
   - `DB_URL`: `jdbc:sqlserver://<host>:<porta>;databaseName=aulajava;encrypt=false`
   - `DB_USER` / `DB_PASSWORD`: credenciais do seu SQL Server.

## Compilar e executar (linha de comando)
```powershell
cd C:\ESD\CBTLPR2_TP_04
javac -cp ".;mssql-jdbc-12.4.1.jre11.jar" src/Main.java
java  -cp ".;mssql-jdbc-12.4.1.jre11.jar;src" Main
```
> Ajuste o nome do `.jar` se usar outra versão.

## Como usar
- Digite parte do nome no campo superior e clique **Pesquisar**.  
- A consulta faz `SELECT ... LIKE` com `PreparedStatement`.  
- Se encontrar resultados, os campos são preenchidos; use **Anterior/Próximo** para navegar.  
- Botões desabilitam nos limites (primeiro/último registro).
