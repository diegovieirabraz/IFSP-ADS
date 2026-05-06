package dao;

import model.Produto;
import java.util.ArrayList;
import java.util.List;

public class BancoProdutos {
	
	private static BancoProdutos instancia = null;
    private List<Produto> lista = new ArrayList<>();
    private int proximoId = 1;

    private BancoProdutos() {
        lista.add(new Produto(proximoId++, "Arroz", 50, "Arroz branco tipo 1", 200.0, 8.50));
        lista.add(new Produto(proximoId++, "Feijão", 30, "Feijão carioca", 150.0, 6.90));
    }

    public static BancoProdutos getInstancia() {
        if (instancia == null) {
            instancia = new BancoProdutos();
        }
        return instancia;
    }

    // CREATE
    public void inserir(Produto p) {
        p.setId(proximoId++);
        lista.add(p);
    }

    // READ ALL
    public List<Produto> listarTodos() {
        return lista;
    }

    // READ ONE
    public Produto buscarPorId(int id) {
        for (Produto p : lista) {
            if (p.getId() == id) return p;
        }
        return null;
    }

    // UPDATE
    public void atualizar(Produto atualizado) {
        for (int i = 0; i < lista.size(); i++) {
            if (lista.get(i).getId() == atualizado.getId()) {
                lista.set(i, atualizado);
                return;
            }
        }
    }

    // DELETE
    public void excluir(int id) {
        lista.removeIf(p -> p.getId() == id);
    }

}
