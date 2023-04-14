namespace MovieAPI.Models
{
    public class Review
    {
        public int ReviewId { get; set; }

        public string Comment { get; set; }

        public int Rate { get; set; }

        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }

    }
}
