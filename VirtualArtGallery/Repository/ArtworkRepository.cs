using VirtualArtGallery.Model;
using VirtualArtGallery.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Common;

namespace VirtualArtGallery.Repository
{
    internal class ArtworkRepository : IArtworkRepository
    {
        private readonly string connectionString;

        public ArtworkRepository()
        {
            connectionString = DBConnection.GetConnectionString();
        }

        public bool AddArtwork(Artwork artwork)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = @"INSERT INTO Artwork (Title, Description, CreationDate, Medium, ImageURL, ArtistID) 
                                     VALUES (@Title, @Description, @CreationDate, @Medium, @ImageURL, @ArtistID)";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Title", artwork.Title);
                    cmd.Parameters.AddWithValue("@Description", artwork.Description);
                    cmd.Parameters.AddWithValue("@CreationDate", artwork.CreationDate);
                    cmd.Parameters.AddWithValue("@Medium", artwork.Medium);
                    cmd.Parameters.AddWithValue("@ImageURL", artwork.ImageURL);
                    cmd.Parameters.AddWithValue("@ArtistID", artwork.ArtistID);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error adding artwork: {ex.Message}");
                    return false;
                }
            }
        }

        public bool UpdateArtwork(Artwork artwork)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = @"UPDATE Artwork SET Title = @Title, Description = @Description, Medium = @Medium, 
                                     ImageURL = @ImageURL, ArtistID = @ArtistID WHERE ArtworkID = @ArtworkID";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Title", artwork.Title);
                    cmd.Parameters.AddWithValue("@Description", artwork.Description);
                    cmd.Parameters.AddWithValue("@Medium", artwork.Medium);
                    cmd.Parameters.AddWithValue("@ImageURL", artwork.ImageURL);
                    cmd.Parameters.AddWithValue("@ArtistID", artwork.ArtistID);
                    cmd.Parameters.AddWithValue("@ArtworkID", artwork.ArtworkID);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating artwork: {ex.Message}");
                    return false;
                }
            }
        }

        public bool RemoveArtwork(int artworkID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "DELETE FROM Artwork WHERE ArtworkID = @ArtworkID";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@ArtworkID", artworkID);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error removing artwork: {ex.Message}");
                    return false;
                }
            }
        }

        public Artwork GetArtworkById(int artworkID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT * FROM Artwork WHERE ArtworkID = @ArtworkID";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@ArtworkID", artworkID);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return ExtractArtwork(reader);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching artwork by ID: {ex.Message}");
                }
            }
            return null;
        }

        public List<Artwork> SearchArtworks(string keyword)
        {
            List<Artwork> artworks = new List<Artwork>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT * FROM Artwork WHERE Title LIKE @Keyword OR Description LIKE @Keyword";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Keyword", $"%{keyword}%");

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        artworks.Add(ExtractArtwork(reader));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error searching artworks: {ex.Message}");
                }
            }
            return artworks;
        }

        private Artwork ExtractArtwork(SqlDataReader reader)
        {
            return new Artwork
            {
                ArtworkID = (int)reader["ArtworkID"],
                Title = (string)reader["Title"],
                Description = (string)reader["Description"],
                CreationDate = (DateTime)reader["CreationDate"],
                Medium = (string)reader["Medium"],
                ImageURL = (string)reader["ImageURL"],
                ArtistID = (int)reader["ArtistID"]
            };
        }
    }
}
