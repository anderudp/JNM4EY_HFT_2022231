using JNM4EY_HFT_2022231.Models;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Endpoint
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // See Documentation folder for chart

            // Users
            var armin = new User() { UserId = 1, Name = "Armin Arlert", Email = "armin1@tatakae.gov.mg" };
            var rivaille = new User() { UserId = 2, Name = "Rivaille Ackerman", Email = "beybl8@tatakae.gov.mg" };
            var mikasa = new User() { UserId = 3, Name = "Mikasa Ackerman", Email = "mikasaEsSuCasa@tatakae.gov.mg" };
            var eren = new User() { UserId = 4, Name = "Eren Yeager", Email = "yaeger_bombastic@tatakae.gov.mg" };
            var floch = new User() { UserId = 5, Name = "Floch Forster", Email = "iEatBabiesForALiving@tatakae.gov.mg" };
            var zeke = new User() { UserId = 6, Name = "Zeke Yeager", Email = "monkeDaddy@tatakae.gov.mg" };
            var gabi = new User() { UserId = 7, Name = "Gabi Braun", Email = "potat_no_moar@tatakae.gov.mg" };

            // To-do item lists
            var goodguys = new Agenda()
            {
                AgendaId = 1,
                Title = "Good guy tasks",
                Description = "Tasks for the good guys of the story",
            };
            var fullcast = new Agenda()
            {
                AgendaId = 2,
                Title = "Full cast tasks",
                Description = "Tasks for the entire cast of the story",
            };
            var badguys = new Agenda()
            {
                AgendaId = 3,
                Title = "Bad guy tasks",
                Description = "Tasks for the bad guys of the story",
            };

            // To-do items
            var ally = new Todo() { TodoId = 1, Description = "Forge alliances", IsComplete = true, IsImportant = true, IsUrgent = true, AgendaId = 1 };
            var homeland = new Todo() { TodoId = 2, Description = "Protect homeland", IsComplete = false, IsImportant = true, IsUrgent = false, AgendaId = 1 };
            var mourn = new Todo() { TodoId = 3, Description = "Mourn dead friends", IsComplete = false, IsImportant = null, IsUrgent = null, AgendaId = 1 };
            var s2 = new Todo() { TodoId = 4, Description = "Get a second season", IsComplete = true, IsImportant = true, IsUrgent = null, AgendaId = 2 };
            var humanity = new Todo() { TodoId = 5, Description = "Save humanity", IsComplete = false, IsImportant = true, IsUrgent = true, AgendaId = 2 };
            var apocalypse = new Todo() { TodoId = 6, Description = "Survive the apocalypse", IsComplete = false, IsImportant = false, IsUrgent = false, AgendaId = 2 };
            var ignore = new Todo() { TodoId = 7, Description = "Ignore deaths of friends", IsComplete = true, IsImportant = null, IsUrgent = null, AgendaId = 3 };
            var genocide = new Todo() { TodoId = 8, Description = "Commit genocide", IsComplete = true, IsImportant = false, IsUrgent = true, AgendaId = 3 };
            var indoctrinate = new Todo() { TodoId = 9, Description = "Indoctrinate children", IsComplete = false, IsImportant = false, IsUrgent = true, AgendaId = 3 };


            // Join data
            var join1 = new AgendaUser { UserId = 1, AgendaId = 1 }; // armin - goodguys
            var join2 = new AgendaUser { UserId = 1, AgendaId = 2 }; // armin - fullcast
            var join3 = new AgendaUser { UserId = 2, AgendaId = 1 }; // rivaille - goodguys
            var join4 = new AgendaUser { UserId = 2, AgendaId = 2 }; // rivaille - fullcast
            var join5 = new AgendaUser { UserId = 3, AgendaId = 1 }; // mikasa - goodguys
            var join6 = new AgendaUser { UserId = 3, AgendaId = 2 }; // mikasa - fullcast
            var join7 = new AgendaUser { UserId = 4, AgendaId = 2 }; // eren - fullcast
            var join8 = new AgendaUser { UserId = 4, AgendaId = 3 }; // eren - badguys
            var join9 = new AgendaUser { UserId = 5, AgendaId = 2 }; // floch - fullcast
            var join10 = new AgendaUser { UserId = 5, AgendaId = 3 }; // floch - badguys
            var join11 = new AgendaUser { UserId = 6, AgendaId = 1 }; // zeke - goodguys
            var join12 = new AgendaUser { UserId = 6, AgendaId = 2 }; // zeke - fullcast
            var join13 = new AgendaUser { UserId = 6, AgendaId = 3 }; // zeke - badguys
            var join14 = new AgendaUser { UserId = 7, AgendaId = 2 }; // gabi - fullcast

            modelBuilder.Entity<Todo>().HasData(ally, homeland, mourn, s2, humanity, apocalypse, ignore, genocide, indoctrinate);
            modelBuilder.Entity<User>().HasData(armin, rivaille, mikasa, eren, floch, zeke, gabi);
            modelBuilder.Entity<Agenda>().HasData(goodguys, fullcast, badguys);
            modelBuilder.Entity<AgendaUser>().HasData(join1, join2, join3, join4, join5, join6, join7, join8, join9, join10, join11, join12, join13, join14);
        }
    }
}
