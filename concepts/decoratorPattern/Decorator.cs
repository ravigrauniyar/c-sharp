using System;
namespace Internship
{
    public interface Video
    {
        public string Title { get; set; }
        public void ShowVideo();
    }
    public class NormalVideo : Video
    {
        public string Title { get; set; }
        public void ShowVideo()
        {
            Console.WriteLine("\nShowing video: " + Title + "\n");
        }
    }
    public abstract class VideoDecorator : Video
    {
        protected Video video;
        public VideoDecorator(Video video)
        {
            this.video = video;
        }
        public virtual string Title
        {
            get => video.Title;
            set => video.Title = value;
        }
        public virtual void ShowVideo()
        {
            video.ShowVideo();
        }
    }
    public class FilterDecorator : VideoDecorator
    {
        public FilterDecorator(Video video) : base(video) { }
        public override void ShowVideo()
        {
            base.ShowVideo();
            Console.WriteLine("\nAdding Filter on " + base.Title + ".\n");
        }
    }
    public class SubtitleDecorator : VideoDecorator
    {
        public SubtitleDecorator(Video video) : base(video) { }
        public override void ShowVideo()
        {
            base.ShowVideo();
            Console.WriteLine("\nAdding Subtitle on " + base.Title + ".\n");
        }
    }
    public class DecoratorDemo
    {
        public void designPatternDemo()
        {
            Video video = new NormalVideo();
            video.Title = "Classic Movie";

            video = new FilterDecorator(video);
            video = new SubtitleDecorator(video);

            video.ShowVideo();
        }
    }
}