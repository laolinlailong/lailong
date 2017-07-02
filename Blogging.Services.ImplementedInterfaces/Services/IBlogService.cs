using Blogging.Services.ImplementedInterfaces.InputModels;

namespace Blogging.Services.ImplementedInterfaces.Services
{
    public interface IBlogService: IService
    {
        long Create(BlogInputModel model);
        long Comment(CommentInputModel model);
    }
}