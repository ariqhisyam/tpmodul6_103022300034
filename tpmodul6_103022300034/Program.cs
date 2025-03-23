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

            while (true)
            {
                Console.Write("Enter play count to increase (max 10,000,000): ");
                if (int.TryParse(Console.ReadLine(), out int playCount))
                {
                    try
                    {
                        video.IncreasePlayCount(playCount);
                        video.PrintVideoDetails();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
