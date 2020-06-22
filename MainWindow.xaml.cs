using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Net;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.IO;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

namespace BotCustomer
{
    public enum BotDifficulty{
        NONE,
        EASY,
        MEDIUM,
        HARD,
        UBER
    };
    public enum Team{
        Blue,
        Red
    }
    public class botChampions{
        public int id = 0;
        public string name = "";
    }
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {
        public List<string> s_BotDifficulty = new List<string>{
            "NONE",
            "EASY",
            "MEDIUM",
            "HARD",
            "UBER"
        };
        public List<botChampions> botChampionsList = new List<botChampions>{
            new botChampions {
                id = 1,
                name = "黑暗之女"
            },
            new botChampions {
                id = 3,
                name = "正义巨像"
            },
            new botChampions {
                id = 8,
                name = "猩红收割者"
            },
            new botChampions {
                id = 10,
                name = "正义天使"
            },
            new botChampions {
                id = 11,
                name = "无极剑圣"
            },
            new botChampions {
                id = 12,
                name = "牛头酋长"
            },
            new botChampions {
                id = 13,
                name = "符文法师"
            },
            new botChampions {
                id = 15,
                name = "战争女神"
            },
            new botChampions {
                id = 16,
                name = "众星之子"
            },
            new botChampions {
                id = 18,
                name = "麦林炮手"
            },
            new botChampions {
                id = 19,
                name = "祖安怒兽"
            },
            new botChampions {
                id = 21,
                name = "赏金猎人"
            },
            new botChampions {
                id = 22,
                name = "寒冰射手"
            },
            new botChampions {
                id = 24,
                name = "武器大师"
            },
            new botChampions {
                id = 25,
                name = "堕落天使"
            },
            new botChampions {
                id = 26,
                name = "时光守护者"
            },
            new botChampions {
                id = 30,
                name = "死亡颂唱者"
            },
            new botChampions {
                id = 31,
                name = "虚空恐惧"
            },
            new botChampions {
                id = 32,
                name = "殇之木乃伊"
            },
            new botChampions {
                id = 33,
                name = "披甲龙龟"
            },
            new botChampions {
                id = 36,
                name = "祖安狂人"
            },
            new botChampions {
                id = 44,
                name = "瓦洛兰之盾"
            },
            new botChampions {
                id = 45,
                name = "邪恶小法师"
            },
            new botChampions {
                id = 48,
                name = "巨魔之王"
            },
            new botChampions {
                id = 51,
                name = "皮城女警"
            },
            new botChampions {
                id = 53,
                name = "蒸汽机器人"
            },
            new botChampions {
                id = 54,
                name = "熔岩巨兽"
            },
            new botChampions {
                id = 58,
                name = "荒漠屠夫"
            },
            new botChampions {
                id = 62,
                name = "齐天大圣"
            },
            new botChampions {
                id = 63,
                name = "复仇焰魂"
            },
            new botChampions {
                id = 69,
                name = "魔蛇之拥"
            },
            new botChampions {
                id = 75,
                name = "沙漠死神"
            },
            new botChampions {
                id = 76,
                name = "狂野女猎手"
            },
            new botChampions {
                id = 77,
                name = "兽灵行者"
            },
            new botChampions {
                id = 81,
                name = "探险家"
            },
            new botChampions {
                id = 86,
                name = "德玛西亚之力"
            },
            new botChampions {
                id = 89,
                name = "曙光女神"
            },
            new botChampions {
                id = 96,
                name = "深渊巨口"
            },
            new botChampions {
                id = 98,
                name = "暮光之眼"
            },
            new botChampions {
                id = 99,
                name = "光辉女郎"
            },
            new botChampions {
                id = 102,
                name = "龙血武姬"
            },
            new botChampions {
                id = 104,
                name = "法外狂徒"
            },
            new botChampions {
                id = 115,
                name = "爆破鬼才"
            },
            new botChampions {
                id = 122,
                name = "诺克萨斯之手"
            },
            new botChampions {
                id = 143,
                name = "荆棘之兴"
            },
            new botChampions {
                id = 236,
                name = "圣枪游侠"
            }
        };
        public bool isInputPath = true;
        public string path = "D:/Riot Games/League of Legends (PBE)";
        public string port = "25565";
        public string token = "FFFFFFFFFFFFFFFFFFFFFF";
        public int championId = 1;
        public BotDifficulty botDifficulty = BotDifficulty.EASY;
        public Team team = Team.Blue;
        HttpWebRequest request;
        public MainWindow(){
            InitializeComponent();
        }
        public bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors){    
            return true;
        }
        private void OnAddClick(object sender, RoutedEventArgs e){
            try {
                path = TextBox_Path.Text;
                port = TextBox_Port.Text;
                token = TextBox_Token.Text;
                team = (Team)ComboBox_Team.SelectedIndex;
                championId = int.Parse(ComboBox_ID.Text);
                botDifficulty = (BotDifficulty)ComboBox_Difficulty.SelectedIndex;
                if (isInputPath) {
                    using (StreamReader reader = new StreamReader(new FileStream(path + "/lockfile", FileMode.Open, FileAccess.Read, FileShare.ReadWrite), System.Text.Encoding.Default)) {
                        string line = reader.ReadLine();
                        var colonCount = 0;
                        var colonIndex = 0;
                        for (var i = 0; i < line.Length; i++) {
                            if (line[i].ToString() == ":") {
                                colonCount ++;
                                if (colonCount == 3) {
                                    port = line.Substring(colonIndex + 1, i - colonIndex - 1);
                                }
                                if (colonCount == 4) {
                                    token = line.Substring(colonIndex + 1, i - colonIndex - 1);
                                }
                                colonIndex = i;
                            }
                        }
                    }
                }
                Console.WriteLine("https://127.0.0.1:" + port + "/lol-lobby/v1/lobby/custom/bots");
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                request = (HttpWebRequest)WebRequest.Create("https://127.0.0.1:" + port + "/lol-lobby/v1/lobby/custom/bots");
                request.Method = "POST";
                request.ContentType = "application/json";
                request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes("riot:" + token)));
                var postData = new {
                    championId,
                    botDifficulty = s_BotDifficulty[(int)botDifficulty],
                    teamId = ((int)team * 100 + 100).ToString()
                };
                string postBody = JsonConvert.SerializeObject(postData);
                byte[] byteArray = Encoding.UTF8.GetBytes(postBody);
                using (Stream reqStream = request.GetRequestStream()) {
                    reqStream.Write(byteArray, 0, byteArray.Length);
                }
            }
            catch (Exception ex) {
                if (ex.InnerException != null) {
                    Console.WriteLine(ex.InnerException.Message);
                    Textblock_Outupt.Text = ex.InnerException.Message;
                }
                else {
                    Console.WriteLine(ex.Message);
                    Textblock_Outupt.Text = ex.Message;
                }
                return;
            }
            string responseStr = "";
            try {
                using (WebResponse response = request.GetResponse()){
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8)){
                        responseStr = reader.ReadToEnd();
                    }
                }
            }
            catch (WebException ex) {
                using (WebResponse response = ex.Response) {
                     HttpWebResponse httpResponse = (HttpWebResponse)response;
                     if (response == null){
                        Console.WriteLine(ex.ToString());
                        Textblock_Outupt.Text = ex.ToString();
                     }
                     using (Stream data = response.GetResponseStream())
                     using (var reader = new StreamReader(data)){
                        string text = reader.ReadToEnd();
                        Console.WriteLine(text);
                        Textblock_Outupt.Text = text;
                     }
                }
                return;
            }
            if (responseStr == "") {
                responseStr = "添加成功";
            }
            Console.WriteLine(responseStr);
            Textblock_Outupt.Text = responseStr;
        }
        private void InputPath_Checked(object sender, RoutedEventArgs e) {
            if (this.IsLoaded) {
                Radio_PortAndToken.IsChecked = false;
                isInputPath = true;
                TextBox_Path.IsEnabled = true;
                TextBox_Port.IsEnabled = false;
                TextBox_Token.IsEnabled = false;
            }
        }

        private void PortAndToken_Checked(object sender, RoutedEventArgs e) {
            if (this.IsLoaded) {
                Radio_Path.IsChecked = false;
                isInputPath = false;
                TextBox_Path.IsEnabled = false;
                TextBox_Port.IsEnabled = true;
                TextBox_Token.IsEnabled = true;
            }
        }

        private void OnDifficultyLoaded(object sender, RoutedEventArgs e) {
            foreach (string i in s_BotDifficulty) {
                ComboBox_Difficulty.Items.Add(i);
                ComboBox_Difficulty.SelectedIndex = (int)botDifficulty;
            }
        }

        private void OnBotIDLoaded(object sender, RoutedEventArgs e) {
            foreach (botChampions i in botChampionsList) {
                ComboBox_ID.Items.Add(i.id + " " + i.name);
            }
            ComboBox_ID.SelectedIndex = 0;
            ComboBox_ID.Text = "1";
        }

        private void OnIDChanged(object sender, SelectionChangedEventArgs e) {
            if (e.AddedItems.Count > 0) {
                string str = e.AddedItems[0] as string;
                if (str.Contains(" ")) {
                    Dispatcher.BeginInvoke(new MethodInvoker(
                        () => { 
                            ComboBox_ID.Text = str.Substring(0, str.IndexOf(" ")); 
                        }
                    ));
                }
            }
        }

        private void OnTeamsLoaded(object sender, RoutedEventArgs e) {
            ComboBox_Team.Items.Add("蓝方");
            ComboBox_Team.Items.Add("红方");
            ComboBox_Team.SelectedIndex = 0;
        }

    }
}
