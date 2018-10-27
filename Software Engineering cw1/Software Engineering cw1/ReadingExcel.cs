﻿using Software_Engineering_cw1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

public class ReadingExcel
{
    private static ObservableCollection<SirList> sirList = new ObservableCollection<SirList>();

    public ArrayList readFromExcel()
    {
        ArrayList readingfromExcel = new ArrayList();
        using (StreamReader reader = new StreamReader("textwords.csv"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                readingfromExcel.Add(line);

            }
            if (readingfromExcel != null)
            {
                return readingfromExcel;
            }
            else
            {
                return null;
            }
        }
    }

    public ArrayList spliceAnArray(ArrayList textWords)
    {
        ArrayList splicedDataArray = new ArrayList();

        string stringArray = string.Join("\t", (string[])textWords.ToArray(Type.GetType("System.String")));
        stringArray = string.Join(",", (string[])textWords.ToArray(Type.GetType("System.String")));

        string[] words = stringArray.Split('\t');
        words = stringArray.Split(',');

        for (int i = 0; i <= words.Length - 1; i++)
        {
            if (words[i] != "")
            {
                splicedDataArray.Add(words[i]);
            }
        }

        if (splicedDataArray != null)
        {
            return splicedDataArray;
        }
        else
        {
            return null;
        }

    }

    public static void add(SirList newSirList)
    {
        sirList.Add(newSirList);
    }

    public static ObservableCollection<SirList> getData()
    {
        return sirList;

    }

}

