using System.Linq;

namespace InsurancePolicyApplication.Models
{
    public static class DBInitializer
    {
        public static void Initialize(InsurancePolicyDBContext context)
        {
            context.Database.EnsureCreated();

            // Look for any ContentInsurances Table in Database
            if (context.ContentInsurances.Any())
            {
                return; // DB has been seeded
            }

            var categories = new Category[]
            {
            new Category{Name="Electronics"},
            new Category{Name="Clothing"},
            new Category{Name="Kitchen"},
            };
            foreach (Category c in categories)
            {
                context.Categories.Add(c);
            }
            context.SaveChanges();

            var contents = new ContentInsurance[]
            {
                new ContentInsurance{Name="TV", Value=2000, CategoryId=1},
                 new ContentInsurance{Name="Playstation", Value=400, CategoryId=1},
                  new ContentInsurance{Name="Stereo", Value=1600, CategoryId=1},
                   new ContentInsurance{Name="Shirts", Value=1100, CategoryId=2},
                    new ContentInsurance{Name="Jeans", Value=1100, CategoryId=2},
                    new ContentInsurance{Name="Pots and Pans", Value=3000, CategoryId=3},
                    new ContentInsurance{Name="FlatWare", Value=500, CategoryId=3},
                    new ContentInsurance{Name="Knife Set", Value=500, CategoryId=3},
                    new ContentInsurance{Name="Misc", Value=1000, CategoryId=3},
            };
            foreach (ContentInsurance i in contents)
            {
                context.ContentInsurances.Add(i);
            }
            context.SaveChanges();
        }
    }
}
