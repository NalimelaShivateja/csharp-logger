using System.Data.SqlClient;
using System.IO;
using System.IO.Enumeration;
using static System.Data.SqlClient.SqlConnection;

namespace LogLibrary;
public interface ILogger
{
	static void WriteMessage(string msg, string filePath = null){}
}

public class ConsoleLogger : ILogger
{
	public static void WriteMessage(string msg, string filePath = null)
	{
		Console.WriteLine(msg);
	}
}

public class FileLogger : ILogger
{
	public static void WriteToFile(string msg, string filePath)
	{
		using(var fileWriter = new StreamWriter(filePath))
		{
			fileWriter.WriteLine(msg);
		}
	}
	public static void WriteMessage(string msg, string filePath)
	{
		try
		{
			if(File.Exists(filePath))
			{
				WriteToFile(msg, filePath);
			}
		}
		catch(Exception)
		{
			File.Create(filePath);
			WriteToFile(msg, filePath);
		}
	}
}

public class DBLogger : ILogger
{
	public static void WriteMessage(string msg, string filePath = null)
	{
		try
		{
			string connectionString = "databasepath";
			var conn = new SqlConnection(connectionString);
			conn.Open();
			string insert_query = "insert into Table (user_message) values (@msg)";
			SqlCommand cmd = new SqlCommand(insert_query, conn);
			cmd.Parameters.AddWithValue("user_nessage", msg);
			conn.Close();
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}
}