using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (!context.Schools.Any())
            {

                var schools = new List<Education>
            {
                new Education
                {
                    Institution ="North South University",
                    StartDate = DateTime.ParseExact("05/01/2015", "d", null),
                    EndDate = DateTime.ParseExact("06/01/2021", "d", null),
                    Degree=" Bachelor of Science",
                    Major = "Computer Science & Engineering",
                    Result = 3.34
                },

                new Education
                {
                    Institution ="Dhaka City College",
                    StartDate = DateTime.ParseExact("05/01/2012", "d", null),
                    EndDate = DateTime.ParseExact("05/01/2014", "d", null),
                    Degree = "Higher Secondary Certificate (HSC)",
                    Major = "Science",
                    Result = 5.00
                },

            };

                await context.Schools.AddRangeAsync(schools);

            }

            if (!context.Certificates.Any())
            {
                var seedCertificates = new List<Certificate>{
                new Certificate{
                    name="Angular Training",
                    Date = DateTime.ParseExact("12/16/2020", "d", null),
                    Url="https://www.udemy.com/certificate/UC-c664a93c-0655-432a-ab99-99ec568b0264/"
                },
                new Certificate{
                    name="Full Stack Development With Angular & .NET",
                    Date = DateTime.ParseExact("04/18/2021", "d", null),
                    Url="https://www.udemy.com/certificate/UC-55146540-a014-4d8a-9e8a-044bb21d620f/"
                }
            };

                await context.Certificates.AddRangeAsync(seedCertificates);

            }
            await context.SaveChangesAsync();


        }
    }
}