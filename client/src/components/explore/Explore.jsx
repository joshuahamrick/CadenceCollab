import { getAllUserProfiles } from "../../managers/userProfileManager";
import { useEffect, useState } from "react";
import { Card, CardBody } from "reactstrap";

export const Explore = () => {
  const [userProfiles, setUserProfiles] = useState([]);

  useEffect(() => {
    getAllUserProfiles().then(setUserProfiles);
  }, []);

  return (
    <>
      <h1 style={{ margin: "80px auto 40px auto" }}>Collaboration Station</h1>
      {userProfiles.map((up) => (
        <Card key={up.id} className="mb-3">
          <CardBody>
            <div className="d-flex justify-content-between">
              <div>
                <div>{up.userName}</div>
                <div>{up.location}</div>
                <div>{up.typeName}</div>
                <div>{up.genreName}</div>
              </div>
            </div>
            <div style={{ border: "2px solid black" }}>playbar</div>
          </CardBody>
        </Card>
      ))}
    </>
  );
};
