using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using static GraphEditor.GlobalVar;

namespace GraphEditor
{
    class Graph
    {
        List<Node> myNodes = new List<Node>();

        Bitmap b;
        Graphics g;

        PictureBox pictBox;

        public Graph(PictureBox pb)
        {
            pictBox = pb;
            width = pictBox.Width;
            height = pictBox.Height;

            b = new Bitmap(width, height);
            g = Graphics.FromImage(b);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }

        public void AddNode(Point coord)
        {
            Node nNode = new Node(coord);
            if (!nNode.CheckCollision(myNodes))
            {
                myNodes.Add(nNode);
            }
        }

        public void ShowGraph()
        {
            g.Clear(Color.White);

            foreach (Node n in myNodes)
            {
                n.Show(g);
            }

            pictBox.Image = b;
        }

        public void MouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                AddNode(e.Location);
            }
        }

        public void MouseUp(MouseEventArgs e)
        { 
        }

        public void MouseMove(MouseEventArgs e)
        { 
        }

    }
}
