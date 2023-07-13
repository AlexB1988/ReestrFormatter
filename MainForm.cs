using Autofac;
using Autofac.Features.OwnedInstances;
using ReestrFormatter.Interfaces;

namespace ReestrFormatter
{
    public partial class MainForm : Form
    {
        private readonly IFormatter _formatter;
        private readonly ILifetimeScope _lifetimeScope;
        public MainForm(IFormatter formatter,ILifetimeScope lifetimeScope)
        {
            _formatter = formatter;
            _lifetimeScope = lifetimeScope;
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
            string path = pathTextBox.Text;
            string fileName = Path.GetFileName(path);
            string id = fileName.Substring(0,5);
            int result=0;

            if(id == "30473" || id == "30542" || id == "30541" 
                || id == "30483" || id == "30538")
            {
                using (var service = _lifetimeScope.ResolveNamed<Owned<IFormatter>>("sber"))
                {
                    result = service.Value.Format(path, id);
                }
            }

            if (id == "1984_" || id == "1985_" || id == "1856_" 
                || id == "1857_" || id == "1986_" || id == "1987_")
            {
                using (var service = _lifetimeScope.ResolveNamed<Owned<IFormatter>>("pochta"))
                {
                    result = service.Value.Format(path, id);
                }
            }

            if (id == "Krl_0" || id == "Len_7" || id == "Novop" || id == "Okt_0")
            {
                using (var service = _lifetimeScope.ResolveNamed<Owned<IFormatter>>("rnkb"))
                {
                    result = service.Value.Format(path, id);
                }
            }

            if (id == "krylo" || id == "novop" || id == "okt07")
            {
                using (var service = _lifetimeScope.ResolveNamed<Owned<IFormatter>>("otkr"))
                {
                    result = service.Value.Format(path, id);
                }
            }

            if (id == "22456" || id == "65824")
            {
                using (var service = _lifetimeScope.ResolveNamed<Owned<IFormatter>>("kb"))
                {
                    result = service.Value.Format(path, id);
                }
            }

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