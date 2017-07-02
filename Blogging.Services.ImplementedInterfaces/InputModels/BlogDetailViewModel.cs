using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Blogging.Services.ImplementedInterfaces.InputModels
{
    public class BlogDetailViewModel
    {
        public long Id { get; set; }

        [DisplayName("标题")]
        public string Title { get; set; }
        [DisplayName("内容")]
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public List<CommentListItemViewModel> Comments { get; set; }
    }
}