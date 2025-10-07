using System;

class Program
{
    static void Main(string[] args)
    {
        var currentTime = TimeOnly.Parse(Console.ReadLine());
        var timeOfExplosion = TimeOnly.Parse(Console.ReadLine());
        var desiredTime = timeOfExplosion - currentTime;
        if (desiredTime.Equals(TimeSpan.Zero)) Console.WriteLine("24:00:00");
        else Console.WriteLine(desiredTime);
    }
}