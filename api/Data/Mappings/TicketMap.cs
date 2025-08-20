using api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.Mappings;

public class TicketMap : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder) 
    {
        //Define o nome da tabela
        builder.ToTable("ticket");
        //Define chave primaria
        builder.HasKey(x => x.Id);
        //AutoIncrement ID
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        
        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("title")
            .HasColumnType("varchar(50)");
        
        builder.Property(x => x.Description)
            .HasMaxLength(500)
            .HasColumnName("description")
            .HasColumnType("varchar(500)");
        
        builder.Property(x => x.Severity)
            .IsRequired()
            .HasColumnName("severity")
            .HasConversion<int>();
        
        builder.Property(x => x.Status)
            .IsRequired()
            .HasColumnName("status")
            .HasConversion<int>();
        
        builder.Property(x => x.CreationDate)
            .IsRequired()
            .HasColumnName("creationDate")
            .HasColumnType("datetime");
        
        builder.Property(x => x.LastUpdateDate)
            .IsRequired()
            .HasColumnName("lastUpdateDate")
            .HasColumnType("datetime");
        
        
        //N:1 com ticket -> user
        builder.HasOne(x => x.Owner)
            .WithMany(x=> x.Tickets)
            .HasForeignKey(x => x.OwnerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
    
}