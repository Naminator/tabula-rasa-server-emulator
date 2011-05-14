using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using IBatisNet.DataMapper;

namespace TRE.DataAccess.Entities
{
    public struct AppearanceData
    {
        public int classId; // entityClassId
        public uint hue;	// 0xAABBGGRR
    }

    [DataContract]
    public class CharacterDataBase
    {
        public long id { get; set; }
        public string name { get; set; }

        public float posX { get; set; }
        public float posY { get; set; }
        public float posZ { get; set; }
        public float rotation { get; set; }

        public int ad1_classId { get; set; }
        public uint ad1_hue { get; set; }

        public int ad2_classId { get; set; }
        public uint ad2_hue { get; set; }

        public int ad3_classId { get; set; }
        public uint ad3_hue { get; set; }

        public int ad4_classId { get; set; }
        public uint ad4_hue { get; set; }

        public int ad5_classId { get; set; }
        public uint ad5_hue { get; set; }

        public int ad6_classId { get; set; }
        public uint ad6_hue { get; set; }

        public int ad7_classId { get; set; }
        public uint ad7_hue { get; set; }

        public int ad8_classId { get; set; }
        public uint ad8_hue { get; set; }

        public int ad9_classId { get; set; }
        public uint ad9_hue { get; set; }

        public int ad10_classId { get; set; }
        public uint ad10_hue { get; set; }

        public int ad11_classId { get; set; }
        public uint ad11_hue { get; set; }

        public int ad12_classId { get; set; }
        public uint ad12_hue { get; set; }

        public int ad13_classId { get; set; }
        public uint ad13_hue { get; set; }

        public int ad14_classId { get; set; }
        public uint ad14_hue { get; set; }

        public int ad15_classId { get; set; }
        public uint ad15_hue { get; set; }

        public int ad16_classId { get; set; }
        public uint ad16_hue { get; set; }

        public int ad17_classId { get; set; }
        public uint ad17_hue { get; set; }

        public int ad18_classId { get; set; }
        public uint ad18_hue { get; set; }

        public int ad19_classId { get; set; }
        public uint ad19_hue { get; set; }

        public int ad20_classId { get; set; }
        public uint ad20_hue { get; set; }

        public int ad21_classId { get; set; }
        public uint ad21_hue { get; set; }
    }   

    [DataContract]
    public class CharacterData : CharacterDataBase
    {
        public int slotID { get; set; } // 0 to 15
        public int classID { get; set; }
        public int raceID { get; set; } // 1 to 4
        public long userID { get; set; }

        public int gender { get; set; }

        // stats shit

	    // inventory shit

	    // mission data
	    uint missionStateCount;

	    CharacterMissionData missionStateData;

        
        public List<AppearanceData> GetAppearanceData()
        {
                List<AppearanceData> appearanceData = new List<AppearanceData>();

                appearanceData.Add(new AppearanceData() { classId = this.ad1_classId, hue = this.ad1_hue });
                appearanceData.Add(new AppearanceData() { classId = this.ad2_classId, hue = this.ad2_hue });
                appearanceData.Add(new AppearanceData() { classId = this.ad3_classId, hue = this.ad3_hue });
                appearanceData.Add(new AppearanceData() { classId = this.ad4_classId, hue = this.ad4_hue });
                appearanceData.Add(new AppearanceData() { classId = this.ad5_classId, hue = this.ad5_hue });

                appearanceData.Add(new AppearanceData() { classId = this.ad6_classId, hue = this.ad6_hue });
                appearanceData.Add(new AppearanceData() { classId = this.ad7_classId, hue = this.ad6_hue });
                appearanceData.Add(new AppearanceData() { classId = this.ad8_classId, hue = this.ad7_hue });
                appearanceData.Add(new AppearanceData() { classId = this.ad9_classId, hue = this.ad9_hue });
                appearanceData.Add(new AppearanceData() { classId = this.ad10_classId, hue = this.ad10_hue });

                appearanceData.Add(new AppearanceData() { classId = this.ad11_classId, hue = this.ad11_hue });
                appearanceData.Add(new AppearanceData() { classId = this.ad12_classId, hue = this.ad12_hue });
                appearanceData.Add(new AppearanceData() { classId = this.ad13_classId, hue = this.ad13_hue });
                appearanceData.Add(new AppearanceData() { classId = this.ad14_classId, hue = this.ad14_hue });
                appearanceData.Add(new AppearanceData() { classId = this.ad15_classId, hue = this.ad15_hue });

                appearanceData.Add(new AppearanceData() { classId = this.ad16_classId, hue = this.ad16_hue });
                appearanceData.Add(new AppearanceData() { classId = this.ad17_classId, hue = this.ad17_hue });
                appearanceData.Add(new AppearanceData() { classId = this.ad18_classId, hue = this.ad18_hue });
                appearanceData.Add(new AppearanceData() { classId = this.ad19_classId, hue = this.ad19_hue });
                appearanceData.Add(new AppearanceData() { classId = this.ad20_classId, hue = this.ad20_hue });

                appearanceData.Add(new AppearanceData() { classId = this.ad21_classId, hue = this.ad21_hue });

                return appearanceData;
        }
    }


       
       

}
