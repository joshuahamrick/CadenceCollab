const _dbUrl = "/api/artistSong";

export const postArtistSong = (artistSong) => {
  const postOptions = {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(artistSong),
  };

  return fetch(_dbUrl, postOptions);
};
