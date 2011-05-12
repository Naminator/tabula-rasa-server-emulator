using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TRE.GameService
{

    public struct EquipmentClassSlot
    {
        public int classId, slotId;
    }

    public struct MapInfo
    {
        public int contextId;
        public string mapName;
        public int version;
        public int baseRegionId;
    }

    //internal enum ItemTemplateType {
    //    Weapon = 1,
    //    Armor = 2
    //}

    public class ItemTemplate
    {
        public string name;
        public int templateId;
        public int classId;
        public string type; // ItemTemplateType type;
        public int buybackPrice;
        public string req1;
    }

    class GameData
    {
        //const int ITEMTYPE_WEAPON = 1, ITEMTYPE_ARMOR = 2;
            
        static List<EquipmentClassSlot> equipmentClassSlots;
        static Hashtable starterItemTemplateClassIds;
        static List<MapInfo> mapInfoArray;
        // static int mapInfoCount;

        internal static void Load()
        {
            LoadEquipmentClassSlots();

            LoadStarterItemTemplateClassIds();

            LoadMapInfo();

            LoadItemTemplates();
        }   

        internal static void LoadEquipmentClassSlots() {
            equipmentClassSlots = new List<EquipmentClassSlot>();
            string[] lines = File.ReadAllLines("gameData\\equipableClassEquipmentSlot.txt");
            foreach(string line in lines) {
                if ((line.Length > 0) && (line[0] == '('))
                {
                    equipmentClassSlots.Add(new EquipmentClassSlot()
                    {
                        classId = Int32.Parse(line.Substring(1, line.IndexOf(',') - 1).Trim()),
                        slotId = Int32.Parse(line.Substring(line.IndexOf(',') + 1, line.Length - line.IndexOf(',') - 2).Trim())
                    });
                }
            }
        }

        internal static void LoadStarterItemTemplateClassIds() {
            starterItemTemplateClassIds = new Hashtable();
            string[] lines = File.ReadAllLines("gameData\\starterItemTemplateClassIds.txt");
            foreach (string line in lines)
            {
                if ((line.Length > 0) && (line[0] == '('))
                    starterItemTemplateClassIds.Add(
                       line.Substring(1, line.IndexOf(',') - 1).Trim(),
                       line.Substring(line.IndexOf(',') + 1, line.Length - line.IndexOf(',') - 2).Trim()
                        );
            }
        }
        
        internal static void LoadMapInfo()
        {
            // read number of maps
            string[] lines = File.ReadAllLines("gameData\\mapInfo.txt");
            //Scanning.Scanner scn = new Scanning.Scanner();

            mapInfoArray = new List<MapInfo>();

            //object[] targets = new object[4];
            //targets[0] = new Int32(); // contextId
            //targets[1] = string.Empty; // mapName
            //targets[2] = new Int32(); // version
            //targets[3] = new Int32(); // baseRegionId

            foreach (string line in lines)
            {
                if (line.StartsWith("(")) {
                    //scn.Scan(line, @"[\(]*{0}[,] [']*{1}[']*[,]* {2}[,]* {3}[\)]*", targets);
                    string[] values = line.Substring(1, line.IndexOf(')') - 1).Replace(" ", string.Empty).Trim().Split(',');

                    mapInfoArray.Add(new MapInfo()
                    {
                        contextId = Int32.Parse(values[0]),
                        mapName = values[1].Substring(1, values[1].LastIndexOf('\'')-1),
                        version = Int32.Parse(values[2]),
                        baseRegionId = Int32.Parse(values[3]),
                    });

                }
            }
        }

        static List<ItemTemplate> ItemTemplates;

        internal static void LoadItemTemplates()
        {
            ItemTemplates = new List<ItemTemplate>();
            string[] lines = File.ReadAllLines("gameData\\itemTemplates.txt");
            ItemTemplate currentItemTemplate = null;
            foreach (string line in lines)
            {
                if ((line.Trim().Length == 0) || (line.Trim().StartsWith("#") ) ) continue; // comment

                if (line.Trim().StartsWith("["))
                {
                    // category 
                    currentItemTemplate = new ItemTemplate();
                    currentItemTemplate.name = line.Trim().Substring(1, line.LastIndexOf(']') -1);
                    ItemTemplates.Add(currentItemTemplate);
                } else {
                    if (currentItemTemplate != null)
                    {
                        string[] options = line.Trim().Split('=');
                        string optionName = options[0].Trim().ToLower();
                        string optionValue = options[1].Trim();
                        switch (optionName)
                        {
                            case "templateid":
                                currentItemTemplate.templateId = int.Parse(optionValue);
                                break;
                            case "classid": 
                                currentItemTemplate.classId = int.Parse(optionValue);
                                break;
                            case "type":
                                currentItemTemplate.type = optionValue;
                                break;
                            case "buybackprice":
                                currentItemTemplate.buybackPrice = int.Parse(optionValue);
                                break;
                            case "req1":
                                currentItemTemplate.req1 = optionValue;
                                break;

                        }

                    }
                    else
                    {
                        currentItemTemplate = null;
                    }
            }
            }
        }

        internal int getEquipmentClassIdSlot(int classId)
        {
            return equipmentClassSlots.Find(c => c.classId == classId).slotId; 
        }

        internal int getStarterItemTemplateClassId(int templateId)
        {
            return (int) starterItemTemplateClassIds[templateId];
        }

        internal ItemTemplate getItemTemplateById(int templateId)
        {
            return ItemTemplates.Find(it => it.templateId == templateId);
        }

        internal ItemTemplate getItemTemplateByName(string name)
        {
            return ItemTemplates.Find(it => it.name == name);
        }
    }
}
