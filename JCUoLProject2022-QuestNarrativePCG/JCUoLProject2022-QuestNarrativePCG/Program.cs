// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
ConsoleQuestMgr CQM = new ConsoleQuestMgr();

// WILD, WILD IDEA - player has advisors that can help the player decude what to do if they are uncertain - each advisor represents a motivation, though which one is which is left a mystery

class ConsoleElements
{
    public void consoleOutput(string userOut)
    {
        Console.WriteLine(userOut);
    }

    public string consoleYN()
    {
        Console.WriteLine("please enter y/n");
        return Console.ReadLine();
    }
    //public void consoleInput()        //not uncommented till I have a use for it
    //{
    //}

}
 
class StaticNarrative
{
    string introStr = "You are the ruler of a long forgotten Kingdom. Your people are struggling through times of great strife, \nand they look to your for guidance and help. If you are unable to offer this, \nthe people will simply replace you. But a society cannot be run from goodwill and happiness. \nTough choices must be made. Give assistance to your people where possible, but be wary of \nyour stock running dry, or your leadership will wither and die";

    public string[] introResources ()   // 0 = Intro; 1 = __; 2 = __; 3 = __; 4 = __;
    {
        string[] res = new string[5];
        res[0] = introStr;
        return res;
    }
}

/// <summary>
/// This below is just a space to work out what the fuck im doing 
/// to code my project to work because fuck me I need a plan.
/// 
/// </summary>
/// 

// --REMEMBER!!! Quests are more REQUESTS to the KING of a country from its citizens. 
// --The quests need to be tailored to that purpose as best they can.

/* 

Quest{
    Seed: // Each quest needs its own seed, as they are all their own entity, if that makes sense
    noOfParts // random - defined by seed.
    QuestPart(seed){
        
        
        DynamicNarrative(seed){
            
            
        }
    }

}


*/





class DynamicNarrative      // likely have all my NARRATIVE generation in here
{
    Random r = new Random();
    int seed = 1255367;
    List<string> goodOpeners = new List<string>() { "Good day", "I am honoured to be in your presence", "It is a privelage to speak with you", "Salutations" };

    List<string> goodLeaderTitles = new List<string>() { "My Liege", "Your Greatness", "Mighty One", "Great One"};

    List<string> neutralOpeners = new List<string>() { "Hello", "Greetings", "How goes it" };

    List<string> badOpeners = new List<string>() { "What has failed you this time", "May your days be few" };

    List<string> badLeaderTitles = new List<string>() { "Most incompetent one", "Your Ungreatness", "Cretin", "Heretic" };

    ConsoleElements console = new ConsoleElements();


    public string imLazyw() // this needs to be temporary, items should be made in the quest and then passed to the "dn" (dynamic narrative)
    {
        seed = r.Next(111111,999999);
        Item it = new Item(seed); 

        character ch = new character(seed);
        return narrStart(ch, it, "get");
    }

    /// <summary>
    /// If were going detailed, then the character details should have some influence. 
    /// 
    /// For now, just make it work.
    /// </summary>

    string Opener()    // "greetings, your majesty" "good day, your magnificence" just stuff to say to a great leader. 
    {
        string opener = "";
        if (seed % 2 == 1)
        {
            opener = opener + goodLeaderTitles[seed % goodLeaderTitles.Count];
            opener = opener + " ";
            opener = opener + goodOpeners[seed % goodOpeners.Count];
            opener = opener + ".";
        }
        else
        {
            opener = opener + goodOpeners[seed % goodOpeners.Count];
            opener = opener + " ";
            opener = opener + goodLeaderTitles[seed % goodLeaderTitles.Count];
            opener = opener + ".";
        }
        return opener;
    }
    string problemsGiverString(QuestPart questPart) // 
    {
        /*
        
        funding something
        money towards development
        increase taxes




        people have different temperaments, different emotional states - angry, calm, indifferent etc...

        */

        string tasktype = "get";
        string taskItem = "boot";
        switch (tasktype) {
            case null:
                break;

            case "get":
                // need character class built to properly implement
                string characterTemperament = "";



                /*              // this entire section is also superfluous for now
                switch (characterTemperament)
                {
                    case null: // if no response, treat as indifferent temperament.
                        break;
                    case "angry":
                        break;
                }
                */
                break;
        
        
        }
        return " ";
    }

    public string narrStart(character cha, Item item, string narrType)
    {

        List<string> charIntro = new List<string>() { "My name is " + cha.Name + ". ", "Allow me to introduce myself. I am " + cha.Name +  ". ", "I am " + cha.Name + ". ", "the " + cha.gender + " infront of you is " + cha.Name + ". " };
        string content = "";
        if (seed > 500000)
            content = Opener();
        content = content + charIntro[seed % charIntro.Count];
        switch (narrType)
        {
            case "get":
                content = content + narrGet(item, cha);
                break;
        }
        return content;
    }
    public string narrGet(Item item)
    {
        // FORMAL
        List<string> start = new List<string>() {"I would be most appreciative if you", "Could you", "it is of the utmost importance that you", "I formally request that you" };
        List<string> start2 = new List<string>() { "spare some resources to help me find", "fund my venture to find", "help me to find" };



        string content = start[seed % start.Count] + " " + start2[seed % start2.Count] + " " + item.referAs + " " + item.Name;

        //console.consoleOutput(content);

        return content;
    }

    public string narrGet(Item item, character cha)
    {
        List<string> start = new List<string>() { "I would be most appreciative if you", "Could you", "it is of the utmost importance that you", "I formally request that you" };
        List<string> start2 = new List<string>() { "spare some resources to help me find", "fund my venture to find", "help me to find", "fund us to find", "allow me to find" };
        string content = "";
        // FORMAL
        if ((seed / 6) % 2 > 3)
        {

            //content = content + " " + charIntro[seed % charIntro.Count] + " "+ cha.Name;

        }
            
        content = content + start[seed % start.Count] + " " + start2[seed % start2.Count] + " " + item.referAs + " " + item.Name;

        //console.consoleOutput(content);

        return content;
    }


    string narrKill()
    {
        return "";
    }

}






class Item
{
    // all same IDs
    public string Name;
    public string Plural;
    public string referAs; // how the dynamicNarrative refers to the item

    // random qualities
    public bool special;
    string specialQuality; // ["cursed","holy","dull"]

    public int moneyCost;

    public string[] ItemNames = new string[] {  "boots", "sword" , "book" , "food", "drink" , "bow" , "necklace" , "ring" , "trinket" };
    string[] ItemPlurals = new string[] {"boots", "swords", "books", "food", "drinks", "bows", "necklaces", "rings", "trinkets", };
    
    string[] referList = new string[] {"my", "the", "a" };

    string[] ItemQualities = new string[] { "cursed", "holy", "dull", "broken" };
    public Item(int seed)
    {
        Name = ItemNames[seed % ItemNames.Length];
        Plural = ItemPlurals[seed % ItemPlurals.Length];
        referAs = referList[seed % referList.Length];

        special = false;
        specialQuality = "dull";
        string f = ItemQualities[seed * 59 % ItemQualities.Length];
        int tempcost = 0;
        if (special)
            tempcost = 10;
        switch (f)
        {
            case "dull":
                tempcost = tempcost * 1;
                break;
            case "cursed":
                tempcost = tempcost * 3;
                break;
            case "holy":
                tempcost = tempcost * 4;
                break;
            case "broken":
                tempcost = tempcost - 10;
                break;
        }

        switch (Name)
        {
            case "boots":
                tempcost = tempcost + 20;
                break;
            case "sword":
                tempcost = tempcost + 30;
                break;
            case "book":
                tempcost = tempcost + 20;
                break;
            case "food":
                tempcost = tempcost + 10;
                break;
            case "drink":
                tempcost = tempcost + 10;
                break;
            case "bow":
                tempcost = tempcost + 40;
                break;
            case "necklace":
                tempcost = tempcost + 50;
                break;
            case "ring":
                tempcost = tempcost + 40;
                break;
            case "trinket":
                tempcost = tempcost + 30;
                break;
        }

        moneyCost = tempcost;
    }
}


class character
{
    public string Name;
    public string gender;      // [male, female, other]
    List<string> relations;// List of other characters
    public string motivation; // [political advancement, save someone, revenge, better life, madness] // note - madness means the person is insane
    public string job;// Necessary???
    public string temperament; // [angry, content, happy] IDFK

    string[] MaleNames = new string[] {"John", "Adam", "William", "James", "Oliver","Connor", "Gareth", "Jeremy", "Christian", "Alexander", "Timothy" };
    string[] FemaleNames = new string[] {"Anna", "Mary", "Gillian", "Cecily", "Lilith", "Gertrude", "Alexandra", "Jasmine", "Jezebelle", "Susanna", "Alice" };
    string[] SurNames = new string[] {"" };

    string[] temperamentList = new string[] { "angry", "content" , "happy", "insane"};
    string[] motivationList = new string[] { "political", "revenge", "love", "religion", "pride" };
    string[] jobList = new string[] { "Woodcutter", "Builder", "Engineer", "Wastrel", "Member of the Leaders Court", "Artist", "Soldier", "Jailor", "Jester" }; 
    public character(int seed)
    {

        if ((seed / 734) % 2 == 1)
            gender = "man";
        else
            gender = "woman";
        if (gender == "man")
        {
            Name = MaleNames[seed % MaleNames.Length];
        }
        else
        {
            Name = FemaleNames[seed % FemaleNames.Length];
        }
        motivation = motivationList[seed % motivationList.Length];
        job = jobList[seed % jobList.Length];
        temperament = temperamentList[seed % temperamentList.Length];


        relations = new List<string>(); // Will be added to during character use
    }
}

class ConsoleQuestMgr{
    public ConsoleQuestMgr()
    {
        //<temp>
        DynamicNarrative dn = new DynamicNarrative();
        Console.WriteLine(dn.imLazyw());
        //</temp>

        List<Quest> quests = new List<Quest>();
        Quest quest = new Quest();
        
        
        
        
        quests.Add(quest);


        int noofparts = 4;

        int i = 0;
        
        if (i < noofparts)
        {
            // do next questpart
        }
        else
        {
            // do final questpart
        }


    }
}

class Quest // quest structure - have quest parts which can be generated by the algorithms or by a person. Should allow for more uniform quest generation for either process.
{ 
    // Characters are included in quest
    // Items are included in questparts
    Random r = new Random();

    public List<character> chars = new List<character>();
    public List<Item> items = new List<Item>();

    List<QuestPart> questParts = new List<QuestPart>();

    int noOfParts = 0;

    int seed;

    public Quest()
    {
        ConsoleElements ce = new ConsoleElements();
        seed = r.Next(111111, 999999);
        noOfParts = seed % 3 + 2;
        QuestStart qStart = new QuestStart(seed);
        questParts.Add(qStart);
        chars.Add(qStart.questChar);
        items.Add(qStart.items[0]);
        noOfParts--;
        Console.WriteLine("noOfParts: "+noOfParts);
        int modSeed = seed;
        for (int i = 0 ; i < noOfParts; i++)
        {
            Console.WriteLine("i = " + i + ", noOfParts = " + noOfParts);
            if(i != noOfParts - 1)
            {
                QuestPart qPart = new QuestPart();
                modSeed = modSeed / 3;
                qPart.QuestSeedStuff(modSeed);
                qPart.SetupNarrative(items[0], chars[0], "get");
                questParts.Add(qPart);
                ce.consoleOutput(qPart.NarrativeJournal);
            }
            else
            {
                QuestEnd qEnd = new QuestEnd(modSeed/3);
                questParts.Add(qEnd);
            }
            
            string yn = "";
            while (yn != "n" && yn != "y")
                yn = ce.consoleYN();
            if (yn == "y")
            {
                Player.PlayerMoney = Player.PlayerMoney + 1;

                //Player.PlayerMoney = questParts[questParts.Count].items[0].moneyCost;
                //if (questParts[questParts.Count -1].items[0].moneyCost > 0)
                //{
                //    Player.cityHappiness = Player.cityHappiness + questParts[questParts.Count - 1].items[0].moneyCost;
                //}
            }
            else
            {
                if (questParts[questParts.Count - 1].items[0].moneyCost > 0)
                {
                    Player.cityHappiness = Player.cityHappiness - questParts[questParts.Count - 1].items[0].moneyCost;
                }
            }
        }
    }




}
class QuestPart     // quests are made up of multiple questparts
{
    /*
    items
    dynamic narrative
     
     
    */
    character questChar;

    protected DynamicNarrative dn = new DynamicNarrative();

    public List<Item> items = new List<Item>();

    public string NarrativeJournal = "";

    public int seed;

    public QuestPart()
    {
        items = new List<Item>() { };
    }

    public void QuestSeedStuff(int passedseed) {
        seed = passedseed;
        Item i = new Item(seed);
        items.Add(i);
        questChar = new character(seed);
    }

    public string SetupNarrative(Item item, character person, string questType)
    {
        NarrativeJournal = dn.narrStart(person, item, questType);
        return NarrativeJournal;
    }




}
class QuestStart : QuestPart // should be first part of quest
{
    public character questChar;
    public QuestStart(int seed)
    {

        items = new List<Item>() { }; 
        Item i = new Item(seed);
        items.Add(i);
        questChar = new character(seed);
        //SetupNarrative(items[0]);

    }
}
class QuestEnd : QuestPart // should be last part of quest
{
    public QuestEnd(int seed)
    {
        items = new List<Item>() { };


    }
}
class DNDataReturn {
    public string questNarrative;
}


class Player
{
    public static int PlayerMoney = 200;
    public static int cityHappiness = 100;
}