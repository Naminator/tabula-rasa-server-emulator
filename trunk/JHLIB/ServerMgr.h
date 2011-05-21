typedef struct
{
	//General data
	unsigned int AliveTime;
	unsigned int CheckTime;
	unsigned char Flags;
	//Network data
	unsigned int IP;
	unsigned short Port;
	//Server specific
	unsigned char ID;
	char Name[64];
}GAMESERVER;

#define GS_FLAG_AUTOCHECK			1
#define GS_FLAG_SERVERDOESCHECK		2
#define GS_FLAG_ONLINE				4

int GSMgr_Register(char *Name, unsigned char ID, unsigned int IP, unsigned short Port, unsigned char Flags);
void GSMgr_CheckAll();

int GSMgr_GetServerCount();
GAMESERVER *GSMgr_QueryServerByIndex(int idx);

unsigned char *GSMgr_GenerateSecretKey(char *pw);