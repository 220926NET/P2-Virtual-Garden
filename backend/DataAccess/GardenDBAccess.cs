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

    public Garden Add(Garden t)
    {
        using SqlConnection connection = _factory.GetConnection();
        connection.Open();
        Plant dirt = new();
        try
        {
            // Get information about dirt tile


            // Make sure we dont create a garden twice!
            SqlCommand checkCommand = new SqlCommand("select * from Garden where User_id = @uid", connection);
            checkCommand.Parameters.AddWithValue("@uid", t.user_id);
            SqlDataReader checkReader = checkCommand.ExecuteReader();
            // Dont make a new one if it already exists
            if (checkReader.HasRows) return new();
            connection.Close();
            connection.Open();

            SqlCommand selectCommand = new SqlCommand(@"
        select p.id as id, p.name as [name], p.growthMinutes as [minutes], p.worth as worth, ps.state as [state], ps.image as [image]
        from Plants p 
        left join Plantstate as ps on id = plantId
        where name = @d;
        ", connection);
            selectCommand.Parameters.AddWithValue("@d", "dirt");
            SqlDataReader reader = selectCommand.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                dirt.growth_minuets = (int)reader["minutes"];
                dirt.id = (Guid)reader["id"];
                dirt.image_path = (string)reader["image"];
                dirt.name = (string)reader["name"];
                dirt.state = (int)reader["state"];
                dirt.worth = (int)reader["worth"];
            }
            else
            {
                return new();
            }
        }
        catch (SqlException e)
        {
            Log.Error(e, "An error occured in the information gathering step of creating a garden");
            return new();
        }

        connection.Close();
        connection.Open();

        if (new PlantValidator().isValid(dirt))
        {
            SqlTransaction transaction = connection.BeginTransaction();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.Transaction = transaction;
            Guid gardenId = Guid.NewGuid();

            try
            {
                if (t.tiles.Count != 16)
                {
                    // New garden
                    cmd.CommandText = "insert into Garden (id,User_id) VALUES (@id,@uid);";
                    cmd.Parameters.AddWithValue("@id", gardenId);
                    cmd.Parameters.AddWithValue("@uid", t.user_id);
                    cmd.ExecuteNonQuery();

                    for (int i = 0; i < 16; i++)
                    {
                        cmd = new SqlCommand();
                        cmd.Connection = connection;
                        cmd.Transaction = transaction;
                        cmd.CommandText = @"
                        insert into Tile (id,gardenId,[position],plantId,plantTime,groundTime) 
                            VALUES 
                        (@tid,@gid,@pos,@pid,@pt,@gt);";
                        cmd.Parameters.AddWithValue("@tid", Guid.NewGuid());
                        cmd.Parameters.AddWithValue("@gid", gardenId);
                        cmd.Parameters.AddWithValue("@pos", i);
                        cmd.Parameters.AddWithValue("@pid", dirt.id);
                        cmd.Parameters.AddWithValue("@pt", DateTime.Now);
                        cmd.Parameters.AddWithValue("@gt", DateTime.Now);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    // Updating a garden
                    cmd.CommandText = "insert into Garden (id,User_id) VALUES (@id,@uid);";
                    cmd.Parameters.AddWithValue("@id", t.id);
                    cmd.Parameters.AddWithValue("@uid", t.user_id);
                    cmd.ExecuteNonQuery();

                    foreach (Tile tile in t.tiles)
                    {
                        cmd = new SqlCommand();
                        cmd.Connection = connection;
                        cmd.Transaction = transaction;
                        cmd.CommandText = @"
                        insert into Tile (id,gardenId,[position],plantId,plantTime,groundTime) 
                            VALUES 
                        (@tid,@gid,@pos,@pid,@pt,@gt);";
                        cmd.Parameters.AddWithValue("@tid", tile.id);
                        cmd.Parameters.AddWithValue("@gid", t.id);
                        cmd.Parameters.AddWithValue("@pos", tile.position);
                        cmd.Parameters.AddWithValue("@pid", tile.plant_information.id);
                        cmd.Parameters.AddWithValue("@pt", tile.plant_time);
                        cmd.Parameters.AddWithValue("@gt", tile.ground_time);
                        cmd.ExecuteNonQuery();
                    }
                }
                transaction.Commit();
                return GetById(t.user_id);
            }
            catch (SqlException e)
            {
                try
                {
                    Log.Error(e, "An error occured while creating a garden, attempting to rollback");
                    transaction.Rollback();
                    Log.Information("Rollback succeded!");
                }
                catch (Exception e2)
                {
                    Log.Error(e2, "Failed to rollback transaction while creating a garden");
                }
            }
        }

        return new();
    }

    public Garden Delete(Garden t)
    {
        try
        {
            foreach (Tile tile in t.tiles)
            {
                SqlConnection connection = _factory.GetConnection();
                connection.Open();
                SqlCommand cmd = new SqlCommand("delete from Tile where id = @id", connection);
                cmd.Parameters.AddWithValue("@id", tile.id);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            SqlConnection c = _factory.GetConnection();
            c.Open();
            SqlCommand cd = new SqlCommand("delete from Garden where id = @id", c);
            cd.Parameters.AddWithValue("@id", t.id);
            cd.ExecuteNonQuery();
            c.Close();
            return t;
        }
        catch (SqlException e)
        {
            Log.Error(e, "Unable to delete garden");
            return new();
        }
    }

    public List<Garden> GetAll()
    {
        throw new NotImplementedException();
    }

    public List<Garden> GetAllById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Garden GetById(Guid id)
    {
        try
        {
            using SqlConnection connection = _factory.GetConnection();
            connection.Open();

            SqlCommand cmd = new SqlCommand(@"
                SELECT g.id as garden_id , g.User_id, t.id as tile_id, t.position, t.plantId, t.plantTime, t.groundTime,  p.name, p.growthMinutes, p.worth, ps.state, ps.[image]
                FROM Garden g
                LEFT JOIN Tile t on g.id = t.gardenId
                LEFT JOIN Plants p ON t.plantId = p.id
                LEFT JOIN PlantState ps ON p.id = ps.plantId
                where User_id = @uid;
                ", connection);
            cmd.Parameters.AddWithValue("@uid", id);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                Garden newGarden = new();
                bool firstRow = true;
                while (reader.Read())
                {
                    if (firstRow)
                    {
                        firstRow = false;
                        newGarden.id = (Guid)reader["garden_id"];
                        newGarden.user_id = (Guid)reader["User_id"];
                    }
                    newGarden.tiles.Add(new Tile
                    {
                        id = (Guid)reader["tile_id"],
                        position = (int)reader["position"],
                        garden_id = newGarden.id,
                        plant_time = (DateTime)reader["plantTime"],
                        ground_time = (DateTime)reader["groundTime"],
                        plant_information = new Plant
                        {
                            id = (Guid)reader["plantId"],
                            name = (string)reader["name"],
                            growth_minuets = (int)reader["growthMinutes"],
                            worth = (int)reader["worth"],
                            image_path = (string)reader["image"],
                            state = (int)reader["state"]
                        }
                    });
                }
                return newGarden;
            }
        }
        catch (SqlException e)
        {
            Log.Error(e, "An exception was thrown while getting a garden from the database");
        }

        return new();
    }

    public Guid GetId(string plantName)
    {
        try
        {
            using SqlConnection connection = _factory.GetConnection();
            connection.Open();
            SqlCommand cmd = new SqlCommand("select id from Plants where [name] = @name;", connection);
            cmd.Parameters.AddWithValue("@name", plantName);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows) if (reader.Read()) return (Guid)reader["id"];
        }
        catch (SqlException e)
        {
            Log.Error(e, "An exception was thrown while getting the plant's Guid");
        }
        return Guid.Empty;
    }

    public Garden Update(Garden t)
    {
        if (new GardenValidator().isValid(Delete(t)))
        {
            return Add(t);
        }
        return new();
    }
}