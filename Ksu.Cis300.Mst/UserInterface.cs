using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ksu.Cis300.GraphDrawing;
using Ksu.Cis300.Graphs;
using System.IO;

namespace Ksu.Cis300.Mst
{
    public partial class UserInterface : Form
    {
        /// <summary>
        /// The directed graph of points
        /// </summary>
        private DirectedGraph<Point, double> _graph = new DirectedGraph<Point, double>();
        
        /// <summary>
        /// The dictionary
        /// </summary>
        private Dictionary<Point, Tuple<Point, double>> _dict = new Dictionary<Point, Tuple<Point, double>>();
        
        /// <summary>
        /// The total cost
        /// </summary>
        private double _cost;

        private List<Point> _theList = new List<Point>();
        /// <summary>
        /// The user interface component initialization
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        private void uxLoad_Click(object sender, EventArgs e)
        {
            if (uxOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamReader input = new StreamReader(uxOpenFileDialog.FileName))
                    {
                        while (!input.EndOfStream)
                        {
                            string s = input.ReadLine();
                            string[] num = s.Split(',');
                            int first = Convert.ToInt32(num[0]);
                            int second = Convert.ToInt32(num[1]);
                            Point p = new Point();
                            p.X = first;
                            p.Y = second;
                            _theList.Add(p);
                        }
                    }
                    _graph = ParsePoints(_theList);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        /// <summary>
        /// Parses the list of points into the directed graph
        /// </summary>
        /// <param name="points">list of points to parse</param>
        /// <returns>the directed graph filled with points</returns>
        private DirectedGraph<Point, double> ParsePoints(List<Point> points)
        {
            DirectedGraph<Point, double> graph = new DirectedGraph<Point, double>();

            foreach (Point x in points)
            {
                foreach (Point y in points)
                {
                    if (x != y)
                    {
                        if (x.X < uxGraphDrawing.Width && y.X < uxGraphDrawing.Width
                            && y.Y < uxGraphDrawing.Height && x.Y < uxGraphDrawing.Height)
                        {
                            int a = x.Y - y.Y;
                            int b = x.X - y.X;
                            double first = a * a;
                            double second = b * b;
                            double distance = Math.Sqrt(a + b);
                            graph.AddEdge(x, y, distance);
                        
                        }
                    }
                }
                FindMST(x, graph, out _dict);
            }
            return graph;
        }

        /// <summary>
        /// Find the minimum cost tree
        /// </summary>
        /// <param name="p">the point</param>
        /// <param name="graph">the directed graph</param>
        /// <param name="dict">the dictoinary</param>
        private void FindMST(Point p, DirectedGraph<Point, double> graph,
            out Dictionary<Point, Tuple<Point, double>> dict)
        {
            dict = new Dictionary<Point, Tuple<Point, double>>();
           // dict.Add(p, tp);
            uxGraphDrawing.DrawPoint(p);

            foreach (Tuple<Point, double> edge in graph.OutgoingEdges(p))
            {
                dict.Add(edge.Item1, new Tuple<Point, double>(p, edge.Item2));
            }
            while (dict.Keys.Count > 0)
            {
                double min = Double.PositiveInfinity;
                Tuple<Point, double> t = new Tuple<Point, double>(p, 0);
                KeyValuePair<Point, Tuple<Point, double>> k = new KeyValuePair<Point, Tuple<Point, double>>();
                foreach (KeyValuePair<Point, Tuple<Point, double>> kvp in dict)
                {
                    if (kvp.Value.Item2 < min)
                    {
                        min = kvp.Value.Item2;
                        t = new Tuple<Point, double>(kvp.Key, kvp.Value.Item2);
                        k = kvp;
                    }
                    _cost++;
                }
                Point minP = t.Item1;
                uxGraphDrawing.DrawPoint(minP);
                dict.Remove(minP);

                foreach (Tuple<Point, double> outgoing in graph.OutgoingEdges(t.Item1))
                {
                    if (dict.ContainsKey(minP))
                    {
                        dict[minP] = new Tuple<Point,double>(outgoing.Item1, outgoing.Item2);
                    }
                }

                uxGraphDrawing.DrawLine(minP, dict[minP].Item1);
            }
        }
    }
}
