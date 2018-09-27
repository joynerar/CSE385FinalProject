using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Services;


/// <summary>
///		Sample application to demonstrate a C# API
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class armstrongAPI : System.Web.Services.WebService {

	#region ######################################################################################################################################################## Notes
	    /*	Dynamic object Example ...
		    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
		    Dictionary<string, object> row = new Dictionary<string, object>();
		    row.Add("Make", "G35");
		    row.Add("Model", "25 -18 Turbo");
		    row.Add("Year", 2014);
		    rows.Add(row);

		    row = new Dictionary<string, object>();
		    row.Add("Make", "Honda");
		    row.Add("Model", "Accord");
		    row.Add("Year", 2015);
		    rows.Add(row);

		    serialize(rows);
	    */
	#endregion

	#region ######################################################################################################################################################## Wrapper Methods [DON'T MODIFY]

		// Database
		private void addParam(string name, object value)						{	Helper.addParam(name, value);							}
		private DataSet sqlExecDataSet(string sql)								{	return Helper.sqlExecDataSet(sql);						}
		private DataTable sqlExecDataTable(string sql)							{	return Helper.sqlExecDataTable(sql);					}
		private DataTable sqlExec(string sql)									{	return Helper.sqlExec(sql);								}
		private DataTable sqlExec(string sql, DataTable dt, string udtblParam)	{	return Helper.sqlExec(sql, dt, udtblParam);				}
		private DataTable sqlExecQuery(string sql)								{	return Helper.sqlExecQuery(sql);						}

		// Serializer
		private void streamJson(string jsonString)								{	Helper.streamJson(jsonString);							}
		private void serialize(Object obj)										{	Helper.serialize(obj);									}
		private void serializeSingleDataTableRow(DataTable dt)					{	Helper.serializeSingleDataTableRow(dt);					}
		private void serializeDataTable(DataTable dt)							{	Helper.serializeDataTable(dt);							}
		private void serializeDataSet(DataSet ds)								{	Helper.serializeDataSet(ds);							}
		private void serializeXML<T>(T value)									{	Helper.serializeXML(value);								}
		private void serializeDictionary(Dictionary<object, object> dic)		{	Helper.serializeDictionary(dic);						}
		private void serializeObject(Object obj)								{	Helper.serializeObject(obj);							}

		// Going to leave this out so we don't need to import Newtonsoft.Json package
		//private T _download_serialized_json_data<T>(string url) where T : new()	{	return Helper._download_serialized_json_data<T>(url);	}

	#endregion


	//=== Web Service Methods Follow Below
    [WebMethod(Description = "Return all Students")]
    public void returnAllStudents()
    { 
        serializeDataTable(sqlExec("spAllStudents"));
    }

    [WebMethod(Description = "Return all Organizations")]
    public void returnAllOrgs()
    {
        serializeDataTable(sqlExec("spAllOrganizations"));
    }
	
	[WebMethod(Description = "Return all zero Hour Student")]
    public void zeroHourLogins()
    {
        serializeDataTable(sqlExec("spSelectZeroHourLogins"));
    }


    [WebMethod(Description = "Return Average hours of all Organizations")]
    public void getAverageOfAllOrgs(DateTime startTime, DateTime endTime)
    {
        addParam("@startTime", startTime);
        addParam("@endTime", endTime);
        serializeDataTable(sqlExec("spAverageHoursAllOrganizations"));
    }

    [WebMethod(Description = "Return Average hours of a single Organizations")]
    public void getAverageOfSingleOrg(DateTime startTime, DateTime endTime, String OrganizationName)
    {
        addParam("@startTime", startTime);
        addParam("@endTime", endTime);
        addParam("@OrganizationName", OrganizationName);
        serializeDataTable(sqlExec("spAverageHoursSingleOrganization"));
    }
}
