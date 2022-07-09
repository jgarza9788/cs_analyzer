using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.LearnByDoing.General.Algorithms.Graph
{
    public class Graph<T>
    {
        //public List<Node<T>> Nodes { get; set; }

	    public Dictionary<Node<T>, Edge<T>[]> Vertices { get; } = new Dictionary<Node<T>, Edge<T>[]>();

        public void AddVertex(Node<T> node, Edge<T>[] edges)
        {
            if (!Vertices.ContainsKey(node))
                Vertices.Add(node, edges);
        }

	    public List<Node<T>> GetShortestPathUsingBellmanFordAlgorithm(Node<T> fromNode, Node<T> toNode)
	    {
			// Get the predecessor
		    Tuple<Dictionary<Node<T>, int>, Dictionary<Node<T>, Node<T>>> pathInfo = 
				GetPathInfoUsingBellmanFordAlgorithm(fromNode);
		    var predecessors = pathInfo.Item2;

			// Initialize the stack with start node, which is the destination
		    Stack<Node<T>> result = new Stack<Node<T>>();
		    var startNode = toNode;
		    result.Push(startNode);

			// Traverse the predecessor hashtable until we find 
		    do
		    {
			    var node = predecessors[startNode];
			    result.Push(node);

				// if we reached the source, then we are done.
			    if (node.Value.Equals(fromNode.Value)) break;

				// Move onto the next node
				startNode = node;
		    } while (true);

		    return result.ToList();
	    }

	    public Tuple<Dictionary<Node<T>, int>, Dictionary<Node<T>, Node<T>>> 
			GetPathInfoUsingBellmanFordAlgorithm(Node<T> sourceNode)
	    {
			var distance = new Dictionary<Node<T>, int>();
		    var predecessor = new Dictionary<Node<T>, Node<T>>();

		    // Step 1: initialize graph
		    foreach (KeyValuePair<Node<T>, Edge<T>[]> vertex in this.Vertices)
		    {
			    // At the beginning , all vertices have a weight of infinity
			    distance[vertex.Key] = int.MaxValue;
			    // And a null predecessor
			    predecessor[vertex.Key] = null;

				// initialize nodes in edges
			    foreach (var edge in vertex.Value)
			    {
				    distance[edge.Node] = int.MaxValue;
				    predecessor[edge.Node] = null;
			    }
		    }
		    // Except for the Source, where the Weight is zero
		    distance[sourceNode] = 0;

		    // Step 2: relax edges repeatedly
		    for (int i = 1; i < this.Vertices.Count; i++)
		    {
			    foreach (KeyValuePair<Node<T>, Edge<T>[]> vertex in this.Vertices)
			    {
				    var u = vertex.Key;
				    foreach (Edge<T> edge in vertex.Value)
				    {
					    var v = edge.Node;
					    var w = edge.Weight;

					    if (distance[u] + w < distance[v])
					    {
						    distance[v] = distance[u] + w;
						    predecessor[v] = u;
					    }
				    }
			    }
		    }

		    // Step 3: check for negative-weight cycles
		    foreach (KeyValuePair<Node<T>, Edge<T>[]> vertex in this.Vertices)
		    {
			    var u = vertex.Key;
			    foreach (Edge<T> edge in vertex.Value)
			    {
				    var v = edge.Node;
				    var w = edge.Weight;

				    if (distance[u] + w < distance[v])
					    throw new InvalidOperationException("Graph contains a negative-weight cycle");
			    }
		    }

		    return Tuple.Create(distance, predecessor);

		}

		/// <summary>
		/// Implementation using Wikipedia
		/// </summary>
		public List<Node<T>> GetPathBetween3(Node<T> fromNode, Node<T> toNode)
        {
            var dist = new Dictionary<Node<T>, int>();
            var prev = new Dictionary<Node<T>, Node<T>>();
            var Q = new HashSet<Node<T>>();

            foreach (KeyValuePair<Node<T>, Edge<T>[]> v in Vertices)
            {
                foreach (Edge<T> edge in v.Value)
                {
                    // Unknown distance from source to v
                    dist[edge.Node] = int.MaxValue;
                    // Previous node in optimal path from source
                    prev[edge.Node] = null;
                    Q.Add(edge.Node);
                }
            }
            // Distance from source to source
            dist[fromNode] = 0;
            Q.Add(fromNode);

            // while Q is not empty:
            while (Q.Count > 0)
            {
                // Node with the Least distance will be selected
                // Note that order is not guaranteed.
                Node<T> u = (from distance in dist
                             where Q.Contains(distance.Key) && distance.Value == dist.Where(pair => Q.Contains(pair.Key)).Min(pair => pair.Value)
                             select distance.Key).FirstOrDefault();

                if (u.Value.Equals(toNode.Value))
                {
                    var S = new Stack<Node<T>>();
                    while (prev.ContainsKey(u))
                    {
                        S.Push(u);
                        u = prev[u];
                    }
                    S.Push(u);
                    return S.ToList();
                }

                Q.Remove(u);
                if (!Vertices.ContainsKey(u)) continue;

                foreach (Edge<T> v in Vertices[u])
                {
                    var alt = dist[u] + v.Weight;
                    if (alt < dist[v.Node])
                    {
                        dist[v.Node] = alt;
                        prev[v.Node] = u;
                    }
                }

            }

            return null;
        }

        /// <summary>
        /// First implementation was bad. Need to redo.
        /// NOT WORKING.
        /// </summary>
        public List<Node<T>> GetPathBetween2(Node<T> fromNode, Node<T> toNode)
        {
            var s = Vertices;
            var dist = new Dictionary<Node<T>, int>();
            var prev = new Dictionary<Node<T>, T>();
            var Q = new List<Node<T>>();
            var processed = new List<Node<T>>();

            // Initial
            KeyValuePair<Node<T>, Edge<T>[]> first = s.First(pair => pair.Key.Value.Equals(fromNode.Value));
            foreach (var v in Vertices.Where(pair => !pair.Key.Value.Equals(first.Key.Value)))
            {
                foreach (Edge<T> edge in v.Value)
                {
                    dist[edge.Node] = int.MaxValue; // inifinity
                    Q.Add(edge.Node);
                }
            }

            foreach (Edge<T> edge in first.Value)
            {
                dist[edge.Node] = edge.Weight;
                Q.Add(edge.Node);
            }

            dist[first.Key] = 0;
            prev[first.Key] = first.Key.Value;
            Q.Add(first.Key);

            while (Q.Count > 0)
            {
                var notProcessed = dist.Where(pair => !processed.Contains(pair.Key)).ToList();
                if (notProcessed.Count == 0) break;

                // Remove the minimum distance vertex, say m, from the fringe
                // (it is done, the shortest path to it has been found)
                Node<T> u = Q.First(node =>
                {
                    var min = notProcessed.Min(pair => pair.Value);
                    return dist[node].Equals(min);
                });
                Q.Remove(u);

                if (Vertices.ContainsKey(u))
                {
                    foreach (Edge<T> v in Vertices[u])
                    {
                        var alt = dist[u] + v.Weight;
                        if (alt < dist[v.Node])
                        {
                            dist[v.Node] = alt;
                            if (!prev.Values.Contains(u.Value))
                                prev[v.Node] = u.Value;
                        }
                    }
                }

                if (u.Value.Equals(toNode.Value))
                {
                    prev[toNode] = toNode.Value;
                    return new List<Node<T>>(prev.Distinct().Select(pair => new Node<T>(pair.Value)));
                }

                processed.Add(u);
            }

            return prev.Select(pair => pair.Key).ToList();
        }

        /// <summary>
        /// Using pseudocode in Wikipedia https://en.wikipedia.org/wiki/Dijkstra%27s_algorithm#Pseudocode
        /// </summary>
        public List<T> GetPathBetween(Node<T> fromNode, Node<T> toNode)
        {
            List<T> path = new List<T>();
            var dist = new Dictionary<Node<T>, int>();
            // unvisited nodes
            var fringe = new List<Node<T>>();

            foreach (KeyValuePair<Node<T>, Edge<T>[]> vertext in Vertices)
            {
                // Unknown distance from source to v
                dist[vertext.Key] = int.MaxValue;   // int.MaxValue => infinity
                foreach (Edge<T> edge in vertext.Value)
                {
                    dist[edge.Node] = int.MaxValue;
                }
                // All nodes initially in Q (unvisited nodes)
                fringe.Add(vertext.Key);
            }

            // Distance from source to source
            //KeyValuePair<Node<T>, int> first = dist.FirstOrDefault(pair => pair.Value == fromNode.Value);
            KeyValuePair<Node<T>, int> first = dist.FirstOrDefault(pair => pair.Key.Value.Equals(fromNode.Value));
            dist[first.Key] = 0;    // distance from itself is 0

            while (fringe.Count > 0)
            {
                // shortest path
                var processed = dist.Where(pair => !path.Contains(pair.Key.Value)).ToList();
                Node<T> m = processed.FirstOrDefault(pair => pair.Value == processed.Min(p => p.Value)).Key;
                int mDist = dist[m];
                fringe.Remove(m);

                if (!Vertices.ContainsKey(m))
                {
                    dist.Remove(m);
                    continue;
                }

                foreach (Edge<T> w in Vertices[m])
                {
                    if (dist[w.Node] == int.MaxValue)
                    {
                        dist[w.Node] = mDist + (mDist + w.Weight);
                        fringe.Add(w.Node);
                    }
                    else
                    {
                        dist[w.Node] = Math.Min(dist[w.Node], mDist + (mDist + w.Weight));
                    }
                }
                path.Add(m.Value);
            }

            return path;
        }
    }
}
