import { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import { getSongById } from "../../managers/songManager";

export const PostDetails = ({ loggedInUser }) => {
  const { songId } = useParams();

  const [song, setSong] = useState({});

  useEffect(() => {
    getSongById(songId).then(setSong);
  }, [songId]);

  return (
    <>
      <h1>{song.title}</h1>
      <p>{song.artistSongs[0].userProfile?.name}</p>
      <p>{song.genre?.name}</p>
      <p>{song.type?.name}</p>
      <p>{song.description}</p>
      {song.lyrics ? <p>{song.lyrics}</p> : null}
      {
        <Link to={"edit"}>
          <button>Edit</button>
        </Link>
      }
    </>
  );
};
