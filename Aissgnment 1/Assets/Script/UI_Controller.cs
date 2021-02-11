using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    public GameObject Panel_Character;
    public GameObject Panel_CG;


    //Dice
    public Text FirstDice;
    public Text SecondDice;
    public Text ThirdDice;
    public Text ForthDice;
    public Text FifthDice;
    private int SumOfRoll;
    public int counterDice;
    int Digi_Dice;
    List<int> currentRoll;
    //State
    public PlayerState playerState;
    public int NumberOfAbilities;
    bool isRoll;
    //public Text inputField;
    public Dropdown dd_Races;
    public Dropdown dd_Classes;
    public Text Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma;
    public Text speedWalking, Hit_Points, Experience_Points, Armor_Class, Alignment,MAX_Experience_Point;
    public Text Str_modifiers, Dex_modifiers, Con_modifiers, Int_modifiers, Wis_modifiers, Cha_modifiers;
    public InputField inputCharacterName;
    public InputField JsonOutputText;
    // Start is called before the first frame update

    void Start()
    {
        unuse_abilitie();

    }

    // Update is called once per frame
    void Update()
    {
    }
    List<string> Classes = new List<string>()
    {
        "Barbarian",
        "Bard",
        "Cleric",
        "Druid",
        "Fighter",
        "Monk",
        "Paladin",
        "Ranger",
        "Rogue",
        "Sorcerer",
        "Warlock",
        "Wizard"
    };

    List<string> Races = new List<string>()
    {
        "Dragonborn",
        "Dwarf",
        "Elf",
        "Gnome",
        "Half_Elf",
        "Half_Ore",
        "Halfing",
        "Human",
        "Tiefling"
    };
    void Awake()
    {

        Panel_CG = GameObject.Find("Panel_CG");
        Panel_Character = GameObject.Find("Panel_Character");
        dd_Races = GameObject.Find("dd_Races").GetComponent<Dropdown>();
        dd_Classes = GameObject.Find("dd_Classes").GetComponent<Dropdown>();
        dd_Races.AddOptions(Races);
        dd_Classes.AddOptions(Classes);
        FirstDice = GameObject.Find("FirstDice").GetComponent<Text>();
        SecondDice = GameObject.Find("SecondDice").GetComponent<Text>();
        ThirdDice = GameObject.Find("ThridDice").GetComponent<Text>();
        ForthDice = GameObject.Find("ForthDice").GetComponent<Text>();
        FifthDice = GameObject.Find("FifthDice").GetComponent<Text>();
        isRoll = true;
        counterDice = 0;
        currentRoll = new List<int>();
        NumberOfAbilities = 0;
        Strength = GameObject.Find("Strength").GetComponent<Text>();
        Dexterity = GameObject.Find("Dexterity").GetComponent<Text>();
        Constitution = GameObject.Find("Constitution").GetComponent<Text>();
        Intelligence = GameObject.Find("Intelligence").GetComponent<Text>();
        Wisdom = GameObject.Find("Wisdom").GetComponent<Text>();
        Charisma = GameObject.Find("Charisma").GetComponent<Text>();
        inputCharacterName = GameObject.Find("InputCharacterName").GetComponent<InputField>();
        
        speedWalking = GameObject.Find("speedWalking").GetComponent<Text>();
        Hit_Points = GameObject.Find("Hit_Points").GetComponent<Text>();
        Experience_Points = GameObject.Find("Experience_Points").GetComponent<Text>();
        Armor_Class = GameObject.Find("Armor_Class").GetComponent<Text>();
        Alignment = GameObject.Find("Alignment").GetComponent<Text>();
        MAX_Experience_Point = GameObject.Find("MAX_Experience_Point").GetComponent<Text>();
        Str_modifiers = GameObject.Find("Str_modifiers").GetComponent<Text>();
        Dex_modifiers = GameObject.Find("Dex_modifiers").GetComponent<Text>();
        Con_modifiers = GameObject.Find("Con_modifiers").GetComponent<Text>();
        Int_modifiers = GameObject.Find("Int_modifiers").GetComponent<Text>();
        Wis_modifiers = GameObject.Find("Wis_modifiers").GetComponent<Text>();
        Cha_modifiers = GameObject.Find("Cha_modifiers").GetComponent<Text>();

        JsonOutputText = GameObject.Find("JsonOutputText").GetComponent<InputField>();

    }
    public void unuse_abilitie()
    {
        Strength.text = "0";
        Dexterity.text = "0";
        Constitution.text = "0";
        Intelligence.text = "0";
        Wisdom.text = "0";
        Charisma.text = "0";
        Str_modifiers.text = "+2";
        Dex_modifiers.text = "+2";
        Con_modifiers.text = "+2";
        Int_modifiers.text = "+2";
        Wis_modifiers.text = "+2";
        Cha_modifiers.text = "+2";
        speedWalking.text = "0";
        Hit_Points.text = "0";
        Experience_Points.text= "0";
        Armor_Class.text = "13";
        Alignment.text = "Null";
        MAX_Experience_Point.text = "30";

    }
    public void Generate_Character()
    {
        Dice_Simulator();
    }
    //all modifiers default to +2
    public int Modifiers_Abilities( )
    {
        return 2;
    }

    public void JsonOutput()
    {

            playerState = new PlayerState();
            playerState.Strength = int.Parse(Strength.text);
            playerState.Dexterity = int.Parse(Dexterity.text);
            playerState.Constitution = int.Parse(Constitution.text);
            playerState.Intelligence = int.Parse(Intelligence.text);
            playerState.Wisdom = int.Parse(Wisdom.text);
            playerState.Charisma = int.Parse(Charisma.text);
            playerState.Races = dd_Races.captionText.text;
            playerState.Classes = dd_Classes.captionText.text;
            playerState.Character_Name = inputCharacterName.text;
            playerState.speedWalking = int.Parse(speedWalking.text);
            playerState.Hit_Points = int.Parse(Hit_Points.text);
            playerState.Experience_Points = int.Parse(Experience_Points.text);
            playerState.Armor_Class = int.Parse(Armor_Class.text);
            playerState.Alignment = Alignment.text;
            playerState.MAX_Experience_Point = int.Parse(MAX_Experience_Point.text);
            JsonOutputText.text = playerState.SaveToString();


    }


    public void Dice_Simulator()
    {

       Digi_Dice = UnityEngine.Random.Range(1, 7);
       if(isRoll == true)
        {
            if (counterDice == 0)
            {
                FirstDice.text = "";
                SecondDice.text = "";
                ThirdDice.text = "";
                ForthDice.text = "";
                FifthDice.text = "";
                FirstDice.text =  Digi_Dice.ToString();
            }
            if (counterDice == 1)
            {
                SecondDice.text = Digi_Dice.ToString();
            }
            if (counterDice == 2)
            {
                ThirdDice.text = Digi_Dice.ToString();
            }
            if (counterDice == 3)
            {
                ForthDice.text = Digi_Dice.ToString();
            }
            if (counterDice == 4)
            {
                FifthDice.text = Digi_Dice.ToString();
            }
            
            currentRoll.Add(Digi_Dice);
            counterDice++;
            if(counterDice == 5)
            {
                currentRoll.Sort();
                currentRoll.Reverse();
                SumOfRoll = currentRoll[0] + currentRoll[1] + currentRoll[2];
                SetAbilities(SumOfRoll);
                currentRoll.Clear();
                counterDice = 0;
                
}
        }
    }

    public void SetAbilities(int resultofAbilitie)
    {

        if (NumberOfAbilities == 0)
        {
            Strength.text = resultofAbilitie.ToString();
        }
        if (NumberOfAbilities == 1)
        {
           
            Dexterity.text = resultofAbilitie.ToString();

        }
        if (NumberOfAbilities == 2)
        {
           
            Constitution.text = resultofAbilitie.ToString();
        }
        if (NumberOfAbilities == 3)
        {
            
            Intelligence.text = resultofAbilitie.ToString();
        }
        if (NumberOfAbilities == 4)
        {
           
            Wisdom.text = resultofAbilitie.ToString();
        }
        if (NumberOfAbilities == 5)
        {
           
            Charisma.text = resultofAbilitie.ToString();

        }
        NumberOfAbilities++;
        if(NumberOfAbilities == 6)
        {
            NumberOfAbilities = 0;
        }
    }



    Dictionary<string, string> SummaryClass = new Dictionary<string, string>()
    {
        {"Barbarian","In battle, you fight with primal ferocity. " +
            "For some barbarians, rage is a means to an end–that end being violence."},

        {"Bard", "Whether singing folk ballads in taverns or elaborate " +
            "compositions in royal courts, bards use their gifts to hold audiences spellbound" },

        { "Cleric","Clerics act as conduits of divine power"},

        {"Druid","Druids venerate the forces of nature themselves. Druids holds certain " +
            "plants and animals to be sacred, and most druids are devoted to one of the many nature deities "},

        {"Fighter","Different fighters choose different approaches to " +
            "perfecting their fighting prowess, but they all end up perfecting it"},

        {"Monk","Coming from monasteries, monks are masters of " +
            "martial arts combat and meditators with the ki living forces."},

        {"Paladin","Paladins are the ideal of the knight in shining armor; " +
            "they uphold ideals of justice, virtue, and order and use righteous might to meet their ends."},

        {"Ranger","Acting as a bulwark between civilization and the " +
            "terrors of the wilderness, rangers study, track, and hunt their favored enemies." },

        {"Rogue","Rogues have many features in common, including their " +
            "emphasis on perfecting their skills, their precise and deadly approach to combat, and their increasingly quick reflexes."},

        {"Sorcerer","An event in your past, or in the life of a parent or ancestor, " +
            "left an indelible mark on you, infusing you with arcane magic. As a sorcerer the " +
            "power of your magic relies on your ability to project your will into the world."},

        {"Warlock","You struck a bargain with an otherworldly being of your choice: " +
            "the Archfey, the Fiend, or the Great Old One who has imbued you with mystical powers, " +
            "granted you knowledge of occult lore, bestowed arcane research " +
            "and magic on you and thus has given you facility with spells."},

        {"Wizard","The study of wizardry is ancient, stretching back to the earliest " +
            "mortal discoveries of magic. As a student of arcane magic, you have a spellbook containing " +
            "spells that show glimmerings of your true power which is a catalyst for your mastery over certain spells."}
    };



    Dictionary<string, string> SummaryRace = new Dictionary<string, string>()
    {
        {"Dragonborn","Your draconic heritage manifests in a variety of traits you share with other dragonborn."},

        {"Dwarf", "Your dwarf character has an assortment of in abilities, part and parcel of dwarven nature."},

        {"Elf","Your elf character has a variety of natural abilities, the result of thousands of years of elven refinement."},

        {"Gnome","Your gnome character has certain characteristics in common with all other gnomes."},

        {"Half-Elf","Your half-elf character has some qualities in common with elves and some that are unique to half-elves."},

        {"Half-Orc","Your half-orc character has certain traits deriving from your orc ancestry."},

        {"Halfling","Your halfling character has a number of traits in common with all other halflings."},

        {"Human","It's hard to make generalizations about humans, but your human character has these traits."},

        {"Tiefling","Tieflings share certain racial traits as a result of their infernal descent."}
    };
    public void Done() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
