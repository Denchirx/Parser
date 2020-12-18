using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GraphEditor.GlobalVar;

namespace GraphEditor
{
    public partial class Form1 : Form
    {
        Graph myGraph;

        public Form1()
        {
            InitializeComponent();
            myGraph = new Graph(pictureBox1);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            myGraph.MouseDown(e);
            this.Invalidate();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            myGraph.MouseUp(e);
            this.Invalidate();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            myGraph.MouseMove(e);
            this.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            myGraph.ShowGraph();
        }
    }
}
