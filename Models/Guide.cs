namespace EKGMaster.Models
{
    public class Guide
    {
        public int Nr {  get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public Guide(int nr, string title, string content) 
        {
            Nr = nr;
            Title = title;
            Content = content;
        }
    }
}
