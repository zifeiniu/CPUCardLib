extern "C"
{
//1.
HANDLE  __stdcall  dc_init(__int16 port,long baud);
//2.
__int16  __stdcall dc_exit(HANDLE icdev);
//3.
__int16  __stdcall dc_config(HANDLE icdev,unsigned char _Mode,unsigned char _Baud);
//4.
__int16  __stdcall dc_request(HANDLE icdev,unsigned char _Mode,unsigned __int16  *TagType);
//5.
__int16  __stdcall  dc_anticoll(HANDLE icdev,unsigned char _Bcnt,unsigned long *_Snr);
//6.
__int16  __stdcall dc_select(HANDLE icdev,unsigned long _Snr,unsigned char *_Size);
//7.
__int16  __stdcall dc_authentication(HANDLE icdev,unsigned char _Mode,unsigned char _SecNr);
//8.
__int16  __stdcall dc_halt(HANDLE icdev);
//9
__int16  __stdcall dc_read(HANDLE icdev,unsigned char _Adr,unsigned char *_Data);
//10.
__int16  __stdcall dc_read_hex(HANDLE icdev,unsigned char _Adr,char *_Data);
//11.
__int16  __stdcall dc_write(HANDLE icdev,unsigned char _Adr,unsigned char *_Data);
//12.
__int16  __stdcall dc_write_hex(HANDLE icdev,unsigned char _Adr,char *_Data);

__int16  __stdcall dc_write_TS(HANDLE icdev);
//13.
__int16  __stdcall dc_load_key(HANDLE icdev,unsigned char _Mode,unsigned char _SecNr,
							   unsigned char *_NKey);
//14.
__int16  __stdcall dc_load_key_hex(HANDLE icdev,unsigned char _Mode,unsigned char _SecNr,
								   char *_NKey);
//15.
__int16  __stdcall dc_card(HANDLE icdev,unsigned char _Mode,unsigned long *_Snr);
//16
__int16 __stdcall dc_card_hex(HANDLE icdev,unsigned char _Mode,unsigned char *snrstr);
//17.
__int16  __stdcall dc_changeb3(HANDLE icdev,unsigned char _SecNr,unsigned char *_KeyA,
							   unsigned char _B0,unsigned char _B1,unsigned char _B2,
							   unsigned char _B3,unsigned char _Bk,unsigned char *_KeyB);
//18.
__int16  __stdcall dc_restore(HANDLE icdev,unsigned char _Adr);
//19
__int16  __stdcall dc_transfer(HANDLE icdev,unsigned char _Adr);
//20
__int16  __stdcall dc_increment(HANDLE icdev,unsigned char _Adr,unsigned long _Value);
//21.
__int16  __stdcall dc_decrement(HANDLE icdev,unsigned char _Adr,unsigned long _Value);
//22.
__int16  __stdcall dc_initval(HANDLE icdev,unsigned char _Adr,unsigned long _Value);
//23.
__int16  __stdcall dc_readval(HANDLE icdev,unsigned char _Adr,unsigned long *_Value);
//24
__int16  __stdcall dc_initval_ml(HANDLE icdev,unsigned __int16   _Value);
//25
__int16  __stdcall dc_readval_ml(HANDLE icdev,unsigned __int16   *_Value);//17
//26
__int16  __stdcall dc_decrement_ml(HANDLE icdev,unsigned __int16   _Value);
//27
__int16  __stdcall dc_authentication_2(HANDLE icdev,unsigned char _Mode,unsigned char KeyNr,
									   unsigned char Adr);
//28
__int16  __stdcall  dc_anticoll2(HANDLE icdev,unsigned char _Bcnt,unsigned long *_Snr);
//29
__int16  __stdcall dc_select2(HANDLE icdev,unsigned long _Snr,unsigned char *_Size);
//30.
__int16  __stdcall dc_HL_write(HANDLE icdev,unsigned char _Mode,unsigned char _Adr,
							   unsigned long *_Snr,unsigned char *_Data);
//31
__int16  __stdcall dc_HL_writehex(HANDLE icdev,unsigned char _Mode,unsigned char _Adr,
								  unsigned long *_Snr,unsigned char *_Data);

//32.
__int16  __stdcall dc_HL_read(HANDLE icdev,unsigned char _Mode,unsigned char _Adr,
							  unsigned long _Snr,unsigned char *_Data,unsigned long *_NSnr);
//33
__int16  __stdcall dc_HL_readhex(HANDLE icdev,unsigned char _Mode,unsigned char _Adr,
								 unsigned long _Snr,unsigned char *_Data,unsigned long *_NSnr);

//34.
__int16  __stdcall dc_HL_authentication(HANDLE icdev,unsigned char reqmode,unsigned long snr,
										unsigned char authmode,unsigned char secnr);
//35.
__int16  __stdcall dc_check_write(HANDLE icdev,unsigned long Snr,unsigned char authmode,
								  unsigned char Adr,unsigned char * _data);
//36
__int16  __stdcall dc_check_writehex(HANDLE icdev,unsigned long Snr,unsigned char authmode,
									 unsigned char Adr,unsigned char * _data);

//37.
__int16 __stdcall dc_getver(HANDLE icdev,unsigned char *sver);
//38
__int16 __stdcall dc_update(HANDLE icdev);
//39
__int16  __stdcall dc_clr_control_bit(HANDLE icdev,unsigned char _b);
//40.
__int16  __stdcall dc_set_control_bit(HANDLE icdev,unsigned char _b);
//41.
__int16  __stdcall dc_reset(HANDLE icdev,unsigned __int16   _Msec);
//42
__int16  __stdcall dc_beep(HANDLE icdev,unsigned short _Msec);
//43.
__int16  __stdcall dc_disp_str(HANDLE icdev,char *dispstr);
//44
__int16  __stdcall dc_srd_eeprom(HANDLE icdev,__int16   offset,__int16 lenth,
								 unsigned char *rec_buffer);
//45
__int16  __stdcall dc_swr_eeprom(HANDLE icdev,__int16   offset,__int16 lenth,
								 unsigned char* send_buffer);
//46
__int16 __stdcall swr_alleeprom(HANDLE icdev,__int16 offset,__int16 lenth,
								unsigned char* snd_buffer);
//47
__int16 __stdcall srd_alleeprom(HANDLE icdev,__int16 offset,__int16 lenth,
								unsigned char *receive_buffer);
//48
__int16  __stdcall dc_srd_eepromhex(HANDLE icdev,__int16   offset,__int16   lenth,
									unsigned char *rec_buffer);

//49
__int16  __stdcall dc_swr_eepromhex(HANDLE icdev,__int16   offset,__int16   lenth,
									unsigned char* send_buffer);

//50
__int16  __stdcall dc_gettime(HANDLE icdev,unsigned char *time);
//51
__int16  __stdcall dc_gettimehex(HANDLE icdev,char *time);

//52
__int16  __stdcall dc_settime(HANDLE icdev,unsigned char *time);
//53
__int16  __stdcall dc_settimehex(HANDLE icdev,char *time);

//54
__int16  __stdcall dc_setbright(HANDLE icdev,unsigned char bright);
//55
__int16  __stdcall dc_ctl_mode(HANDLE icdev,unsigned char mode);
//56
__int16  __stdcall dc_disp_mode(HANDLE icdev,unsigned char mode);
//57
__int16  __stdcall dcdeshex(unsigned char *key,unsigned char *sour,unsigned char *dest,
							__int16 m);

//58
__int16 __stdcall dcdes(unsigned char *key,unsigned char *sour,unsigned char *dest,__int16 m);
//59
__int16 __stdcall dc_light(HANDLE icdev,unsigned short _OnOff);
//60
__int16 __stdcall dc_high_disp(HANDLE icdev,unsigned char offset,unsigned char displen,
							   unsigned char *dispstr);
//61
__int16 __stdcall dc_setcpu(HANDLE icdev,unsigned char _Byte);
//62
__int16 __stdcall dc_cpureset(HANDLE icdev,unsigned char *rlen,unsigned char *databuffer);
//63
__int16 __stdcall dc_cpuapdusource(HANDLE icdev,unsigned char slen,unsigned char * sendbuffer,
								   unsigned char *rlen,unsigned char * databuffer);
//64
__int16 __stdcall dc_cpuapdu(HANDLE icdev,unsigned char slen,unsigned char * sendbuffer,
							 unsigned char *rlen,unsigned char * databuffer);
//65
__int16 __stdcall dc_cpureset_hex(HANDLE icdev,unsigned char *rlen, char *databuffer);
//66
__int16 __stdcall dc_cpuapdusource_hex(HANDLE icdev,unsigned char slen, char * sendbuffer,
									   unsigned char *rlen, char * databuffer);
//67
__int16 __stdcall dc_cpuapdu_hex(HANDLE icdev,unsigned char slen, char * sendbuffer,
								 unsigned char *rlen, char * databuffer);

__int16 __stdcall dc_cpuapdurespon(HANDLE idComDev,unsigned char slen,unsigned char * sendbuffer,unsigned char *rlen,unsigned char * databuffer);
__int16 __stdcall dc_cpuapdurespon_hex(HANDLE idComDev,unsigned char slen,unsigned char * sendbuffer,unsigned char *rlen,unsigned char * databuffer);


//68
__int16 __stdcall dc_cpudown(HANDLE icdev);
//69
__int16 __stdcall dc_set_addr(unsigned char saddr);
//70
HANDLE __stdcall dc_init_485(__int16 port,long baud);
//71
__int16 __stdcall dc_changebaud_485(HANDLE icdev,long baud);
//72
__int16 __stdcall dc_change_addr(HANDLE icdev,unsigned char saddr);
//73
__int16 __stdcall dc_pro_reset(HANDLE icdev,unsigned char *rlen,unsigned char *receive_data);
//74
__int16 __stdcall dc_pro_command(HANDLE idComDev,unsigned char slen,
								 unsigned char * sendbuffer,unsigned char *rlen,
								 unsigned char * databuffer,unsigned char timeout);
//75
__int16 __stdcall dc_pro_resethex(HANDLE icdev,unsigned char *rlen, char *receive_data);


//76
__int16 __stdcall dc_pro_commandhex(HANDLE idComDev,unsigned char slen, 
									char * sendbuffer,unsigned char *rlen, 
									char * databuffer,unsigned char timeout);
//77
__int16 __stdcall dc_pro_commandsource(HANDLE idComDev,unsigned char slen,
									   unsigned char * sendbuffer,unsigned char *rlen,
									   unsigned char * databuffer,unsigned char timeout);
//78
__int16 __stdcall dc_pro_commandsourcehex(HANDLE idComDev,unsigned char slen, 
									char * sendbuffer,unsigned char *rlen, 
									char * databuffer,unsigned char timeout);

//79
__int16 __stdcall dc_pro_halt(HANDLE icdev);
//80
__int16 __stdcall dc_request_shc1102(HANDLE icdev,unsigned char _Mode,
									 unsigned __int16 *TagType);
//81
__int16 __stdcall dc_auth_shc1102(HANDLE icdev,unsigned char *_Data);
//82
__int16 __stdcall dc_read_shc1102(HANDLE icdev,unsigned char _Adr,unsigned char *_Data);
//83
__int16 __stdcall dc_write_shc1102(HANDLE icdev,unsigned char _Adr,unsigned char *_Data);
//84
__int16 __stdcall dc_halt_shc1102(HANDLE icdev);
//85
__int16 __stdcall hex_a(unsigned char *hex,unsigned char *a,__int16 length);
//86
__int16 __stdcall a_hex(unsigned char *a,unsigned char *hex,__int16 len);
//87
__int16 __stdcall dc_config_card(HANDLE icdev,unsigned char cardtype);
//88
__int16 __stdcall dc_request_b(HANDLE icdev,unsigned char _Mode,unsigned char AFI, 
		                       unsigned char N,unsigned char *ATQB);
//89
__int16 __stdcall dc_slotmarker(HANDLE icdev,unsigned char N, unsigned char *ATQB);
//90
__int16 __stdcall dc_attrib(HANDLE icdev,unsigned char *PUPI, unsigned char CID);
//91
__int16 __stdcall dc_open_door(HANDLE icdev,unsigned char cflag);
//92
__int16 __stdcall dc_open_timedoor(HANDLE icdev,unsigned __int16 utime);
//93
__int16 __stdcall dc_read_random(HANDLE icdev, unsigned char *data);
//94
__int16 __stdcall dc_write_random(HANDLE icdev,__int16 len, unsigned char *data);
//95
__int16 __stdcall dc_read_random_hex(HANDLE icdev, unsigned char *data);
//96
__int16 __stdcall dc_write_random_hex(HANDLE icdev,__int16 len, unsigned char *data);
//97
__int16 __stdcall dc_erase_random(HANDLE icdev,__int16 len);
//98
__int16 __stdcall dc_mfdes_auth(HANDLE icdev,unsigned char keyno,unsigned char keylen,unsigned char *authkey,
								unsigned char *randAdata,unsigned char *randBdata);
//99
__int16 __stdcall dc_authentication_pass(HANDLE icdev,unsigned char _Mode,
										 unsigned char _Addr,unsigned char *passbuff);
//100
__int16 __stdcall dc_disp_neg(HANDLE icdev,char *dispstr);
//101
__int16 __stdcall dc_pro_commandlink(HANDLE idComDev,unsigned char slen,
								 unsigned char * sendbuffer,unsigned char *rlen,
								 unsigned char * databuffer,unsigned char timeout,
								 unsigned char FG);
//102
__int16 __stdcall dc_pro_commandlink_hex(HANDLE idComDev,unsigned char slen,
										 unsigned char * sendbuffer,unsigned char *rlen,
										 unsigned char * databuffer,unsigned char timeout,
										 unsigned char FG);

__int16 __stdcall dc_card_double(HANDLE icdev,unsigned char _Mode,unsigned char *_Snr);
__int16 __stdcall dc_card_double_hex(HANDLE icdev,unsigned char _Mode,unsigned char *_Snr);
__int16 __stdcall dc_read_idcard(HANDLE icdev,unsigned char times,unsigned char *_Data);
__int16 __stdcall dc_read_idcard_hex(HANDLE icdev,unsigned char times,unsigned char *_Data);

__int16 __stdcall dc_authentication_pass_hex(HANDLE icdev,unsigned char _Mode,
										 unsigned char _Addr,unsigned char *passbuff);

__int16  __stdcall  dc_setcpupara(HANDLE icdev,unsigned char cputype,
								  unsigned char cpupro,unsigned char cpuetu);
__int16 __stdcall dc_command(HANDLE idComDev,unsigned char cmd,unsigned char slen,
									   unsigned char * sendbuffer,unsigned char *rlen,
									   unsigned char * databuffer);

__int16 __stdcall dc_command_hex(HANDLE idComDev,unsigned char cmd,unsigned char slen, 
										  char * sendbuffer,unsigned char *rlen, 
										  char * databuffer);
__int16 __stdcall dc_creat_mac(unsigned char KeyLen,unsigned char *Key,unsigned short DataLen,
							unsigned char *Data,unsigned char *InitData,unsigned char AutoFixFlag,
							unsigned char FixChar,unsigned char *MacData);
__int16 __stdcall dc_creat_mac_hex(unsigned char KeyLen,unsigned char *Key,unsigned short DataLen,
							unsigned char *Data,unsigned char *InitData,unsigned char AutoFixFlag,
							unsigned char FixChar,unsigned char *MacData);
//------------------------------新增的为了整齐DLL而做的代码------------------------------
__int16  __stdcall dc_HL_write_hex(HANDLE icdev,unsigned char _Mode,unsigned char _Adr,
								   unsigned long *_Snr,unsigned char *_Data);
__int16  __stdcall dc_HL_read_hex(HANDLE icdev,unsigned char _Mode,unsigned char _Adr,
								  unsigned long _Snr,unsigned char *_Data,unsigned long *_NSnr);
__int16  __stdcall dc_check_write_hex(HANDLE icdev,unsigned long Snr,unsigned char authmode,
									  unsigned char Adr,unsigned char * _data);

__int16  __stdcall dc_srd_eeprom_hex(HANDLE icdev,__int16   offset,__int16   lenth,
									 unsigned char *rec_buffer);
__int16  __stdcall dc_swr_eeprom_hex(HANDLE icdev,__int16   offset,__int16   lenth,
									 unsigned char* send_buffer);

__int16  __stdcall dc_gettime_hex(HANDLE icdev,char *time);
__int16  __stdcall dc_settime_hex(HANDLE icdev,char *time);
__int16  __stdcall dc_des_hex(unsigned char *key,unsigned char *sour,unsigned char *dest,
							  __int16 m);
__int16 __stdcall dc_des(unsigned char *key,unsigned char *sour,unsigned char *dest,__int16 m);
__int16 __stdcall dc_pro_reset_hex(HANDLE icdev,unsigned char *rlen, char *receive_data);
__int16 __stdcall dc_pro_command_hex(HANDLE idComDev,unsigned char slen, 
									 char * sendbuffer,unsigned char *rlen, 
									 char * databuffer,unsigned char timeout);
__int16 __stdcall dc_pro_commandsource_hex(HANDLE idComDev,unsigned char slen, 
										   char * sendbuffer,unsigned char *rlen, 
										   char * databuffer,unsigned char timeout);
//-------------------------------------整齐DLL工作结束--------------------------------------------------
__int16 __stdcall dc_switch_unix(HANDLE icdev,long baud);

__int16 __stdcall dc_authentication_passaddr(HANDLE icdev,unsigned char _Mode,
										 unsigned char _Addr,unsigned char *passbuff);
__int16 __stdcall dc_authentication_passaddr_hex(HANDLE icdev,unsigned char _Mode,
											 unsigned char _Addr,unsigned char *passbuff);

__int16 __stdcall dc_card_fm11rf005(HANDLE icdev,unsigned char _Mode,unsigned long *_Snr);

__int16 __stdcall dc_setusbtimeout(unsigned char ntimes);

__int16 __stdcall dc_mfdes_baud(HANDLE icdev,unsigned char _Mode,unsigned char para);

__int16 __stdcall dc_tripledes(unsigned char *key,unsigned char *src,unsigned char *dest,__int16 m);

__int16 __stdcall dc_tripledes_hex(unsigned char *key,unsigned char *src,unsigned char *dest,__int16 m);

__int16 __stdcall dc_mfdes_auth_hex(HANDLE icdev,unsigned char keyno,unsigned char keylen,unsigned char *authkey,
								unsigned char *randAdata,unsigned char *randBdata);

__int16 __stdcall dc_pro_sendcommandsource(HANDLE idComDev,unsigned char slen,
										   unsigned char * sendbuffer,unsigned char timeout);										   

__int16 __stdcall dc_pro_receivecommandsource(HANDLE idComDev,unsigned char *rlen,
											  unsigned char * databuffer);
//----------------------------------以下为ISO15693 相关函数----------------------------------------
__int16 __stdcall dc_inventory(HANDLE icdev,unsigned char flags,
							   unsigned char AFI, 
							   unsigned char masklen, 
							   unsigned char *rlen,unsigned char *rbuffer);
__int16 __stdcall dc_inventory_hex(HANDLE icdev,unsigned char flags,
							   unsigned char AFI, 
							   unsigned char masklen, 
							   unsigned char *rlen,unsigned char *rbuffer);
__int16 __stdcall dc_stay_quiet(HANDLE icdev,unsigned char flags,unsigned char *UID);
__int16 __stdcall dc_stay_quiet_hex(HANDLE icdev,unsigned char flags,unsigned char *UID);
__int16 __stdcall dc_select_uid(HANDLE icdev,unsigned char flags,unsigned char *UID);
__int16 __stdcall dc_select_uid_hex(HANDLE icdev,unsigned char flags,unsigned char *UID);
__int16 __stdcall dc_reset_to_ready(HANDLE icdev,unsigned char flags,unsigned char *UID);
__int16 __stdcall dc_reset_to_ready_hex(HANDLE icdev,unsigned char flags,unsigned char *UID);
__int16 __stdcall dc_readblock(HANDLE icdev,unsigned char flags,
							   unsigned char startblock,unsigned char blocknum, 
							   unsigned char *UID, 
							   unsigned char *rlen,unsigned char *rbuffer);
__int16 __stdcall dc_readblock_hex(HANDLE icdev,unsigned char flags,
							   unsigned char startblock,unsigned char blocknum, 
							   unsigned char *UID, 
							   unsigned char *rlen,unsigned char *rbuffer);
__int16 __stdcall dc_writeblock(HANDLE icdev,unsigned char flags,
								unsigned char startblock,unsigned char blocknum, 
								unsigned char *UID, 
								unsigned char wlen,unsigned char *rbuffer);
__int16 __stdcall dc_writeblock_hex(HANDLE icdev,unsigned char flags,
								unsigned char startblock,unsigned char blocknum, 
								unsigned char *UID, 
								unsigned char wlen,unsigned char *rbuffer);
__int16 __stdcall dc_lock_block(HANDLE icdev,unsigned char flags,unsigned char block,
								unsigned char *UID);
__int16 __stdcall dc_lock_block_hex(HANDLE icdev,unsigned char flags,unsigned char block,
								unsigned char *UID);
__int16 __stdcall dc_write_afi(HANDLE icdev,unsigned char flags,unsigned char AFI,
							   unsigned char *UID);
__int16 __stdcall dc_write_afi_hex(HANDLE icdev,unsigned char flags,unsigned char AFI,
							   unsigned char *UID);
__int16 __stdcall dc_lock_afi(HANDLE icdev,unsigned char flags,unsigned char AFI,
							  unsigned char *UID);
__int16 __stdcall dc_lock_afi_hex(HANDLE icdev,unsigned char flags,unsigned char AFI,
							  unsigned char *UID);
__int16 __stdcall dc_write_dsfid(HANDLE icdev,unsigned char flags,unsigned char DSFID,
								 unsigned char *UID);
__int16 __stdcall dc_write_dsfid_hex(HANDLE icdev,unsigned char flags,unsigned char DSFID,
								 unsigned char *UID);
__int16 __stdcall dc_lock_dsfid(HANDLE icdev,unsigned char flags,unsigned char DSFID,
								unsigned char *UID);
__int16 __stdcall dc_lock_dsfid_hex(HANDLE icdev,unsigned char flags,unsigned char DSFID,
								unsigned char *UID);
__int16 __stdcall dc_get_systeminfo(HANDLE icdev,unsigned char flags,
									unsigned char *UID, 
									unsigned char *rlen,unsigned char *rbuffer);
__int16 __stdcall dc_get_systeminfo_hex(HANDLE icdev,unsigned char flags,
									unsigned char *UID, 
									unsigned char *rlen,unsigned char *rbuffer);
__int16 __stdcall dc_get_securityinfo(HANDLE icdev,unsigned char flags,
									  unsigned char startblock,unsigned char blocknum, 
									  unsigned char *UID, 
									  unsigned char *rlen,unsigned char *rbuffer);
__int16 __stdcall dc_get_securityinfo_hex(HANDLE icdev,unsigned char flags,
									  unsigned char startblock,unsigned char blocknum, 
									  unsigned char *UID, 
									  unsigned char *rlen,unsigned char *rbuffer);

//------------------------------FM11RF005M------------------------------------
__int16 __stdcall  dc_getsnr_fm11rf005(HANDLE icdev,unsigned long *_Snr);
__int16 __stdcall  dc_getsnr_fm11rf005_hex(HANDLE icdev,unsigned char *snrstr);
__int16 __stdcall  dc_write_fm11rf005(HANDLE icdev,unsigned char _Adr,unsigned char *_Data);
__int16 __stdcall  dc_read_fm11rf005(HANDLE icdev,unsigned char _Adr,unsigned char *_Data);
__int16 __stdcall  dc_read_fm11rf005_hex(HANDLE icdev,unsigned char _Adr,char *_Data);
__int16 __stdcall  dc_write_fm11rf005_hex(HANDLE icdev,unsigned char _Adr,char *_Data);

//------------------------------z9 function----------------------------------------
__int16 __stdcall   DCDEV_CommandMcu(HANDLE idComDev,unsigned char ctimeout,unsigned char slen,unsigned char * sendbuffer,unsigned char *rlen,unsigned char * databuffer);
__int16 __stdcall   DCDEV_CommandMcu_Hex(HANDLE idComDev,unsigned char ctimeout,unsigned char slen,unsigned char * sendbuffer,unsigned char *rlen,unsigned char * databuffer);

__int16  __stdcall  dc_displcd(HANDLE idComDev,unsigned char flag);
__int16  __stdcall  dc_getinputpass(HANDLE idComDev,unsigned char ctime,unsigned char *rlen,unsigned char * cpass);
__int16  __stdcall  dc_readmagcard(HANDLE idComDev, unsigned char ctime, unsigned char *pTrack2Data, unsigned long *pTrack2Len, unsigned char *pTrack3Data, unsigned long *pTrack3Len);
__int16  __stdcall  dc_testdevicecomm(HANDLE idComDev);
__int16  __stdcall  dc_dispmainmenu(HANDLE idComDev);
__int16  __stdcall  dc_setdevicetime(HANDLE idComDev,
									 unsigned char year,
									 unsigned char month,
									 unsigned char date,
									 unsigned char hour,
									 unsigned char minute,
									 unsigned char second);
__int16  __stdcall  dc_getdevicetime(HANDLE idComDev,
									 unsigned char *year,
									 unsigned char *month,
									 unsigned char *date,
									 unsigned char *hour,
									 unsigned char *minute,
									 unsigned char *second);
__int16  __stdcall  dc_dispinfo(HANDLE idComDev,unsigned char line,unsigned char offset,char *data);
__int16  __stdcall  dc_dispmaininfo(HANDLE idComDev,unsigned char offset,char *data);
__int16  __stdcall  dc_posbeep(HANDLE idComDev,unsigned char beeptime);
__int16  __stdcall  dc_ctlbacklight(HANDLE idComDev, unsigned char cOpenFlag);
__int16  __stdcall  dc_ctlled(HANDLE idComDev, unsigned char cLed, unsigned char cOpenFlag);
__int16  __stdcall  dc_lcdclrscrn(HANDLE idComDev, unsigned char cLine);
__int16  __stdcall  dc_passin(HANDLE idComDev,unsigned char ctime);
__int16  __stdcall  dc_passget(HANDLE idComDev,unsigned char *rlen,unsigned char * cpass);
__int16  __stdcall  dc_passcancel(HANDLE idComDev);
__int16  __stdcall  dc_getinputkey(HANDLE idComDev,unsigned char disptype,unsigned char line,
							unsigned char ctime,unsigned char *rlen,unsigned char * ckeydata);
__int16  __stdcall  dc_displcd_ext(HANDLE idComDev,unsigned char flag,unsigned char row,
								   unsigned char offset);
__int16  __stdcall  dc_readmagcardall(HANDLE idComDev, unsigned char ctime, unsigned char *pTrack1Data, unsigned long *pTrack1Len,
									  unsigned char *pTrack2Data, unsigned long *pTrack2Len, unsigned char *pTrack3Data, unsigned long *pTrack3Len);
//-----------------------------z9 function end---------------------------------------------------
__int16  __stdcall  dc_readdevsnr(HANDLE idComDev,unsigned char *snr);
__int16  __stdcall  dc_readreadersnr(HANDLE idComDev,unsigned char *snr);
__int16  __stdcall  dc_resetdevice(HANDLE idComDev);

//-------------------------------------接触式同步卡操作函数--------------------------
__int16 __stdcall dc_read_4442(HANDLE icdev,__int16 offset,__int16 lenth,unsigned char * buffer);
__int16 __stdcall dc_read_4442_hex(HANDLE icdev,__int16 offset,__int16 lenth,unsigned char* buffer);
__int16 __stdcall dc_write_4442(HANDLE icdev,__int16 offset,__int16 lenth,unsigned char * buffer);
__int16 __stdcall dc_write_4442_hex(HANDLE icdev,__int16 offset,__int16 lenth,unsigned char* buffer);
__int16 __stdcall dc_verifypin_4442(HANDLE icdev,unsigned char *passwd);
__int16 __stdcall dc_verifypin_4442_hex(HANDLE icdev,unsigned char *passwd);
__int16 __stdcall dc_readpin_4442(HANDLE icdev,unsigned char *passwd);
__int16 __stdcall dc_readpin_4442_hex(HANDLE icdev,unsigned char *passwd);
__int16 __stdcall dc_readpincount_4442(HANDLE icdev);
__int16 __stdcall dc_changepin_4442(HANDLE icdev,unsigned char *passwd);
__int16 __stdcall dc_changepin_4442_hex(HANDLE icdev,unsigned char *passwd);
__int16 __stdcall dc_readwrotect_4442(HANDLE icdev,__int16 offset,__int16 leng,unsigned char *buffer);
__int16 __stdcall dc_readwrotect_4442_hex(HANDLE icdev,__int16 offset,__int16 leng,unsigned char *buffer);
__int16 __stdcall dc_writeprotect_4442(HANDLE icdev,__int16 offset,__int16 leng,unsigned char *buffer);
__int16 __stdcall dc_writeprotect_4442_hex(HANDLE icdev,__int16 offset,__int16 leng,unsigned char *buffer);

__int16 __stdcall dc_write_24c(HANDLE icdev,__int16 offset,__int16 lenth,unsigned char * snd_buffer);
__int16 __stdcall dc_write_24c_hex(HANDLE icdev,__int16 offset,__int16 lenth,unsigned char * snd_buffer);
__int16 __stdcall dc_write_24c64(HANDLE icdev,__int16 offset,__int16 lenth,unsigned char * snd_buffer);
__int16 __stdcall dc_write_24c64_hex(HANDLE icdev,__int16 offset,__int16 lenth,unsigned char * snd_buffer);
__int16 __stdcall dc_read_24c(HANDLE icdev,__int16 offset,__int16 lenth,unsigned char * receive_buffer);
__int16 __stdcall dc_read_24c_hex(HANDLE icdev,__int16 offset,__int16 lenth,unsigned char * receive_buffer);
__int16 __stdcall dc_read_24c64(HANDLE icdev,__int16 offset,__int16 lenth,unsigned char * receive_buffer);
__int16 __stdcall dc_read_24c64_hex(HANDLE icdev,__int16 offset,__int16 lenth,unsigned char * receive_buffer);


__int16 __stdcall dc_read_4428(HANDLE icdev,__int16 offset,__int16 lenth,unsigned char * buffer);
__int16 __stdcall dc_read_4428_hex(HANDLE icdev,__int16 offset,__int16 lenth,unsigned char* buffer);
__int16 __stdcall dc_write_4428(HANDLE icdev,__int16 offset,__int16 lenth,unsigned char * buffer);
__int16 __stdcall dc_write_4428_hex(HANDLE icdev,__int16 offset,__int16 lenth,unsigned char* buffer);
__int16 __stdcall dc_verifypin_4428(HANDLE icdev,unsigned char *passwd);
__int16 __stdcall dc_verifypin_4428_hex(HANDLE icdev,unsigned char *passwd);
__int16 __stdcall dc_readpin_4428(HANDLE icdev,unsigned char *passwd);
__int16 __stdcall dc_readpin_4428_hex(HANDLE icdev,unsigned char *passwd);
__int16 __stdcall dc_readpincount_4428(HANDLE icdev);
__int16 __stdcall dc_changepin_4428(HANDLE icdev,unsigned char *passwd);
__int16 __stdcall dc_changepin_4428_hex(HANDLE icdev,unsigned char *passwd);

__int16 __stdcall  dc_Check_4442(HANDLE icdev);
__int16 __stdcall  dc_Check_4428(HANDLE icdev);
__int16 __stdcall  dc_Check_24C01(HANDLE icdev);
__int16 __stdcall  dc_Check_24C02(HANDLE icdev);
__int16 __stdcall  dc_Check_24C04(HANDLE icdev);
__int16 __stdcall  dc_Check_24C08(HANDLE icdev);
__int16 __stdcall  dc_Check_24C16(HANDLE icdev);
__int16 __stdcall  dc_Check_24C64(HANDLE icdev);
__int16 __stdcall  dc_Check_CPU(HANDLE icdev);
__int16 __stdcall  dc_CheckCard(HANDLE icdev);

__int16 __stdcall  dc_getrcinfo(HANDLE icdev,unsigned char *info);
__int16 __stdcall  dc_getrcinfo_hex(HANDLE icdev,unsigned char *info);
__int16 __stdcall  dc_getlongver(HANDLE icdev,unsigned char *sver);

__int16 __stdcall  dc_cardstr(HANDLE icdev,unsigned char _Mode,char * Strsnr);

__int16 __stdcall  dc_cardAB(HANDLE icdev,unsigned char *rlen,unsigned char *rbuf,unsigned char *type);
__int16 __stdcall  dc_card_b(HANDLE icdev,unsigned char *rbuf);
__int16 __stdcall  dc_card_b_hex(HANDLE icdev,char *rbuf);

//T8 LCD显示函数
__int16 __stdcall  dc_dispinfo_T8(HANDLE idComDev,unsigned char line,unsigned char offset,char *data);
__int16 __stdcall  dc_dispinfo_pro_T8(HANDLE idComDev,unsigned char offset,char *data);
__int16 __stdcall  dc_clearlcd_T8(HANDLE icdev,unsigned char line);
__int16  __stdcall dc_led_T8(HANDLE icdev,unsigned char cled,unsigned char cflag);
__int16  __stdcall dc_dispmap_T8(HANDLE icdev,unsigned char *mapdata);


__int16 __stdcall  dc_rw_rfreg(HANDLE icdev,unsigned char flag,unsigned char _Adr,unsigned char *_Data);
__int16 __stdcall  dc_rw_rfreg_hex(HANDLE icdev,unsigned char flag,unsigned char _Adr,unsigned char *_Data);
__int16 __stdcall  dc_mulrequest_b(HANDLE icdev,unsigned char _Mode,unsigned char AFI, 
		                              unsigned char *cardnum, unsigned char *mulATQB);
__int16 __stdcall  dc_hltb(HANDLE icdev,unsigned char *PUPI);
__int16 __stdcall  dc_set_poweroff(HANDLE icdev,unsigned int MsTimes,unsigned char TimerClock,unsigned char TimerReload);

__int16 __stdcall dc_pro_commandsourceCRC(HANDLE idComDev,unsigned char slen,
									   unsigned char * sendbuffer,unsigned char *rlen,
									   unsigned char * databuffer,unsigned char timeout,unsigned char CRCSTU);
__int16 __stdcall dc_pro_commandsourceCRChex(HANDLE idComDev,unsigned char slen, 
										  char * sendbuffer,unsigned char *rlen, 
										  char * databuffer,unsigned char timeout,unsigned char CRCSTU);
//MF1PLUS函数
//0级函数
//0-0 设置个人化数据
__int16  __stdcall dc_MFPL0_writeperso(HANDLE icdev,unsigned int BNr,unsigned char * dataperso);
__int16  __stdcall dc_MFPL0_writeperso_hex(HANDLE icdev,unsigned int BNr,unsigned char * dataperso);
//0-1 个人化卡片 ，个人化后卡片进入1级状态
__int16  __stdcall dc_MFPL0_commitperso(HANDLE icdev);

//1级函数
//1-0  1级状态卡片认证函数
__int16  __stdcall dc_MFPL1_authl1key(HANDLE icdev,unsigned char *authkey);
__int16  __stdcall dc_MFPL1_authl1key_hex(HANDLE icdev,unsigned char *authkey);
//1-1  1级状态的卡片转换到2级
__int16  __stdcall dc_MFPL1_switchtol2(HANDLE icdev,unsigned char *authkey);
//1-2  1级状态的卡片转换到3级
__int16  __stdcall dc_MFPL1_switchtol3(HANDLE icdev,unsigned char *authkey);

//2级函数
//2-0  2级状态的卡片转换到3级
__int16  __stdcall dc_MFPL2_switchtol3(HANDLE icdev,unsigned char *authkey);

//3级函数
//3-0  3级状态卡片认证函数
__int16  __stdcall dc_MFPL3_authl3key(HANDLE icdev,unsigned int keyBNr,unsigned char *authkey);
__int16  __stdcall dc_MFPL3_authl3key_hex(HANDLE icdev,unsigned int keyBNr,unsigned char *authkey);
//3-1  3级状态卡片验证扇区密钥函数
__int16  __stdcall dc_MFPL3_authl3sectorkey(HANDLE icdev,unsigned char mode,unsigned int sectorBNr,unsigned char *authkey);
__int16  __stdcall dc_MFPL3_authl3sectorkey_hex(HANDLE icdev,unsigned char mode,unsigned int sectorBNr,unsigned char *authkey);
//3-2  3级读扇区
__int16  __stdcall dc_MFPL3_readinplain(HANDLE icdev,unsigned int BNr,unsigned char num, unsigned char *readdata);
__int16  __stdcall dc_MFPL3_readinplain_hex(HANDLE icdev,unsigned int BNr,unsigned char numblock, unsigned char *readdata);
__int16  __stdcall dc_MFPL3_readencrypted(HANDLE icdev,unsigned int BNr,unsigned char num,unsigned char *readdata, unsigned char flag);
__int16  __stdcall dc_MFPL3_readencrypted_hex(HANDLE icdev,unsigned int BNr,unsigned char numblock, unsigned char *readdata, unsigned char flag);
//3-3  3级写扇区
__int16  __stdcall dc_MFPL3_writeinplain(HANDLE icdev,unsigned int BNr,unsigned char Numblock,unsigned char *writedata);
__int16  __stdcall dc_MFPL3_writeinplain_hex(HANDLE icdev,unsigned int BNr,unsigned char Numblock,unsigned char *writedata);
__int16  __stdcall dc_MFPL3_writeencrypted(HANDLE icdev,unsigned int BNr,unsigned char Numblock,unsigned char *writedata, unsigned char flag);
__int16  __stdcall dc_MFPL3_writeencrypted_hex(HANDLE icdev,unsigned int BNr,unsigned char Numblock,unsigned char *writedata, unsigned char flag);
//ultralight c  
__int16 __stdcall  dc_auth_ulc(HANDLE icdev, unsigned char * key);
__int16 __stdcall  dc_auth_ulc_hex(HANDLE icdev, unsigned char * key);
__int16 __stdcall  dc_changekey_ulc(HANDLE icdev,unsigned char *newkey);
__int16 __stdcall  dc_changekey_ulc_hex(HANDLE icdev,unsigned char *newkey);

__int16 __stdcall  dc_getcpupara(HANDLE icdev,unsigned char cputype,unsigned char *cpupro,unsigned char *cpuetu);
__int16 __stdcall  dc_cpuapdusourceEXT(HANDLE icdev,__int16 slen,unsigned char * sendbuffer,__int16 *rlen,unsigned char * databuffer);
__int16 __stdcall  dc_cpuapdusourceEXT_hex(HANDLE icdev,__int16 slen, char * sendbuffer,__int16 *rlen, char * databuffer);
__int16 __stdcall  dc_cpuapduEXT(HANDLE icdev,__int16 slen,unsigned char * sendbuffer,__int16 *rlen,unsigned char * databuffer);
__int16 __stdcall  dc_cpuapduEXT_hex(HANDLE icdev,__int16 slen,char * sendbuffer,__int16 *rlen,char * databuffer);

__int16 __stdcall  dc_pro_commandlinkEXT(HANDLE idComDev,unsigned int slen,
								 unsigned char * sendbuffer,unsigned int *rlen,
								 unsigned char * databuffer,unsigned char timeout,
								 unsigned char FG);
__int16 __stdcall  dc_pro_commandlinkEXT_hex(HANDLE idComDev,unsigned int slen,
										 unsigned char * sendbuffer,unsigned int *rlen,
										 unsigned char * databuffer,unsigned char timeout,
										 unsigned char FG);
__int16 __stdcall  dc_exchangeblock(HANDLE idComDev,unsigned char slen,
									   unsigned char * sendbuffer,unsigned char *rlen,
									   unsigned char * databuffer,unsigned char timeout);
__int16 __stdcall  dc_exchangeblock_hex(HANDLE idComDev,unsigned char slen,
									   unsigned char * sendbuffer,unsigned char *rlen,
									   unsigned char * databuffer,unsigned char timeout);

__int16 __stdcall  dc_write1024(HANDLE icdev,unsigned long offset,unsigned long lenth,unsigned char *writebuffer);
__int16 __stdcall  dc_write1024_hex(HANDLE icdev,unsigned long offset,unsigned long lenth,unsigned char *writebuffer);
__int16 __stdcall  dc_read1024(HANDLE icdev,unsigned long offset,unsigned long lenth,unsigned char * databuffer);
__int16 __stdcall  dc_read1024_hex(HANDLE icdev,unsigned long offset,unsigned long lenth,unsigned char * databuffer);

__int16 __stdcall  dc_switch_linux(HANDLE icdev);
}