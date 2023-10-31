using MailAutoConfigurationLib;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace MailAutoConfigurationCLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                Console.WriteLine("Usage: dotnet run {MailAddress}");
                return;
            }

            var result = new MailAutoConfiguration().SearchAsync(args[0]).Result;
            if(result == null)
            {
                Console.WriteLine("Mail Config not found.");
                return;
            }

            var json = JsonSerializer.Serialize(result, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true,
            });
            Console.WriteLine(json);
        }
    }
}