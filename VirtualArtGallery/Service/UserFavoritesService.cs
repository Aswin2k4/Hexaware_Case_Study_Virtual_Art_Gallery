using VirtualArtGallery.Repository;
using System;

namespace VirtualArtGallery.Service
{
    internal class UserFavoritesService : IUserFavoritesService
    {
        private readonly IUserFavoritesRepository _userFavoritesRepository;

        public UserFavoritesService(IUserFavoritesRepository userFavoritesRepository)
        {
            _userFavoritesRepository = userFavoritesRepository;
        }

        public bool AddFavoriteArtwork(int userID, int artworkID)
        {
            return _userFavoritesRepository.AddFavoriteArtwork(userID, artworkID);
        }

        public bool RemoveFavoriteArtwork(int userID, int artworkID)
        {
            return _userFavoritesRepository.RemoveFavoriteArtwork(userID, artworkID);
        }

        public void GetUserFavoriteArtworks(int userID)
        {
            _userFavoritesRepository.GetUserFavoriteArtworks(userID);
        }
    }
}
