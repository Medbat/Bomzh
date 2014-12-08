using UnityEngine;
using System.Collections;

public class StoreScript : MonoBehaviour {

	//Одна бутылка 10 рублей
    //Одна еда 100 рублей
    //бутылки еда деньги
    
    public Inventory inv;
    public int width;
    public int height;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button2))
            Application.LoadLevel("MainScene");
        if (Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            var v = inv.Load();
            if (v.x != 0)
                inv.Save(new Vector3(-v.x, v.y, v.y + 10 * v.x));
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            var v = inv.Load();
            if (v.z > 99)
                inv.Save(new Vector3(v.x, v.y + (v.z+1) % 100, -((int)v.z / 100) * 100));
        }
        
    }
    void OnGUI()
    {
        GUI.TextField(new Rect(0, 0, 150, 50), "Бутылок :"+ inv.Load().x);
        GUI.TextField(new Rect(0, 100, 150, 50), "Еды :" + inv.Load().y);
        GUI.TextField(new Rect(0, 200, 150, 50), "Денег :" + inv.Load().z);

        if (GUI.Button(new Rect(Screen.width/2 - width/2, Screen.height/2 - 100, width, height),
            "Продать бутылки (Y)") || Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            var v = inv.Load();
            if (v.x !=0 )
                inv.Save(new Vector3(-v.x, v.y, v.y + 10*v.x));
        }
        if (GUI.Button(new Rect(Screen.width/2 - width/2, Screen.height/2 , width, height), "Купить еду (B)") || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            var v = inv.Load();
            if (v.z>99)
                inv.Save(new Vector3(v.x, v.y + (v.z+1)%100, -((int)v.z/100)*100));
        }
    }
}
