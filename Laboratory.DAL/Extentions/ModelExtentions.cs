using Laboratory.DAL.Entities;
using Microsoft.EntityFrameworkCore;


namespace Laboratory.DAL.Extentions
{
    public static class ModelExtentions
    {
        public static void seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Title>().HasData(
                new Title
                {
                    Id = 1,
                    Name = "Mr"
                },
                new Title
                {
                    Id = 2,
                    Name = "Mrs"
                }
            );
            modelBuilder.Entity<Gender>().HasData(
                new Gender
                {
                    Id = 1,
                    Name = "Male"
                },
                new Gender
                {
                    Id = 2,
                    Name = "Female"
                }
            );
            modelBuilder.Entity<DiscountType>().HasData(
                new Gender
                {
                    Id = 1,
                    Name = "Precentage"
                },
                new Gender
                {
                    Id = 2,
                    Name = "Amount"
                }
            );
            modelBuilder.Entity<Unit>().HasData(
                new Unit
                {
                    Id = 1,
                    Name = "mg/l"
                },
                new Unit
                {
                    Id = 2,
                    Name = "mg/dl"
                },
                new Unit
                {
                    Id = 3,
                    Name = "mmole/l"
                },
                new Unit
                {
                    Id = 4,
                    Name = "pg/l"
                },
                new Unit
                {
                    Id = 5,
                    Name = "ug/l"
                },
                new Unit
                {
                    Id = 6,
                    Name = "u/l"
                },
                new Unit
                {
                    Id = 7,
                    Name = "u/dl"
                },
                new Unit
                {
                    Id = 8,
                    Name = "%"
                },
                new Unit
                {
                    Id = 9,
                    Name = "min"
                },
                new Unit
                {
                    Id = 10,
                    Name = "sec"
                },
                new Unit
                {
                    Id = 11,
                    Name = "L"
                },
                new Unit
                {
                    Id = 12,
                    Name = "pg/ml"
                }
            );
            modelBuilder.Entity<Category>().HasData(

                new Category
                {
                    Id = 1,
                    Name = "Hematology"
                },
                new Category
                {
                    Id = 2,
                    Name = "Chemistry"
                },
                new Category
                {
                    Id = 3,
                    Name = "Hormones"
                },
                new Category
                {
                    Id = 4,
                    Name = "Fluid"
                },
                new Category
                {
                    Id = 5,
                    Name = "Urine"
                },
                new Category
                {
                    Id = 6,
                    Name = "Stool"
                },
                new Category
                {
                    Id = 7,
                    Name = "Semen"
                },
                new Category
                {
                    Id = 8,
                    Name = "Serology"
                },
                new Category
                {
                    Id = 9,
                    Name = "Autoimmune"
                },
                new Category
                {
                    Id = 10,
                    Name = "Cancer"
                }
             );
        }
    }
}
