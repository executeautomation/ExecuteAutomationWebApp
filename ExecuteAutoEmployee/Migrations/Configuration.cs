using ExecuteAutoEmployee.Models;

namespace ExecuteAutoEmployee.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ExecuteAutoEmployee.Models.EmployeeDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "EmployeeDb";
        }

        protected override void Seed(ExecuteAutoEmployee.Models.EmployeeDb context)
        {

            //Create users and roles
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            //Create different roles
            if (!roleManager.RoleExists("Administrator"))
            {
                roleManager.Create(new IdentityRole("Administrator"));
            }
            if (!roleManager.RoleExists("User"))
            {
                roleManager.Create(new IdentityRole("User"));
            }
            if (!roleManager.RoleExists("Guest"))
            {
                roleManager.Create(new IdentityRole("Guest"));
            }

            //Create users
            var admin = new ApplicationUser { UserName = "admin" };
            var user = new ApplicationUser { UserName = "user" };
            var guest = new ApplicationUser { UserName = "guest" };

            //Assign roles
            if (userManager.FindByName("admin") == null)
            {
                var result = userManager.Create(admin, "password");

                if (result.Succeeded)
                {
                    userManager.AddToRole(admin.Id, "Administrator");
                }
            }

            if (userManager.FindByName("user") == null)
            {
                var result = userManager.Create(user, "password");

                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "User");
                }
            }

            if (userManager.FindByName("guest") == null)
            {
                var result = userManager.Create(guest, "password");

                if (result.Succeeded)
                {
                    userManager.AddToRole(guest.Id, "Guest");
                }
            }


            context.Employee.AddOrUpdate(
                r => r.Name,
                new Employee()
                {
                    Id = 1,
                    Name = "Karthik",
                    Salary = 4000,
                    DurationWorked = 24,
                    Grade = 1,
                    Email = "karthik@executeautomation.com",
                    Benefits = new List<Benefits>()
                    {
                        new Benefits()
                        {
                            Id = 1,
                            AdditionalBenefits = new List<AdditionalBenefits>()
                            {
                                new AdditionalBenefits()
                                {
                                    BenefitName = "Car"
                                },
                                new AdditionalBenefits()
                                {
                                    BenefitName = "DriverHire"
                                },
                                new AdditionalBenefits()
                                {
                                    BenefitName = "HolidayClaim"
                                }
                            },
                            BasicBenefits = new List<BasicBenefits>()
                            {
                                new BasicBenefits()
                                {
                                    BenefitName = "Hospital"
                                },
                                new BasicBenefits()
                                {
                                    BenefitName = "Gym"
                                },
                                new BasicBenefits()
                                {
                                    BenefitName = "Dental"
                                }
                            }

                        }
                    }
                },

            new Employee()
            {
                Id = 2,
                Name = "Prashanth",
                Salary = 7000,
                DurationWorked = 30,
                Grade = 2,
                Email = "prashanth@executeautomation.com",
                Benefits = new List<Benefits>()
                    {
                        new Benefits()
                        {
                            Id = 2,
                            AdditionalBenefits = new List<AdditionalBenefits>()
                            {
                                new AdditionalBenefits()
                                {
                                    BenefitName = "Car"
                                },
                                new AdditionalBenefits()
                                {
                                    BenefitName = "DriverHire"
                                },
                            },
                            BasicBenefits = new List<BasicBenefits>()
                            {
                                new BasicBenefits()
                                {
                                    BenefitName = "Hospital"
                                },
                                new BasicBenefits()
                                {
                                    BenefitName = "Gym"
                                },
                                new BasicBenefits()
                                {
                                    BenefitName = "Dental"
                                }
                            }

                        }
                    }
            },

            new Employee()
            {
                Id = 3,
                Name = "Ramesh",
                Salary = 3500,
                DurationWorked = 13,
                Grade = 2,
                Email = "ramesh@executeautomation.com",
                Benefits = new List<Benefits>()
                    {
                        new Benefits()
                        {
                            Id = 3,
                            AdditionalBenefits = new List<AdditionalBenefits>()
                            {
                                new AdditionalBenefits()
                                {
                                    BenefitName = "Car"
                                }
                            },
                            BasicBenefits = new List<BasicBenefits>()
                            {
                                new BasicBenefits()
                                {
                                    BenefitName = "Hospital"
                                },
                                new BasicBenefits()
                                {
                                    BenefitName = "Dental"
                                }
                            }

                        }
                    }

            },

            new Employee()
            {
                Id = 4,
                Name = "John",
                Salary = 2500,
                DurationWorked = 18,
                Grade = 3,
                Email = "john@executeautomation.com",
                Benefits = new List<Benefits>()
                    {
                        new Benefits()
                        {
                            Id = 4,
                            AdditionalBenefits = new List<AdditionalBenefits>()
                            {
                                new AdditionalBenefits()
                                {
                                    BenefitName = "Bike"
                                }
                            },
                            BasicBenefits = new List<BasicBenefits>()
                            {
                                new BasicBenefits()
                                {
                                    BenefitName = "Hospital"
                                }
                            }

                        }
                    }

            }
            );

        }
    }
}
