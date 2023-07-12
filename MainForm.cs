using ReestrFormatter.Services;

namespace ReestrFormatter
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void brouseButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pathTextBox.Text=openFileDialog.FileName;
            }
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            Formatter _formatter=new Formatter();
            var result = _formatter.Format(pathTextBox.Text);

            if (result == 1)
            {
                MessageBox.Show("Ресстр отформатирован",
                    "Готово",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
            }
        }
    }
}