namespace ReestrFormatter
{
    partial class MainForm
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
            this.brouseButton = new System.Windows.Forms.Button();
            this.changeButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // brouseButton
            // 
            this.brouseButton.Location = new System.Drawing.Point(356, 54);
            this.brouseButton.Name = "brouseButton";
            this.brouseButton.Size = new System.Drawing.Size(75, 23);
            this.brouseButton.TabIndex = 0;
            this.brouseButton.Text = "Выбрать";
            this.brouseButton.UseVisualStyleBackColor = true;
            this.brouseButton.Click += new System.EventHandler(this.brouseButton_Click);
            // 
            // changeButton
            // 
            this.changeButton.Location = new System.Drawing.Point(105, 108);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(204, 23);
            this.changeButton.TabIndex = 1;
            this.changeButton.Text = "Получить файл";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // pathTextBox
            // 
            this.pathTextBox.Location = new System.Drawing.Point(12, 54);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(338, 23);
            this.pathTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Выберите файл для форматирования:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 143);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.changeButton);
            this.Controls.Add(this.brouseButton);
            this.Name = "MainForm";
            this.Text = "Реестры";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button brouseButton;
        private Button changeButton;
        private OpenFileDialog openFileDialog;
        private TextBox pathTextBox;
        private Label label1;
    }
}