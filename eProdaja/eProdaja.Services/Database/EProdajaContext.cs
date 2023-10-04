using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace eProdaja.Services.Database;

public partial class EProdajaContext : DbContext
{
    public EProdajaContext()
    {
    }

    public EProdajaContext(DbContextOptions<EProdajaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Dobavljaci> Dobavljacis { get; set; }

    public virtual DbSet<IzlazStavke> IzlazStavkes { get; set; }

    public virtual DbSet<Izlazi> Izlazis { get; set; }

    public virtual DbSet<JediniceMjere> JediniceMjeres { get; set; }

    public virtual DbSet<Korisnici> Korisnicis { get; set; }

    public virtual DbSet<KorisniciUloge> KorisniciUloges { get; set; }

    public virtual DbSet<Kupci> Kupcis { get; set; }

    public virtual DbSet<NarudzbaStavke> NarudzbaStavkes { get; set; }

    public virtual DbSet<Narudzbe> Narudzbes { get; set; }

    public virtual DbSet<Ocjene> Ocjenes { get; set; }

    public virtual DbSet<Proizvodi> Proizvodis { get; set; }

    public virtual DbSet<Skladistum> Skladista { get; set; }

    public virtual DbSet<UlazStavke> UlazStavkes { get; set; }

    public virtual DbSet<Ulazi> Ulazis { get; set; }

    public virtual DbSet<Uloge> Uloges { get; set; }

    public virtual DbSet<VrsteProizvodum> VrsteProizvoda { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-G32L2E3;Initial Catalog=eProdaja; Integrated Security=True; TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dobavljaci>(entity =>
        {
            entity.HasKey(e => e.DobavljacId).HasName("PK__Dobavlja__DE87BE397E524A8B");

            entity.ToTable("Dobavljaci");

            entity.Property(e => e.Adresa).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Fax).HasMaxLength(20);
            entity.Property(e => e.KontaktOsoba).HasMaxLength(100);
            entity.Property(e => e.Naziv).HasMaxLength(100);
            entity.Property(e => e.Telefon).HasMaxLength(20);
            entity.Property(e => e.Web).HasMaxLength(100);
            entity.Property(e => e.ZiroRacuni).HasMaxLength(100);
        });

        modelBuilder.Entity<IzlazStavke>(entity =>
        {
            entity.HasKey(e => e.IzlazStavkaId).HasName("PK__IzlazSta__B3E0F01A01E0D33F");

            entity.ToTable("IzlazStavke");

            entity.Property(e => e.Cijena).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Popust).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Izlaz).WithMany(p => p.IzlazStavkes)
                .HasForeignKey(d => d.IzlazId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__IzlazStav__Izlaz__489AC854");

            entity.HasOne(d => d.Proizvod).WithMany(p => p.IzlazStavkes)
                .HasForeignKey(d => d.ProizvodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__IzlazStav__Proiz__498EEC8D");
        });

        modelBuilder.Entity<Izlazi>(entity =>
        {
            entity.HasKey(e => e.IzlazId).HasName("PK__Izlazi__153899201316AB25");

            entity.ToTable("Izlazi");

            entity.Property(e => e.BrojRacuna).HasMaxLength(100);
            entity.Property(e => e.Datum).HasColumnType("datetime");
            entity.Property(e => e.IznosBezPdv).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.IznosSaPdv).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.Izlazis)
                .HasForeignKey(d => d.KorisnikId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Izlazi__Korisnik__43D61337");

            entity.HasOne(d => d.Narudzba).WithMany(p => p.Izlazis)
                .HasForeignKey(d => d.NarudzbaId)
                .HasConstraintName("FK__Izlazi__Narudzba__44CA3770");

            entity.HasOne(d => d.Skladiste).WithMany(p => p.Izlazis)
                .HasForeignKey(d => d.SkladisteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Izlazi__Skladist__45BE5BA9");
        });

        modelBuilder.Entity<JediniceMjere>(entity =>
        {
            entity.HasKey(e => e.JedinicaMjereId).HasName("PK__Jedinice__F73C37CEBD19629D");

            entity.ToTable("JediniceMjere");

            entity.Property(e => e.Naziv).HasMaxLength(100);
        });

        modelBuilder.Entity<Korisnici>(entity =>
        {
            entity.HasKey(e => e.KorisnikId).HasName("PK__Korisnic__80B06D41155A1C4A");

            entity.ToTable("Korisnici");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Ime).HasMaxLength(100);
            entity.Property(e => e.KorisnickoIme).HasMaxLength(100);
            entity.Property(e => e.LozinkaHash).HasMaxLength(100);
            entity.Property(e => e.LozinkaSalt).HasMaxLength(100);
            entity.Property(e => e.Prezime).HasMaxLength(100);
            entity.Property(e => e.Telefon).HasMaxLength(20);
        });

        modelBuilder.Entity<KorisniciUloge>(entity =>
        {
            entity.HasKey(e => e.KorisnikUlogaId).HasName("PK__Korisnic__1608726E8B273382");

            entity.ToTable("KorisniciUloge");

            entity.Property(e => e.DatumIzmjene).HasColumnType("datetime");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.KorisniciUloges)
                .HasForeignKey(d => d.KorisnikId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Korisnici__Koris__4D5F7D71");

            entity.HasOne(d => d.Uloga).WithMany(p => p.KorisniciUloges)
                .HasForeignKey(d => d.UlogaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Korisnici__Uloga__4E53A1AA");
        });

        modelBuilder.Entity<Kupci>(entity =>
        {
            entity.HasKey(e => e.KupacId).HasName("PK__Kupci__A9593F9BFDAD8DBA");

            entity.ToTable("Kupci");

            entity.Property(e => e.DatumRegistracije).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Ime).HasMaxLength(100);
            entity.Property(e => e.KorisnickoIme).HasMaxLength(100);
            entity.Property(e => e.LozinkaHash).HasMaxLength(100);
            entity.Property(e => e.LozinkaSalt).HasMaxLength(100);
            entity.Property(e => e.Prezime).HasMaxLength(100);
        });

        modelBuilder.Entity<NarudzbaStavke>(entity =>
        {
            entity.HasKey(e => e.NarudzbaStavkaId).HasName("PK__Narudzba__7AC08DB847A238D3");

            entity.ToTable("NarudzbaStavke");

            entity.HasOne(d => d.Narudzba).WithMany(p => p.NarudzbaStavkes)
                .HasForeignKey(d => d.NarudzbaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NarudzbaS__Narud__2EDAF651");

            entity.HasOne(d => d.Proizvod).WithMany(p => p.NarudzbaStavkes)
                .HasForeignKey(d => d.ProizvodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NarudzbaS__Proiz__2FCF1A8A");
        });

        modelBuilder.Entity<Narudzbe>(entity =>
        {
            entity.HasKey(e => e.NarudzbaId).HasName("PK__Narudzbe__FBEC1377FEE0E234");

            entity.ToTable("Narudzbe");

            entity.Property(e => e.BrojNarudzbe).HasMaxLength(100);
            entity.Property(e => e.Datum).HasColumnType("datetime");

            entity.HasOne(d => d.Kupac).WithMany(p => p.Narudzbes)
                .HasForeignKey(d => d.KupacId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Narudzbe__KupacI__1DB06A4F");
        });

        modelBuilder.Entity<Ocjene>(entity =>
        {
            entity.HasKey(e => e.OcjenaId).HasName("PK__Ocjene__E6FC7AA98A97AA55");

            entity.ToTable("Ocjene");

            entity.Property(e => e.Datum).HasColumnType("datetime");

            entity.HasOne(d => d.Kupac).WithMany(p => p.Ocjenes)
                .HasForeignKey(d => d.KupacId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ocjene__KupacId__339FAB6E");

            entity.HasOne(d => d.Proizvod).WithMany(p => p.Ocjenes)
                .HasForeignKey(d => d.ProizvodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ocjene__Proizvod__32AB8735");
        });

        modelBuilder.Entity<Proizvodi>(entity =>
        {
            entity.HasKey(e => e.ProizvodId).HasName("PK__Proizvod__21A8BFF87C93D3FA");

            entity.ToTable("Proizvodi");

            entity.Property(e => e.Cijena).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Naziv).HasMaxLength(100);
            entity.Property(e => e.Sifra).HasMaxLength(100);

            entity.HasOne(d => d.JedinicaMjere).WithMany(p => p.Proizvodis)
                .HasForeignKey(d => d.JedinicaMjereId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Proizvodi__Jedin__0E6E26BF");

            entity.HasOne(d => d.Vrsta).WithMany(p => p.Proizvodis)
                .HasForeignKey(d => d.VrstaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Proizvodi__Vrsta__0D7A0286");
        });

        modelBuilder.Entity<Skladistum>(entity =>
        {
            entity.HasKey(e => e.SkladisteId).HasName("PK__Skladist__8542CDD2077A4287");

            entity.Property(e => e.Adresa).HasMaxLength(100);
            entity.Property(e => e.Naziv).HasMaxLength(100);
        });

        modelBuilder.Entity<UlazStavke>(entity =>
        {
            entity.HasKey(e => e.UlazStavkaId).HasName("PK__UlazStav__4BE49E75AC04D97E");

            entity.ToTable("UlazStavke");

            entity.Property(e => e.Cijena).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Proizvod).WithMany(p => p.UlazStavkes)
                .HasForeignKey(d => d.ProizvodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UlazStavk__Proiz__40F9A68C");

            entity.HasOne(d => d.Ulaz).WithMany(p => p.UlazStavkes)
                .HasForeignKey(d => d.UlazId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UlazStavk__UlazI__40058253");
        });

        modelBuilder.Entity<Ulazi>(entity =>
        {
            entity.HasKey(e => e.UlazId).HasName("PK__Ulazi__732B788D0DC932F0");

            entity.ToTable("Ulazi");

            entity.Property(e => e.BrojFakture).HasMaxLength(100);
            entity.Property(e => e.Datum).HasColumnType("datetime");
            entity.Property(e => e.IznosRacuna).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Pdv).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Dobavljac).WithMany(p => p.Ulazis)
                .HasForeignKey(d => d.DobavljacId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ulazi__Dobavljac__3D2915A8");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.Ulazis)
                .HasForeignKey(d => d.KorisnikId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ulazi__KorisnikI__3C34F16F");

            entity.HasOne(d => d.Skladiste).WithMany(p => p.Ulazis)
                .HasForeignKey(d => d.SkladisteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ulazi__Skladiste__3B40CD36");
        });

        modelBuilder.Entity<Uloge>(entity =>
        {
            entity.HasKey(e => e.UlogaId).HasName("PK__Uloge__DCAB23CB7BE167F4");

            entity.ToTable("Uloge");

            entity.Property(e => e.Naziv).HasMaxLength(100);
        });

        modelBuilder.Entity<VrsteProizvodum>(entity =>
        {
            entity.HasKey(e => e.VrstaId).HasName("PK__VrstePro__42CB8F2F3677EE1D");

            entity.Property(e => e.Naziv).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
