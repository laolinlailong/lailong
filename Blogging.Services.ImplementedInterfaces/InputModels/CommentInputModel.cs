using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Blogging.Services.ImplementedInterfaces.InputModels
{
    public class CommentInputModel
    {
        [HiddenInput(DisplayValue = false)]
        public long Id { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "没有指定对应的博客")]
        [HiddenInput(DisplayValue = false)]
        public long BlogId { get; set; }

        [DisplayName("正文")]
        [Required]
        [StringLength(1000, ErrorMessage = "{0}必须在{2}与{1}个字之间", MinimumLength = 10)]
        [UIHint("MultilineText")] //渲染出来的就不是<input> 而是<textarea>
        public string Content { get; set; }
    }
}