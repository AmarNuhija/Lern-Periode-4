using BOTFORDISCORD2.config;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using System.Threading.Tasks;

namespace BOTFORDISCORD2
{
    internal class Program
    {
        public static DiscordIntents Intents { get; private set; }
        public static string Token { get; private set; }
        public static TokenType TokenType { get; private set; }
        public static bool AutoReconnect { get; private set; }
        private static DiscordClient Client { get; set; }
        private static CommandsNextExtension Commands { get; set; }

        static async Task Main(string[] args)
        {
            var jsonReader = new JSONreader();
            await jsonReader.ReadJSON();

            var discordconfig = new DiscordConfiguration()
            {
                Intents = DiscordIntents.All,
                Token = jsonReader.token,
                TokenType = TokenType.Bot,
                AutoReconnect = true
            };

            Client = new DiscordClient(discordconfig);

            Client.Ready += Client_Ready;


            await Client.ConnectAsync();
            await Task.Delay(-1);           //Das hier mit -1 bringt uns das solange ich dieses Programm starte, das es die ganze Zeit auf Discord läuft.
             }

            private static Task Client_Ready(DiscordClient sender, DSharpPlus.EventArgs.ReadyEventArgs args)

            {
                return Task.CompletedTask;
            }
    }
}
