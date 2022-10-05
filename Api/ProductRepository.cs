
// Criando um Repositorio
// Static: torna global
public static class ProductRepository {
    public static List<Product> Products { get; set; } = Products = new List<Product>();

    //"Iniciando"- Atribuindo os dados já existentes à lista, dados  que estão no "Banco de dados"
    public static void Init(IConfiguration configuration) {
        var products = configuration.GetSection("Products").Get<List<Product>>();
        Products = products;
    }

// Adicionar produto
    public static void Add(Product product){
        Products.Add(product);
    }

    // OrDefault é para se caso não ache, informe 0, neste caso aparece NULL, por ser uma string
    public static Product GetBy(string code) {
        return Products.FirstOrDefault(p => p.Code == code);
    }

    // Remover
    public static void Remove(Product product) {
        Products.Remove(product);
    }
}
