using VirtualArtGallery.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Common;
using VirtualArtGallery.Model;

namespace VirtualArtGallery.Repository
{
    internal class UserFavoritesRepository : IUserFavoritesRepository
    {
        private readonly string connectionString;

        public UserFavoritesRepository()
        {
            connectionString = DBConnection.GetConnectionString();
        }

        public bool AddFavoriteArtwork(int userID, int artworkID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "INSERT INTO User_Favorite_Artwork (UserID, ArtworkID) VALUES (@UserID, @ArtworkID)";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.Parameters.AddWithValue("@ArtworkID", artworkID);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error adding favorite artwork: {ex.Message}");
                    return false;
                }
            }
        }

        public bool RemoveFavoriteArtwork(int userID, int artworkID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "DELETE FROM User_Favorite_Artwork WHERE UserID = @UserID AND ArtworkID = @ArtworkID";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.Parameters.AddWithValue("@ArtworkID", artworkID);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error removing favorite artwork: {ex.Message}");
                    return false;
                }
            }
        }

        public List<Artwork> GetUserFavoriteArtworks(int userID)
        {
            List<Artwork> favoriteArtworks = new List<Artwork>();

            using (SqlConnection conn = new SqlConnection(DBConnection.GetConnectionString()))
            {
                string query = @"SELECT a.ArtworkID, a.Title, a.Description, a.Medium, a.ImageURL, a.CreationDate, a.ArtistID
                         FROM User_Favorite_Artwork ufa
                         INNER JOIN Artwork a ON ufa.ArtworkID = a.ArtworkID
                         WHERE ufa.UserID = @UserID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userID);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    favoriteArtworks.Add(new Artwork
                    {
                        ArtworkID = (int)reader["ArtworkID"],
                        Title = (string)reader["Title"],
                        Description = (string)reader["Description"],
                        Medium = (string)reader["Medium"],
                        ImageURL = (string)reader["ImageURL"],
                        CreationDate = (DateTime)reader["CreationDate"],
                        ArtistID = (int)reader["ArtistID"]
                    });
                }
            }

            return favoriteArtworks;
        }
    }
}
