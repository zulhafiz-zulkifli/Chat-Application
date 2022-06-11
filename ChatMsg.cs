using System;

public class ChatMsg
{
	public string Name { get; set; }
	public string Body { get; set; }
	public DateTime Timestamp { get; set; }

	public ChatMsg()
    {
	}

	public string getMessageWithoutName()
    {
		string fullMessage = Body + " [" + Timestamp.ToString("t") + "]";
		return fullMessage;
    }

	public string getMessage()
	{
		string fullMessage = Name + " : " + Body + " [" + Timestamp.ToString("t") + "]";
		return fullMessage;
	}

}
