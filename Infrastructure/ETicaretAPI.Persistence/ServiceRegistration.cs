using Microsoft.EntityFrameworkCore;
using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
	public static class ServiceRegistration
	{
		public static void AddPersistanceServices(this IServiceCollection services)
		{
			services.AddDbContext<ETicaretAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
		}
	}

    // Aşagıdan package manager console a gelip default procjti seçip (Infrastructure\ETicaretAPI.Persistence)


    // --- Entitiy'yi olusturduktan sonra migration Oluşturma
    // add-migration mig_1

    // --- Oluşan migrationları veritabanına ekler.veritabanı yoksa appsetting içindeki bilgiye göre veritabanı oluşturur ve ekler
    // update-database
}
