using System.Diagnostics.Contracts;
using System.Security.Cryptography;

class SayaTubeVideo
{
    private int id;
    private String title;
    private int playCount;

    public SayaTubeVideo(String title)
    {
        //Contract.Requires <ArgumentNullException>(title != null, "Judul tidak boleh kosong");
        //Contract.Requires<ArgumentException>(title.Length < 200, "Judul terlalu panjang");

        if (title.Length > 200)
            throw new ArgumentException("Judul Terlalu Panjang");
        if (title == null)
            throw new ArgumentNullException("Judul Harus diisi");

        Random random = new Random();
        this.id = random.Next(00000, 99999);
        this.title = title;
        this.playCount = 0;
    }
    public void IncreasePlayCount(int jumNonton)
    {
        if (jumNonton > 25000000)
            throw new ArgumentOutOfRangeException("Jumlah penonton maksimal 25.000.000 / pemanggilan method");
        if (jumNonton < 0)
            throw new ArgumentOutOfRangeException("Jumlah penonton tidak boleh negatif");

        try
        {
            checked
            {
                this.playCount += jumNonton;
            }
        } catch (OverflowException)
        {
            Console.WriteLine("Sudah melebihi batas");
            return;
        }

    }

    public void PrintVideoDetails()
    {
        Console.WriteLine("Id = " + id);
        Console.WriteLine("Title = " + title);
        Console.WriteLine("Play Count = " + playCount);
        Console.WriteLine("");
    }

    public int GetPlayCount()
    {
        return playCount;
    }

    public String GetTitle()
    {
        return title;
    }
}
class SayaTubeUser
{
    private int id;
    private List<SayaTubeVideo> uploadVideos;
    public String username;

    public SayaTubeUser(String username)
    {
        if (username.Length > 100)
            throw new ArgumentException("Username terlalu panjang");
        if (username == null)
            throw new ArgumentNullException("Username tidak boleh kosong");

        Random random = new Random();
        this.id = random.Next(00000, 99999);
        this.username = username;
        this.uploadVideos = new List<SayaTubeVideo>();
    }

    public int GetTotalVideoPlayCount()
    {
        int total = 0;
        for (int i = 0; i < uploadVideos.Count; i++) {
            total += uploadVideos[i].GetPlayCount();
        }
        return total;
    }

    public void AddVideo(SayaTubeVideo vid)
    {
        if (vid == null)
            throw new ArgumentNullException("Video tidak boleh kosong");
        uploadVideos.Add(vid);
    }

    public void PrintAllViddeoPlaycount()
    {
        Console.WriteLine("User = " + username);

        for (int i = 0; i < 8; i++)
        {
            Console.WriteLine("Video " + (i + 1) + " judul = " + uploadVideos[i].GetTitle());
        }
    }
}

public class Program
{
    static void Main()
    {

        SayaTubeVideo vid1 = new SayaTubeVideo("Review Film Umbrella Academy oleh Bella");
        SayaTubeVideo vid2 = new SayaTubeVideo("Review Film Reply 1988 oleh Bella");
        SayaTubeVideo vid3 = new SayaTubeVideo("Review Film Hospital Playlist oleh Bella");
        SayaTubeVideo vid4 = new SayaTubeVideo("Review Film When Life Gives You Tangerines oleh Bella");
        SayaTubeVideo vid5 = new SayaTubeVideo("Review Film When Yakuza's Baby Sitting oleh Bella");
        SayaTubeVideo vid6 = new SayaTubeVideo("Review Film Hight Has Come oleh Bella");
        SayaTubeVideo vid7 = new SayaTubeVideo("Review Film Link Click oleh Bella");
        SayaTubeVideo vid8 = new SayaTubeVideo("Review Film Naruto oleh Bella");
        SayaTubeVideo vid9 = new SayaTubeVideo("Review Film Haikyu oleh Bella");
        SayaTubeVideo vid10 = new SayaTubeVideo("Review Film One Piece oleh Bella");

        for (int i = 0; i < 250; i++)
        {

            vid1.IncreasePlayCount(2500000);
            vid2.IncreasePlayCount(2500000);
            vid3.IncreasePlayCount(2500000);
            vid4.IncreasePlayCount(2500000);
            vid5.IncreasePlayCount(2500000);
            vid6.IncreasePlayCount(2500000);
            vid7.IncreasePlayCount(2500000);
            vid8.IncreasePlayCount(2500000);
            vid9.IncreasePlayCount(2500000);
            vid10.IncreasePlayCount(2500000);
        }

        vid1.PrintVideoDetails();
        vid2.PrintVideoDetails();
        vid3.PrintVideoDetails();
        vid4.PrintVideoDetails();
        vid5.PrintVideoDetails();
        vid6.PrintVideoDetails();
        vid7.PrintVideoDetails();
        vid8.PrintVideoDetails();
        vid9.PrintVideoDetails();
        vid10.PrintVideoDetails();

        SayaTubeUser user = new SayaTubeUser("Bella");
        user.GetTotalVideoPlayCount();
        user.AddVideo(vid1);
        user.AddVideo(vid2);
        user.AddVideo(vid3);
        user.AddVideo(vid4);
        user.AddVideo(vid5);
        user.AddVideo(vid6);
        user.AddVideo(vid7);
        user.AddVideo(vid8);
        user.AddVideo(vid9);
        user.AddVideo(vid10);
        user.PrintAllViddeoPlaycount();
    }
}