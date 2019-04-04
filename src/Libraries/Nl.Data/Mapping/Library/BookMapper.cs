using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nl.Core.Domain.Library;


/****************************************************************
*   Author：L
*   Time：2019/4/4 10:30:39
*   FrameVersion：2.2
*   Description：
*
*****************************************************************/
namespace Nl.Data.Mapping.Library
{
    public partial class BookMapper : NopEntityTypeConfiguration<Book>
    {

        #region =============属性============



        #endregion

        #region ===========构造函数==========



        #endregion

        #region ===========基本方法==========



        #endregion

        #region =============方法============

        public override void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable(nameof(Book));

            builder.HasKey(book => book.Id);
            builder.Property(book => book.Title).HasMaxLength(200);
            builder.Property(book => book.PictrueUrl).HasMaxLength(200);
            builder.Property(book => book.FileName).HasMaxLength(200);
            builder.Property(book => book.TempFileName).HasMaxLength(50);
            builder.Property(book => book.FilePath).HasMaxLength(500);
            builder.Property(book => book.KeyWords).HasMaxLength(200);

            builder.Property(book => book.VirtualRoot).HasMaxLength(200);
            builder.Property(book => book.FileRoot).HasMaxLength(200);
            builder.Property(book => book.MD5).HasMaxLength(200);
            builder.Property(book => book.Attachment).HasMaxLength(50);
            builder.Property(book => book.AttachmentPath).HasMaxLength(500);
            builder.Property(book => book.UserName).HasMaxLength(200);
            builder.Property(book => book.NodeCode).HasMaxLength(200);
            builder.Property(book => book.CategoryTitle).HasMaxLength(200);
            builder.Property(book => book.picview).HasMaxLength(200);
            builder.Property(book => book.FileNo).HasMaxLength(50);
            builder.Property(book => book.Refuse).HasMaxLength(500);
            builder.Property(book => book.designtools).HasMaxLength(200);


            base.Configure(builder);
        }

        #endregion
    }
}
