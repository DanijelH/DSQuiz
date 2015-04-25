namespace DSKviz.Dao.Migrations
{
    using DSKviz.Model.Entity;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DSKviz.Dao.DBContextManager>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DSKviz.Dao.DBContextManager context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists("Normal"))
            {
                roleManager.Create(new IdentityRole("Normal"));
            }

            if (!roleManager.RoleExists("Administrator"))
            {
                roleManager.Create(new IdentityRole("Administrator"));
            }

            //Seed za kategorije
            /*
            context.Quizes.AddOrUpdate(new Quiz()
            {
                Name = "Programiranje",
                Category = new Category()
                {
                    Name = "Programiranje"
                },
                Questions =
                        new Collection<Question>()
                        {
                            new Question()
                            {
                                QuestionText = "Koji od navedenih programskih jezika se koristi na klijentskoj strani?",
                                Points = 3,
                                Answers = new Collection<Answer>()
                                {
                                    new Answer()
                                    {
                                        AnswerText = "C++",
                                        IsCorrect = false
                                    },
                                    new Answer()
                                    {
                                        AnswerText = "C#",
                                        IsCorrect = false
                                    },
                                    new Answer()
                                    {
                                        AnswerText = "JavaScript",
                                        IsCorrect = true
                                    },
                                    new Answer()
                                    {
                                        AnswerText = "Java",
                                        IsCorrect = false
                                    },
                                }
                            },
                            new Question()
                            {
                                QuestionText = "Koja od navedenih naredbi ne spada u DDL naredbe?",
                                Points = 3,
                                Answers = new Collection<Answer>()
                                {
                                    new Answer()
                                    {
                                        AnswerText = "DROP",
                                        IsCorrect = false
                                    },
                                    new Answer()
                                    {
                                        AnswerText = "INSERT",
                                        IsCorrect = true
                                    },
                                    new Answer()
                                    {
                                        AnswerText = "CREATE",
                                        IsCorrect = false
                                    },
                                    new Answer()
                                    {
                                        AnswerText = "ALTER",
                                        IsCorrect = false
                                    },
                                }
                            },
                            new Question()
                            {
                                QuestionText = "Koja naredba u JavaScriptu služi za otvaranje info bloka?",
                                Points = 3,
                                Answers = new Collection<Answer>()
                                {
                                    new Answer()
                                    {
                                        AnswerText = "Alert()",
                                        IsCorrect = true
                                    },
                                    new Answer()
                                    {
                                        AnswerText = "ShowInfo()",
                                        IsCorrect = false
                                    },
                                    new Answer()
                                    {
                                        AnswerText = "Confirm()",
                                        IsCorrect = false
                                    },
                                    new Answer()
                                    {
                                        AnswerText = "Console.Log()",
                                        IsCorrect = false
                                    },
                                }
                            },
                            new Question()
                            {
                                QuestionText = "Koja naredba služi za kreiranje Tablice u bazi?",
                                Points = 3,
                                Answers = new Collection<Answer>()
                                {
                                    new Answer()
                                    {
                                        AnswerText = "INSERT",
                                        IsCorrect = false
                                    },
                                    new Answer()
                                    {
                                        AnswerText = "NEW",
                                        IsCorrect = false
                                    },
                                    new Answer()
                                    {
                                        AnswerText = "TABLE",
                                        IsCorrect = false
                                    },
                                    new Answer()
                                    {
                                        AnswerText = "CREATE",
                                        IsCorrect = true
                                    },
                                }
                            }
                        }
            }
                );

            */
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
