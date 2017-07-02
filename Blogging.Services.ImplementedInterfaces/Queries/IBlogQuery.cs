using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blogging.Services.ImplementedInterfaces.InputModels;

namespace Blogging.Services.ImplementedInterfaces.Queries
{
    public interface IBlogQuery: IQuery
    {
        List<BlogListItemViewModel> Blogs();

        BlogDetailViewModel Blog(long id);
    }
}
