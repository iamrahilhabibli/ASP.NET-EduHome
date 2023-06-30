using EduHome.Core.Interfaces;

namespace EduHome.Core.Entities
{
	public class Blogs:IEntity
	{
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public DateTime Date { get; set; }
        public int CommentCount { get; set; }
        public string Title { get; set; }
        public string BlogText { get; set; }
        public  string ImagePath { get; set; }

    }
}
