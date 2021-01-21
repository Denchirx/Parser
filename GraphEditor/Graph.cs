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
            if (!nNode.CheckCollision())
            {
                foreach (Node n in myNodes)
                {
                    if (n != selectedNode
                        && selectedNode.Collide(n))
                    {
                        return;
                    }
                }

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
            foreach (Node n in myNodes)
            {
                if (n.DistTo(e.Location) < nodeSize)
                {
                    selectedNode = n;
                    return;
                }
            }

            if (e.Button == MouseButtons.Left)
            {
                AddNode(e.Location);
            }
        }

        public void MouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (selectedNode != null)
                {
                    selectedNode = null;
                }
            }

            if (e.Button == MouseButtons.Right)
            {
                if (selectedNode != null)
                {
                    foreach (Node n in myNodes)
                    {
                        if (n.DistTo(e.Location) < nodeSize)
                        {
                            if(selectedNode != n)
                            {
                                selectedNode.SetNextNode(n);
                                return;
                            }
                        }
                    }
                }
            }
        }

        public void MouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (selectedNode != null)
                {
                    Point p = selectedNode.coord;
                    selectedNode.coord = e.Location;                    

                    foreach (Node n in myNodes)
                    {
                        if (n != selectedNode
                            && selectedNode.Collide(n))
                        {
                           
                        }
                    }

                    if (selectedNode.CheckCollision())
                    {
                        selectedNode.coord = p;
                        return;
                    }

                }
            }

        }

    }
}
