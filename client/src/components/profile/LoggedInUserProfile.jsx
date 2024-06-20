import { useEffect, useState } from "react";
import { getUserProfileById } from "../../managers/userProfileManager";
import { Card, CardBody } from "reactstrap";

export const LoggedInUserProfile = ({ loggedInUser }) => {
  const [userProfile, setUserProfile] = useState();

  useEffect(() => {
    getUserProfileById(loggedInUser.id).then(setUserProfile);
  }, [loggedInUser]);

  return (
    <>
      <h1 style={{ margin: "80px auto 40px auto" }}>Profile</h1>
      <Card className="mb-3">
        <CardBody>
          <div className="d-flex justify-content-between">
            <div>
              <div>{userProfile?.userName}</div>
              <div>{userProfile?.location}</div>
              <div>{userProfile?.typeName}</div>
              <div>{userProfile?.genreName}</div>
            </div>
          </div>
          <div style={{ border: "2px solid black" }}>playbar</div>
        </CardBody>
      </Card>
    </>
  );
};
