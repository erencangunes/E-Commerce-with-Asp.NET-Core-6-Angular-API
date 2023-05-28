using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
	public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ETicaretAPIDbContext>
	{

        //Bazen cmd'den Dotnet CLI ile igration oluşturmak lazım o yüzden bunu yapmak lazım
        public ETicaretAPIDbContext CreateDbContext(string[] args) 
		{

            DbContextOptionsBuilder<ETicaretAPIDbContext> dbContextOptionsBuilder = new();
			dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);
			return new (dbContextOptionsBuilder.Options);
		}

        // TERMİNALDEN İLGİLİ KLASÖRE GELİP (C:\Users\ERENCAN\Desktop\ETicaretUygulaması\ETicaretAPI\Infrastructure\ETicaretAPI.Persistence)


        // --- Entitiy'yi olusturduktan sonra migration Oluşturma
        // dotnet ef migrations add mig_1

        // --- Oluşan migrationları veritabanına ekler.veritabanı yoksa appsetting içindeki bilgiye göre veritabanı oluşturur ve ekler
        // dotnet ef database update


    }
}
