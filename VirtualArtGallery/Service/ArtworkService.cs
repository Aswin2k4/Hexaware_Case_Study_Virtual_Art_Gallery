using VirtualArtGallery.Model;
using VirtualArtGallery.Repository;
using System;
using System.Collections.Generic;

namespace VirtualArtGallery.Service
{
    internal class ArtworkService : IArtworkService
    {
        private readonly IArtworkRepository _artworkRepository;

        public ArtworkService(IArtworkRepository artworkRepository)
        {
            _artworkRepository = artworkRepository;
        }

        public bool AddArtwork(Artwork artwork)
        {
            return _artworkRepository.AddArtwork(artwork);
        }

        public bool UpdateArtwork(Artwork artwork)
        {
            return _artworkRepository.UpdateArtwork(artwork);
        }

        public bool RemoveArtwork(int artworkID)
        {
            return _artworkRepository.RemoveArtwork(artworkID);
        }

        public Artwork GetArtworkById(int artworkID)
        {
            return _artworkRepository.GetArtworkById(artworkID);
        }

        public List<Artwork> SearchArtworks(string keyword)
        {
            return _artworkRepository.SearchArtworks(keyword);
        }
    }
}
