using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogging.Data.Entities
{
    public class CommentEntity
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }

        public long BlogId { get; set; } //外键
        public BlogEntity Blog { get; set; }  //导航属性
    }
}
