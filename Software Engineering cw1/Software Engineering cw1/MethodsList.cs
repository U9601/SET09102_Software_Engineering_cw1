using Software_Engineering_cw1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Text;
public class MethodsList
{
    //All of the observable collections that hold each lists
    public static ObservableCollection<SirList> sirList = new ObservableCollection<SirList>();
    public static ObservableCollection<MentionsList> mentionsList = new ObservableCollection<MentionsList>();
    public static ObservableCollection<TrendingList> trendingsList = new ObservableCollection<TrendingList>();
    public static ObservableCollection<URLQuarantineList> urlQuarantineList = new ObservableCollection<URLQuarantineList>();

    //Read from excel and into an array list
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

    //splitting the returned Array list by \t for the cells and , so that LOL and <Laughing out Loud> arent in the same element
    //as each other
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

    // this method is for changing LOL in <Laughing out loud>
    public List<string> smsAbbreviations(List<string> inputBody)
    {
        MethodsList readingFromExcel = new MethodsList();
        ArrayList textWords = readingFromExcel.readFromExcel();
        ArrayList splicedTextWords = readingFromExcel.spliceAnArray(textWords);
        string changeAbbreviation = null;
        bool allWordsChanged = false;

        //i = input from user     j = list of abbreviations
        // I run a nested loop inside of a loop so that once i has been compleltey checked then
        //j will be restarted back to the begnning again and will compare the next i to the next j

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

    //used to change any urls in emails to URL Quarantined and add them to a list of Quarantine
    public List<string> urlQuarantine(List<string> inputBody)
    {
        int counter = inputBody.Count;
        for (int i = 0; i <= inputBody.Count; i++)
        {
            if (counter == i)
            {
                break;
            }
            //checks to see if any words contains this start meaning it is a URL
            if (inputBody[i].Contains("https://") || inputBody[i].Contains("http://") || inputBody[i].Contains("www."))
            {
                string url = inputBody[i].ToString();
                URLQuarantineList urlQuarantineData = new URLQuarantineList();
                urlQuarantineData.URL = url;
                urlQuarantineList.Add(urlQuarantineData);
                url = "<" + "URL Quarantined" + ">";
                inputBody.Insert(i + 1, url);
                inputBody.RemoveAt(i);
            }
        }
        return inputBody;
    }

    //deserializer for JSON which returns a list of json objects
    public List<JObject> jsonDeserializer(string file)
    {
        /* string json = File.ReadAllText(file);


        var obj = JsonConvert.DeserializeObject<List<JObject>>(json);
         return obj;
         */
         // setting up objects and file stream
        List<JObject> obj = new List<JObject>();
        using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
        using (StreamReader sr = new StreamReader(fs))
        using (JsonTextReader reader = new JsonTextReader(sr))
        {
            while (reader.Read())
            {

                if (reader.TokenType == JsonToken.StartObject)
                {
                    // Load each object from the stream and add it to a list of JSON objects
                    obj.Add(JsonSerializer.Create().Deserialize<JObject>(reader));
                   
                }

            }
            return obj;

        }     
    }
    //next 4 methods add data to their repsected observable collections
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
    public static void addURLQuaratineList(URLQuarantineList newURLQuarantine)
    {
        urlQuarantineList.Add(newURLQuarantine);
    }
    //next 4 methods return data to their repsected observable collections
    public static ObservableCollection<SirList> getDataSirList()
    {
        return sirList;

    }
    public static ObservableCollection<MentionsList> getDataMentionsList()
    {
        return mentionsList;

    }
    public static ObservableCollection<TrendingList> getDataTrendingsList()
    {
        return trendingsList;

    }

    public static ObservableCollection<URLQuarantineList> getDataQuaratineList()
    {
        return urlQuarantineList;

    }


}

