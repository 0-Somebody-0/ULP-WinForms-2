namespace lab11_1
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
            buttonLoad = new Button();
            buttonGenerate = new Button();
            buttonSearch = new Button();
            textBoxProductName = new TextBox();
            listBoxPrices = new ListBox();
            SuspendLayout();
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(454, 157);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(282, 29);
            buttonLoad.TabIndex = 3;
            buttonLoad.Text = "Показать(загрузить) список товаров";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // buttonGenerate
            // 
            buttonGenerate.Location = new Point(454, 218);
            buttonGenerate.Name = "buttonGenerate";
            buttonGenerate.Size = new Size(282, 29);
            buttonGenerate.TabIndex = 4;
            buttonGenerate.Text = "Генерация списка товаров";
            buttonGenerate.UseVisualStyleBackColor = true;
            buttonGenerate.Click += buttonGenerate_Click;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(488, 59);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(210, 29);
            buttonSearch.TabIndex = 5;
            buttonSearch.Text = "Поиск по имени товара";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // textBoxProductName
            // 
            textBoxProductName.Location = new Point(454, 12);
            textBoxProductName.Multiline = true;
            textBoxProductName.Name = "textBoxProductName";
            textBoxProductName.Size = new Size(282, 29);
            textBoxProductName.TabIndex = 7;
            textBoxProductName.Text = "Поле ввода имени товара";
            textBoxProductName.TextAlign = HorizontalAlignment.Center;
            // 
            // listBoxPrices
            // 
            listBoxPrices.FormattingEnabled = true;
            listBoxPrices.Location = new Point(28, 12);
            listBoxPrices.Name = "listBoxPrices";
            listBoxPrices.Size = new Size(345, 264);
            listBoxPrices.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listBoxPrices);
            Controls.Add(textBoxProductName);
            Controls.Add(buttonSearch);
            Controls.Add(buttonGenerate);
            Controls.Add(buttonLoad);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button buttonGenerate;
        private Button buttonSearch;
        private Button buttonLoad;
        private TextBox textBoxProductName;
        private ListBox listBoxPrices;
    }
}
