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
        [Range(1, int.MaxValue, ErrorMessage = "û��ָ����Ӧ�Ĳ���")]
        [HiddenInput(DisplayValue = false)]
        public long BlogId { get; set; }

        [DisplayName("����")]
        [Required]
        [StringLength(1000, ErrorMessage = "{0}������{2}��{1}����֮��", MinimumLength = 10)]
        [UIHint("MultilineText")] //��Ⱦ�����ľͲ���<input> ����<textarea>
        public string Content { get; set; }
    }
}