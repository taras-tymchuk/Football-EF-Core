using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure( EntityTypeBuilder<Team> builder )
        {
            builder.Property( t => t.Id )
                    .HasColumnName( "TeamId" );

            builder.Property( p => p.Name )
                .IsRequired()
                .HasMaxLength( 30 );

            builder.Property( p => p.Budget )
                .IsRequired()
                .HasColumnType( "money" );
        }
    }
}
