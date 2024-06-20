import { useEffect, useState } from "react";
import { Link, useNavigate, useParams } from "react-router-dom";
import { getSongById } from "../../managers/songManager";
import { postArtistSong } from "../../managers/artistSongManager";

export const PostDetails = ({ loggedInUser }) => {
  const { songId } = useParams();
  const navigate = useNavigate();
  const [userProfile, setUserProfile] = useState({});
  const [artistSongs, setArtistSongs] = useState([]);
  const [song, setSong] = useState({});

  useEffect(() => {
    setArtistSongs(song.artistSongs);
  }, [song]);
  useEffect(() => {
    getSongById(songId).then(setSong);
  }, [songId]);

  const isUserArtist = artistSongs?.some(
    (artistSong) => artistSong.userProfile?.id === loggedInUser.id
  );

  return (
    <>
      <h1>{song.title}</h1>
      {song.artistSongs?.map((artistSong) => (
        <p key={artistSong.id}>{artistSong.userProfile?.name}</p>
      ))}
      <p>Genre: {song.genre?.name}</p>
      <p>Type: {song.type?.name}</p>
      <p>Description: {song.description}</p>
      {song.lyrics ? <p>Lyrics: {song.lyrics}</p> : null}
      {isUserArtist ? (
        <Link to={"edit"}>
          <button>Edit</button>
        </Link>
      ) : null}
      {isUserArtist ? null : (
        <button
          onClick={() =>
            postArtistSong({
              songId: song.id,
              userProfileId: loggedInUser.id,
            }).then(() => getSongById(songId).then(setSong))
          }
        >
          Join Song
        </button>
      )}
    </>
  );
};
