using System;

public class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        if (string.IsNullOrEmpty(title) || title.Length > 100)
        {
            throw new ArgumentException("Judul video tidak valid. Panjang judul harus antara 1-100 karakter.");
        }

        Random random = new Random();
        this.id = random.Next(10000, 99999);

        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        if (count <= 0 || count > 10000000)
        {
            throw new ArgumentException("Jumlah penambahan playCount tidak valid. Harus antara 1-10.000.000.");
        }

        try
        {
            checked
            {
                this.playCount += count;
            }
        }
        catch (OverflowException)
        {
            throw new OverflowException("PlayCount melebihi batas maksimum.");
        }
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine("Video Details:");
        Console.WriteLine("ID: " + this.id);
        Console.WriteLine("Title: " + this.title);
        Console.WriteLine("Play Count: " + this.playCount);
    }

    public static void Main(string[] args)
    {
        try
        {
            SayaTubeVideo video = new SayaTubeVideo("Tutorial Design By Contract - Ariq Hisyam Nabil");

            video.IncreasePlayCount(1000);
            video.IncreasePlayCount(500);

            video.PrintVideoDetails();

            for (int i = 0; i < 1000; i++)
            {
                try
                {
                    video.IncreasePlayCount(10000000);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}