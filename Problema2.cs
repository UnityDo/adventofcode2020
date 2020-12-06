using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Problema2 : MonoBehaviour
{

    string path = "Assets/Resources/Data/input.txt";
    string archivo = "";
   public List<DataPassword> DataPasswords = new List<DataPassword>();
    string ejemplo = "1-3 a: abcde";

    [System.Serializable]
    public class DataPassword
    {
        public int min;
        public int max;
        public char letra;
        public string cadena;

        public override string ToString()
        {
            return min + "-" + max + " " + letra + ": " + cadena;
        }
    }

    // Start is called before the first frame update
    void Start()
    {


        
        foreach (string line in File.ReadLines(path))
        {
            DataPassword dataPassword = new DataPassword();
            string[] Cadenas = line.Split(' ');
            dataPassword.min = int.Parse(Cadenas[0].Split('-')[0]);
            dataPassword.max = int.Parse(Cadenas[0].Split('-')[1]);
            dataPassword.letra = Cadenas[1].ToCharArray()[0];
            dataPassword.cadena = Cadenas[2];
            DataPasswords.Add(dataPassword);
        }






        /*
        print(archivo);
      print("El pasdword es"+ EsCorrectoPassword(7, 8, 'z', "zzzzzzzzzzz"));
        int cuenta = 0;
        foreach(DataPassword d in DataPasswords)
        {
            if (EsCorrectoPassword(d.min, d.max, d.letra, d.cadena))
            {
                cuenta++;
            }
        }
        print("El numero de passwords correctos es " + cuenta);*/
      
        int cuenta = 0;
        foreach (DataPassword d in DataPasswords)
        {
            if (EsCorrectoPassword2(d.min, d.max, d.letra, d.cadena))
            {
                print(d.ToString());
                cuenta++;
            }
        }
        print("El numero de passwords correctos es " + cuenta);

        //print("Correcto" + EsCorrectoPassword2(3, 4, 'q', "qkfq"));
    }

    // Update is called once per frame

    void Update()
    {
        
    }
    bool EsCorrectoPassword(int minimo, int maximo, char letra, string cadena)
    {
        bool correcto = false;
        //primero
        if (cadena.Contains(letra.ToString()))
        {
            int coincidencias = 0;
            char[] letras = cadena.ToCharArray();
            foreach(char l in letras)
            {
                if (l == letra)
                {
                    coincidencias++;
                }
            }
            print("coinciden"+coincidencias);
            //Coincidencias esta comprendido entre minimo y maximo
            if(coincidencias>=minimo)
            {
                if (coincidencias <= maximo)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            //esta mal
            return false;
        }

        return correcto;
    }

    bool EsCorrectoPassword2(int index1, int index2,char letra, string cadena)
    {
        bool correcto = false;
        bool tieneLaprimera = false;
        bool tieneLasegunda = false;

        if (cadena.Contains(letra.ToString()))
        {
            print("tiene letra "+letra);
            if (cadena[index1 - 1] == letra) {
                print("tiene la primera");
                tieneLaprimera = true;
            }
            if (cadena[index2 - 1] == letra)
            {
                print("tiene la segunda");
                tieneLasegunda = true;
            }

           
            if (tieneLaprimera && tieneLasegunda)
            {
                if (cadena[index1 - 1] != cadena[index2 - 1])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (tieneLaprimera==false)
                {
                    if (tieneLasegunda == false)
                    {
                        return false;
                    }
                    else
                    {
                        //no tengo la primera pero si la segunda
                        if (cadena[index1 - 1] != cadena[index2 - 1])
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    //tengo la primera
                    if (cadena[index1 - 1] != cadena[index2 - 1])
                    {
                        return true;
                    }
                }
            }
          
        }

            return correcto;
    }
}
