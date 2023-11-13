using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration;

namespace ProjektHundekennel.Models
{
	public class Owner
	{
		List<Owner> owners = new List<Owner>();

		public int ownerId { get; set; }

		public string? name { get; set; }

		public string? address { get; set; }

		public string? zipCode { get; set; }

        public string? city { get; set; }

        public string? phoneNumber { get; set; }

		public string? email { get; set; }



		public void CreateOwner(Owner ownerToBeCreated)
		{
			IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

			string? ConnectionString = config.GetConnectionString("MyDBConnection");

			using (SqlConnection con = new SqlConnection(ConnectionString))
			{
				con.Open();
				SqlCommand cmd = new SqlCommand("INSERT INTO Owner (Name, Address, ZipCode, City, PhoneNumber, Email)" +

					"VALUES(@Name, @Address, @ZipCode, @City, @PhoneNumber, @Email)" +
					"SELECT @@IDENTITY", con);

				cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = ownerToBeCreated.name;

				cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = ownerToBeCreated.address;

				cmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = ownerToBeCreated.zipCode;

				cmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = ownerToBeCreated.city;

				cmd.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = ownerToBeCreated.phoneNumber;

				cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = ownerToBeCreated.email;

				ownerToBeCreated.ownerId = Convert.ToInt32(cmd.ExecuteScalar());

				owners.Add(ownerToBeCreated);
			}

			//this.ownerId = ownerId;
			//this.name = name;
			//this.phoneNumber = phoneNumber;			
		}

		public void ViewOwner()
		{
			IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

			string? ConnectionString = config.GetConnectionString("MyDBConnection");

			using (SqlConnection con = new SqlConnection(ConnectionString))
			{
				con.Open();
				SqlCommand cmd = new SqlCommand("SELECT OwnerId, Name, Address, ZipCode, City, PhoneNumber, Email FROM Owner", con);

				using (SqlDataReader dr = cmd.ExecuteReader())
				{
					while (dr.Read())
					{ 
						Owner owner = new Owner();
						{
							ownerId = int.Parse(dr["OwnerId"].ToString());
							name = dr["Name"].ToString();
							address = dr["Address"].ToString();
							zipCode = dr["ZipCode"].ToString();
							city = dr["City"].ToString();
							phoneNumber = dr["PhoneNumber"].ToString();
							email = dr["Email"].ToString();
						};
						owners.Add(owner);
					}

				}
			}
		}

		public void UpdateOwner(Owner ownerToBeUpdated)
		{
			IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

			string? ConnectionString = config.GetConnectionString("MyDBConnection");

			using (SqlConnection con = new SqlConnection(ConnectionString))
			{
				con.Open();
				SqlCommand cmd = new SqlCommand("UPDATE Owner SET Name = @Name, Address = @Address, ZipCode = @ZipCode, City = @City, PhoneNumber = @PhoneNumber, Email = @Email WHERE OwnerId = @OwnerId", con);

				cmd.Parameters.Add("@OwnerId", SqlDbType.NVarChar).Value = ownerToBeUpdated.ownerId;

				cmd.ExecuteNonQuery();
			}
		}

		public void DeleteOwner(Owner ownerToBeDeleted)
		{
			IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

			string? ConnectionString = config.GetConnectionString("MyDBConnection");

			using (SqlConnection con = new SqlConnection(ConnectionString))
			{
				con.Open();
				SqlCommand cmd = new SqlCommand("DELETE FROM Owner WHERE OwnerId = @OwnerId", con);

				cmd.Parameters.Add("@OwnerId", SqlDbType.NVarChar).Value = ownerToBeDeleted;

				cmd.ExecuteNonQuery();
			}
			owners.Remove(ownerToBeDeleted);
		}

		
	}
}
