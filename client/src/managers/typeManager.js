const _dbUrl = "/api/type";

export const getAllTypes = () => {
  return fetch(`${_dbUrl}`).then((res) => res.json());
};
