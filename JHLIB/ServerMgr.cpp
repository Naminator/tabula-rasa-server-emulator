#include <Windows.h>
#include <stdio.h>
#include "ServerMgr.h"

#define MAXSERVERCOUNT 28

unsigned int ServerCount = 0;
GAMESERVER ServerList[MAXSERVERCOUNT];

void GSMgr_Unregister(unsigned char ID)
{
	int idx = -1;
	//Search index
	for(int i=0; i<ServerCount; i++)
		if( ServerList[i].ID == ID )
		{
			idx = i; break;
		}
	//Check if found
	if( idx == -1 )
		return;
	//Shift all other elements
	for(int i=idx; i<(ServerCount-1); i++)
		memcpy((void*)&ServerList[i], (void*)&ServerList[i+1], sizeof(GAMESERVER));
	//Decrease count
	ServerCount--;
}

int GSMgr_Register(char *Name, unsigned char ID, unsigned int IP, unsigned short Port, unsigned char Flags)
{
	//Unregister old if already known
	GSMgr_Unregister(ID);
	//Now check if our list is full
	if( ServerCount >= MAXSERVERCOUNT )
		return 1;
	//Add new server
	memset((void*)&ServerList[ServerCount], 0x00, sizeof(GAMESERVER));
	strcpy(ServerList[ServerCount].Name, Name);
	ServerList[ServerCount].AliveTime = 0;
	ServerList[ServerCount].Flags = Flags;
	ServerList[ServerCount].ID = ID;
	ServerList[ServerCount].IP = IP;
	ServerList[ServerCount].Port = Port;

	printf("Register server %d.%d.%d.%d:%d\n", (IP&0xFF), ((IP>>8)&0xFF), ((IP>>16)&0xFF), ((IP>>24)&0xFF), Port);
	//Do Flag depentend work
	unsigned int CurrentTime = GetTickCount();
	if( Flags & GS_FLAG_AUTOCHECK )
		ServerList[ServerCount].AliveTime = (18*1000);//Alive time marks recheck time
	else
		ServerList[ServerCount].AliveTime = (5*60*1000);//Alive time marks auto-unregister time
	ServerList[ServerCount].CheckTime = CurrentTime;
	//Increase server count
	ServerCount++;
	//Return success
	return 0;
}

void GSMgr_CheckAll()
{
	unsigned int CurrentTime = GetTickCount();
	for(int i=0; i<ServerCount; i++)
	{
		unsigned int CurrentAliveTime = CurrentTime-ServerList[i].CheckTime;
		if( CurrentAliveTime > ServerList[i].AliveTime )
		{
			// todo
		}
	}
}

int GSMgr_GetServerCount()
{
	return ServerCount;
}

GAMESERVER *GSMgr_QueryServerByIndex(int idx)
{
	return &ServerList[idx];
}


unsigned char SecretKey[10];
unsigned char *GSMgr_GenerateSecretKey(char *pw)
{
	memset((void*)SecretKey, 0x00, 10);
	int l = strlen(pw);
	//pw input
	for(int i=0; i<l; i++)
		SecretKey[i%10] += pw[i];
	for(int i=0; i<l; i++)
		SecretKey[(i+3)%10] ^= ((pw[i]<<1) | (pw[i]>>7));
	for(int i=0; i<l; i++)
		SecretKey[(i+5)%10] ^= ~((pw[l-1-i]<<3) | (pw[l-1-i]>>5));
	//Some scrambling
	for(int i=0; i<10; i++)
		SecretKey[i] = (SecretKey[i]>>4) | (SecretKey[i]<<4);
	//Some magic xoring
	for(int i=0; i<10; i++)
		SecretKey[i] = SecretKey[i] ^ ((i^4+i+i*34+(i>>3)*45)&0xFF);
	//Return key
	return SecretKey;
}