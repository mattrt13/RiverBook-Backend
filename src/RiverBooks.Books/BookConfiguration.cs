using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RiverBooks.Books;

internal class BookConfiguration : IEntityTypeConfiguration<Book>
{
    internal static readonly Guid book1Guid = new("3df1af55-c683-40c4-b775-7a8394bc0567");
    internal static readonly Guid book2Guid = new("c01fc697-a4da-43e1-8dae-1f191c9f6301");

    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(p => p.Title)
            .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
            .IsRequired();

        builder.Property(p => p.Author)
            .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
            .IsRequired();

        builder.HasData(GetSampleBookData());
    }

    private IEnumerable<Book> GetSampleBookData()
    {
        var tolken = "Tolken";
        yield return new Book(book1Guid, "Lotr1", tolken, 10.99m);
        yield return new Book(book2Guid, "Lotr2", tolken, 12.99m);
    }
}
