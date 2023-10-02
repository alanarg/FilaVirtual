using FilaVirtual.Business.Interface;
using FilaVirtual.Business.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace MSSUPERA.Business.Models;

public partial class FilaVirtual_Context : IdentityDbContext<AspNetUsers>
{
    // Gerar migration a partir desse Context:  Add-Migration -Context MSSUPERA_desContext
    // Realizar atualização de banco a partir desse Context: Update-Database -Context MSSUPERA_desContext
    public FilaVirtual_Context()
    {
    }
    IUser _user;

    public FilaVirtual_Context(DbContextOptions<FilaVirtual_Context> options, IUser user)
    : base(options)

    {
        _user = user;
    }
  

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
