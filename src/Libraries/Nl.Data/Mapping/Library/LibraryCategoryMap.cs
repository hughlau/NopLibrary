using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nl.Core.Domain.Library;

/****************************************************************
*   Author：L
*   Time：2019/3/29 19:10:17
*   FrameVersion：2.2
*   Description：
*
*****************************************************************/
namespace Nl.Data.Mapping.Library
{
    public partial class LibraryCategoryMap : NopEntityTypeConfiguration<LibraryCategory>
    {

        #region =============属性============



        #endregion

        #region ===========构造函数==========



        #endregion

        #region ===========基本方法==========



        #endregion

        #region =============方法============

        public override void Configure(EntityTypeBuilder<LibraryCategory> builder)
        {
            builder.ToTable(nameof(LibraryCategory));
            builder.HasKey(category => category.Id);

            builder.Property(category => category.Name).HasMaxLength(400).IsRequired();
            builder.Property(category => category.MetaKeywords).HasMaxLength(400);
            builder.Property(category => category.MetaTitle).HasMaxLength(400);
            builder.Property(category => category.PriceRanges).HasMaxLength(400);
            builder.Property(category => category.PageSizeOptions).HasMaxLength(200);

            builder.Ignore(category => category.AppliedDiscounts);

            base.Configure(builder);
        }

        #endregion
    }
}
