using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class levelManager : MonoBehaviour {



	[SerializeField]
	private GameObject[] tilePrefabs; // array of tile prefabs for creating map layout

	[SerializeField]
	private cameraMovement cameraMovement;


	void Start () {
		Point p = new Point (0, 0);

		// executes create level
		levelCreator ();
		
	}
	

	void Update () {
		
	}



	// method to intstantiate tiles
	private void levelCreator(){

		string[] mapData = ReadLevelText (); // creates map layout from text document

		int mapX = mapData [0].ToCharArray().Length; // cols
		int mapY = mapData.Length; // rows

		Vector3 maxTile = Vector3.zero;


		// start where the camera origin is 
		Vector3 originPos = Camera.main.ScreenToWorldPoint(new Vector3 (0, Screen.height));

		for (int y = 0; y < mapY; y++) {       //creates rows of tiles
			
			char[] newTiles = mapData[y].ToCharArray();

			for (int x = 0; x < mapX; x++) {   //creates columns of tiles
				maxTile = placeTile (newTiles[x].ToString(), x, y, originPos);
			
			}
		}
		cameraMovement.setLimits (new Vector3 (maxTile.x + TileSize, maxTile.y - TileSize));
	}



	//method to return tize size 
	public float TileSize {
		get{return tilePrefabs[0].GetComponent<SpriteRenderer> ().sprite.bounds.size.x;}
	}





	// method to place tile on map
	private Vector3 placeTile (string tileType, int x, int y, Vector3 originPos){

		int tileIndex = int.Parse (tileType);

		//creates a new tile and makes reference that tile
		TileScript newTile = Instantiate(tilePrefabs[tileIndex]).GetComponent<TileScript>();

		// uses newTile variable to change position

		newTile.Setup (new Point (x, y), new Vector3(originPos.x + (TileSize * x), originPos.y - (TileSize * y), 0));
		return newTile.transform.position;
	}





	// method to read txt file of numbers that determines the tile to place 
	private string[] ReadLevelText(){

		TextAsset bindData = Resources.Load ("Level") as TextAsset;
		String data = bindData.text.Replace (Environment.NewLine, string.Empty);
		return data.Split ('-'); // splits line of texts by -
	
	}




}
