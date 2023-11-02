using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour {

	public GameObject[] bottomRooms;
	public GameObject[] topRooms;
	public GameObject[] leftRooms;
	public GameObject[] rightRooms;

	public GameObject closedRoom;
	public GameObject finalRoom;
	public List<GameObject> rooms;
	private float waitTime = 4;
	private bool spawnedEnd;

	void Update()
	{
		if (waitTime <= 0 && spawnedEnd == false) {
			for (int i = 0; i < rooms.Count; i++)
			{
				if (i == rooms.Count - 1)
				{
					Instantiate(finalRoom, rooms[i].transform.position, Quaternion.identity);
					spawnedEnd = true;
				}
			}
		} else {
			waitTime -= Time.deltaTime;
		}
	}
}
