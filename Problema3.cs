using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class Problema3 : MonoBehaviour
{
    public TextMeshProUGUI texto;
    string path = "Assets/Resources/Data/input2.txt";
    string path2 = "Assets/Resources/Data/input_ejemplo.txt";
    string archivo = "";
   public List<string> Mapa = new List<string>();
    public Posicion posicionActual;
    int fila, pos;
    List<string> MapaPinta = new List<string>();
   public int numeroArboles;
    [System.Serializable]
    public struct Posicion
    {
       public int idFila;
       public int idPosicion;
      public  char letra;
    }
    // Start is called before the first frame update
    void Start()
    {
        foreach (string line in File.ReadLines(path))
        {
            Mapa.Add(line);
            texto.text += line + "\n";
           
        }
        Mapa.Add(Mapa[Mapa.Count-1]);
        Mapa.Add(Mapa[Mapa.Count-1]);
        Mapa.Add(Mapa[Mapa.Count-1]);
        /*
         Right 1, down 1. 60
Right 3, down 1. (This is the slope you already checked.) 191
Right 5, down 1. 64
Right 7, down 1. 63
Right 1, down 2 32.*/
        StartCoroutine(MueveYPara2(1,2  ));
      
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            pos++;
            Mueve(fila, pos);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            pos--;
            Mueve(fila, pos);
        }else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            fila--;
            Mueve(fila, pos);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            fila++;
            Mueve(fila, pos);
        }*/
       
    }
    void Mueve(int idFila, int idPosicion)
    {

        posicionActual.idFila = idFila;
        posicionActual.idPosicion = idPosicion;
        posicionActual.letra= Mapa[idFila][idPosicion];

        MapaPinta.Clear();
        foreach(string s in Mapa)
        {
            MapaPinta.Add(s);
        }
        char[] Letras = MapaPinta[idFila].ToCharArray();
        Letras[idPosicion] = '@';
        MapaPinta[idFila] = Letras.ArrayToString();

        texto.text = "";
        foreach(string s in MapaPinta)
        {
            texto.text += s + "\n";
        }
        
    }

    void MueveYPinta(int idFila, int idPosicion)
    {

     


        char[] Letras = Mapa[idFila].ToCharArray();
      
        if (Letras[idPosicion] == '.')
        {
            Letras[idPosicion] = 'O';
        }else if (Letras[idPosicion] == '#')
            {
                Letras[idPosicion] = 'X';
            numeroArboles++;
            }
        Mapa[idFila] = Letras.ArrayToString();

        texto.text = "";
        foreach (string s in Mapa)
        {
            texto.text += s + "\n";
        }

    }
    IEnumerator MueveYPara()
    {
        int inicio = 0;
        int posincion = 0;
        while (inicio < Mapa.Count)
        {
           
            inicio++;


            if (posincion <= 27)
            {
                posincion += 3;
            }
            else
            {
                if (posincion == 28)
                {
                    posincion = 0;
                }else if (posincion == 29)
                {
                    posincion = 1;
                }else if (posincion == 30)
                {
                    posincion = 2;
                }
            }

           
            print("posicion es " + posincion + " lognitud" + Mapa[inicio].ToCharArray().Length);

            MueveYPinta(inicio, posincion);
            yield return null;
        }

        print("Numero de arboles" + numeroArboles);
    }
    IEnumerator MueveYPara2(int mueveD,int muevAbajo)
    {
        int inicio = 0;
        int posincion = 0;
        while (inicio < Mapa.Count)
        {

            inicio+=muevAbajo;


            if (posincion < Mapa[inicio].ToCharArray().Length -mueveD)
            {
                posincion += mueveD;
            }
            else
            {

                posincion = posincion - Mapa[inicio].ToCharArray().Length + mueveD;
                /*
                if (posincion == 28)
                {
                    posincion = 0;
                }
                else if (posincion == 29)
                {
                    posincion = 1;
                }
                else if (posincion == 30)
                {
                    posincion = 2;
                }*/
            }


            print("posicion es " + posincion + " lognitud" + Mapa[inicio].ToCharArray().Length);

            MueveYPinta(inicio, posincion);
            yield return null;
            texto.transform.position = new Vector2(texto.transform.position.x, texto.transform.position.y + 80f);

        }

        print("Numero de arboles" + numeroArboles);
    }
}
