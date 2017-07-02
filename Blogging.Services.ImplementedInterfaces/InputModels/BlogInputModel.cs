using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Blogging.Services.ImplementedInterfaces.InputModels
{
    public class BlogInputModel
    {
        [HiddenInput(DisplayValue = false)]
        public long Id { get; set; }

        [DisplayName("标题")]
        [Required]
        [StringLength(50, ErrorMessage = "{0}必须在{2}与{1}个字之间" ,MinimumLength = 5)]
        public string Title { get; set; }

        [DisplayName("正文")]
        [Required]
        [StringLength(1000, ErrorMessage = "{0}必须在{2}与{1}个字之间" ,MinimumLength = 10)]
        [UIHint("MultilineText")] //渲染出来的就不是<input> 而是<textarea>
        public string Content { get; set; }
    }
}