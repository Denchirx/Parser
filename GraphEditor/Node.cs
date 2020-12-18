using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using static GraphEditor.GlobalVar;

namespace GraphEditor
{
    class Node
    {
        Point coord;

        public Node(Point c)
        {
            coord = c;

        }

        public void Show(Graphics g)
        {
            g.DrawEllipse(Pens.Black, 
                coord.X - nodeSize, coord.Y - nodeSize,
                2 * nodeSize, 2 * nodeSize);
        }

        public bool CheckCollision(List<Node> toCheck)
        {
            if (coord.X + nodeSize > width
                || coord.X - nodeSize < 0
                || coord.Y + nodeSize > height
                || coord.Y - nodeSize < 0)
            {
                return true;
            }

            foreach(Node n in toCheck)
            {
                if (Collide(n))
                {
                    return true;
                }
            }

            return false;
        }
        bool Collide(Node n)
        {
            return DistTo(n.coord) < 2 * nodeSize;
        }

        double DistTo(Point p)
        {
            return Math.Sqrt(
                Math.Pow(coord.X - p.X, 2)
                +
                Math.Pow(coord.Y - p.Y, 2)
                );
        }
    }

   
}
