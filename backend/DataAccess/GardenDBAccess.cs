using Microsoft.Data.SqlClient;
using Models;
using Serilog;

namespace DataAccess;

public class GardenDBAccess : IDBAccess<Garden>
{
    private readonly SqlConnectionFactory _factory;

    public GardenDBAccess(SqlConnectionFactory factory)
    {
        _factory = factory;
    }

    public Garden Add(Garden garden)
    {
        Garden temp = new();
        using SqlConnection connection = _factory.GetConnection();
        SqlTransaction transaction = connection.BeginTransaction();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.Transaction = transaction;
        try
        {
            cmd.CommandText = "select id from Plants where name = 'dirt';";
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                Guid dirt_id = (Guid)reader["id"];
                reader.Close();

                cmd.CommandText = "insert into Garden (id,User_id) values (@gid,@uid);";
                cmd.Parameters.AddWithValue("@gid", temp.id);
                cmd.Parameters.AddWithValue("@uid", garden.user_id);
                cmd.ExecuteNonQuery();


                for (int i = 0; i < 16; i++)
                {
                    Tile tile = new Tile { garden_id = temp.id, position = i };
                    cmd.CommandText = @"insert into Tiles 
                                        (id,gardenId,position,plantId,plantTime,groundTime) 
                                            VALUES
                                        (@id,@gid,@pos,@pid,@pt,@gt);";
                    cmd.Parameters.AddWithValue("@id", tile.id);
                    cmd.Parameters.AddWithValue("@gid", temp.id);
                    cmd.Parameters.AddWithValue("@pos", i);
                    cmd.Parameters.AddWithValue("@pid", dirt_id);
                    cmd.Parameters.AddWithValue("@pt", tile.plant_time);
                    cmd.Parameters.AddWithValue("@gt", tile.ground_time);
                    cmd.ExecuteNonQuery();
                }

            }
            temp = GetById(temp.id);
        }
        catch (SqlException e)
        {
            Log.Error(e, "An error occured while creating a new garden resource, attempting db rollback");
            try
            {
                transaction.Rollback();
                Log.Information("Rollback succeeded!");
            }
            catch (Exception e2)
            {
                Log.Error(e2, "Failed to rollback transaction");
            }
        }

        return temp;
    }

    public Garden Delete(Garden t)
    {
        throw new NotImplementedException();
    }

    public List<Garden> GetAll()
    {
        throw new NotImplementedException();
    }

    public Garden GetById(Guid id)
    {
        Garden temp = new();

        try
        {

        }
        catch (SqlException e)
        {
            Log.Error(e, "An exception was thrown while getting garden");
        }

        return temp;
    }

    public Garden Update(Garden t)
    {
        throw new NotImplementedException();
    }
}