using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using IBatisNet.DataMapper;

namespace TRE.DataAccess.Entities
{
    struct AppearanceData
	{
		int classId; // entityClassId
		int hue;	// 0xAABBGGRR
	}

    [DataContract]
    public class CharacterBase
    {
        public long id { get; set; }
        public string name { get; set; }
       
        public float posX { get; set; }
        public float posY { get; set; }
        public float posZ { get; set; }
        public float rotation { get; set; }

        [NonSerialized]
        public AppearanceData[] { 

        public long ad1_classId { get; set; }
        public long ad1_hue { get; set; }

        public long ad2_classId { get; set; }
        public long ad2_hue { get; set; }

        public long ad3_classId { get; set; }
        public long ad3_hue { get; set; }

        public long ad4_classId { get; set; }
        public long ad4_hue { get; set; }

        public long ad5_classId { get; set; }
        public long ad5_hue { get; set; }

        public long ad6_classId { get; set; }
        public long ad6_hue { get; set; }

        public long ad7_classId { get; set; }
        public long ad7_hue { get; set; }

        public long ad8_classId { get; set; }
        public long ad8_hue { get; set; }

        public long ad9_classId { get; set; }
        public long ad9_hue { get; set; }

        public long ad10_classId { get; set; }
        public long ad10_hue { get; set; }

        public long ad11_classId { get; set; }
        public long ad11_hue { get; set; }

        public long ad12_classId { get; set; }
        public long ad12_hue { get; set; }

        public long ad13_classId { get; set; }
        public long ad13_hue { get; set; }

        public long ad14_classId { get; set; }
        public long ad14_hue { get; set; }

        public long ad15_classId { get; set; }
        public long ad15_hue { get; set; }

        public long ad16_classId { get; set; }
        public long ad16_hue { get; set; }

        public long ad17_classId { get; set; }
        public long ad17_hue { get; set; }

        public long ad18_classId { get; set; }
        public long ad18_hue { get; set; }

        public long ad19_classId { get; set; }
        public long ad19_hue { get; set; }

        public long ad20_classId { get; set; }
        public long ad20_hue { get; set; }

        public long ad21_classId { get; set; }
        public long ad21_hue { get; set; }


    }

    [DataContract]
    public class Character : CharacterBase
    {
        public int slotID { get; set; }
        public int classID { get; set; }
        public int raceID { get; set; }
        public long userID { get; set; }
        
        public int gender { get; set; }
    }

}
