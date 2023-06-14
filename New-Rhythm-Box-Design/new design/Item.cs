using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace new_design
{
    public partial class Item : UserControl
    {
        private string _lbIdText;
        public string lbIdText
        {
            get { return _lbIdText; }
            set { _lbIdText = value; lbID.Text = value; }
        }
        private string _lbTitleText;
        public string lbTitleText
        {
            get { return _lbTitleText; }
            set { _lbTitleText = value; lbTitle.Text = value; }
        }
        private string _lbNameText;
        public string LBNameText
        {
            get { return _lbNameText; }
            set { _lbNameText = value; lbAddition.Text = value; }
        }
        private byte[] _Image;
        public byte[] image
        {
            get { return _Image; }
            set
            {
                _Image = value;
                using (MemoryStream ms = new MemoryStream(_Image))
                {
                    // Tạo đối tượng Image từ luồng dữ liệu
                    pbImage.Image = Image.FromStream(ms);
                }

            }
        }

        public Item()
        {
            InitializeComponent();
        }
    }
}
