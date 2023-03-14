#include "pch.h"
#include "PCANBasicCLR.h"

using namespace Peak::Can::Basic;
using namespace System;
using namespace System::Threading;

public ref class EventDrivenRead
{
#pragma region Defines
private:
	/// <summary>
	/// Sets the PCANHandle (Hardware Channel)
	/// </summary>
	literal TPCANHandle PcanHandle = PCANBasic::PCAN_USBBUS1;
	/// <summary>
	/// Sets the desired connection mode (CAN = false / CAN-FD = true)
	/// </summary>
	literal bool IsFD = false;
	/// <summary>
	/// Sets the bitrate for normal CAN devices
	/// </summary>
	literal TPCANBaudrate Bitrate = TPCANBaudrate::PCAN_BAUD_500K;
	/// <summary>
	/// Sets the bitrate for CAN FD devices. 
	/// Example - Bitrate Nom: 1Mbit/s Data: 2Mbit/s:
	///   "f_clock_mhz=20, nom_brp=5, nom_tseg1=2, nom_tseg2=1, nom_sjw=1, data_brp=2, data_tseg1=3, data_tseg2=1, data_sjw=1"
	/// </summary>
	literal TPCANBitrateFD BitrateFD = "f_clock_mhz=20, nom_brp=5, nom_tseg1=2, nom_tseg2=1, nom_sjw=1, data_brp=2, data_tseg1=3, data_tseg2=1, data_sjw=1";
#pragma endregion

#pragma region Members
private:
	/// <summary>
	/// Shows if DLL was found
	/// </summary>
	bool m_DLLFound;
	/// <summary>
	/// Thread for reading messages
	/// </summary>
	Thread^ m_ReadThread;
	/// <summary>
	/// Shows if thread run
	/// </summary>
	bool m_ThreadRun;
#pragma endregion

	/// <summary>
	/// Starts the PCANBasic Sample
	/// </summary>
public: EventDrivenRead()
{
	ShowConfigurationHelp(); // Shows information about this sample
	ShowCurrentConfiguration(); // Shows the current parameters configuration

	// Checks if PCANBasic.dll is available, if not, the program terminates
	m_DLLFound = CheckForLibrary();
	if (!m_DLLFound)
		return;

	TPCANStatus stsResult;
	// Initialization of the selected channel
	if (IsFD)
		stsResult = PCANBasic::InitializeFD(PcanHandle, (String^)BitrateFD);
	else
		stsResult = PCANBasic::Initialize(PcanHandle, Bitrate);

	if (stsResult != TPCANStatus::PCAN_ERROR_OK)
	{
		Console::WriteLine("Can not initialize. Please check the defines in the code.");
		ShowStatus(stsResult);
		Console::WriteLine();
		Console::WriteLine("Press any key to close");
		Console::Read();
		return;
	}

	// Reading messages...
	Console::WriteLine("Successfully initialized.");
	m_ReadThread = gcnew Thread(gcnew ThreadStart(this, &EventDrivenRead::ThreadExecute));
	m_ThreadRun = true;
	m_ReadThread->Start();
	Console::WriteLine("Started reading messages...");
	Console::WriteLine("");
	Console::WriteLine("Press any key to close");
	Console::ReadKey();
	m_ThreadRun = false;
	m_ReadThread->Join();
}

public: ~EventDrivenRead()
{
	if (m_DLLFound)
		PCANBasic::Uninitialize(PCANBasic::PCAN_NONEBUS);
}

#pragma region Main-Functions
private:
	/// <summary>
	/// Thread function for reading messages
	/// </summary>
	void ThreadExecute()
	{
		// Sets the handle of the Receive-Event.
		AutoResetEvent^ evtReceiveEvent = gcnew AutoResetEvent(false);
		UInt32 iBuffer = Convert::ToUInt32(evtReceiveEvent->SafeWaitHandle->DangerousGetHandle().ToInt32());
		TPCANStatus stsResult = PCANBasic::SetValue(PcanHandle, TPCANParameter::PCAN_RECEIVE_EVENT, iBuffer, sizeof(UInt32));

		if (stsResult != TPCANStatus::PCAN_ERROR_OK)
		{
			ShowStatus(stsResult);
			return;
		}

		while (m_ThreadRun)
			// Checks for messages when an event is received
			if (evtReceiveEvent->WaitOne(50))
				ReadMessages();

		// Removes the Receive-Event again.
		iBuffer = 0;
		stsResult = PCANBasic::SetValue(PcanHandle, TPCANParameter::PCAN_RECEIVE_EVENT, iBuffer, sizeof(UInt32));

		if (stsResult != TPCANStatus::PCAN_ERROR_OK)
			ShowStatus(stsResult);
		evtReceiveEvent->Close();
	}

	/// <summary>
	/// Function for reading PCAN-Basic messages
	/// </summary>
	void ReadMessages()
	{
		TPCANStatus stsResult;

		// We read at least one time the queue looking for messages. If a message is found, we look again trying to 
		// find more. If the queue is empty or an error occurr, we get out from the dowhile statement.
		do
		{
			stsResult = IsFD ? ReadMessageFD() : ReadMessage();
			if (stsResult != TPCANStatus::PCAN_ERROR_OK && stsResult != TPCANStatus::PCAN_ERROR_QRCVEMPTY)
			{
				ShowStatus(stsResult);
				return;
			}
		} while ((!Convert::ToBoolean(stsResult & TPCANStatus::PCAN_ERROR_QRCVEMPTY)));
	}

	/// <summary>
	/// Function for reading messages on CAN-FD devices
	/// </summary>
	/// <returns>A TPCANStatus error code</returns>
	TPCANStatus ReadMessageFD()
	{
		TPCANMsgFD CANMsg;
		TPCANTimestampFD CANTimeStamp;

		// We execute the "Read" function of the PCANBasic    
		TPCANStatus stsResult = PCANBasic::ReadFD(PcanHandle, CANMsg, CANTimeStamp);
		if (stsResult != TPCANStatus::PCAN_ERROR_QRCVEMPTY)
			// We process the received message
			ProcessMessageCanFD(CANMsg, CANTimeStamp);

		return stsResult;
	}

	/// <summary>
	/// Function for reading CAN messages on normal CAN devices
	/// </summary>
	/// <returns>A TPCANStatus error code</returns>
	TPCANStatus ReadMessage()
	{
		TPCANMsg CANMsg;
		TPCANTimestamp CANTimeStamp;

		// We execute the "Read" function of the PCANBasic   
		TPCANStatus stsResult = PCANBasic::Read(PcanHandle, CANMsg, CANTimeStamp);
		if (stsResult != TPCANStatus::PCAN_ERROR_QRCVEMPTY)
			// We process the received message
			ProcessMessageCan(CANMsg, CANTimeStamp);

		return stsResult;
	}

	/// <summary>
	/// Processes a received CAN message
	/// </summary>
	/// <param name="msg">The received PCAN-Basic CAN message</param>        
	/// <param name="itsTimeStamp">Timestamp of the message as TPCANTimestamp structure</param>
	void ProcessMessageCan(TPCANMsg msg, TPCANTimestamp itsTimeStamp)
	{
		UInt64 microsTimestamp = Convert::ToUInt64(itsTimeStamp.micros + 1000 * itsTimeStamp.millis + 0x100000000 * 1000 * itsTimeStamp.millis_overflow);

		Console::WriteLine("Type: " + GetMsgTypeString(msg.MSGTYPE));
		Console::WriteLine("ID: " + GetIdString(msg.ID, msg.MSGTYPE));
		Console::WriteLine("Length: " + msg.LEN.ToString());
		Console::WriteLine("Time: " + GetTimeString(microsTimestamp));
		Console::WriteLine("Data: " + GetDataString(msg.DATA, msg.MSGTYPE, msg.LEN));
		Console::WriteLine("----------------------------------------------------------");
	}

	/// <summary>
	/// Processes a received CAN-FD message
	/// </summary>
	/// <param name="msg">The received PCAN-Basic CAN-FD message</param>
	/// <param name="itsTimeStamp">Timestamp of the message as microseconds (ulong)</param>
	void ProcessMessageCanFD(TPCANMsgFD msg, TPCANTimestampFD itsTimeStamp)
	{
		Console::WriteLine("Type: " + GetMsgTypeString(msg.MSGTYPE));
		Console::WriteLine("ID: " + GetIdString(msg.ID, msg.MSGTYPE));
		Console::WriteLine("Length: " + GetLengthFromDLC(msg.DLC).ToString());
		Console::WriteLine("Time: " + GetTimeString(itsTimeStamp));
		Console::WriteLine("Data: " + GetDataString(msg.DATA, msg.MSGTYPE, GetLengthFromDLC(msg.DLC)));
		Console::WriteLine("----------------------------------------------------------");
	}
#pragma endregion

#pragma region Help-Functions
private:
	/// <summary>
	/// Checks for availability of the PCANBasic labrary
	/// </summary>
	/// <returns>If the library was found or not</returns>
	bool CheckForLibrary()
	{
		// Check for dll file
		try
		{
			PCANBasic::Uninitialize(PCANBasic::PCAN_NONEBUS);
			return true;
		}
		catch (DllNotFoundException^)
		{
			Console::WriteLine("Unable to find the library: PCANBasic::dll !");
			Console::WriteLine("Press any key to close");
			Console::ReadKey();
		}

		return false;
	}

	/// <summary>
	/// Shows/prints the configurable parameters for this sample and information about them
	/// </summary>
	void ShowConfigurationHelp()
	{
		Console::WriteLine("=========================================================================================");
		Console::WriteLine("|                           PCAN-Basic EventDrivenRead Example                           |");
		Console::WriteLine("=========================================================================================");
		Console::WriteLine("Following parameters are to be adjusted before launching, according to the hardware used |");
		Console::WriteLine("                                                                                         |");
		Console::WriteLine("* PcanHandle: Numeric value that represents the handle of the PCAN-Basic channel to use. |");
		Console::WriteLine("              See 'PCAN-Handle Definitions' within the documentation                     |");
		Console::WriteLine("* IsFD: Boolean value that indicates the communication mode, CAN (false) or CAN-FD (true)|");
		Console::WriteLine("* Bitrate: Numeric value that represents the BTR0/BR1 bitrate value to be used for CAN   |");
		Console::WriteLine("           communication                                                                 |");
		Console::WriteLine("* BitrateFD: String value that represents the nominal/data bitrate value to be used for  |");
		Console::WriteLine("             CAN-FD communication                                                        |");
		Console::WriteLine("=========================================================================================");
		Console::WriteLine("");
	}

	/// <summary>
	/// Shows/prints the configured paramters
	/// </summary>
	void ShowCurrentConfiguration()
	{
		Console::WriteLine("Parameter values used");
		Console::WriteLine("----------------------");
		Console::WriteLine("* PCANHandle: " + FormatChannelName(PcanHandle, IsFD));
		Console::WriteLine("* IsFD: " + IsFD);
		Console::WriteLine("* Bitrate: " + ConvertBitrateToString(Bitrate));
		Console::WriteLine("* BitrateFD: " + BitrateFD);
		Console::WriteLine("");
	}

	/// <summary>
	/// Shows formatted status
	/// </summary>
	/// <param name="status">Will be formatted</param>
	void ShowStatus(TPCANStatus status)
	{
		Console::WriteLine("=========================================================================================");
		Console::WriteLine(GetFormattedError(status));
		Console::WriteLine("=========================================================================================");
	}

	/// <summary>
	/// Gets the formatted text for a PCAN-Basic channel handle
	/// </summary>
	/// <param name="handle">PCAN-Basic Handle to format</param>
	/// <param name="isFD">If the channel is FD capable</param>
	/// <returns>The formatted text for a channel</returns>
	String^ FormatChannelName(TPCANHandle handle, bool isFD)
	{
		TPCANDevice devDevice;
		Byte byChannel;

		// Gets the owner device and channel for a PCAN-Basic handle
		if (handle < 0x100)
		{
			devDevice = (TPCANDevice)(handle >> 4);
			byChannel = (Byte)(handle & 0xF);
		}
		else
		{
			devDevice = (TPCANDevice)(handle >> 8);
			byChannel = (Byte)(handle & 0xFF);
		}

		// Constructs the PCAN-Basic Channel name and return it
		if (isFD)
			return String::Format("{0}:FD {1} ({2:X2}h)", devDevice, byChannel, handle);

		return String::Format("{0} {1} ({2:X2}h)", devDevice, byChannel, handle);
	}

	/// <summary>
	/// Help Function used to get an error as text
	/// </summary>
	/// <param name="error">Error code to be translated</param>
	/// <returns>A text with the translated error</returns>
	String^ GetFormattedError(TPCANStatus error)
	{
		// Creates a buffer big enough for a error-text
		StringBuilder^ strTemp = gcnew StringBuilder(256);
		// Gets the text using the GetErrorText API function. If the function success, the translated error is returned. 
		// If it fails, a text describing the current error is returned.
		if (PCANBasic::GetErrorText(error, 0x09, strTemp) != TPCANStatus::PCAN_ERROR_OK)
			return String::Format("An error occurred. Error-code's text ({0:X}) couldn't be retrieved", error);

		return strTemp->ToString();
	}

	/// <summary>
	/// Convert bitrate c_short value to readable string
	/// </summary>
	/// <param name="bitrate">Bitrate to be converted</param>
	/// <returns>A text with the converted bitrate</returns>
	String^ ConvertBitrateToString(TPCANBaudrate bitrate)
	{
		switch (bitrate)
		{
		case TPCANBaudrate::PCAN_BAUD_1M:
			return "1 MBit/sec";
		case TPCANBaudrate::PCAN_BAUD_800K:
			return "800 kBit/sec";
		case TPCANBaudrate::PCAN_BAUD_500K:
			return "500 kBit/sec";
		case TPCANBaudrate::PCAN_BAUD_250K:
			return "250 kBit/sec";
		case TPCANBaudrate::PCAN_BAUD_125K:
			return "125 kBit/sec";
		case TPCANBaudrate::PCAN_BAUD_100K:
			return "100 kBit/sec";
		case TPCANBaudrate::PCAN_BAUD_95K:
			return "95,238 kBit/sec";
		case TPCANBaudrate::PCAN_BAUD_83K:
			return "83,333 kBit/sec";
		case TPCANBaudrate::PCAN_BAUD_50K:
			return "50 kBit/sec";
		case TPCANBaudrate::PCAN_BAUD_47K:
			return "47,619 kBit/sec";
		case TPCANBaudrate::PCAN_BAUD_33K:
			return "33,333 kBit/sec";
		case TPCANBaudrate::PCAN_BAUD_20K:
			return "20 kBit/sec";
		case TPCANBaudrate::PCAN_BAUD_10K:
			return "10 kBit/sec";
		case TPCANBaudrate::PCAN_BAUD_5K:
			return "5 kBit/sec";
		default:
			return "Unknown Bitrate";
		}
	}

	/// <summary>
	/// Gets the string representation of the type of a CAN message
	/// </summary>
	/// <param name="msgType">Type of a CAN message</param>
	/// <returns>The type of the CAN message as string</returns>
	String^ GetMsgTypeString(TPCANMessageType msgType)
	{
		if ((msgType & TPCANMessageType::PCAN_MESSAGE_STATUS) == TPCANMessageType::PCAN_MESSAGE_STATUS)
			return "STATUS";

		if ((msgType & TPCANMessageType::PCAN_MESSAGE_ERRFRAME) == TPCANMessageType::PCAN_MESSAGE_ERRFRAME)
			return "ERROR";

		String^ strTemp;
		if ((msgType & TPCANMessageType::PCAN_MESSAGE_EXTENDED) == TPCANMessageType::PCAN_MESSAGE_EXTENDED)
			strTemp = "EXT";
		else
			strTemp = "STD";

		if ((msgType & TPCANMessageType::PCAN_MESSAGE_RTR) == TPCANMessageType::PCAN_MESSAGE_RTR)
			strTemp += "/RTR";
		else
			if ((int)msgType > (int)TPCANMessageType::PCAN_MESSAGE_EXTENDED)
			{
				strTemp += " [ ";
				if ((msgType & TPCANMessageType::PCAN_MESSAGE_FD) == TPCANMessageType::PCAN_MESSAGE_FD)
					strTemp += " FD";
				if ((msgType & TPCANMessageType::PCAN_MESSAGE_BRS) == TPCANMessageType::PCAN_MESSAGE_BRS)
					strTemp += " BRS";
				if ((msgType & TPCANMessageType::PCAN_MESSAGE_ESI) == TPCANMessageType::PCAN_MESSAGE_ESI)
					strTemp += " ESI";
				strTemp += " ]";
			}

		return strTemp;
	}

	/// <summary>
	/// Gets the string representation of the ID of a CAN message
	/// </summary>
	/// <param name="id">Id to be parsed</param>
	/// <param name="msgType">Type flags of the message the Id belong</param>
	/// <returns>Hexadecimal representation of the ID of a CAN message</returns>
	String^ GetIdString(UInt32 id, TPCANMessageType msgType)
	{
		if ((msgType & TPCANMessageType::PCAN_MESSAGE_EXTENDED) == TPCANMessageType::PCAN_MESSAGE_EXTENDED)
			return String::Format("{0:X8}h", id);

		return String::Format("{0:X3}h", id);
	}

	/// <summary>
	/// Gets the data length of a CAN message
	/// </summary>
	/// <param name="dlc">Data length code of a CAN message</param>
	/// <returns>Data length as integer represented by the given DLC code</returns>
	int GetLengthFromDLC(Byte dlc)
	{
		switch (dlc)
		{
		case 9: return 12;
		case 10: return 16;
		case 11: return 20;
		case 12: return 24;
		case 13: return 32;
		case 14: return 48;
		case 15: return 64;
		default: return dlc;
		}
	}

	/// <summary>
	/// Gets the string representation of the timestamp of a CAN message, in milliseconds
	/// </summary>
	/// <param name="time">Timestamp in microseconds</param>
	/// <returns>String representing the timestamp in milliseconds</returns>
	String^ GetTimeString(TPCANTimestampFD time)
	{
		double fTime = (time / 1000.0);
		return fTime.ToString("F1");
	}

	/// <summary>
	/// Gets the data of a CAN message as a string
	/// </summary>
	/// <param name="data">Array of bytes containing the data to parse</param>
	/// <param name="msgType">Type flags of the message the data belong</param>
	/// <param name="dataLength">The amount of bytes to take into account wihtin the given data</param>
	/// <returns>A string with hexadecimal formatted data bytes of a CAN message</returns>
	String^ GetDataString(array<Byte>^ data, TPCANMessageType msgType, int dataLength)
	{
		if ((msgType & TPCANMessageType::PCAN_MESSAGE_RTR) == TPCANMessageType::PCAN_MESSAGE_RTR)
			return "Remote Request";
		else
		{
			String^ strTemp = "";
			for (int i = 0; i < dataLength; i++)
				strTemp += String::Format("{0:X2} ", data[i]);
			return strTemp;
		}
	}
#pragma endregion

};


int main(array<System::String^>^ args)
{
	EventDrivenRead^ start = gcnew EventDrivenRead();
	return 0;
}
