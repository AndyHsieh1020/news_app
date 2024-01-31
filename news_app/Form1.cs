using System;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Drawing;
using System.Configuration;
using System.Collections.Specialized;

namespace news_app
{
    public partial class Form1 : Form
    {
        private void title_Click(object sender, EventArgs e)
        {
            Label Lbl = (Label)sender;
            System.Diagnostics.Process.Start(Lbl.Name);
        }

        public Form1()
        {
            InitializeComponent();

            string acc = ConfigurationManager.AppSettings.Get("account");
            string pwd = ConfigurationManager.AppSettings.Get("password");

            var dbClient = new MongoClient("mongodb+srv://"+acc+":"+pwd+"@tw-news.mbrlkzb.mongodb.net/");
            var database = dbClient.GetDatabase("tw-news");

            string[] news_col = { "CHT", "LTN", "UDN", "CNA", "CTEE", "Money" };

            foreach (var col_name in news_col)
            {
                var collection = database.GetCollection<BsonDocument>(col_name);
                var Documents = collection.Find(new BsonDocument()).ToList();
                foreach (var Document in Documents)
                {

                    PictureBox Pctbox_news = new PictureBox();
                    Label Lbl_news_title = new Label();
                    Label Lbl_news_content = new Label();
                    FlowLayoutPanel Flp_title_content = new FlowLayoutPanel();
                    Flp_title_content.FlowDirection = FlowDirection.TopDown;
                    Flp_title_content.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

                    Panel outerPanel = new Panel();
                    outerPanel.Size = new Size(flowLayout_news.Size.Width - 30, 200);
                    //outerPanel.AutoSize = true;
                    outerPanel.BorderStyle = BorderStyle.FixedSingle;
                    outerPanel.BackColor = Color.FromArgb(240, 248, 255);

                    TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
                    tableLayoutPanel.Size = new Size(outerPanel.Size.Width, 200);
                    tableLayoutPanel.RowCount = 1;
                    tableLayoutPanel.ColumnCount = 2;

                    //圖片
                    Pctbox_news = new PictureBox();
                    if (Document.Contains("img"))
                    {
                        if (Document.GetElement("img").Value.ToString() != "")
                        {
                            try
                            {
                                Pctbox_news.Load(Document.GetElement("img").Value.ToString());
                                Pctbox_news.Text = Document.GetElement("title").Value.ToString();
                                Pctbox_news.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                                Pctbox_news.SizeMode = PictureBoxSizeMode.StretchImage;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }

                        }
                        else
                        {
                            Pctbox_news.Load("../../../no-pictures.png");
                            Pctbox_news.Text = Document.GetElement("title").Value.ToString();
                            Pctbox_news.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                            Pctbox_news.SizeMode = PictureBoxSizeMode.StretchImage;

                        }
                    }
                    else
                    {
                        Pctbox_news.Load("../../../no-pictures.png");
                        Pctbox_news.Text = Document.GetElement("title").Value.ToString();
                        Pctbox_news.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                        Pctbox_news.SizeMode = PictureBoxSizeMode.StretchImage;
                    }


                    //標題
                    Lbl_news_title = new Label();
                    Lbl_news_title.Text = Document.GetElement("title").Value.ToString();
                    Lbl_news_title.AutoSize = true;
                    Lbl_news_title.Name = Document.GetElement("link").Value.ToString();
                    Lbl_news_title.Font = new Font("微軟正黑體", 12, FontStyle.Bold);

                    Lbl_news_title.Click += title_Click;



                    //內容
                    if (Document.Contains("content"))
                    {
                        Lbl_news_content = new Label();
                        Lbl_news_content.Text = "\n"+Document.GetElement("content").Value.ToString();
                        Lbl_news_content.Font = new Font("微軟正黑體", 8, FontStyle.Bold);
                        Lbl_news_content.AutoSize = true;

                    }
                    else
                    {
                        Lbl_news_content = new Label();
                        Lbl_news_content.Text = "";
                        Lbl_news_content.AutoSize = true;
                    }


                    Flp_title_content.Controls.Add(Lbl_news_title);
                    Flp_title_content.Controls.Add(Lbl_news_content);


                    // 建立左控制項
                    tableLayoutPanel.Controls.Add(Pctbox_news, 0, 0);

                    // 建立右控制項
                    tableLayoutPanel.Controls.Add(Flp_title_content, 1, 0);
                    

                    // 設定列的大小比例
                    tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));  // 左列佔25%
                    tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));  // 右列佔75%


                    outerPanel.Controls.Add(tableLayoutPanel);

                    //Flp_g_pctlbl.Controls.Add(Pctbox_news);
                    //Flp_g_pctlbl.Controls.Add(Lbl_news_title);
                    //Flp_g_pctlbl.Controls.Add(Lbl_news_content);

                    flowLayout_news.Controls.Add(outerPanel);

                }
            }


            /*var filter = Builders<BsonDocument>.Filter.Gte("your_date_field", startDate) &
                    Builders<BsonDocument>.Filter.Lt("your_date_field", endDate);
            var Documents = collection.Find(filter).ToList();*/
        }
    }
}
