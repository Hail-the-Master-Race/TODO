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
		string curr_state = "unset";
		float path_score = 0;
		Point enemy_prevPoint;
		
		List<Point> ConnectedPathPoints = new List<Point>();
		List<Point> PotentialPathPoints = new List<Point>();
		
		public Point(Vector3 pos, string state = "unset")
		{
			enemy_pos = pos;
			curr_state = state;
		}
		
		public string GetState()
		{
			return curr_state;
		}
		
		public Vector3 GetPos()
		{
			return enemy_pos;
		}
		
		public List<Point> GetConnectedpath_points()
		{
			return ConnectedPathPoints;
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
			return PotentialPathPoints;
		}
		
		public void AddConnectedPoint(Point point)
		{
			ConnectedPathPoints.Add(point);
		}
		
		public void AddPotentialPrevPoint(Point point)
		{
			PotentialPathPoints.Add(point);
		}
		
		public void SetPrevPoint(Point point)
		{
			enemy_prevPoint = point;
		}
		
		public void SetState(string newState)
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

		//find all the nodes with the specified nodeTag
		GameObject[] nodes = GameObject.FindGameObjectsWithTag(nodeTag);

		//create new class list
		List<Point> path_points = new List<Point>();

		foreach (GameObject n in nodes)
		{
			Point currNode = new Point(n.transform.position);
			path_points.Add(currNode);
		}
		
		Point endPoint = new Point(targetPos, "end");

		foreach(Point p in path_points) 
		{
			foreach (Point p2 in path_points)
			{
				float distance = Vector3.Distance(p.GetPos(), p2.GetPos());
				if (!Physics.Raycast(p.GetPos(), p2.GetPos() - p.GetPos(), distance))
				{
					p.AddConnectedPoint(p2);
				}
			}
			float distance2 = Vector3.Distance(targetPos, p.GetPos());
			if (!Physics.Raycast(targetPos, p.GetPos() - targetPos, distance2))
			{
				p.AddConnectedPoint(endPoint);
			}
		}
		
		//path_points startPos can see
		foreach (Point p in path_points)
		{
			float distance = Vector3.Distance(startPos, p.GetPos());
			if (!Physics.Raycast(startPos, p.GetPos() - startPos, distance))
			{
				Point startPoint = new Point(startPos, "start");
				p.SetPrevPoint(startPoint);
				p.SetState("nb");
				p.SetScore(distance + Vector3.Distance(targetPos, p.GetPos()));
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
				if (point.GetState() == "nb")
				{
					searchedAll = false;
					List<Point> potentials = point.GetConnectedpath_points();
					
					foreach (Point potentialPoint in potentials)
					{
						if (potentialPoint.GetState() == "unset")
						{
							potentialPoint.AddPotentialPrevPoint(point);
							foundConnections.Add(potentialPoint);
							potentialPoint.SetScore(Vector3.Distance(startPos, potentialPoint.GetPos()) + Vector3.Distance(targetPos, potentialPoint.GetPos()));
						} else if (potentialPoint.GetState() == "end")
						{
							//Found the exit
							foundEnd = true;
							endPoint.AddConnectedPoint(point);
						}
					}
					point.SetState("useless");
				}
			}
			foreach (Point c in foundConnections)
			{
				c.SetState("nb");
				float lowestScore = 0;
				Point bestPrevPoint = null;
				bool first = true;
				foreach (Point prevpath_points in c.GetPotentialPrevpath_points())
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
				c.SetPrevPoint(bestPrevPoint);
			}
		}
		
		if (foundEnd)
		{
			List<Point> shortestRoute = null;
			float lowestScore = 0;
			bool firstRoute = true;
			
			foreach (Point p in endPoint.GetConnectedpath_points())
			{
				float score = 0;
				bool finding = true;
				Point c_Point = p;
				List<Point> route = new List<Point>();
				route.Add(endPoint);
				while(finding)
				{
					route.Add(c_Point);
					if (c_Point.GetState() == "start")
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
						finding = false;
						break;
					}
					score += c_Point.GetScore();
					c_Point = c_Point.GetPrevPoint();
				}
			}
			
			shortestRoute.Reverse();
			List<Vector3> path = new List<Vector3>();
			foreach (Point p in shortestRoute)
			{
				path.Add(p.GetPos());
			}
			return path;
		} 
		else
		{
			return null;
		}
	}
}