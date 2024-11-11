-- Database Creation
CREATE DATABASE VirtualArtGallery;

USE VirtualArtGallery;

-- 1. Create Artist Table
CREATE TABLE Artist (
    ArtistID INT PRIMARY KEY IDENTITY,
    Name VARCHAR(255) NOT NULL,
    Biography TEXT,
    BirthDate DATE,
    Nationality VARCHAR(100),
    Website VARCHAR(255),
    ContactInfo VARCHAR(255)
);

-- 2. Create Artwork Table
CREATE TABLE Artwork (
    ArtworkID INT PRIMARY KEY IDENTITY,
    Title VARCHAR(255) NOT NULL,
    Description TEXT,
    CreationDate DATE,
    Medium VARCHAR(100),
    ImageURL VARCHAR(255),
    ArtistID INT,
    CONSTRAINT FK_Artwork_Artist FOREIGN KEY (ArtistID) REFERENCES Artist(ArtistID)
);

-- 3. Create User Table
CREATE TABLE [User] (
    UserID INT PRIMARY KEY IDENTITY,
    Username VARCHAR(255) NOT NULL UNIQUE,
    Password VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL UNIQUE,
    FirstName VARCHAR(100),
    LastName VARCHAR(100),
    DateOfBirth DATE,
    ProfilePicture VARCHAR(255)
);

-- 4. Create Gallery Table
CREATE TABLE Gallery (
    GalleryID INT PRIMARY KEY IDENTITY,
    Name VARCHAR(255) NOT NULL,
    Description TEXT,
    Location VARCHAR(255),
    CuratorID INT,
    OpeningHours VARCHAR(100),
    CONSTRAINT FK_Gallery_Curator FOREIGN KEY (CuratorID) REFERENCES Artist(ArtistID)
);

-- 5. Create User_Favorite_Artwork Table (Junction table for User and Artwork)
CREATE TABLE User_Favorite_Artwork (
    UserID INT,
    ArtworkID INT,
    CONSTRAINT PK_User_Favorite_Artwork PRIMARY KEY (UserID, ArtworkID),
    CONSTRAINT FK_User_Favorite_Artwork_User FOREIGN KEY (UserID) REFERENCES [User](UserID),
    CONSTRAINT FK_User_Favorite_Artwork_Artwork FOREIGN KEY (ArtworkID) REFERENCES Artwork(ArtworkID)
);

-- 6. Create Artwork_Gallery Table (Junction table for Artwork and Gallery)
CREATE TABLE Artwork_Gallery (
    ArtworkID INT,
    GalleryID INT,
    CONSTRAINT PK_Artwork_Gallery PRIMARY KEY (ArtworkID, GalleryID),
    CONSTRAINT FK_Artwork_Gallery_Artwork FOREIGN KEY (ArtworkID) REFERENCES Artwork(ArtworkID),
    CONSTRAINT FK_Artwork_Gallery_Gallery FOREIGN KEY (GalleryID) REFERENCES Gallery(GalleryID)
);

