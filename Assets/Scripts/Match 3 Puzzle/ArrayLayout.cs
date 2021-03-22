using UnityEngine;
using System.Collections;

[System.Serializable]
public class ArrayLayout  {

	[System.Serializable]
	public struct rowData{
		public bool[] row;
	}

    public Grid grid;
    public rowData[] rows = new rowData[6]; //Grid of 7 x 6
}
