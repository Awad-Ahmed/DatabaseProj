using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseGUI
{
    public partial class DBGUI : Form
    {
        public DBGUI()
        {
            InitializeComponent();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            ImageList myImageList = new ImageList();
            myImageList.Images.Add(Image.FromFile(@"D:\\C# saves\\DataBaseGUI\\Databaseicon5.png"));
            ConnectTreeView.Nodes.Add("item1");
            ConnectTreeView.Nodes[0].Nodes.Add("subitem1");
            ConnectTreeView.Nodes[0].Nodes[0].Nodes.Add("subsubitem1");
            ConnectTreeView.ImageList = myImageList;
            
        }
    }
}
