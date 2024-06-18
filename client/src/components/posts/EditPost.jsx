import { useEffect, useState } from "react";
import { Form, useNavigate, useParams } from "react-router-dom";
import {
  deleteSong,
  getSongByIdForEdit,
  updateSong,
} from "../../managers/songManager";
import { getAllGenres } from "../../managers/genreManager";
import { getAllTypes } from "../../managers/typeManager";

export const EditPost = () => {
  const { songId } = useParams();

  const navigate = useNavigate();

  const [songUpdate, setSongUpdate] = useState({});
  const [song, setSong] = useState({});
  const [genres, setGenres] = useState([]);
  const [types, setTypes] = useState([]);

  useEffect(() => {
    getSongByIdForEdit(songId).then(setSong);
  }, [songId]);

  useEffect(() => {
    setSongUpdate(song);
  }, [song]);

  useEffect(() => {
    getAllGenres().then(setGenres);
  }, []);

  useEffect(() => {
    getAllTypes().then(setTypes);
  }, []);

  const handleChange = (event) => {
    const { name, value } = event.target;
    setSongUpdate((prev) => ({
      ...prev,
      [name]:
        name === "genreId" || name === "typeId" ? parseInt(value, 10) : value,
    }));
  };

  const handleSave = (event) => {
    event.preventDefault();
    updateSong(songUpdate);
    navigate(`/song/${song.id}`);
  };

  const handleDelete = () => {
    deleteSong(songUpdate.id)
      .then(() => {
        navigate(`/`);
      })
      .catch((error) => {
        console.error("Error deleting song:", error);
      });
  };
  return (
    <>
      <h1>Edit</h1>
      <form className="form" onSubmit={handleSave}>
        <fieldset>
          <input
            name="title"
            type="text"
            defaultValue={song?.title}
            // required
            onChange={handleChange}
            className="form-input"
          />
        </fieldset>
        <fieldset>
          <textarea
            name="description"
            type="text"
            defaultValue={song?.description}
            // required
            onChange={handleChange}
            id="form-big"
            className="form-input"
          ></textarea>
        </fieldset>
        <fieldset>
          <textarea
            name="lyrics"
            type="text"
            defaultValue={song?.lyrics ? song?.lyrics : ""}
            // required
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
            value={songUpdate.genreId || ""}
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
            value={songUpdate.typeId || ""}
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
          <button onClick={handleDelete}>Delete</button>
        </fieldset>
      </form>
    </>
  );
};
