using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TRE.DataAccess.Common;
using TRE.DataAccess.Entities;
using IBatisNet.DataMapper;

namespace TRE.DataAccess.DAOs
{
    public class CharacterDAO
    {
        public static IList<CharacterData> listUserCharacters(long userId)
        {
            ISqlMapper mapper = Mapper.Instance();
            IList<CharacterData> characters = new List<CharacterData>();
            mapper.QueryForList<CharacterData>("listUserCharacters", userId, characters);
            return characters;
        }

        public static CharacterData getUserCharacter(long userId, long slotId)
        {
            return listUserCharacters(userId).Single<CharacterData>(c => c.slotID == slotId);
        }

        public static void createCharacter(CharacterData character)
        {
            ISqlMapper mapper = Mapper.Instance();
            mapper.Insert("InsertCharacter", character);
        }

        public static void deleteCharacter(long userID, int slotId)
        {
            ISqlMapper mapper = Mapper.Instance();
            //mapper.Delete("DeleteCharacter", [ userID, sloId ] );
        }
    }
}
