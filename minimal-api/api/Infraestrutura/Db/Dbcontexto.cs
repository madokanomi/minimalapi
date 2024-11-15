using Microsoft.EntityFrameworkCore;
using minimal_api.Dominio.Entidades;

namespace MinimalApi.Infraestrutura.Db;

public class Dbcontexto : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.Entity<Administrador>().HasData(
new Administrador{
    Id = 1,       
    Email = "administrador@teste.com",
    Senha = "123456",
    Perfil = "Adm"
}
       );
    }
    private readonly IConfiguration _configuracaoAppSettings;
    public Dbcontexto(IConfiguration configuracaoAppSettings)
    {
        _configuracaoAppSettings = configuracaoAppSettings;
    }
    public DbSet<Administrador> Administradores {get ; set;}
      public DbSet<Veiculo> Veiculos {get ; set;} = default!;

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    if (!optionsBuilder.IsConfigured)
    {
        var stringConexao = _configuracaoAppSettings.GetConnectionString("mysql");
        
        if (!string.IsNullOrEmpty(stringConexao))
        {
            optionsBuilder.UseMySql(stringConexao, 
                ServerVersion.AutoDetect(stringConexao));
        }
    }
}

}