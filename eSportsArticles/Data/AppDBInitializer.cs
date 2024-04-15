using eSportsArticles.Models;

namespace eSportsArticles.Data
{
    public class AppDBInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope()) 
            {
                var context = serviceScope.ServiceProvider.GetService<AppDBContext>();

                
                if(context != null)
                {
                    context.Database.EnsureCreated();

                } else
                {
                    throw new Exception("AppDBContext nu a fost regăsit în containerul de servicii.");
                }

                //Article
                if(!context.Articles.Any())
                {
                    context.Articles.AddRange(new List<Article>()
                    {
                        new Article() 
                        {
                            Description = "test ",
                            articleName = "Sanie",
                            Price = 200,
                            Color = "maro",
                            Size = "copii",
                            PictureURL = "https://sportano.ro/img/5c06e5cc417e494d49cecc1c7a999f9a/5/9/5904823010107_20E-jpg/sanie-de-lemn-vt-sport-davos-colint-maro-dcl-60110-614415.jpg"
                        },
                        
                        new Article()
                        {
                            Description = "test ",
                            articleName = "Schiuri",
                            Price = 300,
                            Color = "gri",
                            Size = "adulti",
                            PictureURL = "https://s13emagst.akamaized.net/products/62848/62847141/images/res_6f254f096b19bd4417ce24d2b4a55bc8.jpg?width=450&height=450&hash=EBD4B8178A768C3D481D82A5980F0AA9"
                        },

                        new Article()
                        {
                            Description = "test ",
                            articleName = "Snowboard",
                            Price = 350,
                            Color = "albastru",
                            Size = "adulti",
                            PictureURL = "https://www.shop-sgsnowboards.com/wp-content/uploads/2019/05/SG-SNOWBOARDS-SHRED-17-18.png"
						}
                    });
                    context.SaveChanges();
                }
                
                
                
                //Store
                if (!context.Stores.Any())
                {
                    context.Stores.AddRange(new List<Store>()
                    {
                    new Store()
                    {

                        storeName = "Inchirieri articole sportive",
                        Location = "Pitesti",
                        PictureURL ="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTAp2mr0xy14i9pgVZWzSI3R0vJpD3rYR9Knw&usqp=CAU",
                        closeHour = "22:00",
                        openHour = "08:00"
                    },

                    new Store()
                    {

                        storeName = "ESports",
                        Location = "Brasov",
                        PictureURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQPDCiOeEL6ApGyjILQP75OBauMUs70JR0h3g&usqp=CAU",
                        closeHour = "22:00",
                        openHour = "08:00"
                    },

                    new Store()
                    {

                        storeName = "Rent a Bike",
                        Location = "Galati",
                        PictureURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTRIdDWlCAD3BBWLhbfSdb2cck3z8BCW-bdNw&usqp=CAU",
                        closeHour = "22:00",
                        openHour = "08:00"
                    }
                    });
                    context.SaveChanges(); 
                }

                //Employee
                if (!context.Employees.Any())
                {
                    foreach (var store in context.Stores)
                    {
                        
                        context.Employees.AddRange(new List<Employee>()
                        {
                            
                            new Employee()
                            {
                                storeId = store.Id,
                                employeePosition ="casier",
                                Phone = "telefon",
                                Email = "email",
                                firstName = "Vlad",
                                lastName = "Atanasiu",
                                City = "Pitesti",
                                Salary = 10000
                            },

                        new Employee()
                        {
                            storeId = store.Id,
                            employeePosition ="casier",
                            Phone = "telefon",
                            Email = "email",
                           firstName = "Eduard",
                           lastName = "Oprescu",
                           City = "Brasov",
                           Salary = 3000
                        },

                        new Employee()
                        {
                            storeId = store.Id,
                            employeePosition ="casier",
                            Phone = "telefon",
                            Email = "email",
                            firstName = "Roxana",
                            lastName = "Dumitrescu",
                            City = "Galati",
                            Salary = 4000
                        }
                    });
                    }
                    context.SaveChanges();
                }


                //StoresArticles
                if (!context.StoresArticles.Any())
                {
                    // Get a list of articleId's from the Articles table
                    var articleIds = context.Articles.Select(a => a.Id).ToList();

                    foreach (var store in context.Stores)
                    {
                        // Add each articleId to the StoresArticles table for the current store
                        var storesArticles = articleIds.Select(Article_Id => new StoresArticles
                        {
                            storeId = store.Id,
                            articleId = Article_Id
                        }).ToList();

                        context.StoresArticles.AddRange(storesArticles);
                    }

                    context.SaveChanges();
                }

            }
        }
    }
}
