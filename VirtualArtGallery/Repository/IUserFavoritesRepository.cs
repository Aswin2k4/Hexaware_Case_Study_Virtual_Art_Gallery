using VirtualArtGallery.Model;

namespace VirtualArtGallery.Repository
{
    internal interface IUserFavoritesRepository
    {
        bool AddFavoriteArtwork(int userID, int artworkID);
        bool RemoveFavoriteArtwork(int userID, int artworkID);
        List<Artwork> GetUserFavoriteArtworks(int userID);
    }
}
