using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public class Problema6 : MonoBehaviour
{

    //26 preguntas si o no de la A a la Z
    //respuestas duplicadas no cuentan
    // Start is called before the first frame update
    Dictionary<char, int> LetrasAparecen = new Dictionary<char, int>();
    string path = "Assets/Resources/Data/inputAduana.txt";
    string pathTest = "Assets/Resources/Data/inputAduanaTest.txt";
    public List<string> Archivo = new List<string>();
    public bool test;
    void Start()
    {
        RellenaDicionario();
        string archivo = "";
        if (test)
        {
            archivo = File.ReadAllText(pathTest);
        }
        else
        {
            archivo = File.ReadAllText(path);
        }
        
        string[] Aux = archivo.Split(new string[] { Environment.NewLine+Environment.NewLine }, StringSplitOptions.None);
        for (int i = 0; i < Aux.Length; i++)
        {      

            Archivo.Add(Aux[i].Replace("\r\n", "*"));
        }
        int todas = 0;
        for (int i = 0; i < Archivo.Count; i++)
        {
            //Solucion 1 todas+=   EvaluaLetras(i);

            todas += EvaluaLetrasRepetidas(i);
            


        }
        print("Todas es "+todas);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private string[] SplitStringByLineFeed(string inpString)
    {
        string[] locResult = Regex.Split(inpString, "[\r\n]+");
        return locResult;
    }
    void RellenaDicionario()
    {
        LetrasAparecen.Add('a', 0);
        LetrasAparecen.Add('b', 0);
        LetrasAparecen.Add('c', 0);
        LetrasAparecen.Add('d', 0);
        LetrasAparecen.Add('e', 0);
        LetrasAparecen.Add('f', 0);
        LetrasAparecen.Add('g', 0);
        LetrasAparecen.Add('h', 0);
        LetrasAparecen.Add('i', 0);
        LetrasAparecen.Add('j', 0);
        LetrasAparecen.Add('k', 0);
        LetrasAparecen.Add('l', 0);
        LetrasAparecen.Add('m', 0);
        LetrasAparecen.Add('n', 0);
        LetrasAparecen.Add('o', 0);
        LetrasAparecen.Add('p', 0);
        LetrasAparecen.Add('q', 0);
        LetrasAparecen.Add('r', 0);
        LetrasAparecen.Add('s', 0);
        LetrasAparecen.Add('t', 0);
        LetrasAparecen.Add('u', 0);
        LetrasAparecen.Add('v', 0);
        LetrasAparecen.Add('w', 0);
        LetrasAparecen.Add('x', 0);
        LetrasAparecen.Add('y', 0);
        LetrasAparecen.Add('z', 0);
    }
    void ReseteaDiccionario()
    {
        var list = new List<char>(LetrasAparecen.Keys);
        foreach (char c in list)
        {
            LetrasAparecen[c] = 0;
        }
    }
    int EvaluaLetras(int indice)
    {
        ReseteaDiccionario();
        for (int i = 0; i < Archivo[indice].Length; i++)
        {
            if (LetrasAparecen.ContainsKey(Archivo[indice][i]))
            {
                if (LetrasAparecen[Archivo[indice][i]] != 1)
                {
                    LetrasAparecen[Archivo[indice][i]] += 1;
                }

            }
        }
        int cont = 0;
        foreach (KeyValuePair<char, int> kvp in LetrasAparecen)
        {
            Debug.Log("La " + kvp.Key + " aparece " + kvp.Value);
            cont += kvp.Value;
        }
        Debug.Log("Tiene: " + cont);
        return cont;
    }
    int EvaluaLetrasRepetidas(int indice)
    {
        ReseteaDiccionario();
        int contcon = 0;
        int contsin = 0;
        int numGrupos = 1;
        if (Archivo[indice].Contains("*"))
        {
          
            for (int i = 0; i < Archivo[indice].Length; i++)
            {
                if (Archivo[indice][i] == '*')
                {
                    numGrupos++;
                }
              
                if (LetrasAparecen.ContainsKey(Archivo[indice][i]))
                {
                    
                        LetrasAparecen[Archivo[indice][i]] += 1;
                    

                }
            }
            contcon = 0;
            bool iguales = false;
            foreach (KeyValuePair<char, int> kvp in LetrasAparecen)
            {

                Debug.Log("La " + kvp.Key + " aparece " + kvp.Value);
                if (kvp.Value == 1)
                {
                    iguales = true;

                }
                else
                {
                    iguales = false;
                    break;
                }
                
                
            }
            if (!iguales)
            {
                print("no iguales");
                foreach (KeyValuePair<char, int> kvp in LetrasAparecen)
                {
                 
                    //igual al numero de grupos
                    if (kvp.Value > 1 && kvp.Value== numGrupos)
                    {
                        contcon += 1;

                    }

                }
            }
            print("Varios bloques " + contcon);
        }
        else
        {
            for (int i = 0; i < Archivo[indice].Length; i++)
            {
                if (LetrasAparecen.ContainsKey(Archivo[indice][i]))
                {
                    if (LetrasAparecen[Archivo[indice][i]] != 1)
                    {
                        LetrasAparecen[Archivo[indice][i]] += 1;
                    }

                }
            }
            contsin = 0;
            foreach (KeyValuePair<char, int> kvp in LetrasAparecen)
            {
            
                contsin += kvp.Value;
            }
            print("Un bloque " + contsin);
        }
       
        
        return contcon+contsin;
    }
}
