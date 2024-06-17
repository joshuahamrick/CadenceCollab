const _dbUrl = "/api/genre";

export const getAllGenres = () => {
  return fetch(`${_dbUrl}`).then((res) => res.json());
};
