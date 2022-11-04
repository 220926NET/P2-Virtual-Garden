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
        connection.Open();
        SqlTransaction transaction = connection.BeginTransaction();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.Transaction = transaction;
        try
        {
            SqlConnection cn = _factory.GetConnection();
            cn.Open();
            SqlCommand c = new SqlCommand("select id from Plants where name = 'dirt';", cn);
            SqlDataReader reader = c.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                Guid dirt_id = (Guid)reader["id"];
                cn.Close();

                cmd.CommandText = "insert into Garden (id,User_id) values (@gid,@uid);";
                cmd.Parameters.AddWithValue("@gid", temp.id);
                cmd.Parameters.AddWithValue("@uid", garden.user_id);
                cmd.ExecuteNonQuery();


                for (int i = 0; i < 16; i++)
                {
                    cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.Transaction = transaction;
                    Tile tile = new Tile { garden_id = temp.id, position = i };
                    cmd.CommandText = $"insert into Tile (id,gardenId,position,plantId,plantTime,groundTime) VALUES (@id,@g,@p,@pid,@pt,@gt);";
                    cmd.Parameters.AddWithValue($"@id", tile.id);
                    cmd.Parameters.AddWithValue("@g", temp.id);
                    cmd.Parameters.AddWithValue("@p", i);
                    cmd.Parameters.AddWithValue("@pid", dirt_id);
                    cmd.Parameters.AddWithValue("@pt", tile.plant_time);
                    cmd.Parameters.AddWithValue("@gt", tile.ground_time);
                    cmd.ExecuteNonQuery();
                }

            }
            transaction.Commit();
            temp.user_id = garden.user_id;
            temp = GetById(temp.user_id);
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
            using SqlConnection connection = _factory.GetConnection();
            connection.Open();
            SqlCommand cmd = new SqlCommand(@"
                select * from garden where User_id = @id;
            ", connection);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                temp.user_id = id;
                temp.id = (Guid)reader["id"];

                connection.Close();
                connection.Open();

                cmd = new SqlCommand("select * from Tile where gardenId = @g;", connection);
                cmd.Parameters.AddWithValue("@g", temp.id);
                SqlDataReader r = cmd.ExecuteReader();
                if (r.HasRows)
                {
                    while (r.Read())
                    {
                        Guid tid = (Guid)r["id"];
                        Guid garden_id = (Guid)r["gardenId"];
                        int position = (int)r["position"];
                        Guid plant_id = (Guid)r["plantId"];
                        DateTime plant_time = (DateTime)r["plantTime"];
                        DateTime ground_time = (DateTime)r["groundTime"];

                        Tile tile = new Tile
                        {
                            id = tid,
                            garden_id = garden_id,
                            position = position,
                            plant_id = plant_id,
                            plant_time = plant_time,
                            ground_time = ground_time
                        };
                        temp.tiles.Add(tile);
                        Log.Information($"{tile.id}");
                    }
                }
            }
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