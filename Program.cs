using System.Security.Cryptography;

class SayaTubeVideo
{
    private int id;
    private String title;
    private int playCount;

    public SayaTubeVideo(String title)
    {
        Random random = new Random();
        this.id = random.Next(00000, 99999);
        this.title = title;
        this.playCount = 0;
    }
    public void IncreasePlayCount(int jumNonton)
    {
        this.playCount += jumNonton;
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine("Id = " + id);
        Console.WriteLine("Title = " + title);
        Console.WriteLine("Play Count = " + playCount);
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
        uploadVideos.Add(vid);
    }

    public void PrintAllViddeoPlaycount()
    {
        Console.WriteLine("User = " + username);

        for (int i = 0; i < uploadVideos.Count; i++)
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