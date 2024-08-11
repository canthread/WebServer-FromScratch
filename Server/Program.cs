using System.Net;

public class Program{
    public static void Main(){
        Server server = new Server();


        server.GetIPAddresses().ForEach(ip => Console.WriteLine(ip.ToString()));



    }
}
