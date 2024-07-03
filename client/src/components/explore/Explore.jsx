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
      <h1 style={{ margin: "80px auto 40px auto" }}>Explore</h1>
      {userProfiles.map((up) => (
        <Card
          key={up.id}
          className="mb-3"
          style={{
            width: "350px",
            boxShadow: "2px 2px 4px rgba(0, 0, 0, 0.25) ",
          }}
        >
          <CardBody>
            <div>
              <div>
                <h5>{up.userName}</h5>
                <div>Location: {up.location}</div>
                <div>Type: {up.typeName}</div>
                <div>Genre: {up.genreName}</div>
              </div>
            </div>
          </CardBody>
        </Card>
      ))}
    </>
  );
};
