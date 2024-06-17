import { Route, Routes } from "react-router-dom";
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import Login from "./auth/Login";
import Register from "./auth/Register";
import { HomePagePosts } from "./posts/HomePagePosts";
import { NewPost } from "./posts/NewPost";
import { Explore } from "./explore/Explore.jsx";
import { LoggedInUserProfile } from "./profile/LoggedInUserProfile.jsx";
import { PostDetails } from "./posts/PostDetails.jsx";
import { EditPost } from "./posts/EditPost.jsx";

export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  return (
    <Routes>
      <Route path="/">
        <Route
          index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <HomePagePosts loggedInUser={loggedInUser} />
            </AuthorizedRoute>
          }
        />
        <Route
          path="song/:songId"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <PostDetails loggedInUser={loggedInUser} />
            </AuthorizedRoute>
          }
        />
        <Route
          path="song/:songId/edit"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <EditPost loggedInUser={loggedInUser} />
            </AuthorizedRoute>
          }
        />
        <Route
          path="newpost"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <NewPost loggedInUser={loggedInUser} />
            </AuthorizedRoute>
          }
        />
        <Route
          path="explore"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <Explore loggedInUser={loggedInUser} />
            </AuthorizedRoute>
          }
        />
        <Route
          path="profile"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <LoggedInUserProfile loggedInUser={loggedInUser} />
            </AuthorizedRoute>
          }
        />

        <Route
          path="login"
          element={<Login setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="register"
          element={<Register setLoggedInUser={setLoggedInUser} />}
        />
      </Route>
      <Route path="*" element={<p>Whoops, nothing here...</p>} />
    </Routes>
  );
}
