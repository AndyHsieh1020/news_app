namespace news_app
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.flowLayout_news = new System.Windows.Forms.FlowLayoutPanel();
            this.timepicker = new System.Windows.Forms.DateTimePicker();
            this.filter_grpbox = new System.Windows.Forms.GroupBox();
            this.CNA = new System.Windows.Forms.CheckBox();
            this.UDN = new System.Windows.Forms.CheckBox();
            this.Money = new System.Windows.Forms.CheckBox();
            this.CTEE = new System.Windows.Forms.CheckBox();
            this.LTN = new System.Windows.Forms.CheckBox();
            this.CHT = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.search_str = new System.Windows.Forms.TextBox();
            this.nxt_page = new System.Windows.Forms.Button();
            this.last_page = new System.Windows.Forms.Button();
            this.filter_grpbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayout_news
            // 
            this.flowLayout_news.AutoScroll = true;
            this.flowLayout_news.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayout_news.Location = new System.Drawing.Point(12, 12);
            this.flowLayout_news.Name = "flowLayout_news";
            this.flowLayout_news.Size = new System.Drawing.Size(500, 389);
            this.flowLayout_news.TabIndex = 0;
            this.flowLayout_news.WrapContents = false;
            // 
            // timepicker
            // 
            this.timepicker.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.timepicker.Location = new System.Drawing.Point(6, 76);
            this.timepicker.Name = "timepicker";
            this.timepicker.Size = new System.Drawing.Size(258, 33);
            this.timepicker.TabIndex = 1;
            this.timepicker.ValueChanged += new System.EventHandler(this.timepicker_ValueChanged);
            // 
            // filter_grpbox
            // 
            this.filter_grpbox.Controls.Add(this.CNA);
            this.filter_grpbox.Controls.Add(this.UDN);
            this.filter_grpbox.Controls.Add(this.Money);
            this.filter_grpbox.Controls.Add(this.CTEE);
            this.filter_grpbox.Controls.Add(this.LTN);
            this.filter_grpbox.Controls.Add(this.CHT);
            this.filter_grpbox.Controls.Add(this.label1);
            this.filter_grpbox.Controls.Add(this.search_str);
            this.filter_grpbox.Controls.Add(this.timepicker);
            this.filter_grpbox.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.filter_grpbox.Location = new System.Drawing.Point(518, 12);
            this.filter_grpbox.Name = "filter_grpbox";
            this.filter_grpbox.Size = new System.Drawing.Size(270, 293);
            this.filter_grpbox.TabIndex = 2;
            this.filter_grpbox.TabStop = false;
            this.filter_grpbox.Text = "搜索";
            // 
            // CNA
            // 
            this.CNA.AutoSize = true;
            this.CNA.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CNA.Location = new System.Drawing.Point(10, 256);
            this.CNA.Name = "CNA";
            this.CNA.Size = new System.Drawing.Size(66, 21);
            this.CNA.TabIndex = 9;
            this.CNA.Text = "中央社";
            this.CNA.UseVisualStyleBackColor = true;
            // 
            // UDN
            // 
            this.UDN.AutoSize = true;
            this.UDN.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.UDN.Location = new System.Drawing.Point(10, 228);
            this.UDN.Name = "UDN";
            this.UDN.Size = new System.Drawing.Size(66, 21);
            this.UDN.TabIndex = 8;
            this.UDN.Text = "聯合報";
            this.UDN.UseVisualStyleBackColor = true;
            // 
            // Money
            // 
            this.Money.AutoSize = true;
            this.Money.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Money.Location = new System.Drawing.Point(10, 200);
            this.Money.Name = "Money";
            this.Money.Size = new System.Drawing.Size(79, 21);
            this.Money.TabIndex = 7;
            this.Money.Text = "經濟日報";
            this.Money.UseVisualStyleBackColor = true;
            // 
            // CTEE
            // 
            this.CTEE.AutoSize = true;
            this.CTEE.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CTEE.Location = new System.Drawing.Point(10, 172);
            this.CTEE.Name = "CTEE";
            this.CTEE.Size = new System.Drawing.Size(79, 21);
            this.CTEE.TabIndex = 6;
            this.CTEE.Text = "工商時報";
            this.CTEE.UseVisualStyleBackColor = true;
            // 
            // LTN
            // 
            this.LTN.AutoSize = true;
            this.LTN.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LTN.Location = new System.Drawing.Point(10, 144);
            this.LTN.Name = "LTN";
            this.LTN.Size = new System.Drawing.Size(79, 21);
            this.LTN.TabIndex = 5;
            this.LTN.Text = "自由時報";
            this.LTN.UseVisualStyleBackColor = true;
            // 
            // CHT
            // 
            this.CHT.AutoSize = true;
            this.CHT.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CHT.Location = new System.Drawing.Point(10, 116);
            this.CHT.Name = "CHT";
            this.CHT.Size = new System.Drawing.Size(79, 21);
            this.CHT.TabIndex = 4;
            this.CHT.Text = "中國時報";
            this.CHT.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "關鍵字:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // search_str
            // 
            this.search_str.Location = new System.Drawing.Point(83, 31);
            this.search_str.Name = "search_str";
            this.search_str.Size = new System.Drawing.Size(181, 39);
            this.search_str.TabIndex = 2;
            // 
            // nxt_page
            // 
            this.nxt_page.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.nxt_page.Location = new System.Drawing.Point(437, 407);
            this.nxt_page.Name = "nxt_page";
            this.nxt_page.Size = new System.Drawing.Size(75, 23);
            this.nxt_page.TabIndex = 3;
            this.nxt_page.Text = "下一頁";
            this.nxt_page.UseVisualStyleBackColor = true;
            this.nxt_page.Click += new System.EventHandler(this.nxt_page_Click);
            // 
            // last_page
            // 
            this.last_page.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.last_page.Location = new System.Drawing.Point(12, 407);
            this.last_page.Name = "last_page";
            this.last_page.Size = new System.Drawing.Size(75, 23);
            this.last_page.TabIndex = 4;
            this.last_page.Text = "上一頁";
            this.last_page.UseVisualStyleBackColor = true;
            this.last_page.Click += new System.EventHandler(this.last_page_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.last_page);
            this.Controls.Add(this.nxt_page);
            this.Controls.Add(this.filter_grpbox);
            this.Controls.Add(this.flowLayout_news);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "新聞入口";
            this.filter_grpbox.ResumeLayout(false);
            this.filter_grpbox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayout_news;
        private System.Windows.Forms.DateTimePicker timepicker;
        private System.Windows.Forms.GroupBox filter_grpbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox search_str;
        private System.Windows.Forms.CheckBox CNA;
        private System.Windows.Forms.CheckBox UDN;
        private System.Windows.Forms.CheckBox Money;
        private System.Windows.Forms.CheckBox CTEE;
        private System.Windows.Forms.CheckBox LTN;
        private System.Windows.Forms.CheckBox CHT;
        private System.Windows.Forms.Button nxt_page;
        private System.Windows.Forms.Button last_page;
    }
}

