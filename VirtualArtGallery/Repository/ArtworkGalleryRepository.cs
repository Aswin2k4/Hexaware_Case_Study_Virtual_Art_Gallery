using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using VirtualArtGallery.Utility;

namespace VirtualArtGallery.Repository
{
    internal class ArtworkGalleryRepository : IArtworkGalleryRepository
    {
        private readonly string _connectionString;

        public ArtworkGalleryRepository()
        {
            _connectionString = DBConnection.GetConnectionString();
        }

        public bool AddArtworkToGallery(int artworkID, int galleryID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    string query = "INSERT INTO Artwork_Gallery (ArtworkID, GalleryID) VALUES (@ArtworkID, @GalleryID)";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@ArtworkID", artworkID);
                    cmd.Parameters.AddWithValue("@GalleryID", galleryID);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error adding artwork to gallery: {ex.Message}");
                    return false;
                }
            }
        }

        public bool RemoveArtworkFromGallery(int artworkID, int galleryID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    string query = "DELETE FROM Artwork_Gallery WHERE ArtworkID = @ArtworkID AND GalleryID = @GalleryID";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@ArtworkID", artworkID);
                    cmd.Parameters.AddWithValue("@GalleryID", galleryID);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error removing artwork from gallery: {ex.Message}");
                    return false;
                }
            }
        }

        public void GetArtworksByGalleryID(int galleryID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    string query = "SELECT ArtworkID FROM Artwork_Gallery WHERE GalleryID = @GalleryID";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@GalleryID", galleryID);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    Console.WriteLine($"Artworks in Gallery {galleryID}:");
                    while (reader.Read())
                    {
                        Console.WriteLine($"Artwork ID: {reader["ArtworkID"]}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error retrieving artworks for gallery {galleryID}: {ex.Message}");
                }
            }
        }

        public void GetGalleriesByArtworkID(int artworkID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    string query = "SELECT GalleryID FROM Artwork_Gallery WHERE ArtworkID = @ArtworkID";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@ArtworkID", artworkID);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    Console.WriteLine($"Galleries for Artwork {artworkID}:");
                    while (reader.Read())
                    {
                        Console.WriteLine($"Gallery ID: {reader["GalleryID"]}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error retrieving galleries for artwork {artworkID}: {ex.Message}");
                }
            }
        }
    }
}
