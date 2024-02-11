using System;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Drawing;
using System.Configuration;
using System.Collections.Specialized;
using System.Collections.Generic;
using MongoDB.Driver.Linq;
using System.Linq;

namespace news_app
{
    public partial class Form1 : Form
    {
        int page = 0;
        bool end_nxt = true;


        private void title_Click(object sender, EventArgs e)
        {
            Label Lbl = (Label)sender;
            System.Diagnostics.Process.Start(Lbl.Name);
        }

        private void filter_checkbox_change(object sender, EventArgs e)
        {
            clear_flowlayout();
            load_news(page=0);
        }

        public void clear_flowlayout()
        {
            List<Control> listControls = new List<Control>();

            foreach (Control control in flowLayout_news.Controls)
            {
                listControls.Add(control);
            }

            foreach (Control control in listControls)
            {
                flowLayout_news.Controls.Remove(control);
                control.Dispose();
            }
        }

        public Form1()
        {
            InitializeComponent();

            CHT.CheckedChanged += filter_checkbox_change;
            LTN.CheckedChanged += filter_checkbox_change;
            UDN.CheckedChanged += filter_checkbox_change;
            CTEE.CheckedChanged += filter_checkbox_change;
            CNA.CheckedChanged += filter_checkbox_change;
            Money.CheckedChanged += filter_checkbox_change;


            load_news(page);


        }
        //上一頁按鈕
        private void last_page_Click(object sender, EventArgs e)
        {
            if(page>0)
            {
                page--;
                clear_flowlayout();
                load_news(page);
            } 
        }
        //下一頁按鈕
        private void nxt_page_Click(object sender, EventArgs e)
        {
            if(end_nxt!=true)
            {
                page++;
                clear_flowlayout();
                load_news(page);
            }  
        }

        //時間選擇變更時
        private void timepicker_ValueChanged(object sender, EventArgs e)
        {
            clear_flowlayout();
            load_news(page=0);
        }

        //更新頁面
        private void load_news(int page)
        {
            string acc = ConfigurationManager.AppSettings.Get("account");
            string pwd = ConfigurationManager.AppSettings.Get("password");

            var dbClient = new MongoClient("mongodb+srv://" + acc + ":" + pwd + "@tw-news.mbrlkzb.mongodb.net/");
            var database = dbClient.GetDatabase("tw-news");

            //日期選擇
            var date = timepicker.Value;
            date = date.Date + new TimeSpan(0, 0, 0); // 將時間設置在0點
            //搜尋關鍵字
            var search_txt = search_str.Text.ToString();

            //檢查CHKBOX勾選來源
            List<string> news_col = new List<string>() { };
            
            
            foreach (Control ctl in filter_grpbox.Controls)
            {
                if (ctl is CheckBox) 
                {
                    if(((CheckBox)ctl).Checked)
                    {
                        news_col.Add(((CheckBox)ctl).Name);
                    }
                }
            }
            if (!news_col.Any())
            {
                foreach (Control ctl in filter_grpbox.Controls)
                {
                    if(ctl is CheckBox)
                    {
                        news_col.Add(((CheckBox)ctl).Name);
                    }  
                }
                    
            }

            //建立聚合搜尋
            var pipelineStages = new List<BsonDocument>();


            var pipeline_match = new BsonDocument("$match", new BsonDocument
                {
                    { "$and", new BsonArray
                        {
                            new BsonDocument("time", new BsonDocument("$gte", date)),  // 時間大於今日0點
                            new BsonDocument("time", new BsonDocument("$lte", date.AddDays(+1))),    // 時間小於明日0點
                            new BsonDocument("title", new BsonRegularExpression(search_txt))  // title 包含特定關鍵字
                        }
                    }
                });

            
            foreach (var col_name in news_col)
            {
                var pipeline_union = new BsonDocument("$unionWith", new BsonDocument
                {
                    { "coll", col_name }, // 指定要 union 的集合
                    { "pipeline", new BsonArray { pipeline_match } } // 指定要套用在該集合的查詢
                });

                // 加到聚合查詢中
                pipelineStages.Add(pipeline_union);
            }


            //建立聚合pipeline
            var pipeline = PipelineDefinition<BsonDocument, BsonDocument>.Create(pipelineStages);

            // 取得结果
            var result = database.GetCollection<BsonDocument>("aggregate")
                         .Aggregate<BsonDocument>(pipeline)
                         .ToList();

            result = result.Skip(page*10).Take(10).ToList();

            end_nxt = result.Count < 10;

            
            foreach (var Document in result)
            {
                
                PictureBox Pctbox_news = new PictureBox();
                Label Lbl_news_title = new Label();
                Label Lbl_news_content = new Label();
                FlowLayoutPanel Flp_title_content = new FlowLayoutPanel();
                Flp_title_content.FlowDirection = FlowDirection.TopDown;
                Flp_title_content.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

                Panel outerPanel = new Panel();
                outerPanel.Size = new Size(flowLayout_news.Size.Width - 30, 200);
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
                    Lbl_news_content.Text = "\n" + Document.GetElement("content").Value.ToString();
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

                

                flowLayout_news.Controls.Add(outerPanel);


            }
        }

    }
}
