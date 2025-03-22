internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Masukkan judul video: ");
        string judulBaru = Console.ReadLine();

        SayaTubeVideo video;
        try
        {
            video = new SayaTubeVideo(judulBaru);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

        video.printVideoDetails();

        bool isValidInput;
        int play;
        do
        {
            Console.Write("Masukkan jumlah penambahan playcount (maksimal 10.000.000): ");
            isValidInput = int.TryParse(Console.ReadLine(), out play) && play <= 10000000;

            if (!isValidInput)
            {
                Console.WriteLine("Input jumlah penambahan playcount tidak valid!");
            }
        } while (!isValidInput);

        try
        {
            video.IncreasePlayCount(play);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

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
            if (title == "" || title.Length > 100)
                throw new Exception("Judul video tidak valid");

            this.id = random.Next(00000, 99999);
            this.title = title;
            this.playCount = 0;
        }

        public void IncreasePlayCount(int play)
        {
            if (play > 10000000)
                throw new Exception("Playcount melebihi batas");
            try
            {
                checked
                {
                    playCount += play;
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("Playcount melebihi batas tertinggi integer");
            }
        }

        public void printVideoDetails()
        {
            Console.WriteLine("ID : " + id);
            Console.WriteLine("Judul : " + title);
            Console.WriteLine("Play Count : " + playCount);
        }
    }
}