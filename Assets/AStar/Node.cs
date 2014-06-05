using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Node : MonoBehaviour {
	/* Pathfinding Algorithm: 
	 * are there nodes in the set? if no -> return failer 
	 * if so, get node with the lowest "score". if it is the target 
	 * then return best path to this node. add this node to the set.
	 * find all of the walkable nodes of this node. and then for each neighbor, calculate the cost
	 * of reaching the neighbor via the current node. Update the score for the node and store
	 * it in the set. 
	 */
	public string nodeTag;
	
	class Point
	{
		Vector3 enemy_pos;
		char curr_state = 'u';
		float path_score = 0;
		Point enemy_prevPoint;
		
		List<Point> m_connectedpath_points = new List<Point>();
		List<Point> m_potentialPrevpath_points = new List<Point>();
		
		public Point(Vector3 pos, char state = 'u')
		{
			enemy_pos = pos;
			curr_state = state;
		}
		
		public char GetState()
		{
			return curr_state;
		}
		
		public Vector3 GetPos()
		{
			return enemy_pos;
		}
		
		public List<Point> GetConnectedpath_points()
		{
			return m_connectedpath_points;
		}
		
		public Point GetPrevPoint()
		{
			return enemy_prevPoint;
		}
		
		public float GetScore()
		{
			return path_score;
		}
		
		public List<Point> GetPotentialPrevpath_points()
		{
			return m_potentialPrevpath_points;
		}
		
		public void AddConnectedPoint(Point point)
		{
			m_connectedpath_points.Add(point);
		}
		
		public void AddPotentialPrevPoint(Point point)
		{
			m_potentialPrevpath_points.Add(point);
		}
		
		public void SetPrevPoint(Point point)
		{
			enemy_prevPoint = point;
		}
		
		public void SetState(char newState)
		{
			curr_state = newState;
		}
		
		public void SetScore(float newScore)
		{
			path_score = newScore;
		}
	}
	
	public List<Vector3> Path(Vector3 startPos, Vector3 targetPos)
	{
		//Can I see the target
		float targetDistance = Vector3.Distance(startPos, targetPos);
		if (targetDistance > .7f)
			targetDistance -= .7f;
		//if the target and start are the same then just return path with the two nodes
		if (!Physics.Raycast(startPos, targetPos - startPos, targetDistance))
		{
			List<Vector3> path = new List<Vector3>();
			path.Add(startPos);
			path.Add(targetPos);
			return path;
		}
		
		GameObject[] nodes = GameObject.FindGameObjectsWithTag(nodeTag);
		List<Point> path_points = new List<Point>();
		foreach (GameObject node in nodes)
		{
			Point currNode = new Point(node.transform.position);
			path_points.Add(currNode);
		}
		
		Point endPoint = new Point(targetPos, 'e');

		foreach(Point point in path_points) 
		{
			foreach (Point point2 in path_points)
			{
				float distance = Vector3.Distance(point.GetPos(), point2.GetPos());
				if (!Physics.Raycast(point.GetPos(), point2.GetPos() - point.GetPos(), distance))
				{
					point.AddConnectedPoint(point2);
				}
			}
			float distance2 = Vector3.Distance(targetPos, point.GetPos());
			if (!Physics.Raycast(targetPos, point.GetPos() - targetPos, distance2))
			{
				point.AddConnectedPoint(endPoint);
			}
		}
		
		//path_points startPos can see
		foreach (Point point in path_points)
		{
			float distance = Vector3.Distance(startPos, point.GetPos());
			if (!Physics.Raycast(startPos, point.GetPos() - startPos, distance))
			{
				Point startPoint = new Point(startPos, 's');
				point.SetPrevPoint(startPoint);
				point.SetState('o');
				point.SetScore(distance + Vector3.Distance(targetPos, point.GetPos()));
			}
		}
		
		//Go through until we find the exit or run out of connections
		bool searchedAll = false;
		bool foundEnd = false;
		
		while(!searchedAll)
		{
			searchedAll = true;
			List<Point> foundConnections = new List<Point>();
			foreach (Point point in path_points)
			{
				if (point.GetState() == 'o')
				{
					searchedAll = false;
					List<Point> potentials = point.GetConnectedpath_points();
					
					foreach (Point potentialPoint in potentials)
					{
						if (potentialPoint.GetState() == 'u')
						{
							potentialPoint.AddPotentialPrevPoint(point);
							foundConnections.Add(potentialPoint);
							potentialPoint.SetScore(Vector3.Distance(startPos, potentialPoint.GetPos()) + Vector3.Distance(targetPos, potentialPoint.GetPos()));
						} else if (potentialPoint.GetState() == 'e')
						{
							//Found the exit
							foundEnd = true;
							endPoint.AddConnectedPoint(point);
						}
					}
					point.SetState('c');
				}
			}
			foreach (Point connection in foundConnections)
			{
				connection.SetState('o');
				float lowestScore = 0;
				Point bestPrevPoint = null;
				bool first = true;
				foreach (Point prevpath_points in connection.GetPotentialPrevpath_points())
				{
					if (first)
					{
						lowestScore = prevpath_points.GetScore();
						bestPrevPoint = prevpath_points;
						first = false;
					} else
					{
						if (lowestScore > prevpath_points.GetScore())
						{
							lowestScore = prevpath_points.GetScore();
							bestPrevPoint = prevpath_points;
						}
					}
				}
				connection.SetPrevPoint(bestPrevPoint);
			}
		}
		
		if (foundEnd)
		{
			List<Point> shortestRoute = null;
			float lowestScore = 0;
			bool firstRoute = true;
			
			foreach (Point point in endPoint.GetConnectedpath_points())
			{
				float score = 0;
				bool tracing = true;
				Point currPoint = point;
				List<Point> route = new List<Point>();
				route.Add(endPoint);
				while(tracing)
				{
					route.Add(currPoint);
					if (currPoint.GetState() == 's')
					{
						if (firstRoute)
						{
							shortestRoute = route;
							lowestScore = score;
							firstRoute = false;
						} else
						{
							if (lowestScore > score)
							{
								shortestRoute = route;
								lowestScore = score;
							}
						}
						tracing = false;
						break;
					}
					score += currPoint.GetScore();
					currPoint = currPoint.GetPrevPoint();
				}
			}
			
			shortestRoute.Reverse();
			List<Vector3> path = new List<Vector3>();
			foreach (Point point in shortestRoute)
			{
				path.Add(point.GetPos());
			}
			return path;
		} else
		{
			return null;
		}
	}
}