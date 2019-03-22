using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nl.Core.Domain.Catalog;

namespace Nl.Data.Mapping.Catalog
{
    /// <summary>
    /// Represents a product tag with count mapping configuration
    /// </summary>
    public partial class ProductTagWithCountMap : NopQueryTypeConfiguration<ProductTagWithCount>
    {
    }
}