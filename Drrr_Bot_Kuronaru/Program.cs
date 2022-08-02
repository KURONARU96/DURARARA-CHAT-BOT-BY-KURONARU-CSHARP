using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;
using System.Text;
using System.Text.Json.Serialization;
using System.Timers;
using System.Collections;

namespace Drrr_Bot_Kuronaru
{
    class Program
    {

        public static List<Task> loop_func = new List<Task>();
        public static ArrayList Musicas_PlayList = new ArrayList();

        static string TRIPCODE_BOSS = "TRIPCODEBOTOWNER"; //Tripcode of the user who owns the bot in the room
        static string ID_SALA = "";
        static string tripcode_bot = "";
        static string Name = "";
        static string Icon_ID = "";

        static async Task Main(string[] args)
        {
            Console.WriteLine("Running Bot...");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Connection", "keep-alive");
            client.DefaultRequestHeaders.Add("Keep-Alive", "true");
            client.DefaultRequestHeaders.Add("UserAgent", "bot");


            var content = await client.GetStringAsync("https://drrr.com/?api=json");
            var json_login = JsonConvert.DeserializeObject<Root>(content.ToString());

            Console.WriteLine($"Auth. Token: {json_login.Authorization}");

            Console.WriteLine("Set bot username:");

            Name = Console.ReadLine();

            Console.WriteLine("Set bot icon:");

            Icon_ID = Console.ReadLine();

            content = await login(client, json_login, "login");

            var salas_lounge = JsonConvert.DeserializeObject<Lounge_Json>(content);

            Console.WriteLine("Bot Logged!");

            Console.WriteLine("Set Room ID Manually? [Y/N]");

            if (Console.ReadLine().ToUpper() == "Y")
            {
                Console.WriteLine("Set the ROOM ID:");
                ID_SALA = Console.ReadLine();
                Console.WriteLine($"Room ID Set to:{ID_SALA}");

            }
            else if (Console.ReadLine().ToUpper() == "N")
            {
                foreach (var salas in salas_lounge.Rooms)
                {
                    foreach (var users in salas.Users)
                    {
                        if (users.Tripcode == TRIPCODE_BOSS)
                        {
                            ID_SALA = salas.RoomId;
                        }
                    }
                }


            }

            tripcode_bot = salas_lounge.Profile.Tripcode;
            Console.WriteLine($"Tripcode BOT: {tripcode_bot}");
            Console.WriteLine("Entering the room...");

            content = await client.GetStringAsync($"https://drrr.com/room/?id={ID_SALA}");

            Console.Clear();
            Console.WriteLine("Bot Online!");

            loop_func.Add(MSG_LOADS(client, json_login));

            Console.ReadKey();



        }

        #region [MSG LOADS]
        public static async Task MSG_LOADS(HttpClient client, Root json_login)
        {

            int count_msgs = 0;

            while (true)
            {

                try
                {

                    var content = await client.GetStringAsync("https://drrr.com/room/?api=json");

                    var json_sala_info = JsonConvert.DeserializeObject<Json_Room>(content);

                    if (json_sala_info.Room.Talks.Count > count_msgs)
                    {
                        count_msgs = json_sala_info.Room.Talks.Count;


                        if (json_sala_info.Room.Talks[0].Type == "join" && json_sala_info.Room.Talks[0].User.Tripcode != $"{tripcode_bot}" && json_sala_info.Room.Talks[0].User.Name != Name)
                        {
                            Console.ForegroundColor = ConsoleColor.Green; Console.Write("[SYSTEM]: "); Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine($"[Message]: {json_sala_info.Room.Talks[0].User.Name} {json_sala_info.Room.Talks[0].Message.Substring(3).Trim()}");
                            Console.ResetColor();

                            loop_func.Add(ENVIA_MSG_URL(client, $" Welcome! ^^)/ {json_sala_info.Room.Talks[0].User.Name}.\nUse command /help to know my commands ^^)", "https://media.tenor.com/images/466e1357b8aa9ff7a22119af21856006/tenor.gif"));

                        }

                        if (json_sala_info.Room.Talks[0].Type == "message" && json_sala_info.Room.Talks[0].From.Tripcode != tripcode_bot)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write($"[{json_sala_info.Room.Talks[0].From.Name}]");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("[Message]: "); Console.ResetColor();
                            Console.WriteLine($"{json_sala_info.Room.Talks[0].Message}");
                            Console.ResetColor();

                        }
                        if (json_sala_info.Room.Talks[0].Type != "join" && json_sala_info.Room.Talks[0].Type != "leave"
                            && json_sala_info.Room.Talks[0].Type != "new_host" && json_sala_info.Room.Talks[0].Type != "ban"
                            && json_sala_info.Room.Talks[0].Type != "unban" && json_sala_info.Room.Talks[0].Type != "system"
                            && json_sala_info.Room.Talks[0].Type != "music" && json_sala_info.Room.Talks[0].Type != "kick"
                            && json_sala_info.Room.Talks[0].Type != "me")
                        {
                            if (json_sala_info.Room.Talks[0].From.Tripcode == tripcode_bot && json_sala_info.Room.Talks[0].Message != ".")
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("[BOT]"); Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("[Message]: "); Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"{json_sala_info.Room.Talks[0].Message}");
                                Console.ResetColor();
                            }
                        }
                        #region [COMMAND HANDLER]
                        if (json_sala_info.Room.Talks[0].Message.Substring(0, 1) == "/")
                        {

                            #region [COMMAND GIF]
                            Parallel.Invoke(async () =>
                            {
                                if (json_sala_info.Room.Talks[0].Message.Substring(1).ToUpper().Contains("GIF"))
                                {
                                    string query_pesquisa = json_sala_info.Room.Talks[0].Message.Substring(json_sala_info.Room.Talks[0].Message.IndexOf(' '));
                                    string url = $"https://api.tenor.com/v1/search?q=anime{query_pesquisa}&key=KEYTENOR&limit=50";
                                    //To use the GIF API you need to generate a key on the tenor website and replace "KEYTENOR" with the access key you generated.

                                    var gif_random = (HttpWebRequest)WebRequest.CreateHttp(url);

                                    var json_gifs_respo = gif_random.GetResponse();

                                    StreamReader readerJson = new StreamReader(json_gifs_respo.GetResponseStream());

                                    var gif_json_obj = JsonConvert.DeserializeObject<GIF_TENOR.Root>(readerJson.ReadToEnd());
                                    Random rand_gif_ = new Random();
                                    int rand_gif = rand_gif_.Next(0, 50);

                                    loop_func.Add(ENVIA_MSG_URL(client, $"{json_sala_info.Room.Talks[0].From.Name}, here's your GIF:", gif_json_obj.Results[rand_gif].Media[0].Mediumgif.Url));


                                }
                            });
                            #endregion

                            #region [COMANDO SHIP]
                            Parallel.Invoke(async () =>
                            {
                                if (json_sala_info.Room.Talks[0].Message.Substring(1).ToUpper().Contains("SHIP"))
                                {

                                    string[] ship_users_split = json_sala_info.Room.Talks[0].Message.Substring(json_sala_info.Room.Talks[0].Message.IndexOf(' ') + 1).Split(' ');
                                    if (ship_users_split.Length > 2 || ship_users_split.Length < 2)
                                    {
                                        loop_func.Add(ENVIA_MSG_NORMAL(client, "I'm sorry, but it looks like something went wrong, please check the command and try again. (^^)"));
                                    }
                                    else if (ship_users_split.Length == 2)
                                    {
                                        string ship_msg = SHIP_CALC.ship(ship_users_split[0], ship_users_split[1]);
                                        loop_func.Add(ENVIA_MSG_NORMAL(client, ship_msg));
                                    }
                                }
                            });
                            #endregion

                            #region [COMANDO MUSICA YT]
                            Parallel.Invoke(async () =>
                            {
                                if (json_sala_info.Room.Talks[0].Message.Substring(1).ToUpper().Contains("YT"))
                                {
                                    string link_yt = json_sala_info.Room.Talks[0].Message.Substring(json_sala_info.Room.Talks[0].Message.IndexOf(' ') + 1);
                                    string id_yt = link_yt.Replace("https://www.youtube.com/watch?v=", "");
                                    loop_func.Add(ENVIA_MSG_NORMAL(client, $"[▶GENERATING VIDEO LINK] {json_sala_info.Room.Talks[0].From.Name}, Please wait ^^)/"));

                                    try
                                    {
                                        using (var clientHttp = new HttpClient())
                                        {
                                            var response = await clientHttp.GetStringAsync($"https://api.vevioz.com/api/button/mp3/{id_yt}");
                                            //--------To use the google api to get information from the video, generate an access key and replace "KEYGOOGLE" with the generated key
                                            var response2 = await clientHttp.GetStringAsync($"https://youtube.googleapis.com/youtube/v3/videos?part=snippet&id={id_yt}&key=KEYGOOGLE");
                                            var ytSnippet = JsonConvert.DeserializeObject<YT_SNIPPETAPI>(response2);
                                            string title_mp3 = ytSnippet.Items[0].Snippet.Title;
                                            string link = response.Split(new[] { "href=\"" }, StringSplitOptions.None)[3];
                                            link = link.Substring(0, link.IndexOf("\""));//$"https://api.vevioz.com/download/{tag_mp3}/{title_mp3}.mp3";

                                            Console.WriteLine(link);

                                            loop_func.Add(ENVIA_MSG_URL(client, $"[▶STARTING] - [{title_mp3}]", $"https://img.youtube.com/vi/{id_yt}/hqdefault.jpg"));
                                            loop_func.Add(Play_YT(client, json_sala_info.Room.Talks[0].From.Name, link, title_mp3));

                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        loop_func.Add(ENVIA_MSG_URL(client, $"[▶ MUSIC ] - ERROR GENERATING MUSIC LINK. 💔", $"https://media.tenor.com/images/63332240195e48532c74725e694aab26/tenor.gif"));
                                    }


                                }
                            });
                            #endregion

                            #region [COMANDO BUSCA ANIME E MANGA]
                            Parallel.Invoke(() =>
                            {
                                if (json_sala_info.Room.Talks[0].Message.Substring(1).ToUpper().Contains("ANIMANGA"))
                                {

                                    string url = "";
                                    string[] animanga_split = json_sala_info.Room.Talks[0].Message.Substring(json_sala_info.Room.Talks[0].Message.IndexOf(' ') + 1).Split(' ');
                                    if (animanga_split.Length > 3 || animanga_split.Length < 3)
                                    {
                                        loop_func.Add(ENVIA_MSG_NORMAL(client, "I'm sorry, but it looks like something went wrong, please check the command and try again. (^^)"));
                                    }
                                    else if (animanga_split.Length == 3)
                                    {
                                        url = $"https://api.jikan.moe/v3/search/{animanga_split[0]}?q={animanga_split[1]}&page={animanga_split[2]}";

                                        var manga_anime = (HttpWebRequest)WebRequest.CreateHttp(url);

                                        var json_animanga_respo = manga_anime.GetResponse();

                                        StreamReader readerJson = new StreamReader(json_animanga_respo.GetResponseStream());
                                        if (animanga_split[0].ToUpper() == "ANIME")
                                        {
                                            var anime_json_obj = JsonConvert.DeserializeObject<ANIME_MANGA_SEARCH.Root_Anime>(readerJson.ReadToEnd());
                                            string andamento = anime_json_obj.results[0].airing ? "No" : "Yes";
                                            loop_func.Add(ENVIA_MSG_URL(client, $"[{anime_json_obj.results[0].type}] {anime_json_obj.results[0].title} — Episodes: {anime_json_obj.results[0].episodes}/ Airing: {andamento}/ Note:{anime_json_obj.results[0].score}", anime_json_obj.results[0].image_url));

                                        }
                                        else if (animanga_split[0].ToUpper() == "MANGA")
                                        {
                                            var manga_json_obj = JsonConvert.DeserializeObject<ANIME_MANGA_SEARCH.Root_Manga>(readerJson.ReadToEnd());
                                            string publicando = manga_json_obj.results[0].publishing ? "Não" : "Sim";
                                            loop_func.Add(ENVIA_MSG_URL(client, $"[{manga_json_obj.results[0].type}] {manga_json_obj.results[0].title} — Volumes: {manga_json_obj.results[0].volumes}/ Chapters: {manga_json_obj.results[0].chapters} /In publication: {publicando}/ Note:{manga_json_obj.results[0].score}", manga_json_obj.results[0].image_url));

                                        }
                                    }


                                }
                            });
                            #endregion

                            #region [COMANDO POKEFUSION]
                            Parallel.Invoke(async () =>
                            {
                                if (json_sala_info.Room.Talks[0].Message.Substring(1).ToUpper().Contains("POKEFUSION"))
                                {
                                    try
                                    {


                                        using (var clientHttp = new HttpClient())
                                        {
                                            var response = await clientHttp.GetStringAsync(@"https://pokemon.alexonsager.net");

                                            string pokename = response.Split(new[] { "pk_name\">" },StringSplitOptions.None)[1];
                                            pokename = pokename.Substring(0, pokename.IndexOf("<"));

                                            string pokeIMg = response.Split(new[] { "pk_img\"" }, StringSplitOptions.None)[1];
                                            pokeIMg = pokeIMg.Substring(26, pokeIMg.IndexOf(">"));
                                            pokeIMg = pokeIMg.Substring(0, pokeIMg.IndexOf(">"));
                                            pokeIMg = pokeIMg.Trim();
                                            pokeIMg = pokeIMg.Substring(0, pokeIMg.Length - 1);

                                            loop_func.Add(ENVIA_MSG_URL(client, $"{json_sala_info.Room.Talks[0].From.Name}, here's your pokefusion:\nIt's a {pokename} 😁", pokeIMg));
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        loop_func.Add(ENVIA_MSG_URL(client, $"[▶ POKEFUSION ] - ERROR ACCESSING API (;-;) . 💔", $"https://media.tenor.com/images/63332240195e48532c74725e694aab26/tenor.gif"));
                                    }

                                }
                            });
                            #endregion

                            #region [COMANDO MANGA RANDÔMICO]
                            Parallel.Invoke(async () =>
                            {
                                if (json_sala_info.Room.Talks[0].Message.Substring(1).ToUpper().Contains("MANGA RANDOM"))
                                {
                                    int page_random = new Random().Next(1, 20);
                                    int manga_random = new Random().Next(0, 49);
                                    string url = $"https://api.jikan.moe/v3/search/manga?q=&order_by=members&sort=desc&page={page_random}";

                                    var manga_url_img = (HttpWebRequest)WebRequest.CreateHttp(url);
                                    var respoimggeturl = manga_url_img.GetResponse();
                                    StreamReader reader_manga_random = new StreamReader(respoimggeturl.GetResponseStream());

                                    var img_json_get = JsonConvert.DeserializeObject<ANIME_MANGA_SEARCH.Root_Manga>(reader_manga_random.ReadToEnd());

                                    //------ This function translates the description and any text from English to other languages ​​using the Google Translation API
                                    //string descricao_traducao = Translate_TXT(img_json_get.results[manga_random].synopsis);

                                    loop_func.Add(ENVIA_MSG_URL(client, $"[MANGA] - {img_json_get.results[manga_random].title} \n [Description] - {img_json_get.results[manga_random].synopsis}", img_json_get.results[manga_random].image_url));

                                }
                            });

                            #endregion

                            #region [COMANDO ANIME RANDÔMICO]
                            Parallel.Invoke(async () =>
                            {
                                if (json_sala_info.Room.Talks[0].Message.Substring(1).ToUpper().Contains("ANIME RANDOM"))
                                {
                                    int page_random = new Random().Next(1, 20);
                                    int anime_random = new Random().Next(0, 49);
                                    string url = $"https://api.jikan.moe/v3/search/anime?q=&order_by=members&sort=desc&page={page_random}";

                                    var manga_url_img = (HttpWebRequest)WebRequest.CreateHttp(url);
                                    var respoimggeturl = manga_url_img.GetResponse();
                                    StreamReader reader_manga_random = new StreamReader(respoimggeturl.GetResponseStream());

                                    var img_json_get = JsonConvert.DeserializeObject<ANIME_MANGA_SEARCH.Root_Manga>(reader_manga_random.ReadToEnd());

                                    //------ This function translates the description and any text from English to other languages ​​using the Google Translation API
                                    //string descricao_traducao = Translate_TXT(img_json_get.results[anime_random].synopsis);

                                    loop_func.Add(ENVIA_MSG_URL(client, $"[ANIME] - {img_json_get.results[anime_random].title} \n [Description] - {img_json_get.results[anime_random].synopsis}", img_json_get.results[anime_random].image_url));

                                }
                            });
                            #endregion

                            #region [COMANDO SEARCH ANIME POR IMG]
                            Parallel.Invoke(async () =>
                            {
                                try
                                {
                                    if (json_sala_info.Room.Talks[0].Message.Substring(1).ToUpper().Contains("NOME ANIME"))
                                    {
                                        string nome_anime_query = json_sala_info.Room.Talks[0].Message.Split(' ')[2];
                                        HttpWebRequest request_anime_search = (HttpWebRequest)WebRequest.CreateHttp($"https://trace.moe/api/search?url={nome_anime_query}");
                                        var respo_request = request_anime_search.GetResponse();
                                        StreamReader stream_reader_animg = new StreamReader(respo_request.GetResponseStream());

                                        var json_anime_img_search = JsonConvert.DeserializeObject<ANIME_FIND_IMG.Root>(stream_reader_animg.ReadToEnd());
                                        loop_func.Add(ENVIA_MSG_URL(client, $"[Result] - Anime: {json_anime_img_search.Docs[0].Anime} \n" +
                                            $"AniList: {json_anime_img_search.Docs[0].AnilistId} \n" +
                                            $"Episode: {json_anime_img_search.Docs[0].Episode}", $"https://media.trace.moe/image/{json_anime_img_search.Docs[0].AnilistId}/{json_anime_img_search.Docs[0].Filename}?t={json_anime_img_search.Docs[0].At}&token={json_anime_img_search.Docs[0].Tokenthumb}"));

                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine($"ERROR: {e.Message}");
                                    loop_func.Add(ENVIA_MSG_URL(client, $"[ERROR] - ERROR FINDING THE ANIME. 💔", $"https://media.tenor.com/images/63332240195e48532c74725e694aab26/tenor.gif"));

                                }
                            });
                            #endregion

                            #region [COMMAND ADVICE]
                            Parallel.Invoke(async () =>
                            {
                                if (json_sala_info.Room.Talks[0].Message.Substring(1).ToUpper().Contains("ADVICE"))
                                {

                                    string url = "https://api.adviceslip.com/advice";
                                    HttpWebRequest request_advice = (HttpWebRequest)WebRequest.CreateHttp(url);

                                    var response_advice = request_advice.GetResponse();

                                    StreamReader reader_advice = new StreamReader(response_advice.GetResponseStream());

                                    var json_advice = JsonConvert.DeserializeObject<ADVICE.Root>(reader_advice.ReadToEnd());

                                    loop_func.Add(ENVIA_MSG_NORMAL(client, Translate_TXT(json_advice.Slip.Advice)));

                                }
                            });
                            #endregion

                            #region [COMMAND NUMBER]
                            Parallel.Invoke(async () =>
                            {
                                if (json_sala_info.Room.Talks[0].Message.Substring(1).ToUpper().Contains("NUMBER"))
                                {
                                    string numero_trivia = json_sala_info.Room.Talks[0].Message.Substring(json_sala_info.Room.Talks[0].Message.IndexOf(' ') + 1);
                                    string url = $"http://numbersapi.com/{numero_trivia}?json";
                                    HttpWebRequest request_advice = (HttpWebRequest)WebRequest.CreateHttp(url);

                                    var response_advice = request_advice.GetResponse();

                                    StreamReader reader_advice = new StreamReader(response_advice.GetResponseStream());

                                    var json_trivia_number = JsonConvert.DeserializeObject<NUMBER_TRIVIA.Root>(reader_advice.ReadToEnd());

                                    loop_func.Add(ENVIA_MSG_NORMAL(client, Translate_TXT(json_trivia_number.text)));

                                }
                            });
                            #endregion

                            #region [COMMAND YEAR]
                            Parallel.Invoke(async () =>
                            {
                                if (json_sala_info.Room.Talks[0].Message.Substring(1).ToUpper().Contains("YEAR"))
                                {
                                    string numero_trivia = json_sala_info.Room.Talks[0].Message.Substring(json_sala_info.Room.Talks[0].Message.IndexOf(' ') + 1);
                                    string url = $"http://numbersapi.com/{numero_trivia}/year?json";
                                    HttpWebRequest request_advice = (HttpWebRequest)WebRequest.CreateHttp(url);

                                    var response_advice = request_advice.GetResponse();

                                    StreamReader reader_advice = new StreamReader(response_advice.GetResponseStream());

                                    var json_trivia_number = JsonConvert.DeserializeObject<NUMBER_TRIVIA.Root>(reader_advice.ReadToEnd());

                                    loop_func.Add(ENVIA_MSG_NORMAL(client, json_trivia_number.text));

                                }
                            });
                            #endregion

                            #region [COMMAND EPIC GAMES]
                            Parallel.Invoke(async () =>
                            {
                                if (json_sala_info.Room.Talks[0].Message.Substring(1).ToUpper().Contains("EPICGAMES"))
                                {
                                    string url = $"https://store-site-backend-static.ak.epicgames.com/freeGamesPromotions?locale=en-US&country=BR&allowCountries=BR";
                                    HttpWebRequest request_advice = (HttpWebRequest)WebRequest.CreateHttp(url);

                                    var response_epicgames = request_advice.GetResponse();

                                    StreamReader reader_epicgames = new StreamReader(response_epicgames.GetResponseStream());

                                    var json_freebies_epicgames = JsonConvert.DeserializeObject<EPICGAMES_FREEBIES.Root>(reader_epicgames.ReadToEnd());
                                    string MSG_EPIC = $"------[EPIC GAMES FREE]------\nGAME: {json_freebies_epicgames.Data.Catalog.SearchStore.Elements[2].Title}" +
                                    $"\n EXPIRES IN: {json_freebies_epicgames.Data.Catalog.SearchStore.Elements[2].Promotions.PromotionalOffers[0].PromotionalOffers[0].EndDate.ToString().Substring(0, 16)}";
                                    loop_func.Add(ENVIA_MSG_URL(client, MSG_EPIC, $"https://www.epicgames.com/store/pt-BR/p/{json_freebies_epicgames.Data.Catalog.SearchStore.Elements[2].ProductSlug}"));

                                }
                            });
                            #endregion

                            #region [COMMAND HELP]
                            Parallel.Invoke(async () =>
                            {
                                if (json_sala_info.Room.Talks[0].Message.Substring(1).ToUpper().Contains("HELP"))
                                {
                                    await Task.Delay(5000);
                                    loop_func.Add(ENVIA_MSG_NORMAL(client, $"{json_sala_info.Room.Talks[0].From.Name}, These are the commands: \n " +
                                        $"\"/ship NAME1 NAME2\"\n" +
                                        $"\"/yt link_do_yt (Play YT music)\"\n" +
                                        $"\"/animanga anime(or)manga name (pag. ex: 1)\"\n"));
                                    await Task.Delay(5000);
                                    loop_func.Add(ENVIA_MSG_NORMAL(client, $"\"/pokefusion\"\n" +
                                        $"\"/manga random\"\n" +
                                        $"\"/anime random\"\n" +
                                        $"\"/advice\"" +
                                        $"\n\"/gif some_name\"\n" +
                                        $"\"/number [number] (ex: /number 1)\"\n" +
                                        $"\"/name anime link_image\""));
                                    await Task.Delay(5000);
                                    loop_func.Add(ENVIA_MSG_NORMAL(client, $"\"/epicgames\" (returns the free game of the week)"));



                                }
                            });
                            #endregion

                        }
                        #endregion

                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine($"ERROR: {e.Message}");
                }
                await Task.Delay(5000);
            }

        }
        #endregion

        #region [LOGIN DRRR.COM]
        public static async Task<string> login(HttpClient client, Root json_login, string tipo)
        {
            if (tipo == "login")
            {
                var request = new HttpRequestMessage();
                request.Headers.ExpectContinue = false;
                request.RequestUri = new Uri("https://drrr.com?api=json");
                request.Headers.UserAgent.ParseAdd("Bot");
                var postData = new Dictionary<string, string> { { "name", $"{Name}" }, { "login", "ENTER" }, { "token", $"{json_login.token}" }, { "language", "pt-BR" }, { "icon", $"{Icon_ID}" } };
                request.Content = FormUrlEncodedContentWithEncoding(postData, Encoding.UTF8);

                request.Method = HttpMethod.Post;

                var login_drrr = await client.SendAsync(request);

                return await client.GetStringAsync("https://drrr.com/lounge?api=json");

            }
            else if (tipo == "relogin")
            {
                var request = new HttpRequestMessage();
                request.Headers.ExpectContinue = false;
                request.RequestUri = new Uri("https://drrr.com?api=json");
                request.Headers.UserAgent.ParseAdd("Bot");
                var postData = new Dictionary<string, string> { { "name", $"{Name}" }, { "login", "ENTER" }, { "token", $"{json_login.token}" }, { "language", "pt-BR" }, { "icon", $"{Icon_ID}" } };
                request.Content = FormUrlEncodedContentWithEncoding(postData, Encoding.UTF8);

                request.Method = HttpMethod.Post;

                var login_drrr = await client.SendAsync(request);

                return await login_drrr.Content.ReadAsStringAsync();

            }
            return null;
        }
        #endregion

        #region [SEND URL MSG]
        public static async Task ENVIA_MSG_URL(HttpClient client, string msg, string url)
        {
            var requestenvia = new HttpRequestMessage();
            requestenvia.Headers.ExpectContinue = false;
            requestenvia.RequestUri = new Uri("https://drrr.com/room/?ajax=1&api=json");
            requestenvia.Headers.UserAgent.ParseAdd("Bot");

            var postDataenvia = new Dictionary<string, string> { { "message", $"{msg}" }, { "url", $"{url}" } };

            requestenvia.Content = FormUrlEncodedContentWithEncoding(postDataenvia, Encoding.UTF8);

            requestenvia.Method = HttpMethod.Post;

            var envia_msg = await client.SendAsync(requestenvia);
        }
        #endregion

        #region [SEND NORMAL MSG]

        public static async Task ENVIA_MSG_NORMAL(HttpClient client, string msg)
        {
            var requestenvia = new HttpRequestMessage();
            requestenvia.Headers.ExpectContinue = false;
            requestenvia.RequestUri = new Uri("https://drrr.com/room/?ajax=1&api=json");
            requestenvia.Headers.UserAgent.ParseAdd("Bot");

            var postDataenvia = new Dictionary<string, string> { { "message", $"{msg}" } };

            requestenvia.Content = FormUrlEncodedContentWithEncoding(postDataenvia, Encoding.UTF8);

            requestenvia.Method = HttpMethod.Post;

            var envia_msg = await client.SendAsync(requestenvia);

        }

        #endregion

        #region [SEND SECRET MSG]
        public static async Task ENVIA_MSG_DM(HttpClient client, string msg)
        {

            var request_post_dm = new HttpRequestMessage();
            request_post_dm.Headers.ExpectContinue = false;
            request_post_dm.RequestUri = new Uri("https://drrr.com/room/?ajax=1&api=json");
            request_post_dm.Headers.UserAgent.ParseAdd("Bot");

            var envia_msg_dm = new Dictionary<string, string> { { "message", $"{msg}" }, { "to", $"{msg.Split(' ')[1]}" }, { "direct", "true" } };

            request_post_dm.Content = FormUrlEncodedContentWithEncoding(envia_msg_dm, Encoding.UTF8);
            request_post_dm.Method = HttpMethod.Post;
            var envia_dm = await client.SendAsync(request_post_dm);
        }
        #endregion

        #region [PLAY MUSIC]
        public static async Task Play_YT(HttpClient client, string user, string mp3, string title)
        {


            var requestenvia = new HttpRequestMessage();
            requestenvia.Headers.ExpectContinue = false;
            requestenvia.RequestUri = new Uri("https://drrr.com/room/?ajax=1&api=json");
            requestenvia.Headers.UserAgent.ParseAdd("Bot");

            var postDataenvia = new Dictionary<string, string> { { "music", "music" }, { "name", $"{title}" }, { "url", $"{mp3}" } };

            requestenvia.Content = FormUrlEncodedContentWithEncoding(postDataenvia, Encoding.UTF8);

            requestenvia.Method = HttpMethod.Post;

            var play_musica = await client.SendAsync(requestenvia);

        }
        #endregion

        #region [FORMAT URL ENCODE]
        static ByteArrayContent FormUrlEncodedContentWithEncoding(IEnumerable<KeyValuePair<string, string>> nameValueCollection, Encoding encoding)
        {

            if (Encoding.UTF8.Equals(encoding) || encoding == null)
                return new FormUrlEncodedContent(nameValueCollection);

            var builder = new StringBuilder();
            foreach (var pair in nameValueCollection)
            {
                if (builder.Length > 0)
                    builder.Append('&');
                builder.Append(HttpUtility.UrlEncode(pair.Key, encoding));
                builder.Append('=');
                builder.Append(HttpUtility.UrlEncode(pair.Value, encoding));
            }

            var data = Encoding.GetEncoding("latin1").GetBytes(builder.ToString());
            var content = new ByteArrayContent(data);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            return content;
        }
        #endregion

        #region [TRANSLATE TXT]
        public static string Translate_TXT(string txt)
        {

            string url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl=en&tl=pt&dt=t&q={txt}";
            HttpWebRequest request_traducao = (HttpWebRequest)WebRequest.CreateHttp(url);
            var response_traducao = request_traducao.GetResponse();

            StreamReader reader_traducao = new StreamReader(response_traducao.GetResponseStream());

            string traducao_return = reader_traducao.ReadToEnd().Split('\"')[1];

            return traducao_return;

        }
        #endregion

        #region [KEEP ALIVE]

        //private static async void timer_Elapsed(object sender, ElapsedEventArgs e)
        //{

        //    await keep_alive();

        //}

        //public static async Task keep_alive()
        //{

        //    await ENVIA_MSG_DM(cliente_keep, $"{Name.Split('#')[0]} .");

        //}
        #endregion

        #region [PLAYLIST MUSICS]
        public static async Task playlist_drrr()
        {

            


        }
        #endregion

    }


    //---------------------------------------------------LOGIN JSON--------------------------------
    #region [PAGE LOGIN JSON]
    public class Ap
    {
        public string name { get; set; }
        public string ap { get; set; }
    }

    public class Languages
    {
        [JsonProperty("ka-KA")]
        public string KaKA { get; set; }

        [JsonProperty("af-ZA")]
        public string AfZA { get; set; }

        [JsonProperty("id-ID")]
        public string IdID { get; set; }

        [JsonProperty("ms-MY")]
        public string MsMY { get; set; }

        [JsonProperty("bn-BD")]
        public string BnBD { get; set; }

        [JsonProperty("ca-ES")]
        public string CaES { get; set; }

        [JsonProperty("da-DK")]
        public string DaDK { get; set; }

        [JsonProperty("de-DE")]
        public string DeDE { get; set; }

        [JsonProperty("et-EE")]
        public string EtEE { get; set; }

        [JsonProperty("en-US")]
        public string EnUS { get; set; }

        [JsonProperty("es-ES")]
        public string EsES { get; set; }

        [JsonProperty("eo-UY")]
        public string EoUY { get; set; }

        [JsonProperty("fil-PH")]
        public string FilPH { get; set; }

        [JsonProperty("fr-FR")]
        public string FrFR { get; set; }

        [JsonProperty("hr-HR")]
        public string HrHR { get; set; }

        [JsonProperty("it-IT")]
        public string ItIT { get; set; }

        [JsonProperty("lv-LV")]
        public string LvLV { get; set; }

        [JsonProperty("lt-LT")]
        public string LtLT { get; set; }

        [JsonProperty("hu-HU")]
        public string HuHU { get; set; }

        [JsonProperty("nl-NL")]
        public string NlNL { get; set; }

        [JsonProperty("no-NO")]
        public string NoNO { get; set; }

        [JsonProperty("pl-PL")]
        public string PlPL { get; set; }

        [JsonProperty("pt-PT")]
        public string PtPT { get; set; }

        [JsonProperty("pt-BR")]
        public string PtBR { get; set; }

        [JsonProperty("ro-RO")]
        public string RoRO { get; set; }

        [JsonProperty("sk-SK")]
        public string SkSK { get; set; }

        [JsonProperty("sl-SI")]
        public string SlSI { get; set; }

        [JsonProperty("fi-FI")]
        public string FiFI { get; set; }

        [JsonProperty("sv-SE")]
        public string SvSE { get; set; }

        [JsonProperty("tl-PH")]
        public string TlPH { get; set; }

        [JsonProperty("vi-VN")]
        public string ViVN { get; set; }

        [JsonProperty("tr-TR")]
        public string TrTR { get; set; }

        [JsonProperty("cs-CZ")]
        public string CsCZ { get; set; }

        [JsonProperty("el-GR")]
        public string ElGR { get; set; }

        [JsonProperty("bg-BG")]
        public string BgBG { get; set; }

        [JsonProperty("ru-RU")]
        public string RuRU { get; set; }

        [JsonProperty("sr-SP")]
        public string SrSP { get; set; }

        [JsonProperty("uk-UA")]
        public string UkUA { get; set; }

        [JsonProperty("he-IL")]
        public string HeIL { get; set; }

        [JsonProperty("ur-PK")]
        public string UrPK { get; set; }

        [JsonProperty("ar-SA")]
        public string ArSA { get; set; }

        [JsonProperty("th-TH")]
        public string ThTH { get; set; }

        [JsonProperty("ka-GE")]
        public string KaGE { get; set; }

        [JsonProperty("zh-CN")]
        public string ZhCN { get; set; }

        [JsonProperty("zh-TW")]
        public string ZhTW { get; set; }

        [JsonProperty("ja-JP")]
        public string JaJP { get; set; }

        [JsonProperty("zh-TM")]
        public string ZhTM { get; set; }

        [JsonProperty("ko-KR")]
        public string KoKR { get; set; }
    }

    public class Root
    {
        public string Authorization { get; set; }
        public List<Ap> aps { get; set; }
        public int username_max_length { get; set; }
        public Languages languages { get; set; }
        public string default_language { get; set; }
        public List<string> icons { get; set; }
        public string token { get; set; }
    }
    #endregion

    //-----------------------------------------------LOUNGE JSON-----------------------------------
    #region [LOUNGE JSON]
    public class User
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        [JsonPropertyName("tripcode")]
        public string Tripcode { get; set; }

        [JsonPropertyName("device")]
        public string Device { get; set; }

        [JsonPropertyName("loginedAt")]
        public int? LoginedAt { get; set; }
    }

    public class Host
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        [JsonPropertyName("tripcode")]
        public string Tripcode { get; set; }

        [JsonPropertyName("device")]
        public string Device { get; set; }

        [JsonPropertyName("loginedAt")]
        public int? LoginedAt { get; set; }
    }

    public class Room
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("since")]
        public int Since { get; set; }

        [JsonPropertyName("limit")]
        public double Limit { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("roomId")]
        public string RoomId { get; set; }

        [JsonPropertyName("music")]
        public bool Music { get; set; }

        [JsonPropertyName("staticRoom")]
        public bool StaticRoom { get; set; }

        [JsonPropertyName("hiddenRoom")]
        public bool HiddenRoom { get; set; }

        [JsonPropertyName("gameRoom")]
        public bool GameRoom { get; set; }

        [JsonPropertyName("adultRoom")]
        public bool AdultRoom { get; set; }

        [JsonPropertyName("users")]
        public List<User> Users { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("host")]
        public Host Host { get; set; }
    }

    public class Profile
    {
        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("uid")]
        public string Uid { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("lang")]
        public string Lang { get; set; }

        [JsonPropertyName("device")]
        public string Device { get; set; }

        [JsonPropertyName("tripcode")]
        public string Tripcode { get; set; }
    }

    public class Lounge_Json
    {
        [JsonPropertyName("create_room_url")]
        public string CreateRoomUrl { get; set; }

        [JsonPropertyName("rooms")]
        public List<Room> Rooms { get; set; }

        [JsonPropertyName("active_user")]
        public int ActiveUser { get; set; }

        [JsonPropertyName("profile")]
        public Profile Profile { get; set; }
    }


    #endregion

    //----------------------------------------------ROOM JSON-----------------------------------
    #region [ROOM JSON]
    public class Profile_info
    {
        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("uid")]
        public string Uid { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("lang")]
        public string Lang { get; set; }

        [JsonPropertyName("device")]
        public string Device { get; set; }

        [JsonPropertyName("tripcode")]
        public string Tripcode { get; set; }
    }

    public class User_info
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        [JsonPropertyName("tripcode")]
        public string Tripcode { get; set; }

        [JsonPropertyName("device")]
        public string Device { get; set; }

        [JsonPropertyName("loginedAt")]
        public int? LoginedAt { get; set; }
    }

    public class User2
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        [JsonPropertyName("tripcode")]
        public string Tripcode { get; set; }

        [JsonPropertyName("device")]
        public string Device { get; set; }
    }

    public class From
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        [JsonPropertyName("tripcode")]
        public string Tripcode { get; set; }
    }

    public class To
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        [JsonPropertyName("tripcode")]
        public string Tripcode { get; set; }
    }

    public class Talk
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("time")]
        public double Time { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("user")]
        public User User { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("from")]
        public From From { get; set; }

        [JsonPropertyName("secret")]
        public bool? Secret { get; set; }

        [JsonPropertyName("to")]
        public To To { get; set; }
    }

    public class Room_info
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("since")]
        public int Since { get; set; }

        [JsonPropertyName("update")]
        public double Update { get; set; }

        [JsonPropertyName("limit")]
        public int Limit { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("roomId")]
        public string RoomId { get; set; }

        [JsonPropertyName("music")]
        public bool Music { get; set; }

        [JsonPropertyName("staticRoom")]
        public bool StaticRoom { get; set; }

        [JsonPropertyName("hiddenRoom")]
        public bool HiddenRoom { get; set; }

        [JsonPropertyName("gameRoom")]
        public bool GameRoom { get; set; }

        [JsonPropertyName("adultRoom")]
        public bool AdultRoom { get; set; }

        [JsonPropertyName("host")]
        public string Host { get; set; }

        [JsonPropertyName("users")]
        public List<User_info> Users { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("v")]
        public int V { get; set; }

        [JsonPropertyName("djMode")]
        public bool DjMode { get; set; }

        [JsonPropertyName("talks")]
        public List<Talk> Talks { get; set; }
    }

    public class Json_Room
    {
        [JsonPropertyName("profile")]
        public Profile_info Profile { get; set; }

        [JsonPropertyName("room")]
        public Room_info Room { get; set; }

        [JsonPropertyName("user")]
        public User_info User { get; set; }

        [JsonPropertyName("is_game_host")]
        public bool IsGameHost { get; set; }
    }
    #endregion
}
