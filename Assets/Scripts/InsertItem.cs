﻿using UnityEngine;
using System.Collections;
using Mono.Data.SqliteClient;
using System.Data;
using System;
using UnityEngine.UI;

public class InsertItem : MonoBehaviour {

	public InputField nameInput;
	public InputField passwordInput;

	public void Insert(){
		string connectionString = "URI=file:" + Application.dataPath + "/myDatabase.db"; //Path to database.
		IDbConnection dbconn;
		dbconn = (IDbConnection) new SqliteConnection(connectionString);

		dbconn.Open(); //Open connection to the database.

		IDbCommand dbcmd = dbconn.CreateCommand();

		string sqlQuery = "insert into Account (userName,password) values ('"+ nameInput.text +"','"+ passwordInput.text +"')";
		dbcmd.CommandText = sqlQuery;

		IDataReader reader = dbcmd.ExecuteReader();

		reader.Close();reader = null;
		dbcmd.Dispose();dbcmd = null;
		dbconn.Close();dbconn = null;
	}
}
