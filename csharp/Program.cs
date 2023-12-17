namespace GildedRose;

public class Program
{
    public static void Main(string[] args)
    {
        var services = new ServiceCollection();
        AppDI.AddServices(services);

        var serviceProvider = services.BuildServiceProvider();

        var app = serviceProvider.GetRequiredService<IApp>();
        app.Run(args);
    }
}
