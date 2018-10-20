using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameSaveSwapper {
    public partial class RenameForm : Form {
        public RenameForm() {
            InitializeComponent();
        }

        public string getText() {
            return RenameTextBox.Text;
        }

        public void setText(String s) {
            this.RenameTextBox.Text = s;
        }

        public void setLabel(String s) {
            this.RenameLabel.Text = s;
        }

        private void RenameForm_Closing(object sender, FormClosingEventArgs e) {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
