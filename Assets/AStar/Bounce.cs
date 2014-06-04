using UnityEngine;
using System.Collections;

public class Bounce : MonoBehaviour
{
		public float dist = 0.5f;

		void Update ()
		{
				RaycastHit hit;
				//checking if colliding with the left wall
				if (Physics.Raycast (transform.position, new Vector3 (-dist, 0, 0), out hit, dist)) {
						float resistPower = 0.08f - hit.distance / (dist * 10);
						transform.position += new Vector3 (resistPower, 0, 0);

				}
				//checking collisions with right wall
				if (Physics.Raycast (transform.position, new Vector3 (dist, 0, 0), out hit, dist)) {

						float resistPower = 0.08f - hit.distance / (dist * 10);
						transform.position += new Vector3 (-resistPower, 0, 0);

				}
				//forward raycasting
				if (Physics.Raycast (transform.position, new Vector3 (0, 0, dist), out hit, dist)) {
						float resistPower = 0.08f - hit.distance / (dist * 10);
						transform.position += new Vector3 (0, 0, -resistPower);

				}
				//backwards raycasting
				if (Physics.Raycast (transform.position, new Vector3 (0, 0, -dist), out hit, dist)) {

						float resistPower = 0.08f - hit.distance / (dist * 10);
						transform.position += new Vector3 (0, 0, resistPower);
			
				}
				//checking if hitting another enemy/player. make sure they don't overlap but instead "collide"
				if (Physics.Raycast (transform.position, new Vector3 (dist, 0, dist), out hit, dist)) {
			
						float resistPower = 0.08f - hit.distance / (dist * 10);
						transform.position += new Vector3 (-resistPower, 0, -resistPower);
			
				}
				if (Physics.Raycast (transform.position, new Vector3 (dist, 0, -dist), out hit, dist)) {
			
						float resistPower = 0.08f - hit.distance / (dist * 10);
						transform.position += new Vector3 (-resistPower, 0, resistPower);
			
				}
				if (Physics.Raycast (transform.position, new Vector3 (-dist, 0, dist), out hit, dist)) {
			
						float resistPower = 0.08f - hit.distance / (dist * 10);
						transform.position += new Vector3 (resistPower, 0, -resistPower);
			
				}
				if (Physics.Raycast (transform.position, new Vector3 (-dist, 0, -dist), out hit, dist)) {
			
			
						float resistPower = 0.08f - hit.distance / (dist * 10);
						transform.position += new Vector3 (resistPower, 0, resistPower);
			
				}
		}
}