using Data;
using Data.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Canchas
{
    public static class DbInitializer
    {
        public static void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<CanchasDbContext>();


                // Add Customers
                var justin = new Customer
                {
                    FirstName = "Justin",
                    LastName = "Hood",
                    Mail = "generic@mail.com",
                    CellPhone = "69696969",
                    AccountType = AccountType.User,
                    TrustLevel = 0, 
                    CreatedBy = -1,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = -1,
                    ModifiedDate = DateTime.Now,
                    Desc = "Seed db",
                    Erased = Erased.NO,
                    Status = Status.ACTIVE

                };
                var justin2 = new Customer
                {
                    FirstName = "Justin2",
                    LastName = "Hood2",
                    Mail = "generic123@mail.com",
                    CellPhone = "69696969",
                    AccountType = AccountType.User,
                    TrustLevel = 0,


                    CreatedBy = -1,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = -1,
                    ModifiedDate = DateTime.Now,
                    Desc = "Seed db 2",
                    Erased = Erased.NO,
                    Status = Status.ACTIVE

                };
                context.Customers.Add(justin);
                context.Customers.Add(justin2);
                // Add Game 
                var futbol5 = new Field {
                    Name = "Futbol 5",
                    Size = 5, 
                    CreatedBy = -1,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = -1,
                    ModifiedDate = DateTime.Now,
                    Desc = "Seed db f5",
                    Erased = Erased.NO,
                    Status = Status.ACTIVE
                };
                var futbol7 = new Field
                {
                    Name = "Futbol 7",
                    Size = 7,
                    CreatedBy = -1,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = -1,
                    ModifiedDate = DateTime.Now,
                    Desc = "Seed db f7",
                    Erased = Erased.NO,
                    Status = Status.ACTIVE
                };
                var futbol11 = new Field
                {
                    Name = "Futbol 11",
                    Size = 11,
                    CreatedBy = -1,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = -1,
                    ModifiedDate = DateTime.Now,
                    Desc = "Seed db f11",
                    Erased = Erased.NO,
                    Status = Status.ACTIVE
                };
                context.Games.Add(futbol5);
                context.Games.Add(futbol7);
                context.Games.Add(futbol11);
                // Add Business
                var ex1 = new Business
                { 
                    Name = "Negocio 1", 
                    CreatedBy = -1,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = -1,
                    ModifiedDate = DateTime.Now,
                    Desc = "Seed db f5",
                    Erased = (int)Erased.NO,
                    Status = (int)Status.ACTIVE
                };
                context.Businesses.Add(ex1);

                context.SaveChanges();
                /* Add Field
                var f1 = new Field
                {
                    Name = "Cancha 1",
                    GameId = 2,
                    BusinessId = 1,
                    Size = 5,
                    CreatedBy = -1,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = -1,
                    ModifiedDate = DateTime.Now,
                    Desc = "Seed db f5",
                    Erased = 0,
                    Status = 0
                };
                context.Fields.Add(f1); 
             

                context.SaveChanges();
               */
            }
        }
    }
}
