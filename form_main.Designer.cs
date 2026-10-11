namespace trade
{
    partial class frm_main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.status_bar = new System.Windows.Forms.StatusStrip();
            this.text_user = new System.Windows.Forms.ToolStripStatusLabel();
            this.progress_bar = new System.Windows.Forms.ToolStripProgressBar();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.textbox_node_body = new System.Windows.Forms.RichTextBox();
            this.textbox_title = new System.Windows.Forms.TextBox();
            this.text_title = new System.Windows.Forms.Label();
            this.text_body = new System.Windows.Forms.Label();
            this.tab_control_main = new System.Windows.Forms.TabControl();
            this.tab_page_node_get = new System.Windows.Forms.TabPage();
            this.textbox_TSU_name = new System.Windows.Forms.TextBox();
            this.textbox_title_get = new System.Windows.Forms.TextBox();
            this.btn_node_get = new System.Windows.Forms.Button();
            this.tab_page_new = new System.Windows.Forms.TabPage();
            this.btn_add_new = new System.Windows.Forms.Button();
            this.updown_new_count = new System.Windows.Forms.NumericUpDown();
            this.text_new_count = new System.Windows.Forms.Label();
            this.tab_page_special = new System.Windows.Forms.TabPage();
            this.textbox_before_title = new System.Windows.Forms.TextBox();
            this.text_link_before = new System.Windows.Forms.Label();
            this.updown_category = new System.Windows.Forms.NumericUpDown();
            this.updown_special_count = new System.Windows.Forms.NumericUpDown();
            this.text_category = new System.Windows.Forms.Label();
            this.text_spec_count = new System.Windows.Forms.Label();
            this.textbox_after_title = new System.Windows.Forms.TextBox();
            this.text_before_head = new System.Windows.Forms.Label();
            this.btn_add_special = new System.Windows.Forms.Button();
            this.tab_page_parts = new System.Windows.Forms.TabPage();
            this.text_parts = new System.Windows.Forms.Label();
            this.textbox_parts = new System.Windows.Forms.TextBox();
            this.btn_parts = new System.Windows.Forms.Button();
            this.btn_connect = new System.Windows.Forms.Button();
            this.text_log = new System.Windows.Forms.Label();
            this.textbox_log = new System.Windows.Forms.TextBox();
            this.status_bar.SuspendLayout();
            this.tab_control_main.SuspendLayout();
            this.tab_page_node_get.SuspendLayout();
            this.tab_page_new.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updown_new_count)).BeginInit();
            this.tab_page_special.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updown_category)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updown_special_count)).BeginInit();
            this.tab_page_parts.SuspendLayout();
            this.SuspendLayout();
            // 
            // status_bar
            // 
            this.status_bar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.text_user,
            this.progress_bar});
            this.status_bar.Location = new System.Drawing.Point(0, 400);
            this.status_bar.Name = "status_bar";
            this.status_bar.Size = new System.Drawing.Size(725, 24);
            this.status_bar.TabIndex = 14;
            this.status_bar.Text = "statusStrip1";
            // 
            // text_user
            // 
            this.text_user.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.text_user.Name = "text_user";
            this.text_user.Size = new System.Drawing.Size(37, 19);
            this.text_user.Text = "User:";
            // 
            // progress_bar
            // 
            this.progress_bar.Name = "progress_bar";
            this.progress_bar.Size = new System.Drawing.Size(200, 18);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Enabled = false;
            this.btn_cancel.Location = new System.Drawing.Point(92, 1);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(82, 26);
            this.btn_cancel.TabIndex = 8;
            this.btn_cancel.Text = "Отмена";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // textbox_node_body
            // 
            this.textbox_node_body.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textbox_node_body.Location = new System.Drawing.Point(487, 13);
            this.textbox_node_body.Name = "textbox_node_body";
            this.textbox_node_body.Size = new System.Drawing.Size(208, 145);
            this.textbox_node_body.TabIndex = 8;
            this.textbox_node_body.Text = "";
            // 
            // textbox_title
            // 
            this.textbox_title.Location = new System.Drawing.Point(11, 105);
            this.textbox_title.Name = "textbox_title";
            this.textbox_title.Size = new System.Drawing.Size(249, 22);
            this.textbox_title.TabIndex = 13;
            // 
            // text_title
            // 
            this.text_title.AutoSize = true;
            this.text_title.Location = new System.Drawing.Point(8, 88);
            this.text_title.Name = "text_title";
            this.text_title.Size = new System.Drawing.Size(32, 14);
            this.text_title.TabIndex = 5;
            this.text_title.Text = "Title";
            // 
            // text_body
            // 
            this.text_body.AutoSize = true;
            this.text_body.Location = new System.Drawing.Point(448, 13);
            this.text_body.Name = "text_body";
            this.text_body.Size = new System.Drawing.Size(33, 14);
            this.text_body.TabIndex = 16;
            this.text_body.Text = "Body";
            // 
            // tab_control_main
            // 
            this.tab_control_main.Controls.Add(this.tab_page_special);
            this.tab_control_main.Controls.Add(this.tab_page_new);
            this.tab_control_main.Controls.Add(this.tab_page_node_get);
            this.tab_control_main.Controls.Add(this.tab_page_parts);
            this.tab_control_main.Location = new System.Drawing.Point(0, 44);
            this.tab_control_main.Name = "tab_control_main";
            this.tab_control_main.SelectedIndex = 0;
            this.tab_control_main.Size = new System.Drawing.Size(725, 250);
            this.tab_control_main.TabIndex = 20;
            // 
            // tab_page_node_get
            // 
            this.tab_page_node_get.Controls.Add(this.textbox_TSU_name);
            this.tab_page_node_get.Controls.Add(this.textbox_title_get);
            this.tab_page_node_get.Controls.Add(this.btn_node_get);
            this.tab_page_node_get.Controls.Add(this.text_body);
            this.tab_page_node_get.Controls.Add(this.textbox_node_body);
            this.tab_page_node_get.Controls.Add(this.text_title);
            this.tab_page_node_get.Controls.Add(this.textbox_title);
            this.tab_page_node_get.Location = new System.Drawing.Point(4, 23);
            this.tab_page_node_get.Name = "tab_page_node_get";
            this.tab_page_node_get.Padding = new System.Windows.Forms.Padding(3);
            this.tab_page_node_get.Size = new System.Drawing.Size(717, 223);
            this.tab_page_node_get.TabIndex = 0;
            this.tab_page_node_get.Text = "node.get";
            this.tab_page_node_get.UseVisualStyleBackColor = true;
            // 
            // textbox_TSU_name
            // 
            this.textbox_TSU_name.BackColor = System.Drawing.Color.Yellow;
            this.textbox_TSU_name.Location = new System.Drawing.Point(11, 63);
            this.textbox_TSU_name.Name = "textbox_TSU_name";
            this.textbox_TSU_name.Size = new System.Drawing.Size(247, 22);
            this.textbox_TSU_name.TabIndex = 12;
            // 
            // textbox_title_get
            // 
            this.textbox_title_get.BackColor = System.Drawing.Color.Yellow;
            this.textbox_title_get.Location = new System.Drawing.Point(11, 35);
            this.textbox_title_get.Name = "textbox_title_get";
            this.textbox_title_get.Size = new System.Drawing.Size(247, 22);
            this.textbox_title_get.TabIndex = 11;
            // 
            // btn_node_get
            // 
            this.btn_node_get.Location = new System.Drawing.Point(11, 6);
            this.btn_node_get.Name = "btn_node_get";
            this.btn_node_get.Size = new System.Drawing.Size(89, 23);
            this.btn_node_get.TabIndex = 2;
            this.btn_node_get.Text = "Get Node";
            this.btn_node_get.UseVisualStyleBackColor = true;
            this.btn_node_get.Click += new System.EventHandler(this.buttonNodeGet_Click);
            // 
            // tab_page_new
            // 
            this.tab_page_new.Controls.Add(this.btn_add_new);
            this.tab_page_new.Controls.Add(this.updown_new_count);
            this.tab_page_new.Controls.Add(this.text_new_count);
            this.tab_page_new.Location = new System.Drawing.Point(4, 23);
            this.tab_page_new.Name = "tab_page_new";
            this.tab_page_new.Padding = new System.Windows.Forms.Padding(3);
            this.tab_page_new.Size = new System.Drawing.Size(717, 223);
            this.tab_page_new.TabIndex = 1;
            this.tab_page_new.Text = "Добавление новинок";
            this.tab_page_new.UseVisualStyleBackColor = true;
            // 
            // btn_add_new
            // 
            this.btn_add_new.Location = new System.Drawing.Point(634, 194);
            this.btn_add_new.Name = "btn_add_new";
            this.btn_add_new.Size = new System.Drawing.Size(75, 23);
            this.btn_add_new.TabIndex = 25;
            this.btn_add_new.Text = "Добавить";
            this.btn_add_new.UseVisualStyleBackColor = true;
            this.btn_add_new.Click += new System.EventHandler(this.buttonAddNew_Click);
            // 
            // updown_new_count
            // 
            this.updown_new_count.Location = new System.Drawing.Point(78, 6);
            this.updown_new_count.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.updown_new_count.Name = "updown_new_count";
            this.updown_new_count.Size = new System.Drawing.Size(120, 22);
            this.updown_new_count.TabIndex = 24;
            this.updown_new_count.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // text_new_count
            // 
            this.text_new_count.AutoSize = true;
            this.text_new_count.Location = new System.Drawing.Point(3, 8);
            this.text_new_count.Name = "text_new_count";
            this.text_new_count.Size = new System.Drawing.Size(69, 14);
            this.text_new_count.TabIndex = 23;
            this.text_new_count.Text = "Количество";
            // 
            // tab_page_special
            // 
            this.tab_page_special.Controls.Add(this.textbox_before_title);
            this.tab_page_special.Controls.Add(this.text_link_before);
            this.tab_page_special.Controls.Add(this.updown_category);
            this.tab_page_special.Controls.Add(this.updown_special_count);
            this.tab_page_special.Controls.Add(this.text_category);
            this.tab_page_special.Controls.Add(this.text_spec_count);
            this.tab_page_special.Controls.Add(this.textbox_after_title);
            this.tab_page_special.Controls.Add(this.text_before_head);
            this.tab_page_special.Controls.Add(this.btn_add_special);
            this.tab_page_special.Location = new System.Drawing.Point(4, 23);
            this.tab_page_special.Name = "tab_page_special";
            this.tab_page_special.Padding = new System.Windows.Forms.Padding(3);
            this.tab_page_special.Size = new System.Drawing.Size(717, 223);
            this.tab_page_special.TabIndex = 2;
            this.tab_page_special.Text = "Спецтехника";
            this.tab_page_special.UseVisualStyleBackColor = true;
            // 
            // textbox_before_title
            // 
            this.textbox_before_title.Location = new System.Drawing.Point(173, 59);
            this.textbox_before_title.Name = "textbox_before_title";
            this.textbox_before_title.Size = new System.Drawing.Size(120, 22);
            this.textbox_before_title.TabIndex = 31;
            this.textbox_before_title.Text = "dorozhnaya/";
            // 
            // text_link_before
            // 
            this.text_link_before.AutoSize = true;
            this.text_link_before.Location = new System.Drawing.Point(6, 62);
            this.text_link_before.Name = "text_link_before";
            this.text_link_before.Size = new System.Drawing.Size(161, 14);
            this.text_link_before.TabIndex = 30;
            this.text_link_before.Text = "Добавить в адрес-ссылку ДО";
            // 
            // updown_category
            // 
            this.updown_category.Location = new System.Drawing.Point(173, 6);
            this.updown_category.Maximum = new decimal(new int[] {
            900,
            0,
            0,
            0});
            this.updown_category.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.updown_category.Name = "updown_category";
            this.updown_category.Size = new System.Drawing.Size(120, 22);
            this.updown_category.TabIndex = 28;
            this.updown_category.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // updown_special_count
            // 
            this.updown_special_count.Location = new System.Drawing.Point(374, 6);
            this.updown_special_count.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.updown_special_count.Name = "updown_special_count";
            this.updown_special_count.Size = new System.Drawing.Size(120, 22);
            this.updown_special_count.TabIndex = 29;
            this.updown_special_count.Value = new decimal(new int[] {
            36,
            0,
            0,
            0});
            // 
            // text_category
            // 
            this.text_category.AutoSize = true;
            this.text_category.Location = new System.Drawing.Point(3, 8);
            this.text_category.Name = "text_category";
            this.text_category.Size = new System.Drawing.Size(63, 14);
            this.text_category.TabIndex = 27;
            this.text_category.Text = "Категория";
            // 
            // text_spec_count
            // 
            this.text_spec_count.AutoSize = true;
            this.text_spec_count.Location = new System.Drawing.Point(299, 8);
            this.text_spec_count.Name = "text_spec_count";
            this.text_spec_count.Size = new System.Drawing.Size(69, 14);
            this.text_spec_count.TabIndex = 26;
            this.text_spec_count.Text = "Количество";
            // 
            // textbox_after_title
            // 
            this.textbox_after_title.Location = new System.Drawing.Point(173, 31);
            this.textbox_after_title.Name = "textbox_after_title";
            this.textbox_after_title.Size = new System.Drawing.Size(120, 22);
            this.textbox_after_title.TabIndex = 25;
            // 
            // text_before_head
            // 
            this.text_before_head.AutoSize = true;
            this.text_before_head.Location = new System.Drawing.Point(3, 34);
            this.text_before_head.Name = "text_before_head";
            this.text_before_head.Size = new System.Drawing.Size(110, 14);
            this.text_before_head.TabIndex = 24;
            this.text_before_head.Text = "Текст до заголовка";
            // 
            // btn_add_special
            // 
            this.btn_add_special.Location = new System.Drawing.Point(634, 194);
            this.btn_add_special.Name = "btn_add_special";
            this.btn_add_special.Size = new System.Drawing.Size(75, 23);
            this.btn_add_special.TabIndex = 0;
            this.btn_add_special.Text = "Add!";
            this.btn_add_special.UseVisualStyleBackColor = true;
            this.btn_add_special.Click += new System.EventHandler(this.btn_add_special_click);
            // 
            // tab_page_parts
            // 
            this.tab_page_parts.Controls.Add(this.text_parts);
            this.tab_page_parts.Controls.Add(this.textbox_parts);
            this.tab_page_parts.Controls.Add(this.btn_parts);
            this.tab_page_parts.Location = new System.Drawing.Point(4, 23);
            this.tab_page_parts.Name = "tab_page_parts";
            this.tab_page_parts.Padding = new System.Windows.Forms.Padding(3);
            this.tab_page_parts.Size = new System.Drawing.Size(717, 223);
            this.tab_page_parts.TabIndex = 3;
            this.tab_page_parts.Text = "Запчасти";
            this.tab_page_parts.UseVisualStyleBackColor = true;
            // 
            // text_parts
            // 
            this.text_parts.AutoSize = true;
            this.text_parts.Location = new System.Drawing.Point(8, 6);
            this.text_parts.Name = "text_parts";
            this.text_parts.Size = new System.Drawing.Size(55, 14);
            this.text_parts.TabIndex = 3;
            this.text_parts.Text = "Запчасти";
            // 
            // textbox_parts
            // 
            this.textbox_parts.Location = new System.Drawing.Point(69, 6);
            this.textbox_parts.Name = "textbox_parts";
            this.textbox_parts.Size = new System.Drawing.Size(215, 22);
            this.textbox_parts.TabIndex = 1;
            // 
            // btn_parts
            // 
            this.btn_parts.Location = new System.Drawing.Point(634, 194);
            this.btn_parts.Name = "btn_parts";
            this.btn_parts.Size = new System.Drawing.Size(75, 23);
            this.btn_parts.TabIndex = 0;
            this.btn_parts.Text = "Parts";
            this.btn_parts.UseVisualStyleBackColor = true;
            this.btn_parts.Click += new System.EventHandler(this.btn_add_parts_click);
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(4, 1);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(82, 26);
            this.btn_connect.TabIndex = 7;
            this.btn_connect.Text = "Connect";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_click);
            // 
            // text_log
            // 
            this.text_log.AutoSize = true;
            this.text_log.Location = new System.Drawing.Point(1, 297);
            this.text_log.Name = "text_log";
            this.text_log.Size = new System.Drawing.Size(48, 14);
            this.text_log.TabIndex = 22;
            this.text_log.Text = "Журнал";
            // 
            // textbox_log
            // 
            this.textbox_log.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textbox_log.Location = new System.Drawing.Point(0, 314);
            this.textbox_log.Multiline = true;
            this.textbox_log.Name = "textbox_log";
            this.textbox_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textbox_log.Size = new System.Drawing.Size(721, 85);
            this.textbox_log.TabIndex = 21;
            // 
            // frm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 424);
            this.Controls.Add(this.textbox_log);
            this.Controls.Add(this.text_log);
            this.Controls.Add(this.status_bar);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.tab_control_main);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frm_main";
            this.Text = "dru XRPC";
            this.status_bar.ResumeLayout(false);
            this.status_bar.PerformLayout();
            this.tab_control_main.ResumeLayout(false);
            this.tab_page_node_get.ResumeLayout(false);
            this.tab_page_node_get.PerformLayout();
            this.tab_page_new.ResumeLayout(false);
            this.tab_page_new.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updown_new_count)).EndInit();
            this.tab_page_special.ResumeLayout(false);
            this.tab_page_special.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updown_category)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updown_special_count)).EndInit();
            this.tab_page_parts.ResumeLayout(false);
            this.tab_page_parts.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip status_bar;
        private System.Windows.Forms.ToolStripStatusLabel text_user;
        private System.Windows.Forms.ToolStripProgressBar progress_bar;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label text_log;
        private System.Windows.Forms.TabControl tab_control_main;
        private System.Windows.Forms.TabPage tab_page_node_get;
        private System.Windows.Forms.TextBox textbox_TSU_name;
        private System.Windows.Forms.TextBox textbox_title_get;
        private System.Windows.Forms.Button btn_node_get;
        private System.Windows.Forms.TabPage tab_page_new;
        private System.Windows.Forms.Label text_body;
        private System.Windows.Forms.Label text_title;
        private System.Windows.Forms.TextBox textbox_title;
        private System.Windows.Forms.RichTextBox textbox_node_body;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.TextBox textbox_log;
        private System.Windows.Forms.Button btn_add_new;
        private System.Windows.Forms.NumericUpDown updown_new_count;
        private System.Windows.Forms.Label text_new_count;
        private System.Windows.Forms.TabPage tab_page_special;
        private System.Windows.Forms.Button btn_add_special;
        private System.Windows.Forms.Label text_link_before;
        private System.Windows.Forms.NumericUpDown updown_category;
        private System.Windows.Forms.NumericUpDown updown_special_count;
        private System.Windows.Forms.Label text_category;
        private System.Windows.Forms.Label text_spec_count;
        private System.Windows.Forms.TextBox textbox_after_title;
        private System.Windows.Forms.Label text_before_head;
        private System.Windows.Forms.TextBox textbox_before_title;
        private System.Windows.Forms.TabPage tab_page_parts;
        private System.Windows.Forms.Button btn_parts;
        private System.Windows.Forms.Label text_parts;
        private System.Windows.Forms.TextBox textbox_parts;

    }
}

