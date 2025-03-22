internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Masukkan Judul : ");
        string judulBaru = Console.ReadLine();

        SayaTubeVideo video = new SayaTubeVideo(judulBaru);

        video.printVideoDetails();

        Console.WriteLine("Masukkan jumlah penambahan playcount : ");
        int play = int.Parse(Console.ReadLine());
        video.IncreasePlayCount(play);

        video.printVideoDetails();
    }

    class SayaTubeVideo
    {
        private int id;
        private string title;
        private int playCount;

        private static Random random = new Random();

        public SayaTubeVideo(string title)
        {
            this.id = random.Next(00000, 99999);
            this.title = title;
            this.playCount = 0;
        }

        public void IncreasePlayCount(int play)
        {
            playCount += play;
        }

        public void printVideoDetails()
        {
            Console.WriteLine("ID : " + id);
            Console.WriteLine("Judul : " + title);
            Console.WriteLine("Play Count : " + playCount);
        }
    }
}