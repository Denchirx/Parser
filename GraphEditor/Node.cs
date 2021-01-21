using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using static GraphEditor.GlobalVar;

namespace GraphEditor
{
    public class Node
    {
        public Point coord;
        List<Node> next = new List<Node>();

        public Node(Point c)
        {
            coord = c;
        }

        public void Show(Graphics g)
        {
            g.DrawEllipse(Pens.Black, 
                coord.X - nodeSize, coord.Y - nodeSize,
                2 * nodeSize, 2 * nodeSize);

            if (next.Count > 0)
            {
                Pen p = new Pen(Color.Black, 3);
                p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                foreach (Node n in next)
                {
                    Point a = GetArrowPoint(n.coord);
                    Point b = n.GetArrowPoint(coord);
                    g.DrawLine(p, b.X, b.Y, a.X, a.Y);
                }
            }
        }

        public bool CheckCollision()
        {
            if (coord.X + nodeSize > width
                || coord.X - nodeSize < 0
                || coord.Y + nodeSize > height
                || coord.Y - nodeSize < 0)
            {
                return true;
            }

            return false;
        }

        public void SetNextNode(Node n)
        {
            if (!next.Contains(n))
            { 
                next.Add(n);
            }
        }

        public bool Collide(Node n)
        {
            return DistTo(n.coord) < 2 * nodeSize;
        }

        public double DistTo(Point p)
        {
            return Math.Sqrt(
                Math.Pow(coord.X - p.X, 2)
                +
                Math.Pow(coord.Y - p.Y, 2)
                );
        }

        Point GetArrowPoint(Point p)
        {
            double d = DistTo(p);
            return new Point(p.X - (int)((p.X-coord.X) * nodeSize / d),
                p.Y - (int)((p.Y - coord.Y) * nodeSize / d));
        }

        //Point SetClosestPoint(Point p)
        //{ 
        //}
    }
}

