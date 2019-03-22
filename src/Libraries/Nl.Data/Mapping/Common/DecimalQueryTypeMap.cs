using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nl.Core.Domain.Common;

namespace Nl.Data.Mapping.Common
{
    /// <summary>
    /// Represents a decimal query type mapping configuration
    /// </summary>
    public partial class DecimalQueryTypeMap : NopQueryTypeConfiguration<DecimalQueryType>
    {
        #region Methods

        /// <summary>
        /// Configures the query type
        /// </summary>
        /// <param name="builder">The builder to be used to configure the query type</param>
        public override void Configure(QueryTypeBuilder<DecimalQueryType> builder)
        {
            builder.Property(decimalValue => decimalValue.Value).HasColumnType("decimal(18, 4)");

            base.Configure(builder);
        }

        #endregion
    }
}