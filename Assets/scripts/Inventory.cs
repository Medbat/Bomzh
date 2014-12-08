using System;
using System.IO;
using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour
{

    private FileStream fs;
    private StreamWriter sw;
    private StreamReader sr;

    // Vector3: x - бутылки, y - еда, z - деньги

    // Добавляет к текущему инвентарю новые элементы
    public void Save(Vector3 v)
    {
        var save = Load();
        fs = new FileStream(@"d:\save.txt", FileMode.Create);
        sw = new StreamWriter(fs);
        save += v;
        sw.WriteLine((int)save.x);
        sw.WriteLine((int)save.y);
        sw.WriteLine((int)save.z);
        sw.Close();
        fs.Close();
    }

    // получает текущий инвентарь
    public Vector3 Load()
    {
        fs = new FileStream(@"d:\save.txt", FileMode.Open);
        sr = new StreamReader(fs);
        var v = new Vector3();
        float.TryParse(sr.ReadLine(), out v.x);
        float.TryParse(sr.ReadLine(), out v.y);
        float.TryParse(sr.ReadLine(), out v.z);
        sr.Close();
        fs.Close();
        return v;
    }
	
	private void abc()
	{
		int a = 3+1;
	}

}
