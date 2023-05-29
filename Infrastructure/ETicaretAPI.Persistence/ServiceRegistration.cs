﻿using Microsoft.EntityFrameworkCore;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Persistence.Repositories;

namespace ETicaretAPI.Persistence
{
	public static class ServiceRegistration
	{
		public static void AddPersistanceServices(this IServiceCollection services)
		{
			services.AddDbContext<ETicaretAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString), ServiceLifetime.Singleton);
			services.AddSingleton<ICustomerReadRepository, CustomerReadRepository>();
			services.AddSingleton<ICustomerWriteRepository, CustomerWriteRepository>();
			services.AddSingleton<IOrderReadRepository, OrderReadRepository>();
			services.AddSingleton<IOrderWriteRepository, OrderWriteRepository>();
			services.AddSingleton<IProductReadRepository, ProductReadRepository>();
			services.AddSingleton<IProductWriteRepository, ProductWriteRepository>();
        }
	}

    // Aşagıdan package manager console a gelip default procjti seçip (Infrastructure\ETicaretAPI.Persistence)


    // --- Entitiy'yi olusturduktan sonra migration Oluşturma
    // add-migration mig_1

    // --- Oluşan migrationları veritabanına ekler.veritabanı yoksa appsetting içindeki bilgiye göre veritabanı oluşturur ve ekler
    // update-database
}
