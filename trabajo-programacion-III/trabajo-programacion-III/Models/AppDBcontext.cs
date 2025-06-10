using Microsoft.EntityFrameworkCore;


namespace trabajo_programacion_III.Models
{
    public class AppDBcontext : DbContext
    {
        public AppDBcontext(DbContextOptions<AppDBcontext> options) : base(options)
        {
        }

        public DbSet<Gastos> Gastos { get; set; }
    }
 //    protected override void OnConfiguring(DbContextOptionsBuilder options)
   // {
      //  options.UseSqlServer("Data Source=julita;Initial Catalog=Trabajo_programacio_III;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
    //}
    
}
