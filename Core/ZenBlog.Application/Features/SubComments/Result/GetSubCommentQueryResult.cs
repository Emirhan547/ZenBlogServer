using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Comments.Result;
using ZenBlog.Application.Features.Users.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.SubComments.Result
{
    public class GetSubCommentQueryResult:BaseDto
    {
        public string UserId { get; set; }
        public  GetUsersQueryResult User { get; set; }
        public string Body { get; set; }
        public DateTime CommentDate { get; set; }
        public Guid CommentId { get; set; }
        public  GetCommentsQueryResult Comment { get; set; }
    }
}
