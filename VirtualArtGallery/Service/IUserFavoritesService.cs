using VirtualArtGallery.Model;

namespace VirtualArtGallery.Service
{
    internal interface IUserFavoritesService
    {
        bool AddFavoriteArtwork(int userID, int artworkID);
        bool RemoveFavoriteArtwork(int userID, int artworkID);
        List<Artwork> GetUserFavoriteArtworks(int userID);
    }
}
