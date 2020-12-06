using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using System;
using System.Text.RegularExpressions;

public class Problema4 : MonoBehaviour
{
    private const string validaCuatroDigitos = @"\d{4}";
    public TextMeshProUGUI texto;
    public Dictionary<string,string> ClavesPasword =new Dictionary<string, string>();
    string path = "Assets/Resources/Data/input5.txt";
    public List<string> PasaportesValidos = new List<string>();
    string[] claves = { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid", "cid" };
    int cuenta = 0;
    // Start is called before the first frame update
    void Start()
    {
        ClavesPasword.Add("byr", "1990");
        ClavesPasword.Add("iyr", "2017");
        ClavesPasword.Add("eyr", "1990");
        ClavesPasword.Add("hgt", "183cm");
        ClavesPasword.Add("hcl", "#fffffd");
        ClavesPasword.Add("ecl", "brn");
        ClavesPasword.Add("pid", "860033327");
        ClavesPasword.Add("cid", "147");

        //No importa el contenido sino las que tengan todas las claves o todas menos cid
        string archivo = "";
        /*
        foreach (string line in File.ReadLines(path))
        {
            if(line!= Environment.NewLine)
            {
              
                Pasaportes.Add(line);
            }
            if(line==" ")
            {
                print("Linea");
            }
            archivo += line;
            texto.text += line + "\n";
            print(line);

        }*/
        archivo = File.ReadAllText(path);
        string[] Aux=archivo.Split(new string[] { Environment.NewLine}, StringSplitOptions.None);

        string[] Years = { "adsas", "1919", "2005", "19999", "1978","2023","2009","2020","2015","2035","2021" };


        /*
                string[] Alturas = { "178cm", "165in", "as", "12", "154cm", "69in" };
                for (int i = 0; i < Alturas.Length; i++)
                {
                    print(Alturas[i] + "es " + ValidaAltura(Alturas[i]));

                }*/
        /*
        string[] Colores = { "#866857", "#341e13", "#efcc98", "12", "#efcc98123123", "69in" };
        for (int i = 0; i < Colores.Length; i++)
        {
            print(Colores[i] + "es " + ValidaColor(Colores[i]));

        }
        string[] ColoresOjos = { "dne", "oth", "hzl", "12", "#efcc98123123", "69in" };
        for (int i = 0; i < ColoresOjos.Length; i++)
        {
            print(ColoresOjos[i] + "es " + ValidaColorOjo(ColoresOjos[i]));

        }*/
        /*
        string[] PasswordId = { "64053944","123456789", "1234567890","12345","a12323" };
        for (int i = 0; i < PasswordId.Length; i++)
        {
            print(PasswordId[i] + "es " + ValidaPasswordID(PasswordId[i]));

        }*/
        Ejercicio2(Aux);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
   void Ejercicio1(string[] Aux)
    {
        int cuentaValidos = 0;
        for (int i = 0; i < Aux.Length; i++)
        {
            int cont = 0;
            bool valido = false;
            for (int j = 0; j < claves.Length; j++)
            {
                if (Aux[i].Contains(claves[j]))
                {
                    cont++;
                }
            }

            //Si tiene 8 es valido
            //Si tiene 7 podemos verificar que el que falta es cid


            if (cont == 7)
            {
                if (!Aux[i].Contains("cid"))
                {
                    valido = true;
                }
            }
            if (cont == 8)
            {
                valido = true;
            }



            if (valido)
            {
                cuentaValidos++;
                
            }
            texto.text += Aux[i] + "\n" + "Contiene" + cont + " claves" + " luego es " + valido + " van " + cuentaValidos + "\n\n";
            print(i + "contiene" + cont + " claves" + " luego es " + valido);
        }
        print("El numero de validos es" + cuentaValidos);

        //Todos los validados

    }


    void Ejercicio2(string[] Aux)
    {

      
        for (int i = 0; i < Aux.Length; i++)
        {
            int cont = 0;
            bool valido = false;
            for (int j = 0; j < claves.Length; j++)
            {
                if (Aux[i].Contains(claves[j]))
                {
                    cont++;
                }
            }

            //Si tiene 8 es valido
            //Si tiene 7 podemos verificar que el que falta es cid


            if (cont == 7)
            {
                if (!Aux[i].Contains("cid"))
                {
                    valido = true;
                }
            }
            if (cont == 8)
            {
                valido = true;
            }



            if (valido)
            {
             
                PasaportesValidos.Add(Aux[i]);
            }
          
        }

        
        //Tiene los validos
        int verificados = 0;
        foreach(string p in PasaportesValidos)
        {
           
            cuenta = 0;
            string[] Bloques = p.Split(' ');
            int numeroKeys = 0;
            string mensaje = "";
            for (int i = 0; i < Bloques.Length; i++)
            {
                string key = Bloques[i].Split(':')[0];
                string valor = Bloques[i].Split(':')[1];
                numeroKeys++;
                print(key + " = " + valor + " num keys " + numeroKeys);

                mensaje= ValidaTodo(key, valor);
            }
            if (numeroKeys == cuenta)
            {
                print("Esta verificado");
                texto.text +="<color=green> Verificado"+ p + mensaje + "</color>\n";
                verificados++;
            }
            else
            {
                print("No verificado");
                texto.text += "<color=red>"+p + mensaje+ " </color>\n";
                
            }
            print("Cuenta" + cuenta);
        }
       

        print("Todos los verficidados" + verificados);
    }

   


        bool ValidaCumple(string year ,out string mensanje) {
        mensanje = "";
        // -four digits; at least 1920 and at most 2002.
        Regex regex = new Regex(validaCuatroDigitos);
        if (regex.IsMatch(year))
        {
          
            if (int.Parse(year) >= 1920 && int.Parse(year) <= 2002)
            {
                return true;
            }
        }
        else
        {
            mensanje = "Formato de año invalido";
            return false;
        }
      
        return false;
        
    }
    bool ValidaIssue(string year, out string mensanje)
    {
        mensanje = "";
        // four digits; at least 2010 and at most 2020.
        Regex regex = new Regex(validaCuatroDigitos);
        if (regex.IsMatch(year))
        {
            if (int.Parse(year) >= 2010 && int.Parse(year) <= 2020)
            {
                return true;
            }
        }
        else
        {
            mensanje = "Issue invalido";
            return false;
        }
        print("Falla Issue");
        return false;
    }
    bool ValidaExpiracion(string year)
    {
        //four digits; at least 2020 and at most 2030.   
        return ValidaYear(year, 2020, 2030);
  

    }
    bool ValidaAltura(string height, out string mensanje)
    {
        mensanje = "";
        Regex regex = new Regex(@"^[0-9]{3}[cm]{2}$");
        if (regex.IsMatch(height))
        {
            string num = height.Remove(height.Length-2, 2);
            print("numero" + num);
            if(int.Parse(num) >=150 && int.Parse(num) <= 193)
            {
                return true;
            }
        }
        else
        {
            Regex regex2 = new Regex(@"^[0-9]{2}[in]{2}$");
            if (regex2.IsMatch(height))
            {
                string num = height.Remove(height.Length - 2, 2);
                if (int.Parse(num) >= 59 && int.Parse(num) <= 76)
                {
                    return true;
                }
            }
        }

        mensanje = "Falla altura";
        //a number followed by either cm or in:
        //If cm, the number must be at least 150 and at most 193.
        //If in, the number must be at least 59 and at most 76.
        return false;
    }
    bool ValidaColor(string color, out string mensanje)
    {
        mensanje = "";
        Regex regex = new Regex(@"#[0-9a-f]{6}");

        if (regex.IsMatch(color))
        {
            return true;
        }
        mensanje = "Falla color hexa";
        
        // a # followed by exactly six characters 0-9 or a-f.
        return false;
    }
    bool ValidaColorOjo(string ojo, out string mensanje)
    {
        mensanje = "";
        if (ojo=="amb"|| ojo == "blu" || ojo == "brn"|| ojo == "gry"|| ojo == "grn"|| ojo=="hzl"|| ojo == "oth")
        {
            return true;
        }
        //exactly one of: amb blu brn gry grn hzl oth.
        mensanje = "Falla color ojo";
        return false;
    }
    bool ValidaPasswordID(string pass, out string mensanje)
    {
        mensanje = "";
        //    a nine-digit number, including leading zeroes.
        Regex regex3 = new Regex(@"\d{9}");
        if (regex3.IsMatch(pass))
        {
            return true;
        }
        mensanje = "Falla pasword";
        return false;
    }
    bool ValidaYear(string year,int YearInferior,int YearSuperior)
    {
        Regex regex = new Regex(validaCuatroDigitos);
        if (regex.IsMatch(year))
        {
            if (int.Parse(year) >= YearInferior && int.Parse(year) <= YearSuperior)
            {
                return true;
            }
        }
        else
        {
            print("Falla Año");
            return false;
        }
        print("Falla Año");
        return false;
    }
    string ValidaTodo(string key, string valor)
    {
        string mensaje = "";
        if (key == "byr")
        {

            if (!ValidaCumple(valor, out mensaje))
            {

                return mensaje;
            }
        }
        if (key == "iyr")
        {
            if (!ValidaIssue(valor, out mensaje))
            {
                return mensaje;
            }
        }
        if (key == "eyr")
        {
            if (!ValidaExpiracion(valor))
            {
                mensaje = "Falla expiracion";
                return mensaje;
            }
        }
        if (key == "hgt")
        {
            if (!ValidaAltura(valor, out mensaje))
            {
                return mensaje;
            }
        }
        if (key == "hcl")
        {
            if (!ValidaColor(valor, out mensaje))
            {
                return mensaje;
            }

        }
        if (key == "ecl")
        {
            if (!ValidaColorOjo(valor, out mensaje))
            {
                return mensaje;
            }
        }
        if (key == "pid")
        {
            if (!ValidaPasswordID(valor, out mensaje))
            {
                return mensaje;
            }
        }
      cuenta++;
        return mensaje;
    }
}
