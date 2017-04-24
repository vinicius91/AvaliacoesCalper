using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaliacoesCalper.Domain.Entities;
using AvaliacoesCalper.Domain.ValueObject;

namespace AvaliacoesCalper.Infra.Data.EntityConfig
{
    public class UsersConfiguration : EntityTypeConfiguration<Users>
    {
        public UsersConfiguration()
        {
            HasKey(u => u.Id);

            Property(u => u.Login)
                .IsRequired()
                .HasMaxLength(Users.loginMaxValue);

            Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(50);

            Property(u => u.Sobrenome)
                .IsRequired()
                .HasMaxLength(150);

            Property(u => u.PasswordHash)
                .IsRequired()
                .IsMaxLength();

            Property(u => u.TokenAlteracaoSenha)
                .IsOptional();

            Property(u => u.Email.Address)
                .HasColumnName("Email")
                .HasMaxLength(Email.AddressMaxLenght);




        }
    }
}
