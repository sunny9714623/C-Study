using System;
using System.Net.Http;
using System.Threading.Tasks;
using static System.Console;

namespace AsyncConsole
{
    class Program
    {
        // 如果有以Async方法结束的方法那么应该使用这个方法而不是不以Async作为后缀的方法。
        // 使用await关键字调用这个方法，使用async关键字进行修饰
        static async Task Main(string[] args)
        {
            var client = new HttpClient();

            HttpResponseMessage responseMessage = await client.GetAsync("http://www.apple.com/");
            WriteLine("Apple's home page has {0:N0} bytes.", responseMessage.Content.Headers.ContentLength);
        }
    }
}
