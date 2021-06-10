using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.Json;
using System.Web;

namespace SnagajobAPIAssignment.Models
{
    public class ApplicationManagement
    {

        // checks if the application answers questions correctly and inserts it into the database if it does
        public void ProcessApplication(Application app)
        {
            if (app == null)
                return;

            Dictionary<int, string> validAnswers = new Dictionary<int, string>();

            // fetch our valid answers from SQL
            string connectionString = @"Server=tcp:apiassessmentserver.database.windows.net,1433;Initial Catalog=APIAssessmentSQL;Persist Security Info=False;User ID=application_system;Password=Password1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand retrieveAnswers = new SqlCommand("SELECT * FROM Question", connection);
            connection.Open();
            SqlDataReader reader = retrieveAnswers.ExecuteReader();
            while(reader.Read())
            {   
                validAnswers.Add((int)reader["Question_ID"], reader["ValidAnswer"].ToString());
            }
            connection.Close();

            // check the current application against those valid answers
            bool validApp = true; 
            foreach (ApplicationAnswer answer in app.Questions)
            {
                // confirm that the id exists in the list of valid answers
                if (!validAnswers.TryGetValue(answer.Id, out string validAnswer))
                    validApp = false;
                else if (validAnswer != answer.Answer)
                    validApp = false;
                if (validApp == false)
                    break;
            }

            // if it passes, store it in SQL 
            if (validApp)
            {
                SqlCommand command = new SqlCommand("INSERT INTO dbo.Application (ApplicationJson) VALUES ('" + JsonSerializer.Serialize(app) + "')", connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
            }

        }

        // gets all applications that have been added to the database by ProcessAppplication
        public List<string> FetchApplications()
        {
            List<string> applications = new List<string>();

            string connectionString = @"Server=tcp:apiassessmentserver.database.windows.net,1433;Initial Catalog=APIAssessmentSQL;Persist Security Info=False;User ID=application_system;Password=Password1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand retrieveAnswers = new SqlCommand("SELECT * FROM Application", connection);
            connection.Open();
            SqlDataReader reader = retrieveAnswers.ExecuteReader();
            while (reader.Read())
            {
                applications.Add(reader["ApplicationJson"].ToString());
            }
            connection.Close();

            return applications;
        }
    }
}