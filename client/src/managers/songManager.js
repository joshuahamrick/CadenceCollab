const _dbUrl = "/api/song";

export const getAllSongs = () => {
  return fetch(_dbUrl).then((res) => res.json());
};

export const getSongById = (songId) => {
  return fetch(`${_dbUrl}/${songId}`).then((res) => res.json());
};

export const getSongByIdForEdit = (songId) => {
  return fetch(`${_dbUrl}/${songId}/edit`).then((res) => res.json());
};

export const updateSong = (song) => {
  return fetch(`${_dbUrl}/${song.id}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(song),
  });
};

export const deleteSong = (songId) => {
  return fetch(`${_dbUrl}/${songId}`, {
    method: "DELETE",
  });
};
