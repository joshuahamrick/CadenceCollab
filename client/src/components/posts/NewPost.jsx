import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { getAllGenres } from "../../managers/genreManager";
import { getAllTypes } from "../../managers/typeManager";
import { postArtistSong } from "../../managers/artistSongManager";
import { newSong } from "../../managers/songManager";

export const NewPost = ({ loggedInUser }) => {
  const navigate = useNavigate();

  const [song, setSong] = useState({
    title: "",
    description: "",
    lyrics: "",
    // SongUrl: "",
    // PictureUrl: "",
    genreId: 0,
    typeId: 0,
  });
  const [postedSongId, setPostedSongId] = useState(0);
  const [artistSong, setArtistSong] = useState({
    songId: 0,
    userProfileId: loggedInUser.id,
  });
  const [genres, setGenres] = useState([]);
  const [types, setTypes] = useState([]);
  useEffect(() => {
    if (postedSongId !== 0) {
      // Ensure postedSongId is truthy before proceeding
      const handlePostAndNavigate = async () => {
        try {
          await postArtistSong(artistSong);
          navigate(`/song/${postedSongId}`);
        } catch (error) {
          console.error("Error posting artist song:", error);
        }
      };

      handlePostAndNavigate();
    }
  }, [postedSongId]); // Only depend on postedSongId, not artistSong directly

  useEffect(() => {
    getAllGenres().then(setGenres);
  }, []);

  useEffect(() => {
    getAllTypes().then(setTypes);
  }, []);

  const handleChange = (event) => {
    const { name, value } = event.target;
    setSong((prev) => ({
      ...prev,
      [name]:
        name === "genreId" || name === "typeId" ? parseInt(value, 10) : value,
    }));
  };

  const handleSave = (event) => {
    event.preventDefault();
    newSong(song)
      .then((postedSong) => {
        setPostedSongId(postedSong.id);
        // Update artistSong state after setting postedSongId
        setArtistSong({
          songId: postedSong.id,
          userProfileId: loggedInUser.id,
        });
      })
      .catch((error) => {
        console.error("Error creating new song:", error);
      });
  };

  return (
    <>
      <h1>New Post</h1>
      <form className="form" onSubmit={handleSave}>
        <fieldset>
          <input
            name="title"
            type="text"
            placeholder="Title"
            required
            onChange={handleChange}
            className="form-input"
          />
        </fieldset>
        <fieldset>
          <textarea
            name="description"
            type="text"
            placeholder="Description"
            required
            onChange={handleChange}
            id="form-big"
            className="form-input"
          ></textarea>
        </fieldset>
        <fieldset>
          <textarea
            name="lyrics"
            type="text"
            placeholder="Lyrics"
            required
            onChange={handleChange}
            id="form-big"
            className="form-input"
          ></textarea>
        </fieldset>
        {/* <fieldset>
          <input
            name="songUrl"
            type="text"
            defaultValue="Song Url"
            // required
            onChange={handleChange}
            className="form-input"
          />
        </fieldset>
        <fieldset>
          <input
            name="pictureUrl"
            type="text"
            defaultValue="Picture Url"
            // required
            onChange={handleChange}
            className="form-input"
          />
        </fieldset> */}
        <fieldset>
          <select
            name="genreId"
            className="filter-option"
            onChange={handleChange}
          >
            <option value="">Select Genre</option>
            {genres.map((genre) => (
              <option key={genre.id} value={genre.id}>
                {genre.name}
              </option>
            ))}
          </select>
        </fieldset>
        <fieldset>
          <select
            name="typeId"
            className="filter-option"
            onChange={handleChange}
          >
            <option value="">Select Type</option>
            {types.map((type) => (
              <option key={type.id} value={type.id}>
                {type.name}
              </option>
            ))}
          </select>
        </fieldset>
        <fieldset>
          <button type="submit" className="button">
            Submit
          </button>
        </fieldset>
      </form>
    </>
  );
};
