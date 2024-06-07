using API.Extensions.Enums;
using API.Models.Entity;

namespace API.Models.Response
{
    public record PostResponse(PostEnum Post)
    {
        public string PostString => Post.GetStringValue();
    }
}
