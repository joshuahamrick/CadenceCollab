import { useEffect, useState } from "react";
import { getAllSongs } from "../../managers/songManager";
import { Card, CardBody } from "reactstrap";
import { Link, useNavigate } from "react-router-dom";
import "./Post.css";

export const HomePagePosts = ({ loggedInUser }) => {
  const [songs, setSongs] = useState([]);

  useEffect(() => {
    getAllSongs().then(setSongs);
  }, []);

  return (
    <>
      <h1 style={{ margin: "80px auto 40px auto" }}>Collaboration Station</h1>
      {songs.map((s) => (
        <Card key={s.id} className="mb-3">
          <CardBody>
            <div className="d-flex justify-content-between">
              <div>
                <h6>{s.artistSongs[0]?.userProfile.name}</h6>
                <Link to={`/song/${s.id}`}>
                  <h5>{s.title}</h5>
                </Link>
              </div>
              <div className="text-right">
                <div>Looking for:</div>
                <div>{s.type.name}</div>
              </div>
            </div>
            <div style={{ border: "2px solid black" }}>playbar</div>
          </CardBody>
        </Card>
      ))}
    </>
  );
};
