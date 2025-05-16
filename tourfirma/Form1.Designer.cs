namespace tourfirma
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            tabPage6 = new TabPage();
            btnParam = new Button();
            btnAgreg = new Button();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            button7 = new Button();
            button6 = new Button();
            dataGridViewResult = new DataGridView();
            txtParametricQuery = new RichTextBox();
            txtAggregateQuery = new TextBox();
            button5 = new Button();
            label2 = new Label();
            button4 = new Button();
            label1 = new Label();
            tabPage5 = new TabPage();
            dataGridView6 = new DataGridView();
            tabPage4 = new TabPage();
            dataGridView5 = new DataGridView();
            tabPage3 = new TabPage();
            dataGridView4 = new DataGridView();
            tabPage2 = new TabPage();
            button8 = new Button();
            dataGridView3 = new DataGridView();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            dataGridView7 = new DataGridView();
            tabPage7 = new TabPage();
            tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResult).BeginInit();
            tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView6).BeginInit();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView5).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView4).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView7).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.Location = new Point(277, 657);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(150, 50);
            button1.TabIndex = 1;
            button1.Text = "Добавить";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(540, 657);
            button2.Margin = new Padding(4, 5, 4, 5);
            button2.Name = "button2";
            button2.Size = new Size(150, 50);
            button2.TabIndex = 2;
            button2.Text = "Изменить";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Transparent;
            button3.Location = new Point(822, 657);
            button3.Margin = new Padding(4, 5, 4, 5);
            button3.Name = "button3";
            button3.Size = new Size(150, 50);
            button3.TabIndex = 3;
            button3.Text = "Удалить";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // tabPage6
            // 
            tabPage6.Controls.Add(btnParam);
            tabPage6.Controls.Add(btnAgreg);
            tabPage6.Controls.Add(comboBox2);
            tabPage6.Controls.Add(comboBox1);
            tabPage6.Controls.Add(button7);
            tabPage6.Controls.Add(button6);
            tabPage6.Controls.Add(dataGridViewResult);
            tabPage6.Controls.Add(txtParametricQuery);
            tabPage6.Controls.Add(txtAggregateQuery);
            tabPage6.Controls.Add(button5);
            tabPage6.Controls.Add(label2);
            tabPage6.Controls.Add(button4);
            tabPage6.Controls.Add(label1);
            tabPage6.Location = new Point(4, 34);
            tabPage6.Name = "tabPage6";
            tabPage6.Padding = new Padding(3);
            tabPage6.Size = new Size(1282, 580);
            tabPage6.TabIndex = 5;
            tabPage6.Text = "Запросы";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // btnParam
            // 
            btnParam.Location = new Point(603, 275);
            btnParam.Name = "btnParam";
            btnParam.Size = new Size(112, 34);
            btnParam.TabIndex = 13;
            btnParam.Text = "Выполнить";
            btnParam.UseVisualStyleBackColor = true;
            btnParam.Click += btnParam_Click;
            // 
            // btnAgreg
            // 
            btnAgreg.Location = new Point(603, 102);
            btnAgreg.Name = "btnAgreg";
            btnAgreg.Size = new Size(112, 34);
            btnAgreg.TabIndex = 12;
            btnAgreg.Text = "Выполнить";
            btnAgreg.UseVisualStyleBackColor = true;
            btnAgreg.Click += btnAgreg_Click;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(603, 212);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(415, 33);
            comboBox2.TabIndex = 11;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(603, 53);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(415, 33);
            comboBox1.TabIndex = 10;
            // 
            // button7
            // 
            button7.Location = new Point(16, 450);
            button7.Name = "button7";
            button7.Size = new Size(130, 34);
            button7.TabIndex = 9;
            button7.Text = "импорт excel";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button6
            // 
            button6.Location = new Point(15, 410);
            button6.Name = "button6";
            button6.Size = new Size(131, 34);
            button6.TabIndex = 8;
            button6.Text = "экспорт excel";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // dataGridViewResult
            // 
            dataGridViewResult.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewResult.Location = new Point(16, 23);
            dataGridViewResult.Name = "dataGridViewResult";
            dataGridViewResult.RowHeadersWidth = 62;
            dataGridViewResult.RowTemplate.Height = 33;
            dataGridViewResult.Size = new Size(562, 381);
            dataGridViewResult.TabIndex = 7;
            // 
            // txtParametricQuery
            // 
            txtParametricQuery.Location = new Point(1067, 212);
            txtParametricQuery.Name = "txtParametricQuery";
            txtParametricQuery.Size = new Size(209, 148);
            txtParametricQuery.TabIndex = 6;
            txtParametricQuery.Text = "";
            // 
            // txtAggregateQuery
            // 
            txtAggregateQuery.Location = new Point(1067, 53);
            txtAggregateQuery.Name = "txtAggregateQuery";
            txtAggregateQuery.Size = new Size(209, 31);
            txtAggregateQuery.TabIndex = 1;
            // 
            // button5
            // 
            button5.Location = new Point(1067, 388);
            button5.Name = "button5";
            button5.Size = new Size(112, 34);
            button5.TabIndex = 5;
            button5.Text = "Выполнить";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(603, 163);
            label2.Name = "label2";
            label2.Size = new Size(248, 25);
            label2.TabIndex = 3;
            label2.Text = "Параметризованныq запрос";
            // 
            // button4
            // 
            button4.Location = new Point(1067, 102);
            button4.Name = "button4";
            button4.Size = new Size(112, 34);
            button4.TabIndex = 2;
            button4.Text = "Выполнить";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(603, 13);
            label1.Name = "label1";
            label1.Size = new Size(214, 25);
            label1.TabIndex = 0;
            label1.Text = "Агрегированный запрос";
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(dataGridView6);
            tabPage5.Location = new Point(4, 34);
            tabPage5.Margin = new Padding(4, 5, 4, 5);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(4, 5, 4, 5);
            tabPage5.Size = new Size(1282, 580);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Оплата";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // dataGridView6
            // 
            dataGridView6.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView6.Location = new Point(21, 22);
            dataGridView6.Margin = new Padding(4, 5, 4, 5);
            dataGridView6.Name = "dataGridView6";
            dataGridView6.RowHeadersWidth = 62;
            dataGridView6.RowTemplate.Height = 25;
            dataGridView6.Size = new Size(1253, 531);
            dataGridView6.TabIndex = 0;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(dataGridView5);
            tabPage4.Location = new Point(4, 34);
            tabPage4.Margin = new Padding(4, 5, 4, 5);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(4, 5, 4, 5);
            tabPage4.Size = new Size(1282, 580);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Путевки";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // dataGridView5
            // 
            dataGridView5.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView5.Location = new Point(21, 22);
            dataGridView5.Margin = new Padding(4, 5, 4, 5);
            dataGridView5.Name = "dataGridView5";
            dataGridView5.RowHeadersWidth = 62;
            dataGridView5.RowTemplate.Height = 25;
            dataGridView5.Size = new Size(1235, 537);
            dataGridView5.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(dataGridView4);
            tabPage3.Location = new Point(4, 34);
            tabPage3.Margin = new Padding(4, 5, 4, 5);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(4, 5, 4, 5);
            tabPage3.Size = new Size(1282, 580);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Сезоны";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView4
            // 
            dataGridView4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView4.Location = new Point(4, 10);
            dataGridView4.Margin = new Padding(4, 5, 4, 5);
            dataGridView4.Name = "dataGridView4";
            dataGridView4.RowHeadersWidth = 62;
            dataGridView4.RowTemplate.Height = 25;
            dataGridView4.Size = new Size(1270, 560);
            dataGridView4.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(button8);
            tabPage2.Controls.Add(dataGridView3);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Margin = new Padding(4, 5, 4, 5);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(4, 5, 4, 5);
            tabPage2.Size = new Size(1282, 580);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Туристы";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Location = new Point(537, 527);
            button8.Name = "button8";
            button8.Size = new Size(112, 34);
            button8.TabIndex = 1;
            button8.Text = "Триггер";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // dataGridView3
            // 
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Location = new Point(8, 10);
            dataGridView3.Margin = new Padding(4, 5, 4, 5);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.RowHeadersWidth = 62;
            dataGridView3.RowTemplate.Height = 25;
            dataGridView3.Size = new Size(1266, 509);
            dataGridView3.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage7);
            tabControl1.Controls.Add(tabPage6);
            tabControl1.Location = new Point(13, 14);
            tabControl1.Margin = new Padding(4, 5, 4, 5);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1290, 618);
            tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dataGridView7);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1282, 580);
            tabPage1.TabIndex = 6;
            tabPage1.Text = "Туры";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView7
            // 
            dataGridView7.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView7.Location = new Point(21, 22);
            dataGridView7.Name = "dataGridView7";
            dataGridView7.RowHeadersWidth = 62;
            dataGridView7.RowTemplate.Height = 33;
            dataGridView7.Size = new Size(1224, 535);
            dataGridView7.TabIndex = 0;
            // 
            // tabPage7
            // 
            tabPage7.Location = new Point(4, 34);
            tabPage7.Name = "tabPage7";
            tabPage7.Padding = new Padding(3);
            tabPage7.Size = new Size(1282, 580);
            tabPage7.TabIndex = 7;
            tabPage7.Text = "Графики";
            tabPage7.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1313, 729);
            Controls.Add(tabControl1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Form1";
            tabPage6.ResumeLayout(false);
            tabPage6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResult).EndInit();
            tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView6).EndInit();
            tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView5).EndInit();
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView4).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView7).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private Button button2;
        private Button button3;
        private TabPage tabPage6;
        private DataGridView dataGridViewResult;
        private RichTextBox txtParametricQuery;
        private TextBox txtAggregateQuery;
        private Button button5;
        private Label label2;
        private Button button4;
        private Label label1;
        private TabPage tabPage5;
        private DataGridView dataGridView6;
        private TabPage tabPage4;
        private DataGridView dataGridView5;
        private TabPage tabPage3;
        private DataGridView dataGridView4;
        private TabPage tabPage2;
        private DataGridView dataGridView3;
        private TabControl tabControl1;
        private Button button7;
        private Button button6;
        private Button button8;
        private TabPage tabPage1;
        private TabPage tabPage7;
        private DataGridView dataGridView7;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private Button btnParam;
        private Button btnAgreg;
    }
}