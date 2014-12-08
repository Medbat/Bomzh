using UnityEngine;
using System.Collections;

public class show_inv : MonoBehaviour
{
    public Inventory inventory;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        //inventory.Save(new Vector3(0,0,0));
        var a = inventory.Load();
        GUI.Box(new Rect(5, 5, 200, 100), "Бутылки: " + (int)a.x + "\nЕда: " + (int)a.y + "\nДеньги:" + (int)a.z);
    }
}
