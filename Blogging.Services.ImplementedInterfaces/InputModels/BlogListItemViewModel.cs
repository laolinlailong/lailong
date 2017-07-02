using System;

namespace Blogging.Services.ImplementedInterfaces.InputModels
{
    public class BlogListItemViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
    }
}