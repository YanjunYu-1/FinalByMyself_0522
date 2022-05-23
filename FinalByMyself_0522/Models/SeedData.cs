﻿using FinalByMyself_0522.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FinalByMyself_0522.Models
{
    public class SeedData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());
            serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (!context.Roles.Any())
            {
                List<string> roles = new List<string>()
                {
                   "Administrator","ProjectManager","Developer","Submitter"
                };
                foreach (var role in roles)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            //for seed
            if (!context.AppUser.Any())
            {
                AppUser user = new AppUser()
                {
                    Email = "Administrator@mitt.ca",
                    NormalizedEmail = "ADMINISTRATOR@MITT.CA",
                    UserName = "Administrator@mitt.ca",
                    NormalizedUserName = "ADMINISTRATOR@MITT.CA",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                AppUser user2 = new AppUser()
                {
                    Email = "Projectmanager@mitt.ca",
                    NormalizedEmail = "PROJECTMANAGER@MITT.CA",
                    UserName = "Projectmanager@mitt.ca",
                    NormalizedUserName = "PROJECTMANAGER@MITT.CA",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                AppUser user3 = new AppUser()
                {
                    Email = "Developer001@mitt.ca",
                    NormalizedEmail = "DEVELOPER001@MITT.CA",
                    UserName = "developer001@mitt.ca",
                    NormalizedUserName = "DEVELOPER001@MITT.CA",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                AppUser user4 = new AppUser()
                {
                    Email = "Jaewon@gmail.com",
                    NormalizedEmail = "JAEWON@GMAIL.COM",
                    UserName = "Jaewon@gmail.com",
                    NormalizedUserName = "JAEWON@GMAIL.COM",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                AppUser user5 = new AppUser()
                {
                    Email = "bob@gmail.com",
                    NormalizedEmail = "BOB@GMAIL.COM",
                    UserName = "bob@gmail.com",
                    NormalizedUserName = "BOB@GMAIL.COM",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                AppUser user6 = new AppUser()
                {
                    Email = "Developer002@mitt.ca",
                    NormalizedEmail = "DEVELOPER002@MITT.CA",
                    UserName = "developer002@mitt.ca",
                    NormalizedUserName = "DEVELOPER002@MITT.CA",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                var passwordHasher = new PasswordHasher<AppUser>();
                var hasedPassword = passwordHasher.HashPassword(user, "P@ssword1");
                user.PasswordHash = hasedPassword;
                await userManager.CreateAsync(user);
                await userManager.AddToRoleAsync(user, "Administrator");

                var passwordHasher2 = new PasswordHasher<AppUser>();
                var hasedPassword2 = passwordHasher2.HashPassword(user2, "P@ssword1");
                user2.PasswordHash = hasedPassword2;
                await userManager.CreateAsync(user2);
                await userManager.AddToRoleAsync(user2, "Projectmanager");

                var passwordHasher3 = new PasswordHasher<AppUser>();
                var hasedPassword3 = passwordHasher3.HashPassword(user3, "P@ssword1");
                user3.PasswordHash = hasedPassword3;
                await userManager.CreateAsync(user3);
                await userManager.AddToRoleAsync(user3, "Developer");

                var passwordHasher4 = new PasswordHasher<AppUser>();
                var hasedPassword4 = passwordHasher4.HashPassword(user4, "P@ssword1");
                user4.PasswordHash = hasedPassword4;
                await userManager.CreateAsync(user4);
                await userManager.AddToRoleAsync(user4, "Submitter");

                var passwordHasher5 = new PasswordHasher<AppUser>();
                var hasedPassword5 = passwordHasher5.HashPassword(user5, "P@ssword1");
                user5.PasswordHash = hasedPassword5;
                await userManager.CreateAsync(user5);
                await userManager.AddToRoleAsync(user5, "Submitter");

                var passwordHasher6 = new PasswordHasher<AppUser>();
                var hasedPassword6 = passwordHasher6.HashPassword(user6, "P@ssword1");
                user6.PasswordHash = hasedPassword6;
                await userManager.CreateAsync(user6);
                await userManager.AddToRoleAsync(user6, "Developer");
            }
            context.SaveChanges();


            // for project
            if (!context.Project.Any())
            {
                Project project1 = new Project();
                project1.Name = "Language AI";
                context.Project.Add(project1);

                Project project2 = new Project();
                project2.Name = "Car Navigation AI";
                context.Project.Add(project2);
            }
            context.SaveChanges();

            //for Ticket
            if (!context.Ticket.Any())
            {
                Ticket ticket1 = new Ticket();
                ticket1.Title = "Bug Report Of Answering";
                ticket1.Description = "When I ask Where is your hometown, it says none.";
                ticket1.Created = DateTime.Now;
                ticket1.ProjectId = context.Project.First(p => p.Name == "Language AI").Id;
                ticket1.TicketType = TicketTypes.BugReport;
                ticket1.TicketPriority = TicketPriorities.High;
                ticket1.TicketStatus = TicketStatus.Assigned;
                ticket1.OwnerUserId = context.AppUser.First(u => u.UserName == "Jaewon@gmail.com").Id;
                ticket1.AssignedToUserId = context.AppUser.First(u => u.UserName == "developer001@mitt.ca").Id;
                context.Ticket.Add(ticket1);

                Ticket ticket2 = new Ticket();
                ticket2.Title = "Jump out App";
                ticket2.Description = "When I use App for a long time, The App will be Auto jump out.";
                ticket2.Created = DateTime.Now;
                ticket2.ProjectId = context.Project.First(p => p.Name == "Language AI").Id;
                ticket2.TicketType = TicketTypes.BugReport;
                ticket2.TicketPriority = TicketPriorities.High;
                ticket2.TicketStatus = TicketStatus.Assigned;
                ticket2.OwnerUserId = context.AppUser.First(u => u.UserName == "Jaewon@gmail.com").Id;
                ticket2.AssignedToUserId = context.AppUser.First(u => u.UserName == "developer001@mitt.ca").Id;
                context.Ticket.Add(ticket2);

                Ticket ticket3 = new Ticket();
                ticket3.Title = "Can't show some information";
                ticket3.Description = "When I use App for a long time, I will lose some information";
                ticket3.Created = DateTime.Now;
                ticket3.ProjectId = context.Project.First(p => p.Name == "Language AI").Id;
                ticket3.TicketType = TicketTypes.BugReport;
                ticket3.TicketPriority = TicketPriorities.High;
                ticket3.TicketStatus = TicketStatus.Assigned;
                ticket3.OwnerUserId = context.AppUser.First(u => u.UserName == "Jaewon@gmail.com").Id;
                ticket3.AssignedToUserId = context.AppUser.First(u => u.UserName == "developer001@mitt.ca").Id;
                context.Ticket.Add(ticket3);

                Ticket ticket4 = new Ticket();
                ticket4.Title = "Bug Report Of Showing";
                ticket4.Description = "Sometimes the App shows data that isn't what I want to show";
                ticket4.Created = DateTime.Now;
                ticket4.ProjectId = context.Project.First(p => p.Name == "Car Navigation AI").Id;
                ticket4.TicketType = TicketTypes.BugReport;
                ticket4.TicketPriority = TicketPriorities.High;
                ticket4.TicketStatus = TicketStatus.Assigned;
                ticket4.OwnerUserId = context.AppUser.First(u => u.UserName == "bob@gmail.com").Id;
                ticket4.AssignedToUserId = context.AppUser.First(u => u.UserName == "developer002@mitt.ca").Id;//Qusetion? developer001 :developer002
                context.Ticket.Add(ticket4);

                Ticket ticket5 = new Ticket();
                ticket5.Title = "According to the code";
                ticket5.Description = "When I translate in aother language, it shows grabled characters";
                ticket5.Created = DateTime.Now;
                ticket5.ProjectId = context.Project.First(p => p.Name == "Car Navigation AI").Id;
                ticket5.TicketType = TicketTypes.BugReport;
                ticket5.TicketPriority = TicketPriorities.High;
                ticket5.TicketStatus = TicketStatus.Assigned;
                ticket5.OwnerUserId = context.AppUser.First(u => u.UserName == "bob@gmail.com").Id;
                ticket5.AssignedToUserId = context.AppUser.First(u => u.UserName == "developer002@mitt.ca").Id;
                context.Ticket.Add(ticket5);

                Ticket ticket6 = new Ticket();
                ticket6.Title = "Invalid user name";
                ticket6.Description = "Sometimes I can't use my user name to log in to the App";
                ticket6.Created = DateTime.Now;
                ticket6.ProjectId = context.Project.First(p => p.Name == "Car Navigation AI").Id;
                ticket6.TicketType = TicketTypes.BugReport;
                ticket6.TicketPriority = TicketPriorities.High;
                ticket6.TicketStatus = TicketStatus.Assigned;
                ticket6.OwnerUserId = context.AppUser.First(u => u.UserName == "bob@gmail.com").Id;
                ticket6.AssignedToUserId = context.AppUser.First(u => u.UserName == "developer002@mitt.ca").Id;
                context.Ticket.Add(ticket6);
            }
            context.SaveChanges();
        }
    }
}
