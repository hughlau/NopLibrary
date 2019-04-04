using Nl.Core.Domain.Discounts;
using Nl.Core.Domain.Localization;
using Nl.Core.Domain.Security;
using Nl.Core.Domain.Seo;
using Nl.Core.Domain.Stores;
using System;
using System.Collections.Generic;
using System.Text;

/****************************************************************
*   Author：L
*   Time：2019/4/4 10:24:12
*   FrameVersion：2.2
*   Description：
*
*****************************************************************/
namespace Nl.Core.Domain.Library
{
    public partial class Book : BaseEntity, ILocalizedEntity, ISlugSupported
    {

        #region =============属性============

        public string Title { get; set; }
        public string PictrueUrl { get; set; }
        public string FileName { get; set; }
        public string TempFileName { get; set; }
        public string FilePath { get; set; }
        public string KeyWords { get; set; }
        public int Status { get; set; }
        public int FileCount { get; set; }
        public int CID { get; set; }
        public int CPID { get; set; }
        public int UserID { get; set; }
        public DateTime CreateDate { get; set; }
        public int ReadCount { get; set; }
        public decimal Cost { get; set; }
        public int Flag { get; set; }
        public int? FileType { get; set; }
        public int? ShowType { get; set; }
        public int? PageCount { get; set; }
        public int? FileSize { get; set; }
        public int? IsOnline { get; set; }
        public int? FreePage { get; set; }
        public int? DownLoadType { get; set; }
        public string VirtualRoot { get; set; }
        public string FileRoot { get; set; }
        public string MD5 { get; set; }
        public int? RepeatID { get; set; }
        public int DownLoadCount { get; set; }
        public int CommentCount { get; set; }
        public int DownLoadCountReal { get; set; }
        public int FullReadCount { get; set; }
        public decimal BookScore { get; set; }
        public int ScoreCount { get; set; }
        public int? BookShareFolderID { get; set; }
        public decimal? CostRead { get; set; }
        public string Description { get; set; }
        public DateTime UpLoadDate { get; set; }
        public int? Seconds { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public int? PicCount { get; set; }
        public string Attachment { get; set; }
        public string AttachmentPath { get; set; }
        public string UserName { get; set; }
        public string NodeCode { get; set; }
        public string CategoryTitle { get; set; }
        public int OpenType { get; set; }
        public int? ECID1 { get; set; }
        public int? ECID2 { get; set; }
        public int? ECID3 { get; set; }
        public int? ECID4 { get; set; }
        public int? DownScoreType { get; set; }
        public int? ShareType { get; set; }
        public int? dpi { get; set; }
        public string Rgb { get; set; }
        public string picview { get; set; }
        public string FileNo { get; set; }
        public string Refuse { get; set; }
        public string designtools { get; set; }
        public int? IsCompress { get; set; }
        public int? CPID1 { get; set; }
        public int? CPID2 { get; set; }
        public int? CPID3 { get; set; }
        public int? CPID4 { get; set; }

        #endregion

        #region ===========构造函数==========



        #endregion

        #region ===========基本方法==========



        #endregion

        #region =============方法============



        #endregion

    }
}
