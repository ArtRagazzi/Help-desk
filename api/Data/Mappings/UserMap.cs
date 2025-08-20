using api.Entities;
using api.Entities.Enuns;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        //Define o nome da tabela
        builder.ToTable("user");
        //Define chave primaria
        builder.HasKey(x => x.Id);
        //AutoIncrement ID
        builder.Property(x => x.Id).ValueGeneratedOnAdd();


        builder.Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("first_name")
            .HasColumnType("varchar(50)");
        
        builder.Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("last_name")
            .HasColumnType("varchar(50)");

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("email")
            .HasColumnType("varchar(50)");
            
        //Difine Email como unique
        builder.HasIndex(x => x.Email)
            .IsUnique();

        builder.Property(x => x.Password)
            .IsRequired()
            .HasColumnName("password");
        
        builder.Property(x => x.Phone)
            .HasMaxLength(50)
            .HasColumnName("phone")
            .HasColumnType("varchar(50)");
        
        builder.Property(x => x.Address)
            .HasMaxLength(150)
            .HasColumnName("address")
            .HasColumnType("varchar(150)");


        builder.Property(x => x.Role)
            .IsRequired()
            .HasColumnName("role")
            .HasConversion<int>();

        builder.HasMany(x => x.Tickets)
            .WithOne(x => x.Owner)
            .HasForeignKey(x => x.OwnerId);
        
        // Gerando Seed Inicial

        builder.HasData(
            new User(
                firstName: "Artur",
                lastName: "Admin",
                email: "artur@admin.com",
                password: "123456",
                phone: "1999238-9992",
                address: "123 Main Street",
                role: UserRole.Admin
            ) { Id = 1 }, 
            new User(
                firstName: "Artur",
                lastName: "Normal",
                email: "artur@normal.com",
                password: "123456",
                phone: "1999238-9992",
                address: "123 Main Street",
                role: UserRole.User
            ) { Id = 2 }

        );

    }
}