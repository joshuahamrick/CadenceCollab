import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import {
  deleteSong,
  getSongByIdForEdit,
  updateSong,
} from "../../managers/songManager";
import { getAllGenres } from "../../managers/genreManager";
import { getAllTypes } from "../../managers/typeManager";

export const NewPost = () => {
  const { songId } = useParams();

  const navigate = useNavigate();

  const [songToPost, setSongToPost] = useState({
    title: "",
    description: "",
    lyrics: "",
    // SongUrl: "",
    // PictureUrl: "",
    genreId: 0,
    typeId: 0,
  });

  const [genres, setGenres] = useState([]);
  const [types, setTypes] = useState([]);

  useEffect(() => {
    getAllGenres().then(setGenres);
  }, []);

  useEffect(() => {
    getAllTypes().then(setTypes);
  }, []);

  const handleChange = (event) => {
    const { name, value } = event.target;
    setSongToPost((prev) => ({
      ...prev,
      [name]:
        name === "genreId" || name === "typeId" ? parseInt(value, 10) : value,
    }));
  };

  const handleSave = (event) => {
    event.preventDefault();
    newSong(songToPost);
    navigate(`/song/${song.id}`);
  };

  const handleDelete = () => {
    deleteSong(songToPost.id)
      .then(() => {
        navigate(`/`);
      })
      .catch((error) => {
        console.error("Error deleting song:", error);
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
