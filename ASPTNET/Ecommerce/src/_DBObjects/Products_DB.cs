using Ecommerce.src.Domain.Model;

namespace Ecommerce.src._DBObjects;

public class Products_DB
{
  public List<Product> InsertDatabaseProducts()
  {
    return new List<Product>
    {
        new Product
        {
            Id = Guid.NewGuid().ToString(),
            Nome = "God of War Ragnarok",
            Preco = 59.99M,
            Descricao = "A continuação épica da jornada de Kratos e Atreus nos reinos nórdicos.",
            Categoria = "Jogos",
            Quantidade = 20
        },
        new Product
        {
            Id = Guid.NewGuid().ToString(),
            Nome = "Call of Duty: Modern Warfare II",
            Preco = 69.99M,
            Descricao = "O mais recente título da franquia Call of Duty, oferecendo uma experiência de tiro em primeira pessoa intensa.",
            Categoria = "Jogos",
            Quantidade = 30
        },
        new Product
        {
            Id = Guid.NewGuid().ToString(),
            Nome = "The Legend of Zelda: Breath of the Wild",
            Preco = 59.99M,
            Descricao = "Explore um mundo vasto e aberto na pele de Link, em uma das aventuras mais aclamadas da Nintendo.",
            Categoria = "Jogos",
            Quantidade = 25
        },
                new Product
        {
            Id = Guid.NewGuid().ToString(),
            Nome = "Resident Evil 4 Remake",
            Preco = 69.99M,
            Descricao = "Uma recriação moderna do clássico de survival horror, com gráficos impressionantes e jogabilidade atualizada.",
            Categoria = "Jogos",
            Quantidade = 15
        },
        new Product
        {
            Id = Guid.NewGuid().ToString(),
            Nome = "Final Fantasy XVI",
            Preco = 69.99M,
            Descricao = "Uma nova aventura épica no universo Final Fantasy, com combates dinâmicos e uma história envolvente.",
            Categoria = "Jogos",
            Quantidade = 20
        },
        new Product
        {
            Id = Guid.NewGuid().ToString(),
            Nome = "Spider-Man 2",
            Preco = 69.99M,
            Descricao = "Continue a história de Peter Parker e Miles Morales nesta sequência espetacular do Spider-Man da Marvel.",
            Categoria = "Jogos",
            Quantidade = 30
        },
        new Product
        {
            Id = Guid.NewGuid().ToString(),
            Nome = "Xbox Series X",
            Preco = 499.99M,
            Descricao = "O console mais poderoso da Microsoft, capaz de rodar jogos em 4K com até 120 FPS.",
            Categoria = "Consoles",
            Quantidade = 10
        },
        new Product
        {
            Id = Guid.NewGuid().ToString(),
            Nome = "PlayStation 5",
            Preco = 499.99M,
            Descricao = "Console next-gen da Sony com tecnologia de SSD ultrarrápido e controle DualSense inovador.",
            Categoria = "Consoles",
            Quantidade = 8
        },
        new Product
        {
            Id = Guid.NewGuid().ToString(),
            Nome = "Nintendo Switch OLED",
            Preco = 349.99M,
            Descricao = "Versão atualizada do Nintendo Switch com tela OLED de 7 polegadas e cores mais vibrantes.",
            Categoria = "Consoles",
            Quantidade = 15
        }
    };
  }
  public User InsertDatabaseUsers()
  {
    return new User
    {
      Id = Guid.NewGuid().ToString(),
      Name = "Admin",
      Email = "admin@gmail.com",
      Password = "admin",
    };
  }
}

