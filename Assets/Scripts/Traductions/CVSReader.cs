using UnityEngine;
using System.Text;
using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;
public enum CVSType { ShortTraduction }
enum Idioma {Español, Ingles }
public class CVSReader : MonoBehaviour
{
    public Image flagImage;
    public List<Sprite> flags;
    public int language = 0;
    public TextAsset shortTraduction;
    public TextAsset longTraduction;

    public static CVSReader instance;
    private void Awake()
    {
        instance = this;
    }
    private void OnEnable()
    {
        TranslateMultipleStatictext();
        TranslateDynamicText();

        Flag();
    }
    public string FindCSV(string Id, CVSType cVSType)
    {
        TextAsset textAsset = FindExcel(cVSType);

        string[] lines = textAsset.text.Split('\n'); // Dividir por líneas

        int columnCount = 3; // Número de columnas por fila

        foreach (string line in lines)
        {
            string[] columns = SplitCSVLine(line); // Usar el método SplitCSVLine para dividir cada línea en columnas

            // Asegurarse de que la línea tenga el número correcto de columnas
            if (columns.Length != columnCount)
            {
                Debug.LogWarning("Invalid number of columns in line: " + line);
                continue;
            }

            if (Id == columns[0]) // El ID está en la primera columna
            {
                int languageColumn = 1 + language; // Columna del idioma
                if (languageColumn < columns.Length)
                {

                    return columns[languageColumn];
                }
                else
                {
                    Debug.LogWarning("Translation not found for language: " + language);
                    break;
                }
            }
        }

        Debug.LogWarning("ID not found: " + Id);
        return "Translation not found";
    }

    // Función para dividir cada línea del archivo CSV correctamente
    public string[] SplitCSVLine(string line)
    {
        var result = new List<string>();
        bool inQuotes = false;
        var current = new StringBuilder();

        foreach (char ch in line)
        {
            if (ch == '\"')
            {
                inQuotes = !inQuotes;
            }
            else if (ch == ',' && !inQuotes)
            {
                result.Add(current.ToString());
                current.Clear();
            }
            else
            {
                current.Append(ch);
            }
        }

        result.Add(current.ToString());

        return result.ToArray();
    }
    TextAsset FindExcel(CVSType cvs)
    {
        TextAsset textAsset = new TextAsset();
        switch (cvs)
        {
            case CVSType.ShortTraduction:
                textAsset = shortTraduction;
                break;
           

        }
        return textAsset;
    }
    public void TranslateMultipleStatictext()
    {
        TranslateText[] texts = Resources.FindObjectsOfTypeAll<TranslateText>();
        for (int i = 0; i < texts.Length; i++)
        {
            string translate = FindCSV(texts[i].cvsCode, texts[i].cvsType);
            texts[i].ChangeText(translate);
        }

    }

    public void TranslateDynamicText()
    {
        TranslateDynamic[] texts = Resources.FindObjectsOfTypeAll<TranslateDynamic>();
        for (int i = 0; i < texts.Length; i++)
        {
            if (texts[i].translate)
            {
                string translate = FindCSV(texts[i].id, texts[i].cvsType);
                texts[i].ChangeText(translate);
            }
        }
    }

    public string TranslateOneDynamicText(string cvsCode, CVSType cvsType)
    {
        string text = FindCSV(cvsCode, cvsType);
        return text;
    }


    public void ChangeLenguaje(int num)
    {
        language += num;

        if (language > 1)
        {
            language = 0;
        }
        else if (language < 0)
        {
            language = 1;
        }
        TranslateMultipleStatictext();
        TranslateDynamicText();

        Flag();
    }

    void Flag()
    {
        for (int i = 0; i < flags.Count; i++)
        {
            if (language == i)
            {
                flagImage.sprite = flags[i];
            }
        }
    }

}
