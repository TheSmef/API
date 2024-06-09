using API.Models.Entity;
using API.Utility.Constants;
using Bogus;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using System.Text.RegularExpressions;

namespace API.Data.Context
{
    /// <summary>
    /// EF Core контекст для взаимодействия с базой данных
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// <inheritdoc cref="DbContext()"/>
        /// </summary>
        /// <param name="options"><inheritdoc cref="DbContextOptions"/></param>
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region Employee
            modelBuilder.Entity<Employee>().HasKey(x => x.Id);
            modelBuilder.Entity<Employee>().HasIndex(x => x.Post);
            modelBuilder.Entity<Employee>().Property(x => x.FirstName)
                .HasMaxLength(120).IsRequired(true);
            modelBuilder.Entity<Employee>().Property(x => x.LastName)
                .HasMaxLength(120).IsRequired(true);
            modelBuilder.Entity<Employee>().Property(x => x.MiddleName)
                .HasMaxLength(120).IsRequired(false);
            modelBuilder.Entity<Employee>().Property(x => x.Post)
                .IsRequired(true);
            #endregion
            #region Shift
            modelBuilder.Entity<Shift>().HasKey(x => x.Id);
            modelBuilder.Entity<Shift>()
                .HasOne(x => x.Employee).WithMany(x => x.Shifts)
                .HasForeignKey(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Shift>().HasIndex(x => x.Date);
            modelBuilder.Entity<Shift>().Property(x => x.End)
                .IsRequired(false);
            modelBuilder.Entity<Shift>().Property(x => x.Start)
                .IsRequired(true);
            modelBuilder.Entity<Shift>().Property(x => x.Date)
                .IsRequired(true);
            #endregion
            #region Population 
            //При популяции данных приходиться вручную задавать ключ
            //Это плохо при условиях того, что ключ имеет индекс
            //В условиях теста и малого кол-ва записей, я думаю, нормально
            //Однако в условиях обычного использования, лучше так не делать
            Faker<Employee> employeeFaker = new Faker<Employee>()
                .RuleFor(x => x.Id, faker => faker.Random.Guid())
                .RuleFor(x => x.Post, faker => faker.PickRandom<PostEnum>())
                .RuleFor(x => x.FirstName, faker => faker.Name.FirstName())
                .RuleFor(x => x.LastName, faker => faker.Name.LastName())
                .RuleFor(x => x.MiddleName, faker => faker.Name.FirstName(Bogus.DataSets.Name.Gender.Male));

            List<Employee> employees = employeeFaker.Generate(15);

            modelBuilder.Entity<Employee>().HasData(employees);

            Faker<Shift> shiftfaker = new Faker<Shift>()
                .RuleFor(x => x.Id, faker => faker.Random.Guid())
                .RuleFor(x => x.End, faker => faker.Date
                    .BetweenTimeOnly(TimeOnly.FromTimeSpan(TimeSpan.FromHours(16)),
                    TimeOnly.FromTimeSpan(TimeSpan.FromHours(22))))
                .RuleFor(x => x.Start, faker => faker.Date
                    .BetweenTimeOnly(TimeOnly.FromTimeSpan(TimeSpan.FromHours(8)),
                    TimeOnly.FromTimeSpan(TimeSpan.FromHours(10))))
                .RuleFor(x => x.Date, faker => faker.Date
                    .BetweenDateOnly(DateOnly.FromDateTime(DateTime.Now.AddDays(-30)),
                    DateOnly.FromDateTime(DateTime.Now)))
                .RuleFor(x => x.EmployeeId, faker => faker.PickRandom(employees.Select(x => x.Id)));

            List<Shift> shifts = shiftfaker.Generate(250);

            modelBuilder.Entity<Shift>().HasData(shifts);
            #endregion
        }
        /// <summary>
        /// Сет для сотрудников
        /// </summary>
        public DbSet<Employee> Employees { get; set; }
        /// <summary>
        /// Сет для смен
        /// </summary>
        public DbSet<Shift> Shifts { get; set; }
    }
}
