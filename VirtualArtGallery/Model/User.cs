using System;
using System.Collections.Generic;

namespace VirtualArtGallery.Model
{
    internal class User
    {
        private int _userID;
        private string _username;
        private string _password;
        private string _email;
        private string _firstName;
        private string _lastName;
        private DateTime _dateOfBirth;
        private string _profilePicture;
        private string _role;
        private DateTime _lastLoginDate;

        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }

        public string ProfilePicture
        {
            get { return _profilePicture; }
            set { _profilePicture = value; }
        }

        public string Role
        {
            get { return _role; }
            set { _role = value; }
        }

        public DateTime LastLoginDate
        { 
            get { return _lastLoginDate; }
            set { _lastLoginDate = value; }
        }

        public List<int> FavoriteArtworks { get; set; }

        public int CalculateAge()
        {
            int age = DateTime.Now.Year - DateOfBirth.Year;
            Console.WriteLine($"The age of this user is {age} years.");
            return age;
        }

        public void AddFavoriteArtwork(int artworkID)
        {
            if (!FavoriteArtworks.Contains(artworkID))
            {
                FavoriteArtworks.Add(artworkID);
                Console.WriteLine($"Artwork ID {artworkID} added to favorites.");
            }
            else
            {
                Console.WriteLine($"Artwork ID {artworkID} is already in favorites.");
            }
        }

        public void RemoveFavoriteArtwork(int artworkID)
        {
            if (FavoriteArtworks.Contains(artworkID))
            {
                FavoriteArtworks.Remove(artworkID);
                Console.WriteLine($"Artwork ID {artworkID} removed from favorites.");
            }
            else
            {
                Console.WriteLine($"Artwork ID {artworkID} not found in favorites.");
            }
        }

        public override string ToString()
        {
            return $"User ID: {UserID}\t" +
                   $"Username: {Username}\t" +
                   $"Email: {Email}\t" +
                   $"Age: {CalculateAge()} " +
                   $"Profile Picture: {ProfilePicture}\t" +
                   $"Last Login Date: {LastLoginDate}\n";
        }
    }
}
