const _dbUrl = "/api/userProfile";

export const getAllUserProfiles = () => {
  return fetch(_dbUrl).then((res) => res.json());
};
export const getUserProfileById = (userProfileId) => {
  return fetch(`${_dbUrl}/${userProfileId}`).then((res) => res.json());
};
