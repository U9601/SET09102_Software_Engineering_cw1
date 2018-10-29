using Software_Engineering_cw1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

public class MethodsList
{
    public static ObservableCollection<SirList> sirList = new ObservableCollection<SirList>();
    public static ObservableCollection<MentionsList> mentionsList = new ObservableCollection<MentionsList>();
    public static ObservableCollection<TrendingList> trendingsList = new ObservableCollection<TrendingList>();

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

    public List<string> smsAbbreviations(List<string> inputBody)
    {
        MethodsList readingFromExcel = new MethodsList();
        ArrayList textWords = readingFromExcel.readFromExcel();
        ArrayList splicedTextWords = readingFromExcel.spliceAnArray(textWords);
        string changeAbbreviation = null;
        bool allWordsChanged = false;

        for (int j = 0; j <= inputBody.Count; j++)
        {
            for (int i = 0; i <= splicedTextWords.Count; i++)
            {
                if (i >= splicedTextWords.Count)
                {
                    i = 0;
                    if (j == inputBody.Count - 1)
                    {
                        allWordsChanged = true;
                    }
                    else
                    {
                        j++;
                    }
                }
                if (allWordsChanged == false)
                {
                    if (inputBody[j].ToString().Equals(splicedTextWords[i].ToString()))
                    {
                        changeAbbreviation = splicedTextWords[i + 1].ToString();
                        changeAbbreviation = "<" + changeAbbreviation + ">";
                        inputBody.Insert(j + 1, changeAbbreviation);

                        j++;
                        i = -1;
                    }


                    if (j >= inputBody.Count)
                    {
                        break;
                    }
                }
                if (allWordsChanged == true)
                {
                    break;
                }
            }
            if (allWordsChanged == true)
            {
                break;
            }
        }
        return inputBody;

    }

    public List<string> urlQuarantine(List<string> inputBody)
    {
        int counter = inputBody.Count;
        for (int i = 0; i <= inputBody.Count; i++)
        {
            if (counter == i)
            {
                break;
            }

            if (inputBody[i].Contains("https://") || inputBody[i].Contains("http://") || inputBody[i].Contains("www."))
            {
                string url = inputBody[i].ToString();
                url = "<" + "URL Quarantined" + ">";
                inputBody.Insert(i + 1, url);
                inputBody.RemoveAt(i);
            }
        }
        return inputBody;
    }

    public static void addSirList(SirList newSirList)
    {
        sirList.Add(newSirList);
    }
    
    public static void addMentionsList(MentionsList newMentionsList)
    {
        mentionsList.Add(newMentionsList);
    }

    public static void addTrendingsList(TrendingList newTrendingList)
    {
        trendingsList.Add(newTrendingList);
    }

    public static ObservableCollection<SirList> getDataSirList()
    {
        return sirList;

    }
    public static ObservableCollection<MentionsList> getDataMentionsList()
    {
        return mentionsList;

    }
    public static ObservableCollection<TrendingList> getDataTrendingList()
    {
        return trendingsList;

    }

}

