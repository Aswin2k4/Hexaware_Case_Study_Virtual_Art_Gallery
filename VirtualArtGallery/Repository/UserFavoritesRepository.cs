using VirtualArtGallery.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Common;

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

        public List<int> GetUserFavoriteArtworks(int userID)
        {
            List<int> artworkIDs = new List<int>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT ArtworkID FROM User_Favorite_Artwork WHERE UserID = @UserID";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@UserID", userID);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        artworkIDs.Add((int)reader["ArtworkID"]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching user's favorite artworks: {ex.Message}");
                }
            }
            return artworkIDs;
        }
    }
}
