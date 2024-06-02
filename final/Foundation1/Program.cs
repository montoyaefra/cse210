using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    // Comment class
    public class Comment
    {
        public string CommenterName { get; set; }
        public string CommentText { get; set; }

        public Comment(string commenterName, string commentText)
        {
            CommenterName = commenterName;
            CommentText = commentText;
        }
    }

    // Video class
    public class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int LengthInSeconds { get; set; }
        private List<Comment> _comments;

        public Video(string title, string author, int lengthInSeconds)
        {
            Title = title;
            Author = author;
            LengthInSeconds = lengthInSeconds;
            _comments = new List<Comment>();
        }

        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }

        public int GetNumberOfComments()
        {
            return _comments.Count;
        }

        public List<Comment> GetComments()
        {
            return _comments;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create video objects
            var videos = new List<Video>
            {
                new Video("C# Tutorial", "John Doe", 600),
                new Video("Python Basics", "Jane Smith", 800),
                new Video("Java Programming", "Alice Johnson", 700)
            };

            // Add comments to videos
            videos[0].AddComment(new Comment("Michael", "Great tutorial!"));
            videos[0].AddComment(new Comment("Sarah", "Very helpful, thanks!"));
            videos[0].AddComment(new Comment("Alex", "Well explained!"));

            videos[1].AddComment(new Comment("Tom", "I love Python!"));
            videos[1].AddComment(new Comment("Jerry", "Clear and concise."));
            videos[1].AddComment(new Comment("Emma", "Thanks for sharing!"));

            videos[2].AddComment(new Comment("David", "Java is awesome!"));
            videos[2].AddComment(new Comment("Sophia", "Good job!"));
            videos[2].AddComment(new Comment("Liam", "Learned a lot from this video."));

            // Display video details and comments
            foreach (var video in videos)
            {
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
                Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");

                var comments = video.GetComments();
                foreach (var comment in comments)
                {
                    Console.WriteLine($"- {comment.CommenterName}: {comment.CommentText}");
                }

                Console.WriteLine();
            }
        }
    }
}
