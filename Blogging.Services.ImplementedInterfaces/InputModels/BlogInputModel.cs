using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Blogging.Services.ImplementedInterfaces.InputModels
{
    public class BlogInputModel
    {
        [HiddenInput(DisplayValue = false)]
        public long Id { get; set; }

        [DisplayName("����")]
        [Required]
        [StringLength(50, ErrorMessage = "{0}������{2}��{1}����֮��" ,MinimumLength = 5)]
        public string Title { get; set; }

        [DisplayName("����")]
        [Required]
        [StringLength(1000, ErrorMessage = "{0}������{2}��{1}����֮��" ,MinimumLength = 10)]
        [UIHint("MultilineText")] //��Ⱦ�����ľͲ���<input> ����<textarea>
        public string Content { get; set; }
    }
}