using VirtualArtGallery.Repository;
using System;

namespace VirtualArtGallery.Service
{
    internal class ArtworkGalleryService : IArtworkGalleryService
    {
        private readonly IArtworkGalleryRepository _artworkGalleryRepository;

        public ArtworkGalleryService(IArtworkGalleryRepository artworkGalleryRepository)
        {
            _artworkGalleryRepository = artworkGalleryRepository;
        }

        public bool AddArtworkToGallery(int artworkID, int galleryID)
        {
            return _artworkGalleryRepository.AddArtworkToGallery(artworkID, galleryID);
        }

        public bool RemoveArtworkFromGallery(int artworkID, int galleryID)
        {
            return _artworkGalleryRepository.RemoveArtworkFromGallery(artworkID, galleryID);
        }

        public void GetArtworksByGalleryID(int galleryID)
        {
            _artworkGalleryRepository.GetArtworksByGalleryID(galleryID);
        }

        public void GetGalleriesByArtworkID(int artworkID)
        {
            _artworkGalleryRepository.GetGalleriesByArtworkID(artworkID);
        }


    }
}
