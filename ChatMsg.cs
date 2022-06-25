using System;

public class ChatMsg
{
	public string Name { get; set; }
	public string Body { get; set; }
	public DateTime Timestamp { get; set; }
	public string WS {get;}

public ChatMsg()
    {
		WS = ((char)160).ToString() + ((char)160).ToString();
	}

	public string getMessage()
    {
		string msg = WS + Body + WS;
		return msg;
    }

	public string getTime()
    {
		string msg = "[" + Timestamp.ToString("t") + "]" + WS;
		return msg;
    }

	public string getName()
    {
		string msg = WS + Name + WS;
		return msg;
	}
	public string exportMessage()
	{
		string msg = Name + " : " + Body + " [" + Timestamp.ToString("t") + "]" + "\r\n";
		return msg;
	}
}
