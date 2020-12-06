using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Problema5 : MonoBehaviour
{
    string TarjetaEmbarque = "BBFFBBFRLL";
    string path = "Assets/Resources/Data/inputAvion.txt";
  public  List<float> IdAsientos = new List<float>();
    public List<string> Archivo = new List<string>();
    public string[,] Posicion = new string[128, 8];
    public TMPro.TextMeshProUGUI texto;
    //Front
    //Back
    //Left
    //Rigth
    //El avion tiene 128 filas de 0 al 128
    //La primera letra
    // Start is called before the first frame update
    class Asiento
    {
       public float min;
       public float max;
        public float columnaMin;
        public float columanMax;
        public override string ToString() {
            return "Min " + min + " Max " + max +"ColumMin"+columnaMin+" ColumnaMax"+columanMax;
        }
    
    }
    void Start()
    {
        //Analiza(TarjetaEmbarque);

        
        for (int i = 0; i < Posicion.GetLength(1); i++)
        {
            for (int j = 0; j < Posicion.GetLength(0); j++)
            {
                Posicion[j, i] = "X";

            }
           
        }
        foreach (string linea in File.ReadLines(path))
        {
            Archivo.Add(linea);
        }
        foreach(string s in Archivo)
        {
            Analiza(s);
        }
        for (int i = 0; i < Posicion.GetLength(1); i++)
        {
            for (int j = 0; j < Posicion.GetLength(0); j++)
            {
                if(Posicion[j, i] != "X") {
                    texto.text += " " + Posicion[j, i];
                }
                else{
                    texto.text += "<color=green>Libre</color>" ;
                }
            
            }
            texto.text += "\n";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Analiza(string tarjeta)
    {
        Asiento asiento = new Asiento();
        //Empieza en 0 127
        float minimo = 0;
        float maximo = 127;
        float colmin = 0;
        float colmax = 7;
        float valorfinal = 0;
        for (int i = 0; i < tarjeta.Length; i++)
        {
            char letra = tarjeta[i];
            if (letra == 'F')
            {
                asiento.min = Mathf.Min(minimo,maximo);
                asiento.max = Mathf.FloorToInt((minimo + maximo) / 2);            
                minimo = asiento.min;
                maximo = asiento.max;
                //te quedas con la mitad como maximo

                // minimo = Mathf.Min(asiento.max, Mathf.CeilToInt(minimo + maximo / 2));
                // maximo = Mathf.Max(asiento.min, minimo);


            }
            if (letra == 'B')
            {
              float media= (minimo + maximo) / 2;
                media += 0.3f;
                Debug.Log(media);
                asiento.min =Mathf.Max(minimo,Mathf.RoundToInt(media));
                asiento.max = maximo;

                minimo = asiento.min;
                maximo = asiento.max;
            }

            if (letra == 'L')
            {


                asiento.columnaMin = Mathf.Min(colmin, colmax);
                asiento.columanMax = Mathf.FloorToInt((colmin + colmax) / 2);
                colmin = asiento.columnaMin;
                colmax = asiento.columanMax;

            }
            if (letra == 'R')
            {
                float media = (colmin + colmax) / 2;
                media += 0.3f;
                Debug.Log(media);
                asiento.columnaMin = Mathf.Max(colmin, Mathf.RoundToInt(media));
                asiento.columanMax = colmax;

                colmin = asiento.columnaMin;
                colmax = asiento.columanMax;
            }
            print(asiento.ToString());
        }
        if (asiento.min == asiento.max)
        {

            print("Valor final" + asiento.min);
            valorfinal = asiento.min * 8;
        }
        if (asiento.columnaMin == asiento.columanMax)
        {

            print("Columna" + asiento.columnaMin);
            valorfinal += asiento.columnaMin;
        }
        print("ID final es" + valorfinal);
        IdAsientos.Add(valorfinal);
        Posicion[(int)asiento.min,(int) asiento.columnaMin] = tarjeta;
        // IdAsientos.Sort();
        //La siguiente letra indica la mitad de low o upper
        /*
                Start by considering the whole range, rows 0 through 127.
            F means to take the lower half, keeping rows 0 through 63.
            B means to take the upper half, keeping rows 32 through 63.
            F means to take the lower half, keeping rows 32 through 47.
                B means to take the upper half, keeping rows 40 through 47.
            B keeps rows 44 through 47.
            F keeps rows 44 through 45.
            The final F keeps the lower of the two, row 44.*/
        
        

    }
   
			

}
